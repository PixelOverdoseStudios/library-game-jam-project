using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private string pathTag = "Path";
    [SerializeField] private float waitTimeAtWaypoint = 1f;
    [SerializeField] private float moveSpeed = 5f;

    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private bool isMovingForward = true;
    private bool isWaiting = false;

    private void Start()
    {
        InitializePath();
    }

    private void Update()
    {
        if (HasWaypoints())
        {
            if (!isWaiting)
            {
                MoveToNextWaypoint();
            }
        }
    }

    public void InitializePath()
    {
        GameObject[] pathObjects = GameObject.FindGameObjectsWithTag(pathTag);
        List<Transform> pathTransforms = new List<Transform>();

        foreach (GameObject pathObject in pathObjects)
        {
            pathTransforms.Add(pathObject.transform);
        }

        if (pathTransforms.Count > 0)
        {
            SelectRandomPath(pathTransforms.ToArray());
        }
        else
        {
            Debug.LogWarning("No paths found in the scene!");
        }
    }

    private void SelectRandomPath(Transform[] paths)
    {
        Transform pathTransform = paths[Random.Range(0, paths.Length)];

        Path path = pathTransform.GetComponent<Path>();
        waypoints = path.GetWaypoints();

        if (HasWaypoints())
        {
            transform.position = waypoints[0].position;
            currentWaypointIndex = 0;
        }
    }

    public void SetWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints;
        currentWaypointIndex = 0;
        isMovingForward = true;
    }

    public bool HasWaypoints()
    {
        return waypoints != null && waypoints.Length > 0;
    }

    public void MoveToNextWaypoint()
    {
        if (isMovingForward && currentWaypointIndex < waypoints.Length - 1)
        {
            Vector2 targetPosition = waypoints[currentWaypointIndex + 1].position;
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction * step, step);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
                StartCoroutine(WaitAtWaypoint());
            }
        }
        else if (!isMovingForward && currentWaypointIndex > 0)
        {
            Vector2 targetPosition = waypoints[currentWaypointIndex - 1].position;
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction * step, step);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex--;
                StartCoroutine(WaitAtWaypoint());
            }
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTimeAtWaypoint);
        isWaiting = false;
    }

    public bool ReachedWaypoint()
    {
        return Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f;
    }

    public bool IsAtEnd()
    {
        return currentWaypointIndex >= waypoints.Length - 1;
    }

    public bool IsAtStart()
    {
        return currentWaypointIndex == 0;
    }

    public void ReverseDirection()
    {
        isMovingForward = !isMovingForward;
    }

    public bool IsMovingForward()
    {
        return isMovingForward;
    }
}

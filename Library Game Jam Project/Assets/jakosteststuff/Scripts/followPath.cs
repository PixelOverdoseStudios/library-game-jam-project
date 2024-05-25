using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private Transform[] paths;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private string PathTag = "Path";
    [SerializeField] private float waitTimeAtEnd = 2.0f;
    [SerializeField] private Choise choise;

    private bool isWaiting = false;
    private bool isMovingForward = true;
    private bool hasReturned = false; // Flag to indicate if the object has returned to the start

    void Start()
    {
        InitializePath();
        if (choise == null)
        {
            choise = FindObjectOfType<Choise>();
        }

        if (choise == null)
        {
            Debug.LogError("Choise script not found!");
        }
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        if (!isWaiting)
        {
            MoveToNextWaypoint();
        }
    }

    void InitializePath()
    {
        GameObject[] pathObjects = GameObject.FindGameObjectsWithTag(PathTag);
        List<Transform> pathTransforms = new List<Transform>();

        foreach (GameObject pathObject in pathObjects)
        {
            pathTransforms.Add(pathObject.transform);
        }

        paths = pathTransforms.ToArray();

        if (paths.Length > 0)
        {
            SelectRandomPath();
        }
        else
        {
            Debug.LogWarning("No paths found in the scene!");
        }
    }

    void SelectRandomPath()
    {
        Transform pathTransform = paths[Random.Range(0, paths.Length)];
        Debug.Log(pathTransform.name);

        Path path = pathTransform.GetComponent<Path>();
        waypoints = path.GetWaypoints();

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void MoveToNextWaypoint()
    {
        int nextWaypointIndex = isMovingForward ? currentWaypointIndex + 1 : currentWaypointIndex - 1;

        if (nextWaypointIndex >= 0 && nextWaypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[nextWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex = nextWaypointIndex;

                if (currentWaypointIndex >= waypoints.Length || currentWaypointIndex < 0)
                {
                    StartCoroutine(WaitAtEnd());
                    
                }
            }
        }
        else
        {
            isWaiting = true;
            StartCoroutine(WaitAtEnd());
        }
    }

    IEnumerator WaitAtEnd()
    {
        choise.ChoiseToMake();
        isWaiting = true;
        yield return new WaitForSeconds(waitTimeAtEnd);
        isWaiting = false;
        isMovingForward = !isMovingForward;

        if (!hasReturned && !isMovingForward) // Check if the object has returned and is moving backward
        {
            hasReturned = true;
            StartCoroutine(DespawnAfterReturn());
        }
    }

    IEnumerator DespawnAfterReturn()
    {
        while (currentWaypointIndex != 0) // Wait until the object reaches the first waypoint again
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}

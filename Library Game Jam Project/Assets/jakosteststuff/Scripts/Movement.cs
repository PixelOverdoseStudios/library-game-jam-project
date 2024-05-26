using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private string pathTag = "Path";
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

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
    }

    public bool HasWaypoints()
    {
        return waypoints != null && waypoints.Length > 0;
    }

    public Transform GetCurrentWaypoint()
    {
        if (HasWaypoints())
        {
            return waypoints[currentWaypointIndex];
        }
        return null;
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

    public void MoveToNextWaypoint(float speed, bool isMovingForward)
    {
        int nextWaypointIndex = isMovingForward ? currentWaypointIndex + 1 : currentWaypointIndex - 1;

        if (nextWaypointIndex >= 0 && nextWaypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[nextWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex = nextWaypointIndex;
            }
        }
    }
}

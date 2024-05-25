using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    // Array of path objects in the scene
    [SerializeField] private Transform[] paths;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private string PathTag = "Path";

    void Start()
    {
        // Find all objects in the scene with the Path script attached
        GameObject[] pathObjects = GameObject.FindGameObjectsWithTag(PathTag);
        // Create a list to store transforms of path objects
        List<Transform> pathTransforms = new List<Transform>();

        // Extract the transforms from the Path scripts
        foreach (GameObject pathObject in pathObjects)
        {
            // Add the transform of each path object to the list
            pathTransforms.Add(pathObject.transform);
        }

        // Convert the list of path transforms to an array of transforms
        paths = pathTransforms.ToArray();

        if (paths.Length > 0)
        {
            // Select a random path transform from the array
            Transform pathTransform = paths[Random.Range(0, paths.Length)];
            Debug.Log(pathTransform.name);

            // Get the Path component attached to the selected path
            Path path = pathTransform.GetComponent<Path>();

            // Get the waypoints from the selected path
            waypoints = path.GetWaypoints();

            if (waypoints.Length > 0)
            {
                // Set the initial position of the object to the first waypoint of the selected path
                transform.position = waypoints[0].position;
            }
        }
        else
        {
            // Log a warning if no path objects are found in the scene
            Debug.LogWarning("No paths found in the scene!");
        }
    }

    void Update()
    {
        // Check if waypoints are not assigned or empty
        if (waypoints == null || waypoints.Length == 0) return;

        // Move towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Check if the object has reached the current waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Loop back to the first waypoint if all waypoints are visited
                currentWaypointIndex = 0;
            }
        }
    }
}

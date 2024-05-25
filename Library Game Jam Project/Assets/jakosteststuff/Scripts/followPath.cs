using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections; // Import the namespace for collections
using System.Collections.Generic; // Import the namespace for generic collections
using UnityEngine; // Import the Unity Engine namespace

public class FollowPath : MonoBehaviour // Define a class named FollowPath, inheriting from MonoBehaviour
{
    [SerializeField] private Transform[] paths; // Array of path objects in the scene
    [SerializeField] private float speed = 5f; // Speed of movement along the path
    [SerializeField] private Transform[] waypoints; // Array of waypoints defining the path
    [SerializeField] private int currentWaypointIndex = 0; // Index of the current waypoint
    [SerializeField] private string PathTag = "Path"; // Tag to identify path objects
    [SerializeField] private float waitTimeAtEnd = 2.0f; // Time to wait at the end of the path (adjust as needed)
    [SerializeField] private float despawnDelay = 2.0f; // Delay before despawning

    private bool isWaiting = false; // Flag to indicate if the object is waiting at the end of the path
    private bool isMovingForward = true; // Flag to indicate the direction of movement along the path

    void Start() // Start is called before the first frame update
    {
        InitializePath(); // Initialize the path when the object starts
    }

    void Update() // Update is called once per frame
    {
        if (waypoints == null || waypoints.Length == 0) return; // Check if waypoints are not assigned or empty

        if (!isWaiting) // Check if the object is not waiting
        {
            MoveToNextWaypoint(); // Move to the next waypoint
        }
    }

    void InitializePath() // Initialize the path objects in the scene
    {
        GameObject[] pathObjects = GameObject.FindGameObjectsWithTag(PathTag); // Find all objects with the specified tag
        List<Transform> pathTransforms = new List<Transform>(); // Create a list to store path transforms

        foreach (GameObject pathObject in pathObjects) // Iterate through each path object
        {
            pathTransforms.Add(pathObject.transform); // Add the transform of each path object to the list
        }

        paths = pathTransforms.ToArray(); // Convert the list of path transforms to an array

        if (paths.Length > 0) // Check if there are paths in the scene
        {
            SelectRandomPath(); // Select a random path
        }
        else
        {
            Debug.LogWarning("No paths found in the scene!"); // Log a warning if no paths are found
        }
    }

    void SelectRandomPath() // Select a random path from the available paths
    {
        Transform pathTransform = paths[Random.Range(0, paths.Length)]; // Select a random path transform
        Debug.Log(pathTransform.name); // Log the name of the selected path

        Path path = pathTransform.GetComponent<Path>(); // Get the Path component attached to the selected path
        waypoints = path.GetWaypoints(); // Get the waypoints from the selected path

        if (waypoints.Length > 0) // Check if there are waypoints in the selected path
        {
            transform.position = waypoints[0].position; // Set the initial position of the object to the first waypoint
        }
    }

    void MoveToNextWaypoint() // Move to the next waypoint along the path
    {
        int nextWaypointIndex = isMovingForward ? currentWaypointIndex + 1 : currentWaypointIndex - 1; // Calculate the index of the next waypoint

        // Check if the next waypoint index is within bounds
        if (nextWaypointIndex >= 0 && nextWaypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, speed * Time.deltaTime); // Move towards the next waypoint

            // Check if the object has reached the next waypoint
            if (Vector2.Distance(transform.position, waypoints[nextWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex = nextWaypointIndex; // Update the current waypoint index

                // Check if the object has reached the end of the path
                if (currentWaypointIndex >= waypoints.Length || currentWaypointIndex < 0)
                {
                    StartCoroutine(WaitAtEnd()); // Start waiting at the end of the path
                }
            }
        }
        else
        {
            // If the next waypoint index is out of bounds, stop moving until the direction changes or the end of the path is reached
            isWaiting = true;
            StartCoroutine(WaitAtEnd());
        }
    }

    IEnumerator WaitAtEnd()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTimeAtEnd);
        isWaiting = false;
        isMovingForward = !isMovingForward;

        if (isMovingForward)
        {
            currentWaypointIndex = 0;
        }
        else
        {
            currentWaypointIndex = waypoints.Length - 1;
            StartCoroutine(DespawnAfterDelay()); // Start the despawn coroutine
        }
    }

    IEnumerator DespawnAfterDelay()
    {
        yield return new WaitForSeconds(despawnDelay); // Wait for the specified delay
        Destroy(gameObject); // Despawn the object
    }
}

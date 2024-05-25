using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class followPath : MonoBehaviour
{
    // viables for the pathing
    [SerializeField] private GameObject[] pathPrefabs;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //get a random path from the list 
        GameObject pathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
        Debug.Log(pathPrefab.name);
        //instanciate the path
        GameObject pathInstance = Instantiate(pathPrefab);
        Path path = pathInstance.GetComponent<Path>();
        // get the waypoints from the path
        waypoints = path.GetWaypoints();

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check to see if there are more then one waypoint
        if (waypoints.Length <= 0) return;

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}


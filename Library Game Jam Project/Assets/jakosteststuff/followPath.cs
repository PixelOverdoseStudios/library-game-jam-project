using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class followPath : MonoBehaviour
{
    [SerializeField] private GameObject[] pathPrefabs;
    [SerializeField] private float speed = 5f;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject pathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
        Debug.Log(pathPrefab.name);
        GameObject pathInstance = Instantiate(pathPrefab);
        Path path = pathInstance.GetComponent<Path>();

        
        waypoints = path.GetWaypoints();

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}


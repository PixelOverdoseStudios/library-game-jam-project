using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    [Header("spawn objects")]
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private int numberOfObjectsToSpawn = 1;
    [SerializeField] private float spawnDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPrefabsWithDelay());
    }

    // Coroutine to spawn prefabs with a delay
    IEnumerator SpawnPrefabsWithDelay()
    {
        if (prefabToSpawn != null)
        {
            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                Instantiate(prefabToSpawn, transform.position, transform.rotation);
                yield return new WaitForSeconds(spawnDelay); // Wait for the specified delay before spawning the next object
            }
        }
        else
        {
            Debug.Log("No object to spawn");
        }
    }
}

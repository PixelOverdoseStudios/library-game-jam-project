using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    [Header("spawn objects")]
    [SerializeField] private GameObject[] prefabToSpawn;
    [SerializeField] private int numberOfObjectsToSpawn = 1;
    [SerializeField] private float spawnDelay;
    [Header("time between spawns")]
    [SerializeField] private float minSpawnTimer = 1.0f;
    [SerializeField] private float maxSpawnTimer = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPrefabsWithDelay());
    }

    // Coroutine to spawn prefabs with a delay
    IEnumerator SpawnPrefabsWithDelay()
    {
        
        if (prefabToSpawn != null && prefabToSpawn.Length > 0)
        {
            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                // Select a random prefab from the array
                GameObject randomPrefab = prefabToSpawn[Random.Range(0, prefabToSpawn.Length)];
                // Instantiate the random prefab
                Instantiate(randomPrefab, transform.position, transform.rotation);
                spawnDelay = Random.RandomRange(minSpawnTimer, maxSpawnTimer);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
        else
        {
            Debug.Log("No object to spawn");
        }
    }
}

using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabs;  // Array to hold different prefabs to spawn
    public Vector3 spawnPosition; // Position where prefabs will be spawned

    void Start()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogError("No prefabs assigned to the spawner.");
            return;
        }
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            // Choose a random prefab from the list
            GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

            if (prefabToSpawn == null)
            {
                Debug.LogError("Prefab to spawn is null.");
                yield break;
            }

            // Spawn the prefab at the specified position
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            Debug.Log($"Spawned {prefabToSpawn.name} at {spawnPosition}");

            // Wait for a random amount of time between 1 and 5 seconds
            float waitTime = Random.Range(0.1f, 5f);
            Debug.Log($"Waiting for {waitTime} seconds before spawning next prefab.");
            yield return new WaitForSeconds(waitTime);
        }
    }
}

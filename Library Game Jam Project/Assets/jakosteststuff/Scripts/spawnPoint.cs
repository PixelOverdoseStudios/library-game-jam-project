using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Singleton instance
    public static SpawnPoint Instance;

    [Header("Spawn objects")]
    [SerializeField] private List<GameObject> teensPrefabs;
    [SerializeField] private List<GameObject> adultsPrefabs;
    [SerializeField] private List<GameObject> elderlyPrefabs;
    [SerializeField] private float startSpawnDelay = 1.0f;
    [SerializeField] private int numberOfObjectsToSpawn = 1;
    [SerializeField] private float spawnDelay;

    [Header("Time between spawns")]
    [SerializeField] private float minSpawnTimer = 1.0f;
    [SerializeField] private float maxSpawnTimer = 3.0f;

    [Header("Spawned Npcs")]
    [SerializeField] private int spawnedTeens = 0;
    [SerializeField] private int spawnedAdults = 0;
    [SerializeField] private int spawnedElderly = 0;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnPrefabsWithDelay());
    }

    // Coroutine to spawn prefabs with a delay
    private IEnumerator SpawnPrefabsWithDelay()
    {
        // Initial delay before starting to spawn
        yield return new WaitForSeconds(startSpawnDelay);

        numberOfObjectsToSpawn = LibraryManager.instance.GetVisitorDailyAmount();
        int totalPrefabsCount = teensPrefabs.Count + adultsPrefabs.Count + elderlyPrefabs.Count;

        if (totalPrefabsCount > 0)
        {
            for (int i = 0; i < numberOfObjectsToSpawn; i++)
            {
                GameObject randomPrefab = GetRandomPrefab(out int category);
                Instantiate(randomPrefab, transform.position, transform.rotation);

                // Increment the appropriate counter based on the category
                switch (category)
                {
                    case 0:
                        spawnedTeens++;
                        break;
                    case 1:
                        spawnedAdults++;
                        break;
                    case 2:
                        spawnedElderly++;
                        break;
                }

                spawnDelay = Random.Range(minSpawnTimer, maxSpawnTimer);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
        else
        {
            Debug.Log("No object to spawn");
        }
    }

    // Get a random prefab from the combined lists
    private GameObject GetRandomPrefab(out int category)
    {
        category = Random.Range(0, 3);
        GameObject randomPrefab = null;

        switch (category)
        {
            case 0:
                if (teensPrefabs.Count > 0)
                {
                    randomPrefab = teensPrefabs[Random.Range(0, teensPrefabs.Count)];
                }
                break;
            case 1:
                if (adultsPrefabs.Count > 0)
                {
                    randomPrefab = adultsPrefabs[Random.Range(0, adultsPrefabs.Count)];
                }
                break;
            case 2:
                if (elderlyPrefabs.Count > 0)
                {
                    randomPrefab = elderlyPrefabs[Random.Range(0, elderlyPrefabs.Count)];
                }
                break;
        }

        if (randomPrefab == null)
        {
            // Fallback in case the chosen category list was empty
            List<GameObject> combinedList = new List<GameObject>();
            combinedList.AddRange(teensPrefabs);
            combinedList.AddRange(adultsPrefabs);
            combinedList.AddRange(elderlyPrefabs);
            randomPrefab = combinedList[Random.Range(0, combinedList.Count)];
            // Set category based on the fallback list (assuming equal distribution for simplicity)
            if (combinedList.Count > 0)
            {
                category = combinedList.IndexOf(randomPrefab) % 3;
            }
        }

        return randomPrefab;
    }

    public int GetNumberOfObjectsToSpawn() => numberOfObjectsToSpawn;
    public int GetSpawnedTeens() => spawnedTeens;
    public int GetSpawnedAdults() => spawnedAdults;
    public int GetSpawnedElderly() => spawnedElderly;
}

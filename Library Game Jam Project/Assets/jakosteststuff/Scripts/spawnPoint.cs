using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DayManager;

public class SpawnPoint : MonoBehaviour
{
    // Singleton instance
    public static SpawnPoint Instance;

    [Header("Spawn objects")]
    [SerializeField] private List<GameObject> teensPrefabs;
    [SerializeField] private List<GameObject> adultsPrefabs;
    [SerializeField] private List<GameObject> elderlyPrefabs;
    [SerializeField] private int numberOfObjectsToSpawn = 1;
    [SerializeField] private int despawnedCount = 0;

    [Header("Spawned Npcs")]
    [SerializeField] private int spawnedTeens = 0;
    [SerializeField] private int spawnedAdults = 0;
    [SerializeField] private int spawnedElderly = 0;
    private float spawnTime;

    public static object instance { get; internal set; }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        spawnTime = DayManager.instance.GetTotalDayTime();
        numberOfObjectsToSpawn = LibraryManager.instance.GetVisitorDailyAmount();
    }

    // Start spawning process
    public void StartSpawningProcess()
    {
        Debug.Log("Spawn time: " + spawnTime);
        StartSpawning(); // Start spawning process after setting spawnTime
    }

    // Coroutine to spawn prefabs randomly within the total spawn time
    private IEnumerator SpawnPrefabsRandomly()
    {
        Debug.Log("Spawn process started.");
        float elapsedTime = 0f;
        int totalSpawned = 0;

        while (elapsedTime < spawnTime && totalSpawned < numberOfObjectsToSpawn)
        {
            float remainingTime = spawnTime - elapsedTime;
            float timeUntilNextSpawn = Random.Range(0f, remainingTime / (numberOfObjectsToSpawn - totalSpawned));
            yield return new WaitForSeconds(timeUntilNextSpawn);

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

            elapsedTime += timeUntilNextSpawn;
            totalSpawned++;
        }

        Debug.Log("Spawn process ended. Total spawned: " + totalSpawned);
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
    public void StartSpawning()
    {
        StartCoroutine(SpawnPrefabsRandomly());
    }

    public void NotifyNpcDespawned()
    {
        despawnedCount++;
        CheckEndOfDay();
    }

    // Check if all NPCs have been spawned and despawned
    private void CheckEndOfDay()
    {
        if (despawnedCount == numberOfObjectsToSpawn)
        {
            EndOfDay();
        }
    }

    private void EndOfDay()
    {
        DayManager.instance.ActivateButton();
        DayManager.instance.EndOfDayPanel();
        Debug.Log("End of day");
        
        despawnedCount = 0;
        
    }
    private void ResetNumberSpawned()
    {
        spawnedTeens = 0;
        spawnedAdults = 0;
        spawnedAdults = 0;
    }
    public int GetNumberOfObjectsToSpawn() => numberOfObjectsToSpawn;
    public int GetSpawnedTeens() => spawnedTeens;
    public int GetSpawnedAdults() => spawnedAdults;
    public int GetSpawnedElderly() => spawnedElderly;
    public void ResetSpawns() => ResetNumberSpawned();

    
    
}

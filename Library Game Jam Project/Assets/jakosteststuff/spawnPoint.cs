using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    [Header("spawn objects")]
   [SerializeField] private GameObject prefabToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        spawnPrefab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //pawns the selected  prefab
    void spawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position,transform.rotation);
        }
        else
        {
            Debug.Log("no object to spawn");
        }
    }

}

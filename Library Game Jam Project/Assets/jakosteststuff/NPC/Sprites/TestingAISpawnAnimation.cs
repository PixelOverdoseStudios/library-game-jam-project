using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingAISpawnAnimation : MonoBehaviour
{
    [SerializeField] private Transform animationSpawnLocation;
    [SerializeField] private GameObject animationToPlay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(animationToPlay, animationSpawnLocation.transform.position, Quaternion.identity);
        }
    }
}

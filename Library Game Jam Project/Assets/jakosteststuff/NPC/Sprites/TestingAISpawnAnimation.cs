using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingAISpawnAnimation : MonoBehaviour
{
    [SerializeField] private GameObject membershipAnimation;
    [SerializeField] private Transform animationSpawnLocation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnAnimation();
        }
    }

    private void SpawnAnimation()
    {
        Instantiate(membershipAnimation, animationSpawnLocation.transform.position, Quaternion.identity);
    }
}

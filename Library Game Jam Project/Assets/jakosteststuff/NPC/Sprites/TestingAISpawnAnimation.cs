using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingAISpawnAnimation : MonoBehaviour
{
    [SerializeField] private Transform animationSpawnLocation;
    [SerializeField] private GameObject animationToPlay;


    private void SpawnAnimation()
    {
        Instantiate(animationToPlay, animationSpawnLocation.transform.position, Quaternion.identity);
    }
    public void Signup() => SpawnAnimation();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choise : MonoBehaviour
{
    [SerializeField] float randomValue; // Corrected property declaration

    // Start is called before the first frame update
    void Start()
    {
        randomValue = Random.value; // Assign a random value between 0 and 1
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: You can update randomValue here if you want to re-evaluate it continuously.
    }

    public void ChoiseToMake()
    {
        if (randomValue < 0.5f)
        {
            Debug.Log("Staying"); // Corrected the message for consistency
        }
        else
        {
            Debug.Log("Leaving");
        }
    }
}

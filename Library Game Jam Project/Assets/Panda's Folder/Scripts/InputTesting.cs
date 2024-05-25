using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTesting : MonoBehaviour
{
    [SerializeField] private GameObject objectOne;
    [SerializeField] private GameObject objectTwo;
    [SerializeField] private GameObject objectThree;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        { 
            if(objectOne.activeInHierarchy)
                objectOne.SetActive(false);
            else
                objectOne.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (objectTwo.activeInHierarchy)
                objectTwo.SetActive(false);
            else
                objectTwo.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectThree.activeInHierarchy)
                objectThree.SetActive(false);
            else
                objectThree.SetActive(true);
        }
    }
}

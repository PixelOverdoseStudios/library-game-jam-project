using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputListener : MonoBehaviour
{
    [SerializeField] private String SceneToLoad = "MainMenuTest";
    private void Update()
    {
        // Check for mouse click or spacebar press
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}

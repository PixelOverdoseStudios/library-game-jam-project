using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;  // Import the SceneManager namespace

public class TextChanger : MonoBehaviour
{
    public TMP_Text displayText;  // Reference to the TextMeshProUGUI component
    public string[] textArray;  // Array to hold the texts to be displayed
    private int currentIndex = 0;  // Index to keep track of the current text
    public string nextSceneName;  // Name of the next scene to load

    void Start()
    {
        // Display the first text at the start
        if (textArray.Length > 0)
        {
            displayText.text = textArray[currentIndex];
        }
    }

    void Update()
    {
        // Check for mouse click or spacebar press
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Increment the index
            currentIndex++;

            // Check if we have reached the end of the text array
            if (currentIndex >= textArray.Length)
            {
                // Load the next scene
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                // Update the displayed text
                displayText.text = textArray[currentIndex];
            }
        }
    }
}

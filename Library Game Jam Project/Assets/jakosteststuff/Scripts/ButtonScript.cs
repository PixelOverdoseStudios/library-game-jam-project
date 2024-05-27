using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Reference to the button
    public Button myButton;

    void Start()
    {
        // Ensure the button is assigned
        if (myButton != null)
        {
            // Add a listener to the button
            myButton.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button not assigned in the Inspector.");
        }
    }

    // Method called when the button is clicked
    void OnButtonClick()
    {
        DayManager.instance.StartCountdown();
        SpawnPoint.Instance.StartSpawning();
    }
}

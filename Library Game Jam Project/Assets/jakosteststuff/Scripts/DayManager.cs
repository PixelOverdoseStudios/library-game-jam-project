using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    private static DayManager instance;

    [SerializeField] private float countdownTime = 300f; // 5 minutes in seconds
    public TMP_Text countdownText; // Reference to a UI Text element to display the countdown

    private float initialCountdownTime; // Store the initial countdown time
    private float totalGameTime = 11 * 60 * 60; // Total game time in seconds (11 hours)

    private void Awake()
    {
        instance = this;
        initialCountdownTime = countdownTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the countdown text if it's assigned
        if (countdownText != null)
        {
            countdownText.text = FormatTime(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;

            // Calculate the elapsed time ratio
            float elapsedRatio = 1 - (countdownTime / initialCountdownTime);

            // Calculate the current in-game time
            float currentTime = elapsedRatio * totalGameTime;

            // Update the countdown text if it's assigned
            if (countdownText != null)
            {
                countdownText.text = FormatTime(currentTime);
            }
        }
        else
        {
            countdownTime = 0;
            // Perform any action when the countdown reaches zero
        }
    }

    // Format the time as hours:minutes AM/PM (in-game time from 7 AM to 6 PM)
    private string FormatTime(float time)
    {
        int startHour = 7;
        int totalMinutes = Mathf.FloorToInt(time / 60F);
        int hours = startHour + totalMinutes / 60;
        int minutes = totalMinutes % 60;

        string period = "AM";
        if (hours >= 12)
        {
            period = "PM";
        }

        if (hours > 12)
        {
            hours -= 12;
        }

        return string.Format("{0:00}:{1:00} {2}", hours, minutes, period);
    }
}

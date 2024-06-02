using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
    public static DayManager instance;

    [SerializeField] private float countdownTime = 120f; // 5 minutes in seconds
    [SerializeField] private int startTime = 7;
    [SerializeField] private float totalHours = 11;
    public TMP_Text countdownText; // Reference to a UI Text element to display the countdown
    private float initialCountdownTime; // Store the initial countdown time
    private float totalGameTime; // Total game time in seconds (11 hours)
    private bool isCountdownActive = false; // Flag to check if countdown is active

    // Define a delegate and an event
    public delegate void CountdownFinished();
    public event CountdownFinished OnCountdownFinished;

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
            totalGameTime = totalHours * 60 * 60;
        }
    }

    // Method to start the countdown
    public void StartCountdown()
    {
        isCountdownActive = true;
        countdownTime = initialCountdownTime; // Reset countdown time if needed
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountdownActive && countdownTime > 0)
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
        else if (isCountdownActive && countdownTime != 0) // Ensure this only runs once
        {
            countdownTime = 0;
            // Invoke the event
            OnCountdownFinished?.Invoke();
            isCountdownActive = false; // Stop the countdown
        }
    }

    // Format the time as hours:minutes AM/PM (in-game time from 7 AM to 6 PM)
    private string FormatTime(float time)
    {
        int startHour = startTime;
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
    private void startgameday()
    {
        this.StartCountdown();
        SpawnPoint.Instance.StartSpawning();
        SignupManager.instance.resetSignup();
    }

    public float GetTotalDayTime() => countdownTime;
    public void StartDay() => startgameday();
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private String SceneToLoad = "DialogScenetest";
    [SerializeField] private String CreditsScene = "Credits";
    [SerializeField] private TMP_Text VolumeText;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private TMP_Text MusicOn;

    private bool bitState = false; // Boolean variable to track the bit state

    private void Awake()
    {
        // Initialize the volume slider and text with the saved volume level
        InitializeVolume();
    }
    public void Update()
    {
        if (SettingsManager.instance.GetSoundOn())
        {
            MusicOn.text = "Music On";
        }
        else
        {
            MusicOn.text = "Music Off";
        }
    }

    // Method to start the game
    public void StartGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        // Set the slider value to the current volume level when opening options
        VolumeSlider.value = SettingsManager.instance.GetVolumeLevel();
        VolumeText.text = VolumeSlider.value.ToString("0"); // Update the volume text

        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void Credits()
    {
        SceneManager.LoadScene(CreditsScene);
    }

    public void OnVolumeSliderChanged()
    {
        // Update the volume text and set the new volume in the settings manager
        VolumeText.text = VolumeSlider.value.ToString("0");
        SettingsManager.instance.SetVolume(VolumeSlider.value);
    }

    private void InitializeVolume()
    {
        // Set the slider and text to the saved volume level on initialization
        float savedVolume = SettingsManager.instance.GetVolumeLevel();
        VolumeSlider.value = savedVolume;
        VolumeText.text = savedVolume.ToString("0");
    }

    // Method to toggle the bit state
    public void musicONOff()
    {
        SettingsManager.instance.MusicOnOff();
        if (SettingsManager.instance.GetSoundOn())
        {
            MusicOn.text = "Music On";
        }
        else
        {
            MusicOn.text = "Music Off";
        }


    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private String SceneToLoad = "DialogScenetest";
    [SerializeField] private TMP_Text VolumeText;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject mainMenu;

    public void Awake()
    {
        SetVolume();
    }
    // Method to start the game
    public void StartGame()
    {
        SceneManager.LoadScene(SceneToLoad); // Replace "GameScene" with the name of your game scene
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        VolumeSlider.value = SettingsManager.instance.GetVolumeLevel();
        SetVolume();
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void OpenMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void SetVolume()
    {
        
        VolumeText.text = VolumeSlider.value.ToString();
        SettingsManager.instance.SetVolume(VolumeSlider.value);
    }
}

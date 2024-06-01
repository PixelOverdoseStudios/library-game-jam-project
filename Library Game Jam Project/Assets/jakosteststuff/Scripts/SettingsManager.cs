using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    // Example settings variables
    public bool soundOn = true;
    public float volumeLevel = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        float vol = volume / 100;
        volumeLevel = vol;
    }
    public float GetVolumeLevel()
    { return volumeLevel * 100; }
}

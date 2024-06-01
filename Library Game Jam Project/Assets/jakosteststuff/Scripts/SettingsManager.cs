using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public bool soundOn = true;
    public float volumeLevel = 0.5f; // This should be between 0 and 1
    private const string VolumeKey = "VolumeLevel";
    private const string SoundOnKey = "SoundOn";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            

            // Load the saved volume level and sound state
            LoadVolume();
            LoadSoundOnState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        float vol = Mathf.Clamp(volume / 100f, 0f, 1f); // Convert from percentage to 0-1 range and clamp
        volumeLevel = vol;

        // Save the volume level
        PlayerPrefs.SetFloat(VolumeKey, volumeLevel);
        PlayerPrefs.Save();

        // Notify the SoundManager to apply the new volume
        SoundManager.instance?.ApplySettings();
    }

    public float GetVolumeLevel()
    {
        return volumeLevel * 100f; // Convert from 0-1 range to percentage
    }

    public void MusicOnOff()
    {
        soundOn = !soundOn;

        // Save the sound state
        PlayerPrefs.SetInt(SoundOnKey, soundOn ? 1 : 0);
        PlayerPrefs.Save();

        // Notify the SoundManager to apply the new sound state
        SoundManager.instance?.ApplySettings();
    }

    public bool GetSoundOn() => soundOn;

    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            volumeLevel = PlayerPrefs.GetFloat(VolumeKey);
        }
        else
        {
            volumeLevel = 0.5f; // Default value if not set
        }
    }

    private void LoadSoundOnState()
    {
        soundOn = PlayerPrefs.GetInt(SoundOnKey, 1) == 1; // Default is sound on
    }
}

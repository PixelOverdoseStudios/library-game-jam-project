using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public bool soundOn = true;
    public float volumeLevel = 0.5f; // This should be between 0 and 1

    private const string VolumeKey = "VolumeLevel";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Load the saved volume level
            LoadVolume();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Ensure the audio source volume is set at the start
        ApplyVolume();
    }

    public void SetVolume(float volume)
    {
        float vol = Mathf.Clamp(volume / 100f, 0f, 1f); // Convert from percentage to 0-1 range and clamp
        volumeLevel = vol;

        // Save the volume level
        PlayerPrefs.SetFloat(VolumeKey, volumeLevel);
        PlayerPrefs.Save();

        // Apply the new volume immediately
        ApplyVolume();
    }

    public float GetVolumeLevel()
    {
        return volumeLevel * 100f; // Convert from 0-1 range to percentage
    }

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

    private void ApplyVolume()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.volume = volumeLevel;
        }
    }
}

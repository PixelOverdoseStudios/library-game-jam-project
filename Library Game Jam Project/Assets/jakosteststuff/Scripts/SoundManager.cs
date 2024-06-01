using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public List<AudioClip> musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Awake()
    {
        // Ensure that only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();

        // Apply initial settings from SettingsManager
        ApplySettings();

        if (SettingsManager.instance != null && SettingsManager.instance.GetSoundOn() && musicTracks.Count > 0)
        {
            PlayNextTrack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingsManager.instance == null || !SettingsManager.instance.GetSoundOn())
        {
            return;
        }

        // Check if the current track has finished playing
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayNextTrack()
    {
        if (SettingsManager.instance == null || !SettingsManager.instance.GetSoundOn() || musicTracks.Count == 0)
        {
            return;
        }

        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();

        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Count;
    }

    public void ApplySettings()
    {
        if (SettingsManager.instance != null)
        {
            audioSource.volume = SettingsManager.instance.volumeLevel;
            audioSource.enabled = SettingsManager.instance.GetSoundOn();

            // If music is disabled, stop the audioSource
            if (!SettingsManager.instance.GetSoundOn())
            {
                audioSource.Stop();
            }
        }
    }
}

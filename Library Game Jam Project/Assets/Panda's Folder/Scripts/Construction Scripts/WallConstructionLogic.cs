using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConstructionLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] brickLayers;
    [SerializeField] private GameObject[] wallpaperLayers;

    [SerializeField] private AudioClip flipPageClip;

    public void SetBrickLayer(int value)
    {
        switch(value)
        {
            case 0:
                PlayClickSound();
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 1:
                PlayClickSound();
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 2:
                PlayClickSound();
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 3:
                PlayClickSound();
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 4:
                PlayClickSound();
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
        }
    }

    public void SetWallpaperLayer(int value)
    {
        switch (value)
        {
            case 0:
                PlayClickSound();
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 1:
                PlayClickSound();
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 2:
                PlayClickSound();
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 3:
                PlayClickSound();
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 4:
                PlayClickSound();
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
        }
    }

    private void DeactivateAllBrickLayers()
    {
        foreach(GameObject brickLayer in brickLayers)
        {
            brickLayer.SetActive(false);
        }
    }

    private void DeactivateAllWallpaperLayers()
    {
        foreach (GameObject wallpaper in wallpaperLayers)
        {
            wallpaper.SetActive(false);
        }
    }

    private void PlayClickSound()
    {
        float randomPitch = Random.Range(0.7f, 1.3f);
        AudioManager.instance.PlaySoundFXClipRandomPitch(flipPageClip, transform, 1f, randomPitch);
    }
}

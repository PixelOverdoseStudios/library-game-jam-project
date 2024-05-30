using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConstructionLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] brickLayers;
    [SerializeField] private GameObject[] wallpaperLayers;

    public void SetBrickLayer(int value)
    {
        switch(value)
        {
            case 0:
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 1:
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 2:
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 3:
                DeactivateAllBrickLayers();
                brickLayers[value].SetActive(true);
                break;
            case 4:
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
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 1:
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 2:
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 3:
                DeactivateAllWallpaperLayers();
                wallpaperLayers[value].SetActive(true);
                break;
            case 4:
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
}

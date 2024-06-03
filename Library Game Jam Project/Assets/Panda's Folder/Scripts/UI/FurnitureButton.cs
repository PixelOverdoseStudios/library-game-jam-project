using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureButton : MonoBehaviour
{
    [SerializeField] private GameObject[] furniture;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip flipPageClip;

    public void FurnitureOption1() => UpdateFurniture(0);
    public void FurnitureOption2() => UpdateFurniture(1);
    public void FurnitureOption3() => UpdateFurniture(2);

    private void UpdateFurniture(int choice)
    {
        switch(choice)
        {
            case 0:
                PlayClickSound();
                DisableAllFurniture();
                furniture[choice].SetActive(true);
                break;
            case 1:
                PlayClickSound();
                DisableAllFurniture();
                furniture[choice].SetActive(true);
                break;
            case 2:
                PlayClickSound();
                DisableAllFurniture();
                furniture[choice].SetActive(true);
                break;
        }
    }

    private void DisableAllFurniture()
    {
        foreach (GameObject i in furniture)
            i.SetActive(false);
    }

    private void PlayClickSound()
    {
        float randomPitch = Random.Range(0.7f, 1.3f);
        AudioManager.instance.PlaySoundFXClipRandomPitch(flipPageClip, transform, 1f, randomPitch);
    }
}

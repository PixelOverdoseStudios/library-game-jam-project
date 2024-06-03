using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureConstructionLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] bookshelveColors;
    [SerializeField] private GameObject[] seatingColors;
    [SerializeField] private GameObject[] couchColors;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip flipPageClip;

    public void SetBookshelveColor(int value)
    {
        switch(value)
        {
            case 0:
                PlayClickSound();
                bookshelveColors[1].SetActive(false); 
                bookshelveColors[0].SetActive(true); 
                break;
            case 1:
                PlayClickSound();
                bookshelveColors[0].SetActive(false);
                bookshelveColors[1].SetActive(true);
                break;
        }
    }

    public void SetSeatingColor(int value)
    {
        switch (value)
        {
            case 0:
                PlayClickSound();
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 1:
                PlayClickSound();
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 2:
                PlayClickSound();
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 3:
                PlayClickSound();
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 4:
                PlayClickSound();
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
        }
    }

    public void SetCouchColor(int value)
    {
        switch (value)
        {
            case 0:
                PlayClickSound();
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 1:
                PlayClickSound();
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 2:
                PlayClickSound();
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 3:
                PlayClickSound();
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 4:
                PlayClickSound();
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
        }
    }

    private void DeactivateAllSeats()
    {
        foreach(GameObject seat in seatingColors)
        {
            seat.SetActive(false);
        }
    }

    private void DeactivateAllCouches()
    {
        foreach (GameObject couch in couchColors)
        {
            couch.SetActive(false);
        }
    }
    private void PlayClickSound()
    {
        float randomPitch = Random.Range(0.7f, 1.3f);
        AudioManager.instance.PlaySoundFXClipRandomPitch(flipPageClip, transform, 1f, randomPitch);
    }
}

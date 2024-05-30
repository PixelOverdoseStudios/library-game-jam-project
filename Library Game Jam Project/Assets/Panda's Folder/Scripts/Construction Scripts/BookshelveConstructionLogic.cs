using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelveConstructionLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] bookshelveColors;
    [SerializeField] private GameObject[] seatingColors;
    [SerializeField] private GameObject[] couchColors;

    public void SetBookshelveColor(int value)
    {
        switch(value)
        {
            case 0:
                bookshelveColors[1].SetActive(false); 
                bookshelveColors[0].SetActive(true); 
                break;
            case 1:
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
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 1:
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 2:
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 3:
                DeactivateAllSeats();
                seatingColors[value].SetActive(true);
                break;
            case 4:
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
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 1:
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 2:
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 3:
                DeactivateAllCouches();
                couchColors[value].SetActive(true);
                break;
            case 4:
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
}

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
}

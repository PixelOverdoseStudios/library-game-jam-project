using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;

    [SerializeField] private GameObject[] teenUIStars;
    [SerializeField] private GameObject[] adultUIStars;
    [SerializeField] private GameObject[] elderlyUIStars;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateUI()
    {
        UpdateTeenStars();
        UpdateAdultStars();
        UpdateElderlyStars();
    }

    private void UpdateTeenStars()
    {
        foreach(GameObject star in teenUIStars)
        {
            star.gameObject.SetActive(false);
        }

        for (int i = 0; i < LibraryManager.instance.GetTeenStarLevel(); i++)
        {
            teenUIStars[i].gameObject.SetActive(true);
        }
    }

    private void UpdateAdultStars()
    {
        foreach (GameObject star in adultUIStars)
        {
            star.gameObject.SetActive(false);
        }

        for (int i = 0; i < LibraryManager.instance.GetAdultStarLevel(); i++)
        {
            adultUIStars[i].gameObject.SetActive(true);
        }
    }

    private void UpdateElderlyStars()
    {
        foreach (GameObject star in elderlyUIStars)
        {
            star.gameObject.SetActive(false);
        }

        for (int i = 0; i < LibraryManager.instance.GetElderlyStarLevel(); i++)
        {
            elderlyUIStars[i].gameObject.SetActive(true);
        }
    }
}

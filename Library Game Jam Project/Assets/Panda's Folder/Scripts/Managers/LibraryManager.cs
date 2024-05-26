using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public static LibraryManager instance;

    [Header("Library Stats")]
    [SerializeField] private int teenStars;
    [SerializeField] private int adultStars;
    [SerializeField] private int elderlyStars;
    [SerializeField] private int libraryMemberships;

    [Header("Time Keeping")]
    [SerializeField] private int currentDay;
    [SerializeField] private int visitorDailyAmount = 15;

    private void Awake()
    {
        instance = this;
    }

    //Call this function when you need to add stars to the library stats from another script.
    public void AddStarLevel(int value, int order)
    {
        switch(order)
        {
            case 0:
                teenStars += value;
                break;
            case 1:
                adultStars += value;
                break;
            case 2:
                elderlyStars += value;
                break;
        }
    }
    
    //Call this function when you need to subtract stars to the library stats from another script.
    public void SubtractStarLevel(int value, int order)
    {
        switch(order)
        {
            case 0:
                teenStars -= value;
                break;
            case 1:
                adultStars -= value;
                break;
            case 2:
                elderlyStars -= value;
                break;
        }
    }

    //Call this function when you need to add library memberships from another script.
    public void AddLibraryMemberships(int value)
    {
        libraryMemberships += value;
    }

    //Use any of the below functions to get the star value.
    public int GetTeenStarLevel() => teenStars;
    public int GetAdultStarLevel() => adultStars;
    public int GetElderlyStarLevel() => elderlyStars;
    public int GetLibraryMemberships() => libraryMemberships;
    public int GetCurrentDay() => currentDay;
    public int GetVisitorDailyAmount() => visitorDailyAmount;

    //placeholder signup methode
    public int SetSignups() => libraryMemberships++;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furinature : MonoBehaviour
{
    [Header("Furniture Values")]
    [SerializeField] private int teenValue;
    [SerializeField] private int adultValue;
    [SerializeField] private int elderlyValue;
    [SerializeField] private int vistorValue;

    private void OnEnable()
    {
        LibraryManager.instance.AddStarLevel(teenValue, 0);
        LibraryManager.instance.AddStarLevel(adultValue, 1);
        LibraryManager.instance.AddStarLevel(elderlyValue, 2);
        LibraryManager.instance.AddVisitorsPerDay(vistorValue);
    }
    
    private void OnDisable()
    {
        LibraryManager.instance.SubtractStarLevel(teenValue, 0);
        LibraryManager.instance.SubtractStarLevel(adultValue, 1);
        LibraryManager.instance.SubtractStarLevel(elderlyValue, 2);
        LibraryManager.instance.SubtractVisitorsPerDay(vistorValue);
    }
}

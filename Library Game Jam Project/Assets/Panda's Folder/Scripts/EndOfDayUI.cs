using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfDayUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endOfDayText;
    [SerializeField] TextMeshProUGUI teensVisited;
    [SerializeField] TextMeshProUGUI adultsVisited;
    [SerializeField] TextMeshProUGUI elderlyVisited;
    [SerializeField] TextMeshProUGUI teensGained;
    [SerializeField] TextMeshProUGUI adultsGained;
    [SerializeField] TextMeshProUGUI elderlyGained;
    [SerializeField] TextMeshProUGUI membershipsGained;

    void Update()
    {
        endOfDayText.text = "Day " + LibraryManager.instance.GetCurrentDay().ToString() + " Complete!";
        teensVisited.text = "0001";
        adultsVisited.text = "0001";
        elderlyVisited.text = "0001";
        teensGained.text = SignupManager.instance.GetTeenSignups().ToString("0000");
        adultsGained.text = SignupManager.instance.GetAdultSignups().ToString("0000");
        elderlyGained.text = SignupManager.instance.GetElderlySignups().ToString("0000");
        membershipsGained.text = "0001";
    }
}

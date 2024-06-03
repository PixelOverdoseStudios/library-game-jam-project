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
        
        teensGained.text = SignupManager.instance.GetTeenSignups().ToString("0000");
        adultsGained.text = SignupManager.instance.GetAdultSignups().ToString("0000");
        elderlyGained.text = SignupManager.instance.GetElderlySignups().ToString("0000");
        teensVisited.text = SpawnPoint.Instance.GetSpawnedTeens().ToString("0000");
        adultsVisited.text = SpawnPoint.Instance.GetSpawnedAdults().ToString("0000");
        elderlyVisited.text = SpawnPoint.Instance.GetSpawnedElderly().ToString("0000");

        membershipsGained.text = SignupManager.instance.GetMemberShipsGain().ToString("0000");
    }
}

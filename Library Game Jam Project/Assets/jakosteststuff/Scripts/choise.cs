using UnityEngine;
using System.Collections.Generic;

public class Choise : MonoBehaviour
{
    [SerializeField] float randomValue;
    [SerializeField] int teenStarLevel;
    [SerializeField] int adultStarLevel;
    [SerializeField] int elderlyStarLevel;

    [System.Serializable]
    public class SignupEntry
    {
        public int starLevel;
        public int signupPercentage;
    }

    [SerializeField]
    List<SignupEntry> signupTable = new List<SignupEntry>()
    {
        new SignupEntry { starLevel = 0, signupPercentage = 0 },
        new SignupEntry { starLevel = 1, signupPercentage = 30 },
        new SignupEntry { starLevel = 2, signupPercentage = 40 },
        new SignupEntry { starLevel = 3, signupPercentage = 50 },
        new SignupEntry { starLevel = 4, signupPercentage = 60 },
        new SignupEntry { starLevel = 7, signupPercentage = 80 },
        new SignupEntry { starLevel = 8, signupPercentage = 90 },
        new SignupEntry { starLevel = 9, signupPercentage = 95 },
        new SignupEntry { starLevel = 10, signupPercentage = 100 }
    };

    void Start()
    {
        setStarLevel();
        randomValue = Random.value;
        
    }

    void Update()
    {

    }

    public void ChoiseToMake(NpcController.AgeGroupe ageGroup)
    {
        int signupPercentage = 0;
        int starLevel = 0;

        switch (ageGroup)
        {
            case NpcController.AgeGroupe.Teen:
                starLevel = teenStarLevel;
                break;

            case NpcController.AgeGroupe.Adult:
                starLevel = adultStarLevel;
                break;

            case NpcController.AgeGroupe.Elderly:
                starLevel = elderlyStarLevel;
                break;

            default:
                Debug.LogError("Invalid age group!");
                return;
        }

        foreach (SignupEntry entry in signupTable)
        {
            if (entry.starLevel == starLevel)
            {
                signupPercentage = entry.signupPercentage;
                break;
            }
        }

        if (randomValue * 100 <= signupPercentage)
        {
            switch (ageGroup)
            {
                case NpcController.AgeGroupe.Teen:
                    SignupManager.instance.IncrementTeenSignups();
                    break;

                case NpcController.AgeGroupe.Adult:
                    SignupManager.instance.IncrementAdultSignups();
                    break;

                case NpcController.AgeGroupe.Elderly:
                    SignupManager.instance.IncrementElderlySignups();
                    break;
            }

            LibraryManager.instance.SetSignups();
        }
        else
        {
            Debug.Log(ageGroup + " leaving");
        }
    }

    private void setStarLevel()
    {
        teenStarLevel = LibraryManager.instance.GetTeenStarLevel();
        adultStarLevel = LibraryManager.instance.GetAdultStarLevel();
        elderlyStarLevel = LibraryManager.instance.GetElderlyStarLevel();
    }
}

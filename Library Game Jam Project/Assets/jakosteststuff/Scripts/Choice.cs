using UnityEngine;
using System.Collections.Generic;

public class Choice : MonoBehaviour
{
    [SerializeField] private float randomValue;
    [SerializeField] private int teenStarLevel;
    [SerializeField] private int adultStarLevel;
    [SerializeField] private int elderlyStarLevel;
    [SerializeField] private GameObject SignupCard;

    [System.Serializable]
    public class SignupEntry
    {
        public int starLevel;
        public int signupPercentage;
    }

    [SerializeField]
    private List<SignupEntry> signupTable = new List<SignupEntry>()
    {
        new SignupEntry { starLevel = 0, signupPercentage = 10 },
        new SignupEntry { starLevel = 1, signupPercentage = 30 },
        new SignupEntry { starLevel = 2, signupPercentage = 50 },
        new SignupEntry { starLevel = 3, signupPercentage = 60 },
        new SignupEntry { starLevel = 4, signupPercentage = 80 },
        new SignupEntry { starLevel = 5, signupPercentage = 100 },
        new SignupEntry { starLevel = 7, signupPercentage = 80 },
        new SignupEntry { starLevel = 8, signupPercentage = 90 },
        new SignupEntry { starLevel = 9, signupPercentage = 95 },
        new SignupEntry { starLevel = 10, signupPercentage = 100 }
    };

    private bool hasIncrementedLibrary = false;

    private void Awake()
    {
        randomValue = Random.value * 100;
        // Ensure SignupCard is assigned
        if (SignupCard == null)
        {
            Debug.LogError("SignupCard is not assigned in the Inspector!");
        }
    }

    public void Update()
    {
        if(LibraryManager.instance != null)
        {
        teenStarLevel = LibraryManager.instance.GetTeenStarLevel();
        adultStarLevel = LibraryManager.instance.GetAdultStarLevel();
        elderlyStarLevel = LibraryManager.instance.GetElderlyStarLevel();
        }
        
    }

    public void ChooseToMake(NpcController.AgeGroup ageGroup)
    {
        int starLevel = GetStarLevel(ageGroup);
        int signupPercentage = GetSignupPercentage(starLevel);

        if (randomValue <= signupPercentage)
        {
            
            IncrementSignups(ageGroup);
            if (!hasIncrementedLibrary)
            {
                IncrementLibraryMembership();
                hasIncrementedLibrary = true;
                if (SignupCard != null)
                {
                   
                    SignupCard.SetActive(true);
                    
                }
                else
                {
                    Debug.LogError("SignupCard is not assigned!");
                }
            }
        }
        else
        {
            Debug.Log(ageGroup + " leaving");
        }
    }

    private int GetStarLevel(NpcController.AgeGroup ageGroup)
    {
        switch (ageGroup)
        {
            case NpcController.AgeGroup.Teen:
                return teenStarLevel;

            case NpcController.AgeGroup.Adult:
                return adultStarLevel;

            case NpcController.AgeGroup.Elderly:
                return elderlyStarLevel;

            default:
                Debug.Log("Invalid age group!");
                return 0;
        }
    }

    private int GetSignupPercentage(int starLevel)
    {
        foreach (SignupEntry entry in signupTable)
        {
            if (entry.starLevel == starLevel)
            {
                return entry.signupPercentage;
            }
        }
        return 0;
    }

    private void IncrementSignups(NpcController.AgeGroup ageGroup)
    {
        if (SignupManager.instance == null)
        {
            Debug.LogError("SignupManager instance is not initialized!");
            return;
        }

        switch (ageGroup)
        {
            case NpcController.AgeGroup.Teen:
                SignupManager.instance.IncrementTeenSignups();
                break;

            case NpcController.AgeGroup.Adult:
                SignupManager.instance.IncrementAdultSignups();
                break;

            case NpcController.AgeGroup.Elderly:
                SignupManager.instance.IncrementElderlySignups();
                break;

            default:
                Debug.LogError("Invalid age group!");
                break;
        }
    }

    private void IncrementLibraryMembership()
    {
        if (LibraryManager.instance == null)
        {
            Debug.LogError("LibraryManager instance is not initialized!");
            return;
        }

        LibraryManager.instance.IncrementLibraryMemberships();
    }
}

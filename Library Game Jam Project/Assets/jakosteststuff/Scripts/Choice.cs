using UnityEngine;
using System.Collections.Generic;

public class Choice : MonoBehaviour
{
    [SerializeField] private float randomValue;
    [SerializeField] private int teenStarLevel;
    [SerializeField] private int adultStarLevel;
    [SerializeField] private int elderlyStarLevel;
    [SerializeField] private AnimationsController animationController;

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
    }

    public void ChooseToMake(NpcController.AgeGroup ageGroup)
    {
        int starLevel = GetStarLevel(ageGroup);
        int signupPercentage = GetSignupPercentage(starLevel);

        if (randomValue >= signupPercentage)
        {
            IncrementSignups(ageGroup);
            if (!hasIncrementedLibrary)
            {
                IncrementLibraryMembership();
                hasIncrementedLibrary = true;
            }

            if(animationController != null)
{
                animationController.SpawnCardAboveSprite();
            }
else
            {
                Debug.LogWarning("AnimationController is not assigned!");
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
                Debug.LogError("Invalid age group!");
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
        LibraryManager.instance.IncrementLibraryMemberships();
    }
}
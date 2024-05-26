using UnityEngine;

public class Choise : MonoBehaviour
{
    [SerializeField] float randomValue;

    void Start()
    {
        randomValue = Random.value;
    }

    void Update()
    {
        // You can update randomValue here if you want to re-evaluate it continuously.
    }

    public void ChoiseToMake(NpcController.AgeGroupe ageGroup)
    {
        switch (ageGroup)
        {
            case NpcController.AgeGroupe.Teen:
                // Handle choice for Teen age group
                if (randomValue < 0.5f)
                {
                    SignupManager.instance.IncrementTeenSignups();
                }
                else
                {
                    Debug.Log("Teen leaving");
                }
                break;

            case NpcController.AgeGroupe.Adult:
                // Handle choice for Adult age group
                if (randomValue < 0.5f)
                {
                    SignupManager.instance.IncrementAdultSignups();
                }
                else
                {
                    Debug.Log("Adult leaving");
                }
                break;

            case NpcController.AgeGroupe.Elderly:
                // Handle choice for Elderly age group
                if (randomValue < 0.5f)
                {
                    SignupManager.instance.IncrementElderlySignups();
                }
                else
                {
                    Debug.Log("Elderly leaving");
                }
                break;

            default:
                Debug.LogError("Invalid age group!");
                break;
        }
    }
}

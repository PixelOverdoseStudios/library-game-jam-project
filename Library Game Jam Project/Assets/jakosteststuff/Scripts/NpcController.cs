// NpcController.cs
using System.Collections;
using UnityEngine;



public class NpcController : MonoBehaviour
{
    [System.Serializable]
    public enum AgeGroup { Teen, Adult, Elderly, NPC };
    [SerializeField] private AgeGroup ageGroup;
    [SerializeField] private float waitTimeAtEnd = 2.0f;

    private Movement movement;
    private Choice choice;
    private bool isWaiting = false;
    private bool hasReturned = false;

    private void Start()
    {
        movement = GetComponent<Movement>();
        choice = GetComponent<Choice>(); // Assuming Choice is attached to the same GameObject

        if (movement == null)
        {
            Debug.Log("Movement script not found!");
        }

        if (choice == null)
        {
            Debug.Log("Choice script not found!");
        }

        movement.InitializePath();

        // Disable movement for NPC at the start
        if (ageGroup == AgeGroup.NPC)
        {
            movement.enabled = false;
        }
    }

    private void Update()
    {
         // If not NPC, continue with normal behavior
        
            if (!isWaiting && movement.HasWaypoints())
            {
                movement.MoveToNextWaypoint();
                if (movement.ReachedWaypoint())
                {
                    if (movement.IsAtEnd())
                    {
                        StartCoroutine(WaitAtEnd());
                    }
                }
            }
        
        // No need to handle NPC behavior here since movement is disabled
    }

    private IEnumerator WaitAtEnd()
    {
        if (choice != null)
        {
            choice.ChooseToMake(ageGroup);
        }
        else
        {
            Debug.Log("Choice component is not assigned!");
        }
        isWaiting = true;
        yield return new WaitForSeconds(waitTimeAtEnd);
        isWaiting = false;
        movement.ReverseDirection();

        if (!hasReturned && !movement.IsMovingForward())
        {
            hasReturned = true;
            StartCoroutine(DespawnAfterReturn());
        }
    }

    private IEnumerator DespawnAfterReturn()
    {
        while (!movement.IsAtStart())
        {
            yield return null;
        }
        if (SpawnPoint.Instance != null)
        {
            SpawnPoint.Instance.NotifyNpcDespawned();
        }
        
        Destroy(gameObject);
    }
}

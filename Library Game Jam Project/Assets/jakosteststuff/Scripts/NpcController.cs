
using System.Collections;
using UnityEngine;
 

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Choise))]
public class NpcController : MonoBehaviour
{
    [System.Serializable]
    public enum AgeGroupe { Teen, Adult, Elderly };
    [SerializeField] public AgeGroupe ageGrupe;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float waitTimeAtEnd = 2.0f;
    [SerializeField] private Movement movement;
    [SerializeField] private Choise choise;

    private bool isWaiting = false;
    private bool isMovingForward = true;
    private bool hasReturned = false;

    void Start()
    {
        if (movement == null)
        {
            movement = GetComponent<Movement>();
        }

        if (choise == null)
        {
            choise = FindObjectOfType<Choise>();
        }

        if (movement == null)
        {
            Debug.LogError("Movement script not found!");
        }

        if (choise == null)
        {
            Debug.LogError("ChoiseHandler script not found!");
        }

        movement.InitializePath();
    }

    void Update()
    {
        if (!isWaiting && movement.HasWaypoints())
        {
            movement.MoveToNextWaypoint(speed, isMovingForward);
            if (movement.ReachedWaypoint())
            {
                if (movement.IsAtEnd())
                {
                    StartCoroutine(WaitAtEnd());
                }
            }
        }
    }

    IEnumerator WaitAtEnd()
    {
        choise.ChoiseToMake(ageGrupe);
        isWaiting = true;
        yield return new WaitForSeconds(waitTimeAtEnd);
        isWaiting = false;
        isMovingForward = !isMovingForward;

        if (!hasReturned && !isMovingForward)
        {
            hasReturned = true;
            StartCoroutine(DespawnAfterReturn());
        }
    }

    IEnumerator DespawnAfterReturn()
    {
        while (!movement.IsAtStart())
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}

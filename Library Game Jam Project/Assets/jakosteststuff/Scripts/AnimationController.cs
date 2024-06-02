using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Movement movement;
    private Animator animator;

    private void Start()
    {
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();

        if (movement == null || animator == null)
        {
            Debug.LogError("Movement or Animator component not found on " + gameObject.name);
        }
    }

    private void Update()
    {
        if (movement.HasWaypoints() && !movement.IsWaiting())
        {
            Vector2 direction = GetMovementDirection();
            SetDirectionInteger(direction);
        }
        else
        {
            ResetDirectionInteger();
        }
    }

    private Vector2 GetMovementDirection()
    {
        int nextWaypointIndex = movement.IsMovingForward() ? movement.GetCurrentWaypointIndex() + 1 : movement.GetCurrentWaypointIndex() - 1;

        if (nextWaypointIndex >= 0 && nextWaypointIndex < movement.GetWaypoints().Length)
        {
            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = movement.GetWaypoints()[nextWaypointIndex].position;
            return (targetPosition - currentPosition).normalized;
        }

        return Vector2.zero;
    }

    private void SetDirectionInteger(Vector2 direction)
    {
        int directionValue = 0; // 0 for idle

        float absX = Mathf.Abs(direction.x);
        float absY = Mathf.Abs(direction.y);

        if (absX > absY)
        {
            directionValue = (direction.x > 0) ? 1 : 2; // Right: 1, Left: 2
        }
        else if (absY > absX)
        {
            directionValue = (direction.y > 0) ? 3 : 4; // Up: 3, Down: 4
        }
        else
        {
            directionValue = 0; // Idle when both are equal
        }

        switch (directionValue)
        {
            case 1:
                animator.SetInteger("Direction", 1); // Right
                break;
            case 2:
                animator.SetInteger("Direction", 2); // Left
                break;
            case 3:
                animator.SetInteger("Direction", 3); // Up
                break;
            case 4:
                animator.SetInteger("Direction", 4); // Down
                break;
            default:
                animator.SetInteger("Direction", 0); // Idle
                break;
        }
    }

    private void ResetDirectionInteger()
    {
        animator.SetInteger("Direction", 0); // 0 for idle
    }
}

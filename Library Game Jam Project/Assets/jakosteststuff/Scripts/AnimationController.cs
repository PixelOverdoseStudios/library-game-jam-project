using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Movement mover;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<Movement>();
    }

    public void UpdateDirection(Vector2 direction)
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator not found!");
            return;
        }

        if (direction.magnitude == 0)
        {
            Debug.Log("Idle");
            animator.SetInteger("Direction", 0); // Idle
            return;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 180; // Offset angle to match Unity's coordinate system

        int closestDirection = Mathf.RoundToInt(angle / 45f) % 8;
        if (closestDirection < 0)
        {
            closestDirection += 8;
        }

        switch (closestDirection)
        {
            case 0:
            case 1:
            case 7:
                
                animator.SetInteger("Direction", 1); // Right
                break;
            case 2:
            case 3:
                
                animator.SetInteger("Direction", 3); // Up
                break;
            case 4:
                
                animator.SetInteger("Direction", 2); // Left
                break;
            case 5:
            case 6:
                
                animator.SetInteger("Direction", 4); // Down
                break;
        }
    }
}

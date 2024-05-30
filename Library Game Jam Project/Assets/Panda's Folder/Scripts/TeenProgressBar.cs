using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenProgressBar : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetInteger("teenStarLevel", LibraryManager.instance.GetTeenStarLevel());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStarProgressBar : MonoBehaviour
{
    [Header("Which Progress Bar?")]
    [SerializeField] bool teenProgressBar = false;
    [SerializeField] bool adultProgressBar = false;
    [SerializeField] bool elderlyProgressBar = false;

    [Header("Is Calendar?")]
    [SerializeField] bool isCalendar = false;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(teenProgressBar)
            animator.SetInteger("StarLevel", LibraryManager.instance.GetTeenStarLevel());
        else if(adultProgressBar)
            animator.SetInteger("StarLevel", LibraryManager.instance.GetAdultStarLevel());
        else if(elderlyProgressBar)
            animator.SetInteger("StarLevel", LibraryManager.instance.GetElderlyStarLevel());
        else if(isCalendar)
            animator.SetInteger("Day", LibraryManager.instance.GetCurrentDay());
    }
}

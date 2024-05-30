using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollaspableUIFunction : MonoBehaviour
{
    private Animator UIAnimator;
    private bool isOpen = true;

    private void Awake()
    {
        UIAnimator = GetComponent<Animator>();
    }

    public void OpenAndClosePanel()
    {
        if (isOpen)
        {
            UIAnimator.SetTrigger("closePanel");
            isOpen = false;
        }
        else
        {
            UIAnimator.SetTrigger("openPanel");
            isOpen = true;
        }
    }
}

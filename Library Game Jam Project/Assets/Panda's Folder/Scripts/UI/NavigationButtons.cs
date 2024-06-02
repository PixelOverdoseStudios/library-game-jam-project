using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtons : MonoBehaviour
{
    [SerializeField] private GameObject buttonsToEnable;
    [SerializeField] private GameObject buttonsToDisable;

    public void EnableAndDisablingButtons()
    {
        if (buttonsToEnable != null)
            buttonsToEnable.SetActive(true);

        if (buttonsToDisable != null)
            buttonsToDisable.SetActive(false);
    }
}

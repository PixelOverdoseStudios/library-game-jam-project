using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtons : MonoBehaviour
{
    [SerializeField] private GameObject buttonsToEnable;
    [SerializeField] private GameObject buttonsToDisable;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip ripSoundClip;

    public void EnableAndDisablingButtons()
    {
        AudioManager.instance.PlaySoundFXClip(ripSoundClip, transform, 1f);

        if (buttonsToEnable != null)
            buttonsToEnable.SetActive(true);

        if (buttonsToDisable != null)
            buttonsToDisable.SetActive(false);
    }
}

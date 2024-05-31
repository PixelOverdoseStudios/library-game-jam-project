using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI membershipText;

    private void Update()
    {
        membershipText.text = LibraryManager.instance.GetLibraryMemberships().ToString("0000");
    }
}

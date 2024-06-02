using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureButton : MonoBehaviour
{
    [SerializeField] private GameObject[] furniture;

    public void FurnitureOption1() => UpdateFurniture(0);
    public void FurnitureOption2() => UpdateFurniture(1);
    public void FurnitureOption3() => UpdateFurniture(2);

    private void UpdateFurniture(int choice)
    {
        switch(choice)
        {
            case 0:
                DisableAllFurniture();
                furniture[choice].SetActive(true);
                break;
            case 1:
                DisableAllFurniture();
                furniture[choice].SetActive(true);
                break;
            case 2:
                DisableAllFurniture();
                furniture[choice].SetActive(true);
                break;
        }
    }

    private void DisableAllFurniture()
    {
        foreach (GameObject i in furniture)
            i.SetActive(false);
    }
}

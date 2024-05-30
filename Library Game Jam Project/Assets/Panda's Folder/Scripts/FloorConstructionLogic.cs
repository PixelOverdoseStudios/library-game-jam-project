using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorConstructionLogic : MonoBehaviour
{
    [Header("String References")]
    [SerializeField] private string patternName = "Wood Pattern";
    [SerializeField] private string currentColor = "orange";

    [Header("Orange Patters")]
    [SerializeField] private GameObject orangeArrowPattern;
    [SerializeField] private GameObject orangeTrianglePattern;
    [SerializeField] private GameObject orangePuzzlePattern;
    [SerializeField] private GameObject orangePlainTilePattern;
    [SerializeField] private GameObject orangeSquarePattern;
    [SerializeField] private GameObject orangeDiamondPattern;
    [SerializeField] private GameObject orangeWoodPattern;

    [Header("Pink Patters")]
    [SerializeField] private GameObject pinkArrowPattern;
    [SerializeField] private GameObject pinkTrianglePattern;
    [SerializeField] private GameObject pinkPuzzlePattern;
    [SerializeField] private GameObject pinkPlainTilePattern;
    [SerializeField] private GameObject pinkSquarePattern;
    [SerializeField] private GameObject pinkDiamondPattern;
    [SerializeField] private GameObject pinkWoodPattern;

    [Header("Purple Patters")]
    [SerializeField] private GameObject purpleArrowPattern;
    [SerializeField] private GameObject purpleTrianglePattern;
    [SerializeField] private GameObject purplePuzzlePattern;
    [SerializeField] private GameObject purplePlainTilePattern;
    [SerializeField] private GameObject purpleSquarePattern;
    [SerializeField] private GameObject purpleDiamondPattern;
    [SerializeField] private GameObject purpleWoodPattern;

    [Header("Blue Patters")]
    [SerializeField] private GameObject blueArrowPattern;
    [SerializeField] private GameObject blueTrianglePattern;
    [SerializeField] private GameObject bluePuzzlePattern;
    [SerializeField] private GameObject bluePlainTilePattern;
    [SerializeField] private GameObject blueSquarePattern;
    [SerializeField] private GameObject blueDiamondPattern;
    [SerializeField] private GameObject blueWoodPattern;

    [Header("Green Patters")]
    [SerializeField] private GameObject greenArrowPattern;
    [SerializeField] private GameObject greenTrianglePattern;
    [SerializeField] private GameObject greenPuzzlePattern;
    [SerializeField] private GameObject greenPlainTilePattern;
    [SerializeField] private GameObject greenSquarePattern;
    [SerializeField] private GameObject greenDiamondPattern;
    [SerializeField] private GameObject greenWoodPattern;


    public void SetFloorPattern(string floorPatter)
    {
        DeactivateAllChildGameObjects();
        patternName = floorPatter;
        UpdateFloor();
    }

    public void SetFloorColor(string floorColor)
    {
        DeactivateAllChildGameObjects();
        currentColor = floorColor;
        UpdateFloor();
    }

    private void DeactivateAllChildGameObjects()
    {
        orangeArrowPattern.SetActive(false);
        orangeTrianglePattern.SetActive(false);
        orangePuzzlePattern.SetActive(false);
        orangePlainTilePattern.SetActive(false);
        orangeSquarePattern.SetActive(false);
        orangeDiamondPattern.SetActive(false);
        orangeWoodPattern.SetActive(false);

        pinkArrowPattern.SetActive(false);
        pinkTrianglePattern.SetActive(false);
        pinkPuzzlePattern.SetActive(false);
        pinkPlainTilePattern.SetActive(false);
        pinkSquarePattern.SetActive(false);
        pinkDiamondPattern.SetActive(false);
        pinkWoodPattern.SetActive(false);

        purpleArrowPattern.SetActive(false);
        purpleTrianglePattern.SetActive(false);
        purplePuzzlePattern.SetActive(false);
        purplePlainTilePattern.SetActive(false);
        purpleSquarePattern.SetActive(false);
        purpleDiamondPattern.SetActive(false);
        purpleWoodPattern.SetActive(false);

        blueArrowPattern.SetActive(false);
        blueTrianglePattern.SetActive(false);
        bluePuzzlePattern.SetActive(false);
        bluePlainTilePattern.SetActive(false);
        blueSquarePattern.SetActive(false);
        blueDiamondPattern.SetActive(false);
        blueWoodPattern.SetActive(false);

        greenArrowPattern.SetActive(false);
        greenTrianglePattern.SetActive(false);
        greenPuzzlePattern.SetActive(false);
        greenPlainTilePattern.SetActive(false);
        greenSquarePattern.SetActive(false);
        greenDiamondPattern.SetActive(false);
        greenWoodPattern.SetActive(false);
    }

    private void UpdateFloor()
    {
        if (currentColor == "orange")
        {
            if (patternName == "Arrow Pattern")
                orangeArrowPattern.SetActive(true);
            else if (patternName == "Triangle Pattern")
                orangeTrianglePattern.SetActive(true);
            else if (patternName == "Puzzle Pattern")
                orangePuzzlePattern.SetActive(true);
            else if (patternName == "Plain Tile Pattern")
                orangePlainTilePattern.SetActive(true);
            else if (patternName == "Square Pattern")
                orangeSquarePattern.SetActive(true);
            else if (patternName == "Diamond Pattern")
                orangeDiamondPattern.SetActive(true);
            else if (patternName == "Wood Pattern")
                orangeWoodPattern.SetActive(true);
        }
        else if (currentColor == "pink")
        {
            if (patternName == "Arrow Pattern")
                pinkArrowPattern.SetActive(true);
            else if (patternName == "Triangle Pattern")
                pinkTrianglePattern.SetActive(true);
            else if (patternName == "Puzzle Pattern")
                pinkPuzzlePattern.SetActive(true);
            else if (patternName == "Plain Tile Pattern")
                pinkPlainTilePattern.SetActive(true);
            else if (patternName == "Square Pattern")
                pinkSquarePattern.SetActive(true);
            else if (patternName == "Diamond Pattern")
                pinkDiamondPattern.SetActive(true);
            else if (patternName == "Wood Pattern")
                pinkWoodPattern.SetActive(true);
        }
        else if (currentColor == "purple")
        {
            if (patternName == "Arrow Pattern")
                purpleArrowPattern.SetActive(true);
            else if (patternName == "Triangle Pattern")
                purpleTrianglePattern.SetActive(true);
            else if (patternName == "Puzzle Pattern")
                purplePuzzlePattern.SetActive(true);
            else if (patternName == "Plain Tile Pattern")
                purplePlainTilePattern.SetActive(true);
            else if (patternName == "Square Pattern")
                purpleSquarePattern.SetActive(true);
            else if (patternName == "Diamond Pattern")
                purpleDiamondPattern.SetActive(true);
            else if (patternName == "Wood Pattern")
                purpleWoodPattern.SetActive(true);
        }
        else if (currentColor == "blue")
        {
            if (patternName == "Arrow Pattern")
                blueArrowPattern.SetActive(true);
            else if (patternName == "Triangle Pattern")
                blueTrianglePattern.SetActive(true);
            else if (patternName == "Puzzle Pattern")
                bluePuzzlePattern.SetActive(true);
            else if (patternName == "Plain Tile Pattern")
                bluePlainTilePattern.SetActive(true);
            else if (patternName == "Square Pattern")
                blueSquarePattern.SetActive(true);
            else if (patternName == "Diamond Pattern")
                blueDiamondPattern.SetActive(true);
            else if (patternName == "Wood Pattern")
                blueWoodPattern.SetActive(true);
        }
        else if (currentColor == "green")
        {
            if (patternName == "Arrow Pattern")
                greenArrowPattern.SetActive(true);
            else if (patternName == "Triangle Pattern")
                greenTrianglePattern.SetActive(true);
            else if (patternName == "Puzzle Pattern")
                greenPuzzlePattern.SetActive(true);
            else if (patternName == "Plain Tile Pattern")
                greenPlainTilePattern.SetActive(true);
            else if (patternName == "Square Pattern")
                greenSquarePattern.SetActive(true);
            else if (patternName == "Diamond Pattern")
                greenDiamondPattern.SetActive(true);
            else if (patternName == "Wood Pattern")
                greenWoodPattern.SetActive(true);
        }
    }
}

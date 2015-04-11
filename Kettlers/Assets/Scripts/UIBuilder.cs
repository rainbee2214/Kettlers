using UnityEngine;
using System.Collections;

//This class will be used to instantiate and place all the UI:
//Grid space
//Message boxes
//Set up button references
//Set up all other variable references
public class UIBuilder : MonoBehaviour
{
    public const float TOP_GRID_LEVEL = 0.4f;
    public const float MIDDLE_GRID_LEVEL = 0.3f;
    public const float LOWER_GRID_LEVEL = 0.2f;

    public const float WIDTH_INTERVAL = 0.05f;

    public bool buyGridSpace;

    public GameObject grid; //This object will be the parent of the generated grid spaces
    GameObject gridspace;

    float lastWidthPosition;

    public void InstantiateGrid()
    {
        gridspace = Resources.Load("Prefabs/GridSpaceButton", typeof(GameObject)) as GameObject;
        //Build the middle column
        lastWidthPosition = 0.5f;

        GameObject temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = TOP_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = MIDDLE_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = LOWER_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);
    }


    //Add two new columns to the grid: one on the left and one on the right
    void AddColumnsToGrid()
    {
        lastWidthPosition += WIDTH_INTERVAL; //Add right and left column at the updated lastWidthPosition
        float nextWidthPosition = lastWidthPosition;
        //Add top, middle and bottom; Create three gridspaces and add them as children to the grid object
        GameObject temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = TOP_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = MIDDLE_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = LOWER_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        //Get the 'negative' side for width
        lastWidthPosition = 0.5f - (lastWidthPosition - 0.5f);
        temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = TOP_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = MIDDLE_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        temp = Instantiate(gridspace);
        temp.GetComponent<PlaceButton>().widthPercentage = lastWidthPosition;
        temp.GetComponent<PlaceButton>().heightPercentage = LOWER_GRID_LEVEL;
        temp.transform.SetParent(grid.transform);

        lastWidthPosition = nextWidthPosition;
    }


    public void BuyGridSpace()
    {
        buyGridSpace = false;
        Debug.Log("You bought more grid space!");
        AddColumnsToGrid();
    }

    void Start()
    {
        InstantiateGrid();
    }

    void Update()
    {
        if (buyGridSpace) BuyGridSpace();
    }
}

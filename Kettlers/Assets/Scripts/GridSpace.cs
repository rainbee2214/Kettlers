using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MenuButton
{

    public Menu menuType2;
    public GameObject messageBox2;
    public GameObject kettlerFactory;

    public bool Occupied()
    {
        if (gameObject.GetComponentsInChildren<Image>().Length > 1) return true;
        return false;
    }

    public void ChooseMenu()
    {
        //When a space is empty, open the Build a new Building menu
        //Otherwise, determine what type of building the space has and open that menu
        //Open the BuildingOptions menu with the correct parameter
        if (Occupied())
        {
            GameController.controller.CurrentBuildingMenu = GetBuildingType();
            SetMessageBox(messageBox2, menuType2);
            if (GetBuildingType() == "KettlerFactory")
            {
                SetMessageBox(kettlerFactory, Menu.KettlerFactory);
            }
            DisplayMessageBox(false, GameController.controller.CurrentBuildingMenu + " Options");
        }
        else DisplayMessageBox(false);
    }

    public string GetBuildingType()
    {
        Image[] t = gameObject.GetComponentsInChildren<Image>();
        return t[1].gameObject.name;
    }
}


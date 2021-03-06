﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIController : MonoBehaviour
{
    public GameObject[] messageBoxes;
    public Text clockText;
    public Text dayCount;
    public Text potatoCount;
    public Text sunflowerOilCount;
    public Text saltCount;
    public Text onionCount;
    public Text cheeseCount;
    public Text currentChipCount;
    public Text totalChipCount;
    public Text currentMoney;
    public Text name;

    public Text kettlersCost;
    public Text potatoCost;
    public Text sunflowerCost;
    public Text saltCost;
    public Text onionCost;
    public Text cheeseCost;
    public Text errorMessage;
    ErrorMessage em;

    void FixedUpdate()
    {
        if (clockText != null) clockText.text = TimeController.timeController.GetTime();
        if (dayCount != null) dayCount.text = "Day: " + (((int)GameController.controller.DayCount < 10) ? "0" : "") + GameController.controller.DayCount;

        if (potatoCount != null) potatoCount.text = "Potatoes: " + (GameController.controller.CurrentPotatoCount < 10 ? "0" : "") + GameController.controller.CurrentPotatoCount;
        if (sunflowerOilCount != null) sunflowerOilCount.text = "Sunflower Oil: " + (GameController.controller.CurrentSunflowerOilCount < 10 ? "0" : "") + GameController.controller.CurrentSunflowerOilCount;
        if (saltCount != null) saltCount.text = "Salt: " + (GameController.controller.CurrentSaltCount < 10 ? "0" : "") + GameController.controller.CurrentSaltCount;
        if (onionCount != null) onionCount.text = "Onions: " + (GameController.controller.CurrentOnionCount < 10 ? "0" : "") + GameController.controller.CurrentOnionCount;
        if (cheeseCount != null) cheeseCount.text = "Cheese: " + (GameController.controller.CurrentCheeseCount < 10 ? "0" : "") + GameController.controller.CurrentCheeseCount;
        if (currentChipCount != null) currentChipCount.text = "Current Chips: " + (GameController.controller.CurrentChipCount < 10 ? "0" : "") + GameController.controller.CurrentChipCount;
        if (totalChipCount != null) totalChipCount.text = "Total Chips: " + (GameController.controller.TotalChipCount < 10 ? "0" : "") + GameController.controller.TotalChipCount;
        if (currentMoney != null) currentMoney.text = "Money: $" + GameController.controller.CurrentMoney.ToString("#########.00");
        if (name != null) name.text = "Name: " + GameController.controller.CurrentName;

        if (kettlersCost != null) kettlersCost.text = "$" + GameController.controller.kettlerFactoryCost;
        if (potatoCost != null) potatoCost.text = "$" + GameController.controller.potatoFarmCost;
        if (sunflowerCost != null) sunflowerCost.text = "$" + GameController.controller.sunflowerFarmCost;
        if (saltCost != null) saltCost.text = "$" + GameController.controller.saltMineCost;
        if (onionCost != null) onionCost.text = "$" + GameController.controller.onionFarmCost;
        if (cheeseCost != null) cheeseCost.text = "$" + GameController.controller.cheeseFactoryCost;

    }

    public void DisplayError(string message = " ... ", float duration = 2f, bool error = true)
    {
        if (em == null) em = errorMessage.GetComponent<ErrorMessage>();
        em.DisplayMessage(message, duration, error);
    }

    void Buy(string name)
    {
        switch (name)
        {
            case "Kettler": GameController.controller.PurchaseItem(GameController.controller.kettlerFactoryCost, Resource.Type.KettlerFactory); break;
            case "Potato": GameController.controller.PurchaseItem(GameController.controller.potatoFarmCost, Resource.Type.Potato); break;
            case "Sunflower": GameController.controller.PurchaseItem(GameController.controller.sunflowerFarmCost, Resource.Type.SunflowerOil); break;
            case "Salt": GameController.controller.PurchaseItem(GameController.controller.saltMineCost, Resource.Type.Salt); break;
            case "Onion": GameController.controller.PurchaseItem(GameController.controller.onionFarmCost, Resource.Type.Onion); break;
            case "Cheese": GameController.controller.PurchaseItem(GameController.controller.cheeseFactoryCost, Resource.Type.Cheese); break;
        }

    }

    public void BuyKettlerFactory() { Buy("Kettler"); }
    public void BuyPotatoFarm() { Buy("Potato"); }
    public void BuySunflowerFarm() { Buy("Sunflower"); }
    public void BuySaltMine() { Buy("Salt"); }
    public void BuyOnionFarm() { Buy("Onion"); }
    public void BuyCheeseFactory() { Buy("Cheese"); }

    public void ShowMessageBox(string menuType, string title = "", string message = "")
    {
        int index = 0;
        switch (menuType)
        {
            case "BuildNewBuilding": index = 0; break;
            case "BuildingOptions": index = 1; break;
            case "Employees": index = 2; break;
            case "GeneralMarketplace": index = 3; break;
            case "KettlerFactory": index = 4; break;
            case "ManageChips": index = 5; break;
            case "Marketing": index = 6; break;
            case "ProductionSchedule": index = 7; break;
            case "Statistics": index = 8; break;
            case "OverviewResources": index = 9; break;
            case "ViewHistory": index = 10; break;
            case "MarketResearch": index = 11; break;
            case "OverviewFactories": index = 12; break;
            case "GeneralText": index = 13; break;
        }
        if (title != "" && message != "") messageBoxes[index].GetComponent<Messenger>().SetMessage(title, message);
        messageBoxes[index].GetComponent<Messenger>().ToggleMessageBox();
    }

    public bool CloseCurrentMessageBox()
    {
        //Goes through all message boxes, checks if they're active or not
        int count = 0;
        foreach (GameObject messageBox in messageBoxes)
        {
            //The first in the list is the grid, it has multiple buttons to check
            if (count == 0)
            {
                foreach (Transform gridSpace in messageBox.GetComponentsInChildren<Transform>())
                {
                    //Don't check the first in the list
                    if (count != 0)
                    {
                        Messenger m = gridSpace.GetComponent<Messenger>();
                        if (m != null && gridSpace.gameObject.GetComponent<MenuButton>().messageBox.activeSelf)
                        {
                            m.CloseMessageBox();
                            return true;
                        }
                    }
                    count++;
                }
            }
            else //Check the rest of messageBoxes in the list
            {
                Messenger m = messageBox.GetComponent<Messenger>();
                if (m != null && messageBox.GetComponent<MenuButton>().messageBox.activeSelf)
                {
                    m.CloseMessageBox();
                    return true;
                }
            }
        }
        return true;
    }

}

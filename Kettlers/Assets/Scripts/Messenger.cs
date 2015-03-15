using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Messenger : MonoBehaviour
{
    public enum Menu
    {
        BuildNewBuilding,
        ManageChips, 
        GeneralMarketplace,
        Employees, 
        Statistics,
        Marketing,
        ProductionSchedule,
        BuildingOptions,
        KettlerFactory
    }

    public Menu menuType;

    public GameObject messageBox;

    public string currentTitle = "Default messenger app.";
    public string currentMessage = "Please send an actual message.";

    protected bool displayingMessage;

    public void SetMessage(string title, string message)
    {
        currentTitle = title;
        currentMessage = message;
    }

    public void ToggleMessageBox(bool messageOnly = true)
    {
        if (messageBox.activeSelf) CloseMessageBox();
        else DisplayMessageBox(messageOnly, currentTitle, currentMessage);
    }

    protected void DisplayMessageBox(bool messageOnly = true, string title = "", string message = "")
    {
        GameController.controller.CloseMessageBoxes();
        if (messageOnly)
        {
            messageBox.gameObject.SetActive(true);
            GameController.controller.PauseGame();
            messageBox.GetComponentsInChildren<Text>()[0].text = (title == "") ? currentTitle : title;
            messageBox.GetComponentsInChildren<Text>()[1].text = (message == "") ? currentMessage : message;
            displayingMessage = true;
        }
        else
        {
            if (title == "") DisplayOtherBox();
            else DisplayOtherBox(title);
        }
        //Debug.Log(displayingMessage);
    }

    protected void DisplayOtherBox(string title = "")
    {
        if (title != "") currentTitle = title;
        messageBox.gameObject.SetActive(true);
        GameController.controller.PauseGame();
        displayingMessage = true;
    }

    public void CloseMessageBox()
    {
        messageBox.gameObject.SetActive(false);
        GameController.controller.UnPauseGame();
        displayingMessage = false;
    }

}

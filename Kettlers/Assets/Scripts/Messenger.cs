using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Messenger : MonoBehaviour 
{
    public GameObject messageBox;

    public string currentTitle = "Default messenger app.";
    public string currentMessage = "Please send an actual message.";

    protected bool displayingMessage;

    public void SetMessage(string title, string message)
    {
        currentTitle = title;
        currentMessage = message;
    }

    public void ToggleMessageBox()
    {
        if (messageBox.activeSelf) CloseMessageBox();
        else DisplayMessageBox(currentTitle, currentMessage);
    }

    public void DisplayMessageBox(string title = "", string message = "")
    {
        messageBox.gameObject.SetActive(true);
        GameController.controller.PauseGame();
        messageBox.GetComponentsInChildren<Text>()[0].text = (title == "") ? currentTitle : title;
        messageBox.GetComponentsInChildren<Text>()[1].text = (message == "") ? currentMessage : message;
        displayingMessage = true;
    }

    public void CloseMessageBox()
    {
        messageBox.GetComponentsInChildren<Text>()[1].text = "";
        messageBox.gameObject.SetActive(false);
        GameController.controller.UnPauseGame();
        displayingMessage = false;
    }
}

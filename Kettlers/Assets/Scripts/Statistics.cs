using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public GameObject messageBox;
    public Button chartButton;

    public string currentTitle = "Morning Update";
    public string currentMessage = "...";

    bool displayingMessage;

    void Start()
    {
    }

    void Update()
    {
        if (displayingMessage && Input.GetButtonDown("CloseMessageBox")) CloseMessageBox();
    }

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

    public void DisplayMessageBox(string title = "Title", string message = "")
    {
        messageBox.gameObject.SetActive(true);
        GameController.controller.PauseGame();
        messageBox.GetComponentsInChildren<Text>()[0].text = title;
        messageBox.GetComponentsInChildren<Text>()[1].text = message;
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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public GameObject messageBox;
    public Button chartButton;

    bool displayingMessage;

    void Start()
    {
    }

    void Update()
    {
        if (displayingMessage && Input.GetButtonDown("CloseMessageBox")) CloseMessageBox();
    }

    public void ToggleMessageBox()
    {
        if (messageBox.activeSelf) CloseMessageBox();
        else DisplayMessageBox();
    }

    public void DisplayMessageBox()
    {
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

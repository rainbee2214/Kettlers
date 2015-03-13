using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour 
{
    Text errorText;
    bool displayingMessage;
    float turnOffTime;

    void Awake()
    {
        errorText = GetComponent<Text>();
    }
    void Update()
    {
        if (displayingMessage && Time.time > turnOffTime)
        {
            EmptyMessage();
        }
        else if (!displayingMessage) EmptyMessage();
    }

    public void DisplayMessage(string message, float duration, bool error = true)
    {
        errorText.text = ((error)?"Error: " : "") + message;
        displayingMessage = true;
        turnOffTime = Time.time + duration;
    }

    public void EmptyMessage()
    {
        displayingMessage = false;
        errorText.text = "";
    }
}

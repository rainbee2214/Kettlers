using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text text;
    public Text dayCount;
    public Text actionButtonText;

    void Update()
    {
        text.text = TimeController.timeController.GetTime();
    }

    public void SetActionButtonText(string buttonText)
    {
        actionButtonText.text = buttonText;
    }
}

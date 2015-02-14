using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text clockText;
    public Text dayCount;

    void FixedUpdate()
    {
        if (clockText != null) clockText.text = TimeController.timeController.GetTime();
        if (dayCount != null) dayCount.text = "Day: " + (((int)GameController.controller.DayCount < 10) ? "0" : "") + GameController.controller.DayCount;
    }
}

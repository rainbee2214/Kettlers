using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UIController : MonoBehaviour
{
    public Text clockText;
    public Text dayCount;
    public Text potatoCount;
    public Text sunflowerOilCount;
    public Text saltCount;
    public Text onionCount;
    public Text cheeseCount;
    public Text currentChipCount;
    public Text totalChipCount;

    public bool turnOff = false;

    void FixedUpdate()
    {
        if (!turnOff)
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

        }
        else
        {
            if (clockText != null) clockText.text = "";
            if (dayCount != null) dayCount.text = "";

            if (potatoCount != null) potatoCount.text = "";
            if (sunflowerOilCount != null) sunflowerOilCount.text = "";
            if (saltCount != null) saltCount.text = "";
            if (onionCount != null) onionCount.text = "";
            if (cheeseCount != null) cheeseCount.text = "";
            if (currentChipCount != null) currentChipCount.text = "";
            if (totalChipCount != null) totalChipCount.text = "";
        }
    }

    public void TurnOn()
    {
        turnOff = false;
    }

    public void TurnOff()
    {
        turnOff = true;
    }
}

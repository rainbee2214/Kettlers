using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TimeController))]
[RequireComponent(typeof(UIController))]
public class GameController : MonoBehaviour
{
    public static GameController controller;
    public const int width = 5;
    public const int height = 3;

    public float kettlerFactoryCost = 500f,
                    potatoFarmCost = 200f,
                    sunflowerFarmCost = 350f,
                    saltMineCost = 600f,
                    onionFarmCost = 300f,
                    cheeseFactoryCost = 950f;
    UIController uiController;

    #region Properties
    string currentName = "Sarah";
    public string CurrentName
    {
        get { return currentName; }
        set { currentName = value; }
    }

    float currentMoney = 1000.00f;
    public float CurrentMoney
    {
        get { return currentMoney; }
        set { currentMoney += value; }
    }

    int dayCount = 1;
    public int DayCount
    {
        get { return dayCount; }
        set { dayCount += value; }
    }

    int currentPotatoCount = 0;
    public int CurrentPotatoCount
    {
        get { return currentPotatoCount; }
        set { currentPotatoCount += value; }
    }

    int currentSunflowerOilCount = 0;
    public int CurrentSunflowerOilCount
    {
        get { return currentSunflowerOilCount; }
        set { currentSunflowerOilCount += value; }
    }

    int currentSaltCount = 0;
    public int CurrentSaltCount
    {
        get { return currentSaltCount; }
        set { currentSaltCount += value; }
    }

    int currentOnionCount = 0;
    public int CurrentOnionCount
    {
        get { return currentOnionCount; }
        set { currentOnionCount += value; }
    }

    int currentCheeseCount = 0;
    public int CurrentCheeseCount
    {
        get { return currentCheeseCount; }
        set { currentCheeseCount += value; }
    }

    int currentChipCount = 0;
    public int CurrentChipCount
    {
        get { return currentChipCount; }
        set
        {
            currentChipCount += value;
            if (currentChipCount <= 0) currentChipCount = 0;
        }
    }

    int totalChipCount = 0;
    public int TotalChipCount
    {
        get { return totalChipCount; }
        set
        {
            totalChipCount += value;
            if (totalChipCount <= 0) totalChipCount = 0;
        }
    }

    #endregion

    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }

        uiController = GetComponent<UIController>();
    }

    void Update()
    {
        if (TimeController.timeController.IsPaused() && Application.loadedLevelName == "Level")
        {
            TimeController.timeController.UnPause();
            uiController.TurnOn();
        }
        else if (Application.loadedLevelName != "Level")
        {
            TimeController.timeController.Reset();
            uiController.TurnOff();
        }
    }

    public string GetTime()
    {
        return TimeController.timeController.GetTime();
    }

    public void PurchaseItem(float price, string name = "")
    {
        if (price > currentMoney)
        {
            uiController.DisplayError("Can't buy that, you're too poor!", 3f);
            Debug.Log("Can't buy that, you're too poor!");
        }
        else
        {
            currentMoney -= price;
            if (currentMoney < 0) currentMoney = 0;
        }
    }

    public void SellItem(float price, string name = "")
    {
        currentMoney += price;
    }
}

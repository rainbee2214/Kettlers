using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TimeController))]
[RequireComponent(typeof(UIController))]
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(Statistics))]
[RequireComponent(typeof(Marketplace))]
public class GameController : MonoBehaviour
{
    public static GameController controller;

    public float kettlerFactoryCost = 500f,
                    potatoFarmCost = 200f,
                    sunflowerFarmCost = 300f,
                    saltMineCost = 600f,
                    onionFarmCost = 300f,
                    cheeseFactoryCost = 950f;
    UIController uiController;

    GameObject kettlerResource;
    GameObject potatoResource;
    GameObject sunflowerResource;
    GameObject saltResource;
    GameObject onionResource;
    GameObject cheeseResource;

    List<Image> resources;

    [HideInInspector]
    public Canvas mainUI;
    [HideInInspector]
    public Statistics stats;
    [HideInInspector]
    public Marketplace marketplace;

    #region Properties
    float currentChipPrice = 3f;
    public float CurrentChipPrice
    {
        set { currentChipPrice = value; }
        get { return currentChipPrice; }
    }
    GameObject currentPressedGridButton;
    public GameObject CurrentPressedGridButton
    {
        get { return currentPressedGridButton; }
        set { currentPressedGridButton = value; }
    }
    bool endOfLevel = false;
    public bool EndOFLevel
    {
        get { return endOfLevel; }
        set { endOfLevel = value; }
    }
    string currentName = "Sarah";
    public string CurrentName
    {
        get { return currentName; }
        set { currentName = value; }
    }

    float currentMoney = 3000.00f;
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

    void OnLevelWasLoaded(int level)
    {
        //Debug.Log("Level loaded: " + level);
        if (TimeController.timeController.timeSpeed > 1) GameController.controller.SlowDownGame();
        PauseGame();

        if (level == 3)
        {
            stats.DisplayMessageBox(true, ("Good Morning! Day " + dayCount), "...");
            PauseGame();
        }
    }

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

        resources = new List<Image>();
        uiController = GetComponent<UIController>();
        mainUI = GetComponentInChildren<Canvas>();
        stats = GetComponentInChildren<Statistics>();
        marketplace = GetComponentInChildren<Marketplace>();

        kettlerResource = Resources.Load("Prefabs/Buildings/KettlerFactory", typeof(GameObject)) as GameObject;
        potatoResource = Resources.Load("Prefabs/Buildings/PotatoFarm", typeof(GameObject)) as GameObject;
        sunflowerResource = Resources.Load("Prefabs/Buildings/SunflowerFarm", typeof(GameObject)) as GameObject;
        saltResource = Resources.Load("Prefabs/Buildings/SaltMine", typeof(GameObject)) as GameObject;
        onionResource = Resources.Load("Prefabs/Buildings/OnionFarm", typeof(GameObject)) as GameObject;
        cheeseResource = Resources.Load("Prefabs/Buildings/CheeseFactory", typeof(GameObject)) as GameObject;
    }

    void Update()
    {
        ManageGame();
    }

    void ManageGame()
    {
        if (Application.loadedLevelName == "Between")
        {
            TimeController.timeController.Reset();
            mainUI.enabled = false;
        }
    }

    public void IncrementResources()
    {
        foreach (Image resource in resources)
        {
            switch (resource.name)
            {
                default:
                case "KettlerFactory":
                    {
                        break;
                    }
                case "PotatoFarm":
                    {
                        PotatoFarm pf = resource.GetComponent<PotatoFarm>();
                        pf.IncrementResourceCount();
                        break;
                    }
                case "SunflowerFarm":
                    {
                        SunflowerFarm sf = resource.GetComponent<SunflowerFarm>();
                        sf.IncrementResourceCount();
                        break;
                    }
                case "SaltMine":
                    {
                        SaltMine pf = resource.GetComponent<SaltMine>();
                        pf.IncrementResourceCount();
                        break;
                    }
                case "OnionFarm":
                    {
                        OnionFarm pf = resource.GetComponent<OnionFarm>();
                        pf.IncrementResourceCount();
                        break;
                    }
                case "CheeseFactory":
                    {
                        CheeseFactory pf = resource.GetComponent<CheeseFactory>();
                        pf.IncrementResourceCount();
                        break;
                    }
            }

        }
    }

    public string GetTime()
    {
        return TimeController.timeController.GetTime();
    }

    public string GetHour()
    {
        string time = TimeController.timeController.GetTime();
        return time.Substring(0, 2);
    }

    public void DisplayError(string message, float duration, bool error = true)
    {
        uiController.DisplayError(message, duration, error);
    }

    public bool PurchaseItem(float price, Resource.Type resourceType)
    {
        if (price > currentMoney)
        {
            uiController.DisplayError("Can't buy that, you're too poor!", 3f);
            marketplace.CloseMessageBox();
            return false;
        }
        if (currentPressedGridButton.GetComponent<GridSpace>().Occupied())
        {
            uiController.DisplayError("There's no room for that here!", 3f);
            marketplace.CloseMessageBox();
            return false;
        }

        currentMoney -= price;
        resources.Add(MakeResource(resourceType));
        resources[resources.Count - 1].name = GetResourceName(resourceType);
        resources[resources.Count - 1].transform.SetParent(currentPressedGridButton.transform);  
        resources[resources.Count - 1].rectTransform.position = Vector3.zero;
        ResetBuildingPosition.ResetRectTransform(resources[resources.Count - 1].GetComponent<RectTransform>());
        marketplace.CloseMessageBox();

        return true;
    }

    public void SellItem(float price, string name = "")
    {
        currentMoney += price;
    }

    Image MakeResource(Resource.Type resourceType)
    {
        GameObject resource;

        switch (resourceType)
        {
            default:
            case Resource.Type.KettlerFactory: resource = Instantiate(kettlerResource) as GameObject; break;
            case Resource.Type.Potato: resource = Instantiate(potatoResource) as GameObject; break;
            case Resource.Type.SunflowerOil: resource = Instantiate(sunflowerResource) as GameObject; break;
            case Resource.Type.Salt: resource = Instantiate(saltResource) as GameObject; break;
            case Resource.Type.Onion: resource = Instantiate(onionResource) as GameObject; break;
            case Resource.Type.Cheese: resource = Instantiate(cheeseResource) as GameObject; break;
        }
        return resource.GetComponent<Image>();
    }

    string GetResourceName(Resource.Type resourceType)
    {
        switch (resourceType)
        {
            default:
            case Resource.Type.KettlerFactory: return "KettlerFactory";
            case Resource.Type.Potato: return "PotatoFarm";
            case Resource.Type.SunflowerOil: return "SunflowerFarm";
            case Resource.Type.Salt: return "SaltMine";
            case Resource.Type.Onion: return "OnionFarm";
            case Resource.Type.Cheese: return "CheeseFactory";
        }
    }

    public void TurnCanvasOn()
    {
        mainUI.enabled = true;
    }
    public void TurnCanvasOff()
    {
        mainUI.enabled = false;
    }

    public void PauseGame() { TimeController.timeController.Pause(); }
    public void UnPauseGame() { TimeController.timeController.UnPause(); }
    public void TogglePause()
    {
        if (TimeController.timeController.IsPaused()) UnPauseGame();
        else PauseGame();
    }

    public void FastForwardGame() { TimeController.timeController.timeSpeed = TimeController.fastForward; }
    public void SlowDownGame() { TimeController.timeController.timeSpeed = TimeController.slowGame; }
    public void ToggleFastForward()
    {
        if (TimeController.timeController.timeSpeed > 1) SlowDownGame();
        else FastForwardGame();
    }

    public void SellChips(int amount = -1)
    {
        if (amount == -1) // Sell all chips
        {
            amount = currentChipCount;
        }
        for (int i = 0; i < amount; i++)
        {
            SellItem(currentChipPrice);
            currentChipCount--;
        }
    }

}

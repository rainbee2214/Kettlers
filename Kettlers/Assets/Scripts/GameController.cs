using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TimeController))]
[RequireComponent(typeof(UIController))]
public class GameController : MonoBehaviour
{
    public static GameController controller;
    public const int width = 5;
    public const int height = 3;

    public float kettlerFactoryCost = 500f,
                    potatoFarmCost = 200f,
                    sunflowerFarmCost = 300f,
                    saltMineCost = 600f,
                    onionFarmCost = 300f,
                    cheeseFactoryCost = 950f;
    UIController uiController;

    public GameObject kettlerResource;
    public GameObject potatoResource;
    public GameObject sunflowerResource;
    public GameObject saltResource;
    public GameObject onionResource;
    public GameObject cheeseResource;

    List<GameObject> resources;
    
    [HideInInspector]
    public Canvas mainUI;

    #region Properties
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

    bool itemPurchased;

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("Level loaded: " + level);
        PauseGame();
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

        uiController = GetComponent<UIController>();
        resources = new List<GameObject>();
        mainUI = GetComponentInChildren<Canvas>();
    }

    void Update()
    {
        ManageGame();
    }

    void ManageGame()
    {
        //if (TimeController.timeController.IsPaused() && Application.loadedLevelName == "Level2")
        //{
        //    TimeController.timeController.UnPause();
        //    mainUI.enabled = true;
        //}
        //else if (Application.loadedLevelName != "Level" && Application.loadedLevelName != "Level2")
        //{
        //    TimeController.timeController.Reset();
        //    mainUI.enabled = false;
        //}

        if (Application.loadedLevelName == "Between")
        {
            TimeController.timeController.Reset();
            mainUI.enabled = false;
        }
        //if (itemPurchased && Input.GetButtonDown("PlaceItem")) PlaceItem(resources.Count - 1);
    }
    
    public void IncrementResources()
    {
        foreach (GameObject resource in resources)
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
        return time.Substring(0,2);
    }

    public void DisplayError(string message, float duration, bool error = true)
    {
        uiController.DisplayError(message, duration, error);
    }

    public void PurchaseItem(float price, Resource.Type resourceType)
    {
        if (price > currentMoney)
        {
            uiController.DisplayError("Can't buy that, you're too poor!", 3f);
            //Debug.Log("Can't buy that, you're too poor!");
        }
        else
        {
            currentMoney -= price;
            if (currentMoney < 0) currentMoney = 0;
            resources.Add(MakeResource(resourceType));
            //resources[resources.Count - 1].SetActive(false);
            resources[resources.Count - 1].name = GetResourceName(resourceType);
            resources[resources.Count - 1].transform.SetParent(transform.GetChild(0).transform);
            itemPurchased = true;
        }
    }

    void PlaceItem(int index)
    {
        //if the position clicked is active and unoccupied

        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            resources[index].SetActive(true);
        }
    }

    public void SellItem(float price, string name = "")
    {
        currentMoney += price;
    }

    GameObject MakeResource(Resource.Type resourceType)
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
        return resource;
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
        Debug.Log("Turning ui offf..");
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
}

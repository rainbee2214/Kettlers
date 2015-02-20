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
                    sunflowerFarmCost = 350f,
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

    bool itemPurchased;

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
    }

    void Update()
    {
        ManageGame();
    }

    void ManageGame()
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

        if (Input.GetMouseButtonDown(0))
        {
            EventSystem eventSystem = EventSystem.current;
            if (eventSystem.IsPointerOverGameObject())
            {
                Debug.Log("....");
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(ray.origin, ray.direction, Color.red, 10f);
                if (Physics.Raycast(ray, out hit))
                    print(hit.collider.name);
            }
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

    public void PurchaseItem(float price, Resource.Type resourceType)
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
            resources.Add(MakeResource(resourceType));
            resources[resources.Count - 1].SetActive(false);
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
        string rName;

        switch (resourceType)
        {
            default:
            case Resource.Type.KettlerFactory: rName = "KettlerFactory"; break;
            case Resource.Type.Potato: rName = "PotatoFarm"; break;
            case Resource.Type.SunflowerOil: rName = "SunflowerFarm"; break;
            case Resource.Type.Salt: rName = "SaltMine"; break;
            case Resource.Type.Onion: rName = "OnionFarm"; break;
            case Resource.Type.Cheese: rName = "CheeseFactory"; break;
        }
        return rName;
    }
}

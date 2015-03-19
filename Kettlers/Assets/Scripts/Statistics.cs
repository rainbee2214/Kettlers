using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Statistics : Messenger
{
    public enum StatType
    {
        ChipsProducedPerDay,
        MoneyMadePerDay,
        ResourcesProducedPerDay
    }

    public struct ResourcesList
    {
        List<string> potatoCount;
        List<string> sunflowerCount;
        List<string> saltCount;
        List<string> onionCount;
        List<string> cheeseCount;
    }

    #region ChipsProducedPerDay
    public List<string> chipsProducedPerDay;
    public float averageChipsProducesPerDay;
    #endregion

    #region MoneyMadePerDay
    public List<string> moneyMadePerDay;
    public float averageMoneyMadePerDay;
    #endregion

    #region ResourcesProducedPerDay
    public List<ResourcesList> resourcesProducedPerDay;
    public List<float> averageResourcesProducedPerDay;
    #endregion

    void Awake()
    {
        InitializeList(ref chipsProducedPerDay, "Chips Produced Per Day");
        InitializeList(ref moneyMadePerDay, "Money Made Per Day");
    }


    void Start()
    {
           currentTitle = "Morning Update";
           currentMessage = "...";
    }

    void Update()
    {
        if (displayingMessage && Input.GetButtonDown("CloseMessageBox")) CloseMessageBox();
        
    }

    public void RunStats()
    {
        ChipsProducedPerDay();
        MoneyMadePerDay();

        //Debug.Log("Average chips produced per day: " + averageChipsProducesPerDay);
        ///Debug.Log("Average money made per day: " + averageMoneyMadePerDay);
    }

    void ChipsProducedPerDay()
    {
        chipsProducedPerDay.Add(GameController.controller.chipsSoldToday.ToString());
        averageChipsProducesPerDay = GetAverage(chipsProducedPerDay);
    }

    void MoneyMadePerDay()
    {
        moneyMadePerDay.Add(GameController.controller.moneyMadeToday.ToString());
        averageMoneyMadePerDay = GetAverage(moneyMadePerDay);
    }

    void ResourcesProducedPerDay()
    {
        
    }

    float GetAverage(List<string> numbers)
    {
        float total = 0;

        for (int i = 1; i < numbers.Count; i++)
        {
            total += float.Parse(numbers[i], System.Globalization.CultureInfo.InvariantCulture); 
        }
        return total/(numbers.Count - 1);
    }

    void InitializeList(ref List<string> list, string name)
    {
        list = new List<string>();
        list.Add(name);
    }
}

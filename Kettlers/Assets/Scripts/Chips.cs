using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chips
{
    //Chips will have 2-5 ingredients, a string name, a base worth
    public List<Resource.Type> ingredients;
    string brandName;
    public string BrandName
    {
        get { return brandName; }
        set { brandName = value; }
    }

    float basePrice;
    public float BasePrice
    {
        set { basePrice = value; }
        get 
        {
            CalculatePrice();
            return basePrice; 
        }
    }
    //void Start()
    //{

    //}

    //void Update()
    //{
    //    Debug.Log(BasePrice);
    //}

    public List<Resource.Type> GetIngredients()
    {
        return ingredients;
    }

    public void SetIngredients(List<Resource.Type> activeIngredients)
    {
        ingredients = activeIngredients;
    }

    public void CalculatePrice()
    {
        switch (ingredients.Count)
        {
            case 2:
                {
                    basePrice = 3f; 
                    break;
                }
            case 3:
                {
                    basePrice = 3.5f;
                    if (ingredients[2] == Resource.Type.Cheese) basePrice += 0.1f;
                    break;
                }
            case 4:
                {
                    basePrice = 4.5f;
                    if (ingredients[2] == Resource.Type.Cheese && ingredients[3] == Resource.Type.Onion) basePrice += 0.25f;
                    if (ingredients[2] == Resource.Type.Salt && ingredients[3] == Resource.Type.Salt) basePrice += 0.2f;
                    if (ingredients[2] == ingredients[3]) basePrice -= 0.15f;
                    break;
                }
            case 5:
                {
                    basePrice = 6f;
                    if (ingredients[2] == ingredients[3]) basePrice -= 0.2f;
                    if (ingredients[3] == ingredients[4]) basePrice -= 0.2f;
                    if (ingredients[2] == ingredients[4]) basePrice -= 0.2f;
                    if (ingredients[3] == ingredients[4] && ingredients[2] == ingredients[3]) basePrice -= 0.1f;
                    break;
                }
                
        }
    }

    public string PrintOutIngredients()
    {
        string s = "";
        foreach (Resource.Type ingredient in ingredients)
        {
            s += ingredient + "\n";
        }

        return s;
    }
}

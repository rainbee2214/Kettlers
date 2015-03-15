using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chips : MonoBehaviour
{
    //Chips will have 2-5 ingredients, a string name, a base worth
    public List<Resource.Type> ingredients;
    string brandName;
    public string BrandName
    {
        get { return brandName; }
        set { brandName = value; }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public List<Resource.Type> GetIngredients()
    {
        return ingredients;
    }

    public void SetIngredients(List<Resource.Type> activeIngredients)
    {
        ingredients = activeIngredients;
    }


}

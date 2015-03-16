using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChipProduction : MonoBehaviour 
{
    //Make a call to all kettler factories in priority order to make all chips once
    //Need to track a list of kettler factories
    public List<Chips> chips;

    void Awake ()
    {
        chips = new List<Chips>();
    }

    public List<Chips> ViewChips()
    {
        return chips;
    }

    public List<Chips> TakeChips()
    {
        List<Chips> temp = chips;
        chips.Clear();
        return temp;
    }
    
    public void MakeChips(List<Resource.Type> ingredients)
    {
        if (chips == null) chips = new List<Chips>();
        Chips newChips = new Chips();
        newChips.SetIngredients(ingredients);
        chips.Add(newChips);
    }

    void Update()
    {
        
    }
}

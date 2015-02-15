using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour 
{
    public int outputPerHour = 1;
    public float mulitplier = 1f;
    public string name;
    public Type resourceType;
    
    public enum Type
    {
        Potato, 
        SunflowerOil, 
        Salt, 
        Onion, 
        Cheese, 
        KettlerFactory
    }

    public void IncrementResourceCount()
    {
        switch (resourceType)
        {
            case Type.Potato: GameController.controller.CurrentPotatoCount = outputPerHour; break;
            case Type.SunflowerOil: GameController.controller.CurrentSunflowerOilCount = outputPerHour; break;
            case Type.Salt: GameController.controller.CurrentSaltCount = outputPerHour; break;
            case Type.Onion: GameController.controller.CurrentOnionCount = outputPerHour; break;
            case Type.Cheese: GameController.controller.CurrentCheeseCount = outputPerHour; break;
        }
    }
}

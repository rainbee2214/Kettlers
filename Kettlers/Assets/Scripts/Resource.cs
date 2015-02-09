using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour 
{
    public int outputPerDay = 1;
    public float mulitplier = 1f;
    public string name;
    public Type resourceType;
    
    public enum Type
    {
        Potato, 
        SunflowerOil, 
        Salt, 
        Onion, 
        Cheese
    }

}

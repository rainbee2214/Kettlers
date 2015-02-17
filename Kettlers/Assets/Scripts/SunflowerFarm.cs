using UnityEngine;
using System.Collections;

public class SunflowerFarm : Resource
{
    SunflowerFarm()
    {
        currentName = "Sunflower Farm";
        outputPerHour = 3;
        resourceType = Type.SunflowerOil;
    }
}

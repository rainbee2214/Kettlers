using UnityEngine;
using System.Collections;

public class SunflowerFarm : Resource
{
    SunflowerFarm()
    {
        name = "Sunflower Farm";
        outputPerHour = 3;
        resourceType = Type.SunflowerOil;
    }
}

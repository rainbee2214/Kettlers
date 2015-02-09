using UnityEngine;
using System.Collections;

public class SunflowerFarm : Resource
{
    SunflowerFarm()
    {
        name = "Sunflower Farm";
        outputPerDay = 3;
        resourceType = Type.SunflowerOil;
    }
}

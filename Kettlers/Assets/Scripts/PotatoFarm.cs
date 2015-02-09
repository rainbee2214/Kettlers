using UnityEngine;
using System.Collections;

public class PotatoFarm : Resource
{
    PotatoFarm()
    {
        name = "Potato Farm";
        outputPerDay = 3;
        resourceType = Type.Potato;
    }
}

using UnityEngine;
using System.Collections;

public class PotatoFarm : Resource
{
    PotatoFarm()
    {
        currentName = "Potato Farm";
        outputPerHour = 3;
        resourceType = Type.Potato;
    }
}

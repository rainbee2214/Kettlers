using UnityEngine;
using System.Collections;

public class PotatoFarm : Resource
{
    PotatoFarm()
    {
        name = "Potato Farm";
        outputPerHour = 3;
        resourceType = Type.Potato;
    }

    void FixedUpdate()
    {
        
    }

}

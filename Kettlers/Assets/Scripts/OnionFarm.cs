using UnityEngine;
using System.Collections;

public class OnionFarm : Resource
{
    OnionFarm()
    {
        currentName = "Onion Farm";
        outputPerHour = 2;
        resourceType = Type.Onion;
    }
}

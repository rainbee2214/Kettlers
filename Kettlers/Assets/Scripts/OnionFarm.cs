using UnityEngine;
using System.Collections;

public class OnionFarm : Resource
{
    OnionFarm()
    {
        name = "Onion Farm";
        outputPerHour = 2;
        resourceType = Type.Onion;
    }
}

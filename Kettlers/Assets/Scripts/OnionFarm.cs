using UnityEngine;
using System.Collections;

public class OnionFarm : Resource
{
    OnionFarm()
    {
        name = "Onion Farm";
        outputPerDay = 2;
        resourceType = Type.Onion;
    }
}

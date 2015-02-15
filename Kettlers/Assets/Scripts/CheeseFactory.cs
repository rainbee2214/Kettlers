using UnityEngine;
using System.Collections;

public class CheeseFactory : Resource
{
    CheeseFactory()
    {
        name = "Cheese Factory";
        outputPerHour = 1;
        resourceType = Type.Cheese;
    }
}

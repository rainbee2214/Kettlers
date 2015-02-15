using UnityEngine;
using System.Collections;

public class SaltMine : Resource
{
    SaltMine()
    {
        name = "Salt Mine";
        outputPerHour = 3;
        resourceType = Type.Salt;
    }
}

using UnityEngine;
using System.Collections;

public class SaltMine : Resource
{
    SaltMine()
    {
        currentName = "Salt Mine";
        outputPerHour = 3;
        resourceType = Type.Salt;
    }
}

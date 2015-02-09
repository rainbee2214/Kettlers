using UnityEngine;
using System.Collections;

public class SaltMine : Resource
{
    SaltMine()
    {
        name = "Salt Mine";
        outputPerDay = 3;
        resourceType = Type.Salt;
    }
}

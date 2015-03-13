using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public bool Occupied()
    {
        if (GetComponentsInChildren<Object>().Length > 1)
        {
            return true;
        }

        return false;
    }

    void Update()
    {
        if (Occupied()) Debug.Log("Occupied!");
    }
}


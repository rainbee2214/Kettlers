using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public bool Occupied()
    {
        if (GetComponent<GameObject>() != null)
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


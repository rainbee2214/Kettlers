using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public bool Occupied()
    {
        if (gameObject.GetComponentsInChildren<Transform>().Length > 1) return true;
        return false;
    }
}


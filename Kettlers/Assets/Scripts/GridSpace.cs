using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public bool occupied;
    public bool activated;

    public Color activeColor;
    public Color inactiveColor;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }
    public void SetUpSpace()
    {
        activated = true;
        occupied = false;
    }

    public void TakeDownSpace()
    {
        activated = false;
        occupied = false;
    }

    void Update()
    {
        Debug.Log("Gridspace is occupied: " + occupied + " and activated: " + activated);
        if (activated) image.color = activeColor;
        else image.color = inactiveColor;
    }


}


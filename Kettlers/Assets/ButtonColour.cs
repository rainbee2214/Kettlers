using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonColour : MonoBehaviour
{
    public Color pausedColor, unpausedColor;
    Button button;
    
    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (TimeController.timeController.IsPaused())
            button.image.color = pausedColor;
        else button.image.color = unpausedColor;
    }
}

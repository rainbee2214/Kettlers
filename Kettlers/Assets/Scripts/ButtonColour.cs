using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonColour : MonoBehaviour
{
    public Color onColor, offColor;
    Button button;
    public string buttonType = "Pause";

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        ColorButtons();
    }

    void ColorButtons()
    {
        switch(buttonType)
        {
            case"Pause":
                {
                    if (TimeController.timeController.IsPaused()) button.image.color = onColor;
                    else button.image.color = offColor;
                    break;
                }
            case "FastForward":
                {
                    if (TimeController.timeController.timeSpeed > 1) button.image.color = onColor;
                    else button.image.color = offColor;
                    break;
                }
        }
    }
}

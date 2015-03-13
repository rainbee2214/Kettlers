using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Fades in and out at the beginning and end of the day
//Needs a delay at the end of the day to display the last message, and to show the final hour time
[RequireComponent(typeof(Image))]
public class Fader : MonoBehaviour
{
    public float fadeFactor = 0.1f;
    public Color opaque, transparent;
    public float speed = 0.01f;
    public bool fadeIn, fadeOut;
    public bool activated;
    public bool reset;

    float startSpeed;
    Image image;

    void Start()
    {
        startSpeed = speed;
        image = GetComponent<Image>();
        image.color = opaque;
    }

    void Update()
    {
        if (reset) Reset();

        if (GameController.controller.EndOFLevel)
        {
            fadeOut = true;
        }
        if (fadeIn)
        {
            GameController.controller.PauseGame();
            GameController.controller.TurnCanvasOff();
            image.color = Color.Lerp(image.color, transparent, speed * Time.deltaTime);
            speed += fadeFactor;
            if (image.color == transparent)
            {
                speed = startSpeed;
                fadeIn = false;
                GameController.controller.TurnCanvasOn();
            }
        }
        else if (fadeOut)
        {
            image.color = Color.Lerp(image.color, opaque, speed * Time.deltaTime);
            speed += fadeFactor;
            if (image.color == opaque)
            {
                speed = startSpeed;
                fadeOut = false;
                Application.LoadLevel("Between");
                GameController.controller.EndOFLevel = false;
            }
        }
    }

    public void Activate()
    {
        activated = true;
    }

    public void Reset()
    {
        image.color = opaque;
        activated = true;
        reset = false;
        speed = startSpeed;
    }
}

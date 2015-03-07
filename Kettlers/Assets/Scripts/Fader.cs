using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    static int LEVEL_NUMBER = 2;
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
            image.color = Color.Lerp(image.color, transparent, speed * Time.deltaTime);
            speed += 0.01f;
            if (image.color == transparent)
            {
                //Debug.Log("Color target reached!");
                speed = startSpeed;
                fadeIn = false;
            }
        }
        else if (fadeOut)
        {
            image.color = Color.Lerp(image.color, opaque, speed * Time.deltaTime);
            speed += 0.01f;
            if (image.color == opaque)
            {
               Debug.Log("Color target reached!");
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

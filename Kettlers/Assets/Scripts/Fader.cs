using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Color start, target, transparent;
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
        image.color = start;
    }

    void Update()
    {
        if (reset) Reset();
        if (activated)
        {
            if (fadeIn)
            {
                image.color = Color.Lerp(image.color, target, speed*Time.deltaTime);
                speed += 0.01f;
                if (image.color == target)
                {
                    Debug.Log("Color target reached!");
                    activated = false;
                }
            }
            else if (fadeOut)
            {
                image.color = Color.Lerp(image.color, start, speed * Time.deltaTime);
                speed += 0.01f;
                if (image.color == target)
                {
                    Debug.Log("Color target reached!");
                    activated = false;
                }
            }
        }
        else
        {
            image.color = transparent;
        }
        
    }

    public void Activate()
    {
        activated = true;
    }

    public void Reset()
    {
        image.color = start;
        activated = true;
        reset = false;
        speed = startSpeed;
    }

}

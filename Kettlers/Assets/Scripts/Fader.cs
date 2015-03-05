using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Color start, target, transparent;
    public float speed = 0.01f;
    public bool on;
    public bool activated;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = start;
    }

    void Update()
    {
        if (activated)
        {
            if (on)
            {
                image.color = Color.Lerp(image.color, target, speed*Time.deltaTime);
                speed += 0.01f;
                if (image.color == target)
                {
                    Debug.Log("Color target reached!");
                    activated = false;
                }
            }
            else
            {
                image.color = start;
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


}

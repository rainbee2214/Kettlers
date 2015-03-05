using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Color start, target;
    public float speed = 0.01f;
    public bool on;

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = start;
    }
    void Update()
    {
        if (on)
        {
            image.color = Color.Lerp(image.color, target, speed);
        }
        else
        {
            image.color = start;

        }
    }
}

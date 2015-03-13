using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ResetBuildingPosition : MonoBehaviour
{
    public bool reset;

    RectTransform image;

    void Start()
    {
        image = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (reset)
        {
            reset = false;
            ResetRectTransform(image);
        }
    }

    public static void ResetRectTransform(RectTransform rectPosition)
    {
        rectPosition.localPosition = Vector2.zero;
    }
}

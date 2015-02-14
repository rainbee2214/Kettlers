using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PlaceUI : MonoBehaviour
{
    [Range(0f, 1f)]
    public float widthPercentage, heightPercentage;

    float screenWidth;
    float screenHeight;
    float lastWP, lastHP;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (screenHeight != Screen.height || screenWidth != Screen.width
            || widthPercentage != lastWP || heightPercentage != lastHP) PositionUI();
    }

    void PositionUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        lastWP = widthPercentage;
        lastHP = heightPercentage;
        text.rectTransform.position = new Vector3(screenWidth - screenWidth * (1 - widthPercentage), screenHeight - screenHeight * (1 - heightPercentage), 0);
    }
}

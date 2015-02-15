using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Button))]
public class PlaceButton : MonoBehaviour
{
    [Range(0f, 1f)]
    public float widthPercentage = 0.5f, heightPercentage = 0.5f;

    float screenWidth;
    float screenHeight;
    float lastWP, lastHP;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (button != null && (screenHeight != Screen.height || screenWidth != Screen.width
              || widthPercentage != lastWP || heightPercentage != lastHP)) PositionUI();
    }

    void PositionUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        lastWP = widthPercentage;
        lastHP = heightPercentage;
        button.transform.position = new Vector3(screenWidth - screenWidth * (1 - widthPercentage), screenHeight - screenHeight * (1 - heightPercentage), 0);
        ///button.rectTransform.position = new Vector3(screenWidth - screenWidth * (1 - widthPercentage), screenHeight - screenHeight * (1 - heightPercentage), 0);
    }
}


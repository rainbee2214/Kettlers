using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Toggle))]
public class PlaceToggle : MonoBehaviour
{
    [Range(0f, 1f)]
    public float widthPercentage = 0.5f, heightPercentage = 0.5f;

    float screenWidth;
    float screenHeight;
    float lastWP, lastHP;
    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (toggle != null && (screenHeight != Screen.height || screenWidth != Screen.width
              || widthPercentage != lastWP || heightPercentage != lastHP)) PositionUI();
    }

    void PositionUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        lastWP = widthPercentage;
        lastHP = heightPercentage;
        toggle.transform.position = new Vector3(screenWidth - screenWidth * (1 - widthPercentage), screenHeight - screenHeight * (1 - heightPercentage), 0);
        ///button.rectTransform.position = new Vector3(screenWidth - screenWidth * (1 - widthPercentage), screenHeight - screenHeight * (1 - heightPercentage), 0);
    }
}


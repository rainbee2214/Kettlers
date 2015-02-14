using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class SizeUI : MonoBehaviour
{
    [Range(1,30)]
    public float rows, columns;
    float lastRow, lastColumn;

    [Range(0f, 1f)]
    public float widthPercentage = 0.5f, heightPercentage = 0.5f;
    float screenWidth;
    float screenHeight;
    float lastWP, lastHP;

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (image != null &&(screenHeight != Screen.height || screenWidth != Screen.width
            || rows != lastRow || columns != lastColumn || lastWP != widthPercentage || lastHP != heightPercentage)) ResizeUI();
    }

    void ResizeUI()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        lastRow = rows;
        lastColumn = columns;
        image.rectTransform.localScale = new Vector3((screenWidth/rows)/100f, (screenHeight/columns)/100f, 1);
        PositionUI();
    }


    void PositionUI()
    {
        lastWP = widthPercentage;
        lastHP = heightPercentage;
        image.rectTransform.position = new Vector3(screenWidth - screenWidth * (1 - widthPercentage), screenHeight - screenHeight * (1 - heightPercentage), 0);
    }
}

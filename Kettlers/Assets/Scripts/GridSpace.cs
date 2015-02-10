using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridSpace : MonoBehaviour
{
    public static GridSpace gridSpace;

    public int width = GameController.width, height = GameController.height;
    public List<Space> gridSpaces;
    public Vector2 test;
    List<GameObject> gridSpacePrefabs;
    int lastWidth, lastHeight, lastIndex;

    Vector2 initialOffset;

    void Awake()
    {
        initialOffset = transform.position;
        BuildGrid();
    }

    void Update()
    {
        if (lastWidth < width || lastHeight < height)
        {
            if (lastWidth != width) Debug.Log(lastWidth + " : Width: " + width);
            if (lastHeight != height) Debug.Log(lastHeight + " : Height: " + height);
            BuildGrid();
        }
    }
    void BuildGrid()
    {
        if (gridSpaces == null)
        {
            gridSpaces = new List<Space>();
            int count = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //Vector2 coordinate = new Vector2(x + initialOffset.x, y + initialOffset.y);
                    //gridSpaces.Add(new Space(coordinate, false));
                    gridSpaces.Add(new Space(new Vector2(x, y) + initialOffset, false));
                    Debug.Log(gridSpaces[count].index  + " " + initialOffset);
                    count++;
                }
            }
            lastWidth = width;
            lastHeight = height;
            lastIndex = gridSpaces.Count - 1;
        }
        
    }

    int FindSpace(Vector2 coordinate)
    {
        for (int i = 0; i < gridSpaces.Count; i++)
        {
            if ((int)coordinate.x == (int)gridSpaces[i].index.x && (int)coordinate.y == (int)gridSpaces[i].index.y) return i;
        }
        return -1;
    }



}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridSpace : MonoBehaviour
{
    public static GridSpace gridSpace;
    public GameObject gridSpacePrefab;

    int width = GameController.width, height = GameController.height;
    public List<Space> gridSpaces;

    List<GameObject> gridSpacePrefabs;
    int lastWidth, lastHeight, lastIndex;

    void Awake()
    {
        BuildGrid();
    }

    void Update()
    {
        if (lastWidth != width || lastHeight != height)
        {
            BuildGrid();
            Debug.Log("Rebuilding grid.");
        }
    }
    void BuildGrid()
    {
        if (gridSpaces == null)
        {
            gridSpaces = new List<Space>();
            gridSpacePrefabs = new List<GameObject>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    gridSpaces.Add(new Space(new Vector2(x, y), false));
                }
            }
            foreach (Space s in gridSpaces)
            {
                //Debug.Log(s.ToString());
                gridSpacePrefabs.Add(Instantiate(gridSpacePrefab, s.index, Quaternion.identity) as GameObject);
            }
            foreach (GameObject space in gridSpacePrefabs)
            {
                space.transform.parent = transform;
            }

            lastWidth = width;
            lastHeight = height;
            lastIndex = gridSpaces.Count - 1;
        }
    }



}

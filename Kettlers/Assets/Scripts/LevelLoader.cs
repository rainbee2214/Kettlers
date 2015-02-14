using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public string level = "Test";
    public float delay = 1f;

    void Start()
    {
        delay += Time.time;
    }

    void Update()
    {
        if (Time.time > delay) Application.LoadLevel(level);
    }
    public void LoadLevel(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}

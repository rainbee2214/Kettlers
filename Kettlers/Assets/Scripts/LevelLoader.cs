using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public string level = "Menu";
    public float delay = 1f;

    public bool clickToLoad = false;

    void Start()
    {
        delay += Time.time;
    }

    void Update()
    {
        if (clickToLoad && Input.GetButtonDown("Play")) LoadLevel(level);
        if (!clickToLoad && Time.time > delay) LoadLevel(level);
    }

    public void LoadLevel(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}

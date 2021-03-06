﻿using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour
{
    public Material[] skyTimes;
    public int currentSky;
    public float speed = 1f;

    Skybox skybox;
    int lastSky;

    void Start()
    {
        skybox = Camera.main.GetComponent<Skybox>();
    }

    void Update()
    {
        if (GameController.controller.EndOFLevel) skybox.material = skyTimes[lastSky];
        else SetSky();
    }

    void SetSky()
    {
        int hour = int.Parse(GameController.controller.GetHour());
        if (hour >= 6 && hour <= 11)
        {
            currentSky = 0;
        }
        else if (hour >= 12 && hour <= 17)
        {
            currentSky = 1;
        }
        else if (hour >= 18 && hour <= 23)
        {
            currentSky = 3;
        }
        else if (hour >= 24 && hour <= 5)
        {
            currentSky = 4;
        }
        lastSky = currentSky;
        skybox.material = skyTimes[currentSky];
    }
}

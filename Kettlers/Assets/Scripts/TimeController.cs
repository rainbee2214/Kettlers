using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour
{
    public static TimeController timeController;

    [Range(1, 100)]
    public int timeSpeed = 1;
    //Timescale of 0 is 'game time' and timescale of 1 is basically real time
    [Range(0, 1)]
    public float timeScale = 1f;
    public int startingHour = 8;
    public bool tick;
    public bool reset;

    float nextTickTime;
    int currentSeconds, currentMinutes, currentHours;
    int dayCount;

    void Awake()
    {
        if (timeController == null)
        {
            timeController = this;
        }
        else if (timeController != this)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (tick && Time.time > nextTickTime)
        {
            Tick();
        }
        if (reset) Reset();
    }

    public void Reset()
    {
        reset = false;
        currentHours = 0;
        currentMinutes = 0;
        currentSeconds = 0;
        tick = false;
    }

    public void Tick()
    {
        for (int i = 0; i < timeSpeed; i++)
        {
            currentSeconds++;
            if (currentSeconds >= 60) TickMinutes();
        }
        nextTickTime = Time.time + timeScale;
    }

    void TickMinutes()
    {
        currentSeconds = 0;
        currentMinutes++;
        if (currentMinutes >= 60) TickHours();
    }

    void TickHours()
    {
        GameController.controller.IncrementResources();
        currentMinutes = 0;
        currentHours++;
        if (currentHours >= 8)
        {
            Pause();
            Reset();
            GameController.controller.TurnCanvasOff();
            GameController.controller.EndOFLevel = true;
            GameController.controller.DayCount = 1;
        }
    }

    public override string ToString()
    {
        string time = ((currentHours + startingHour) < 10 ? "0" : "") + (currentHours + startingHour) + ":" +
        (currentMinutes < 10 ? "0" : "") + currentMinutes;
        return time;
    }

    public string GetTime()
    {
        return ToString();
    }

    public void UnPause()
    {
        tick = true;
    }

    public void Pause()
    {
        tick = false;
    }

    public bool IsPaused()
    {
        return !tick;
    }
}

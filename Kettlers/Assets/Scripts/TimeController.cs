using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour
{
    public static TimeController timeController;

    public float timeScale = 1f;
    public int startingHour = 8;
    public bool tick;
    public bool reset;

    float nextTickTime;
    int currentSeconds, currentMinutes, currentHours;
    int dayCount;

    void Awake()
    {
        timeController = this;
    }
    void FixedUpdate()
    {
        if (tick && Time.time > nextTickTime) Tick();
        if (reset) Reset();
    }

    void Reset()
    {
        reset = false;
        currentHours = 0;
        currentMinutes = 0;
        currentSeconds = 0;
    }

    public void Tick()
    {
        currentSeconds++;
        if (currentSeconds >= 60) TickMinutes();
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
        currentMinutes = 0;
        currentHours++;
        if (currentHours >= 12) currentHours = startingHour;
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
}

using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour
{
    public float timeScale = 1f;
    public int startingHour = 8;
    public bool tick;

    float nextTickTime;
    int currentSeconds, currentMinutes, currentHours;
    int dayCount;

    void Update()
    {
        if (tick && Time.time > nextTickTime) Tick();
    }

    public void Tick()
    {
        Debug.Log(ToString());
        //tick = false;
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
        string time = ((currentHours+startingHour) < 10 ? "0" : "") + (currentHours + startingHour) + ":" +
        (currentMinutes < 10 ? "0" : "") + currentMinutes + ":" +
        (currentSeconds < 10 ? "0" : "") + currentSeconds;
        return time;
    }
}

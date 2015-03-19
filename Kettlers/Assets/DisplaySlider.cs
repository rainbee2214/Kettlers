using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplaySlider : MonoBehaviour
{
    Slider slider;

    public int experience;

    public int Level
    {
        get { return experience / 3; }
    }
    public bool loseHealth;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void FixedUpdate() {
        slider.value = Mathf.MoveTowards(slider.value, slider.maxValue, Time.deltaTime);
	
        if (loseHealth)
        {
            loseHealth = false;
            LoseHealth();
        }
    }

    public void LoseHealth()
    {
        slider.value--;
    }
}

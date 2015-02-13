using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text = TimeController.timeController.GetTime();
    }
}

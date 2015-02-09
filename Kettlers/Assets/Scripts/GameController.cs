using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    public const int width = 5;
    public const int height = 3;

    #region Properties
    int currentPotatoCount = 0;
    public int CurrentPotatoCount
    {
        get { return currentPotatoCount;}
        set { currentPotatoCount += value;}
    }

    int currentSunflowerOilCount = 0;
    public int CurrentSunflowerOilCount
    {
        get { return currentSunflowerOilCount; }
        set { currentSunflowerOilCount += value; }
    }

    int currentSaltCount = 0;
    public int CurrentSaltCount
    {
        get { return currentSaltCount; }
        set { currentSaltCount += value; }
    }

    int currentOnionCount = 0;
    public int CurrentOnionCount
    {
        get { return currentOnionCount; }
        set { currentOnionCount += value; }
    }

    int currentCheeseCount = 0;
    public int CurrentCheeseCount
    {
        get { return currentCheeseCount; }
        set { currentCheeseCount += value; }
    }

    int currentChipCount = 0;
    public int CurrentChipCount
    {
        get { return currentChipCount; }
        set { currentChipCount += value; }
    }  
    #endregion
}

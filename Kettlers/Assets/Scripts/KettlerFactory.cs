using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KettlerFactory : MonoBehaviour
{
    public Factory factoryType = Factory.TwoInputs;

    public bool setInputs;
    public List<string> inputs;

    Vector2 position;

    public KettlerFactory(Factory factoryType = Factory.TwoInputs)
    {
        this.factoryType = factoryType;
    }

    public enum Factory
    {
        AnyInputs = 1,
        TwoInputs = 2,
        ThreeInputs = 3,
        FourInputs = 4,
        FiveInputs = 5
    }

    void Start()
    {
    }

    void Update()
    {
        if (setInputs) SetInputs();
    }

    void SetInputs(string input1 = "Potato", string input2 = "SunflowerOil", string input3 = "", string input4 = "", string input5 = "")
    {
        setInputs = false;
        inputs = new List<string>(); 
        switch (factoryType)
        {
            case Factory.TwoInputs:
                {
                    inputs.Add(input1);
                    inputs.Add(input2);
                    break;
                }
            case Factory.ThreeInputs:
                {
                    inputs.Add(input1);
                    inputs.Add(input2);
                    inputs.Add(input3);
                    break;
                }
            case Factory.FourInputs:
                {
                    inputs.Add(input1);
                    inputs.Add(input2);
                    inputs.Add(input3);
                    inputs.Add(input4);
                    break;
                }
            case Factory.FiveInputs:
                {
                    inputs.Add(input1);
                    inputs.Add(input2);
                    inputs.Add(input3);
                    inputs.Add(input4);
                    inputs.Add(input5);
                    break;
                }
            case Factory.AnyInputs:
                {
                    inputs.Add(input1);
                    inputs.Add(input2);
                    if (input3 != "") inputs.Add(input3);
                    if (input4 != "") inputs.Add(input4);
                    if (input5 != "") inputs.Add(input5);
                    break;
                }
            default: break;
        }
    }

    public void SetFactoryType(Factory factoryType)
    {
        this.factoryType = factoryType;
    }

    public static Factory GetFactoryType(int numberOfInputs)
    {
        switch (numberOfInputs)
        {
            case 1: return Factory.AnyInputs;
            case 2: return Factory.TwoInputs;
            case 3: return Factory.ThreeInputs;
            case 4: return Factory.FourInputs;
            case 5: return Factory.FiveInputs;
            default: return Factory.TwoInputs;
        }
    }



}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KettlerFactory : MonoBehaviour
{
    public Factory factoryType = Factory.TwoInputs;

    public bool setInputs;
    public List<string> inputs;

    public bool autoMake = false;
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
        if (autoMake && CanMakeChips()) MakeChips();
    }

    public void MakeChips()
    {
        switch (factoryType)
        {
            case Factory.AnyInputs: break;
            case Factory.TwoInputs: MakeChips(Resource.Type.Potato, Resource.Type.SunflowerOil); break;
            case Factory.ThreeInputs: break;
            case Factory.FourInputs: break;
            case Factory.FiveInputs: break;
        }
    }

    void MakeChips(Resource.Type input1, Resource.Type input2, Resource.Type input3 = Resource.Type.Empty,
                    Resource.Type input4 = Resource.Type.Empty, Resource.Type input5 = Resource.Type.Empty)
    {
        List<Resource.Type> inputs = new List<Resource.Type>();
        inputs.Add(input1);
        inputs.Add(input2);
        inputs.Add(input3);
        inputs.Add(input4);
        inputs.Add(input5);

        if (CanMakeChips(inputs))
        {
            Debug.Log("Make chips.");
            GameController.controller.DisplayError("Chips++", 3f, false);
            GameController.controller.CurrentChipCount = 1;
            TakeResources(inputs);
        }
        else GameController.controller.DisplayError("You can't afford chips!", 3f, false);
    }

    void TakeResources(List<Resource.Type> inputs)
    {
        foreach (Resource.Type input in inputs)
        {
            switch (input)
            {
                case Resource.Type.Potato:
                    {
                        GameController.controller.CurrentPotatoCount = -1; ;
                        break;
                    }
                case Resource.Type.SunflowerOil:
                    {
                        GameController.controller.CurrentSunflowerOilCount = -1;
                        break;
                    }
                case Resource.Type.Salt:
                    {
                        GameController.controller.CurrentSaltCount = -1;
                        break;
                    }
                case Resource.Type.Onion:
                    {
                        GameController.controller.CurrentOnionCount = -1;
                        break;
                    }
                case Resource.Type.Cheese:
                    {
                        GameController.controller.CurrentCheeseCount = -1;
                        break;
                    }
                case Resource.Type.Empty: break;
            }
        }
    }
    bool CanMakeChips(List<Resource.Type> inputs)
    {
        foreach (Resource.Type input in inputs)
        {
            switch (input)
            {
                case Resource.Type.Potato:
                    {
                        if (GameController.controller.CurrentPotatoCount < 1) return false;
                        break;
                    }
                case Resource.Type.SunflowerOil:
                    {
                        if (GameController.controller.CurrentSunflowerOilCount < 1) return false;
                        break;
                    }
                case Resource.Type.Salt:
                    {
                        if (GameController.controller.CurrentSaltCount < 1) return false;
                        break;
                    }
                case Resource.Type.Onion:
                    {
                        if (GameController.controller.CurrentOnionCount < 1) return false;
                        break;
                    }
                case Resource.Type.Cheese:
                    {
                        if (GameController.controller.CurrentCheeseCount < 1) return false;
                        break;
                    }
                case Resource.Type.Empty: break;
            }
        }
        return true;
    }

    bool CanMakeChips()
    {
        if (GameController.controller.CurrentPotatoCount < 1) return false;
        if (GameController.controller.CurrentSunflowerOilCount < 1) return false;
        //if (GameController.controller.CurrentSaltCount < 1) return false;
        //if (GameController.controller.CurrentOnionCount < 1) return false;
        //if (GameController.controller.CurrentCheeseCount < 1) return false;
        //I need to write logic here
        return true;
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

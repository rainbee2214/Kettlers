using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KettlerFactory : MonoBehaviour
{
    public int priority = 1;

    public Factory factoryType = Factory.TwoInputs;

    public List<Resource.Type> inputResources;

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
    }

    public void MakeChips()
    {
        switch (factoryType)
        {
            case Factory.AnyInputs: break;
            case Factory.TwoInputs: MakeChips(Resource.Type.Potato, Resource.Type.SunflowerOil); break;
            case Factory.ThreeInputs: MakeChips(inputResources[0], inputResources[1], inputResources[2]); break;
            case Factory.FourInputs: MakeChips(inputResources[0], inputResources[1], inputResources[2], inputResources[3]); break;
            case Factory.FiveInputs: MakeChips(inputResources[0], inputResources[1], inputResources[2], inputResources[3], inputResources[4]); break;
        }
    }

    void MakeChips(Resource.Type input1, Resource.Type input2, Resource.Type input3 = Resource.Type.Empty,
                    Resource.Type input4 = Resource.Type.Empty, Resource.Type input5 = Resource.Type.Empty)
    {
        List<Resource.Type> inputs = new List<Resource.Type>();
        inputs.Add(input1);
        inputs.Add(input2);
        if (input3 != Resource.Type.Empty) inputs.Add(input3);
        if (input4 != Resource.Type.Empty) inputs.Add(input4);
        if (input5 != Resource.Type.Empty) inputs.Add(input5);

        if (CanMakeChips(inputs))
        {
            GameController.controller.DisplayError("Chips++", 3f, false);
            GameController.controller.TotalChipCount = 1;
            GameController.controller.chipProduction.MakeChips(inputs);
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

    public bool ManageInputs(List<bool> inputsOnOff)
    {
        int maxInputs = 2;

        switch (factoryType)
        {
            case Factory.TwoInputs: maxInputs = 2; break;
            case Factory.ThreeInputs: maxInputs = 3; break;
            case Factory.FourInputs: maxInputs = 4; break;
            case Factory.AnyInputs: 
            case Factory.FiveInputs: maxInputs = 5; break;
        }

        int count = 0;
        foreach (bool b in inputsOnOff)
        {
            if (b) count++;
        }

        if (count > maxInputs) return false; //Can't check the box
        else return true; //Can check the box
    }
}

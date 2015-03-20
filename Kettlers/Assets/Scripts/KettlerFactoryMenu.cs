using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[ExecuteInEditMode]
public class KettlerFactoryMenu : MonoBehaviour
{
    public List<Toggle> resourceToggles;
    public ToggleGroup resourceGroup1;

    void Start()
    {
        //Assumes that only 3 inputs are possible
        foreach (Toggle t in resourceToggles) t.group = resourceGroup1;

    }

    void Update()
    {
    }

    public void UpdateKettlerInputs()
    {
        List<Resource.Type> inputs = new List<Resource.Type>();
        inputs.Add(Resource.Type.Potato);
        inputs.Add(Resource.Type.SunflowerOil);

        if (resourceToggles[0].isOn) inputs.Add(Resource.Type.Salt);
        else if (resourceToggles[1].isOn) inputs.Add(Resource.Type.Onion);
        else if (resourceToggles[2].isOn) inputs.Add(Resource.Type.Cheese);


        GameController.controller.CurrentPressedGridButton.GetComponentInChildren<KettlerFactory>().SetInputs(inputs);

    }
}

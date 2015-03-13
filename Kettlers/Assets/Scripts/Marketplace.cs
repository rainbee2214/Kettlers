using UnityEngine;
using System.Collections;

public class Marketplace : Messenger
{

    void Start()
    {

    }

    void Update()
    {
        if (displayingMessage && Input.GetButtonDown("CloseMessageBox")) CloseMessageBox();
    }
}

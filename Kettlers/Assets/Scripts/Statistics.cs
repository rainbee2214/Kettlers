﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statistics : Messenger
{

    void Start()
    {
           currentTitle = "Morning Update";
           currentMessage = "...";
    }

    void Update()
    {
        if (displayingMessage && Input.GetButtonDown("CloseMessageBox")) CloseMessageBox();
    }
}

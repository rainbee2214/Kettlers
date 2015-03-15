using UnityEngine;
using System.Collections;

public class MenuButton : Messenger
{
    void Update()
    {
        if (displayingMessage && Input.GetButtonDown("CloseMessageBox")) CloseMessageBox();
    }
}

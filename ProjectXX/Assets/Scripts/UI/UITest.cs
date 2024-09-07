using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : UIBase
{
    public void Close()
    {
        UIManager.Instance.CloseUI("Test");
    }
}

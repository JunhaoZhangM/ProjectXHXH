using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;
using System;

public class UIActionBarElement : UIBase
{
    public Image Icon;
    public Text Name;
    public Text curActionTime;

    public void SetElementInfo(CharBase creature)
    {
        //Icon.overrideSprite = ResourceManager.Instance.Load<Sprite>(creature.define.IconResource);
        Name.text = creature.name;
        curActionTime.enabled = false;
        curActionTime.text =((int)creature.attributes.CurActionTime).ToString();
    }

    internal void ShowActionInfo(bool v)
    {
        curActionTime.enabled=v;
    }
}

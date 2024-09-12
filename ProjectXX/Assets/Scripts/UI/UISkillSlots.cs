using Entities;
using Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillSlots : MonoBehaviour
{
    public List<UISkillSlot> slots = new List<UISkillSlot>();

    public void Awake()
    {
        EventManager.Instance.Subscribe<CharBase>("OnPlayerChange", Refresh);
    }

    private void Refresh(object arg1, CharBase player)
    {
        int idx = 0;
        foreach(var skill in player.SkillMgr.skills)
        {
            if (idx == 2) break;
            slots[idx].SetSkillInfo(skill);
            idx++;
        }
    }

    public void OnDestroy()
    {
        EventManager.Instance.UnSubscribe<CharBase>("OnPlayerChange", Refresh);
    }
}

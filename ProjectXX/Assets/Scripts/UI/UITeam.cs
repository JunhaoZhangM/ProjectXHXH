using Battle;
using Entities;
using Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeam : MonoBehaviour
{
    public GameObject Prefab;
    public Transform parent;

    private UITeamElement _selectedElement;
    public UITeamElement selectedElement
    {
        get
        {
            return _selectedElement;
        }
        set
        {
            if(_selectedElement!=null&&value!= _selectedElement)
            {
                _selectedElement.Mark.SetActive(false);
            }
            _selectedElement = value;
            _selectedElement.Mark.SetActive(true);
        }
    }


    public Dictionary<int,UITeamElement> _elements = new Dictionary<int, UITeamElement>();

    void Awake()
    {
        EventManager.Instance.Subscribe<object>("OnBattleBegin", OnBattleBegin);
        EventManager.Instance.Subscribe<CharBase>("OnPlayerChange", OnPlayerChange);
    }

    private void OnPlayerChange(object arg1, CharBase creature)
    {
        selectedElement = _elements[creature.define.ID];
    }

    private void OnBattleBegin(object arg1, object arg2)
    {
        foreach(var creature in BattleManager.Instance.Team)
        {
            GameObject go = Instantiate(Prefab, parent);
            UITeamElement ui = go.GetComponent<UITeamElement>();
            ui.SetCharacterInfo(creature);
            _elements.Add(creature.define.ID, ui);
        }
    }
}

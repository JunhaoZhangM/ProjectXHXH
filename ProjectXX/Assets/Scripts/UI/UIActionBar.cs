using Entities;
using Event;
using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIActionBar : UIBase,IPointerEnterHandler, IPointerExitHandler
{
    public List<UIActionBarElement> _elements = new List<UIActionBarElement>();

    public GameObject prefab;

    public Transform parent;

    private void Awake()
    {
        EventManager.Instance.Subscribe<List<CharBase>>(EventString.RoundInit, OnInit);
        EventManager.Instance.Subscribe<List<CharBase>>(EventString.ActionTimeUpdate, OnActionTimeUpdate);
    }

    private void OnDisable()
    {
        EventManager.Instance.UnSubscribe<List<CharBase>>(EventString.RoundInit, OnInit);
        EventManager.Instance.UnSubscribe<List<CharBase>>(EventString.ActionTimeUpdate, OnActionTimeUpdate);
    }

    public void OnInit(object arg1,List<CharBase> creatures)
    {
        for (int i = 0; i < creatures.Count; i++)
        {
            GameObject go = Instantiate(prefab, parent);
            UIActionBarElement ui = go.GetComponent<UIActionBarElement>();
            _elements.Add(ui);
            ui.SetElementInfo(creatures[i]);
        }
    }

    private void OnActionTimeUpdate(object arg1, List<CharBase> creatures)
    {
        for(int i = 0; i < creatures.Count; i++)
        {            
            _elements[i].SetElementInfo(creatures[i]);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < _elements.Count; i++)
        {
            _elements[i].ShowActionInfo(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < _elements.Count; i++)
        {
            _elements[i].ShowActionInfo(false);
        }
    }
}

using Entities;
using Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArrow : MonoBehaviour
{
    public void Awake()
    {
        EventManager.Instance.Subscribe<CharBase>(EventString.OnPlayerChange, OnChange);
    }

    private void OnChange(object arg1, CharBase cur)
    {
        Debug.Log(cur.position);
        transform.position = cur.position + new Vector3(0, 2, 0);
    }
}

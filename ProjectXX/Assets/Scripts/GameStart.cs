using Data;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{


    void Start()
    {
        DataManager.Instance.Load();

        for(int i = 1; i <= DataManager.Instance.Example.Count; i++)
        {
            Debug.LogFormat("ExampleInfo : ID:{0} Name:{1} Description:{2} ", DataManager.Instance.Example[i].ID, DataManager.Instance.Example[i].Name, DataManager.Instance.Example[i].Description);
        }

        ResourceManager.Instance.Init();
        UIManager.Instance.SetUIGroup(5);
        PoolManager.Instance.CreateGameObjectPool("UI", 10);
    }

    public void Test()
    {
        UIManager.Instance.OpenUI("Test", 1);
    }

    void Update()
    {
        
    }
}

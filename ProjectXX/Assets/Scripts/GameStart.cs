using Battle;
using Data;
using Entities;
using Event;
using GameObjectController;
using Managers;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public List<int> CharacterID = new List<int>();

    void Start()
    {
        DataManager.Instance.Load();
        EventManager.Instance.Init();
        User.Instance.Init();

        ResourceManager.Instance.Init();
        UIManager.Instance.SetUIGroup(5);
        PoolManager.Instance.CreateGameObjectPool("UI", 10);
        RoundManager.Instance.Init();
        BattleManager.Instance.Init();

    }

    public void TestBattle()
    {
        UIManager.Instance.OpenUI("UIBattle", 2);

        BattleManager.Instance.JoinBattle();
        Debug.Log("---------------------------");
        for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
        {
            CharBase creature = RoundManager.Instance.creatures[i];
            Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
            creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
        }
    }


    public void TestBuff()
    {
        BattleManager.Instance.CurPlayer.AddBuff(1, null);
        BattleManager.Instance.CurPlayer.BuffMgr.DebugAllBuff();
    }

    void Update()
    {

    }

}

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

        ResourceManager.Instance.Init();
        UIManager.Instance.SetUIGroup(5);
        PoolManager.Instance.CreateGameObjectPool("UI", 10);


    }

    public void TestBattle()
    {
        UIManager.Instance.OpenUI("UIBattle", 2);
        BattleManager.Instance.Init(CharacterID);
        RoundManager.Instance.Init();
        Debug.Log("---------------------------");
        for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
        {
            CharBase creature = RoundManager.Instance.creatures[i];
            Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
            creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
        }
    }

    public void Test()
    {

    }
    public void SpeedUp()
    {
        BuffDefine define = new BuffDefine();
        define.BuffType = BuffType.Attributes;
        define.ActionTimeRatio = 50;
        Buff buff = new Buff(define);
        buff.DoBuff(RoundManager.Instance.creatures[2]);
        Debug.Log("---------------------------");
        Debug.Log("SpeedUp Character :" + RoundManager.Instance.creatures[2].name);
        RoundManager.Instance.OnUpdate();
        for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
        {
            CharBase creature = RoundManager.Instance.creatures[i];
            Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
            creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
        }
    }

    void Update()
    {

    }

}

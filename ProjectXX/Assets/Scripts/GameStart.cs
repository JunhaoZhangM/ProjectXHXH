using Data;
using Entities;
using Managers;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{


    void Start()
    {
        DataManager.Instance.Load();

        for (int i = 1; i <= DataManager.Instance.Example.Count; i++)
        {
            Debug.LogFormat("ExampleInfo : ID:{0} Name:{1} Description:{2} ", DataManager.Instance.Example[i].ID, DataManager.Instance.Example[i].Name, DataManager.Instance.Example[i].Description);
        }

        ResourceManager.Instance.Init();
        UIManager.Instance.SetUIGroup(5);
        PoolManager.Instance.CreateGameObjectPool("UI", 10);
        Creature HuangQuan = new Creature("HuangQuan", 146);
        Creature HuaHuo = new Creature("HuaHuo", 138);
        Creature RuanMei = new Creature("RuanMei", 105);
        Creature YinLang = new Creature("YinLang", 104);
        RoundManager.Instance.creatures.Add(HuangQuan);
        RoundManager.Instance.creatures.Add(HuaHuo);
        RoundManager.Instance.creatures.Add(RuanMei);
        RoundManager.Instance.creatures.Add(YinLang);
        RoundManager.Instance.Init();
        Debug.Log("---------------------------");
        for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
        {
            Creature creature = RoundManager.Instance.creatures[i];
            Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
            creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
        }
    }

    public void Test()
    {
        Debug.Log("---------------------------");

        RoundManager.Instance.OnAttack();
        for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
        {
            Creature creature = RoundManager.Instance.creatures[i];
            Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
            creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
        }
    }
    public void SpeedUp()
    {
        BuffDefine define = new BuffDefine();
        define.Type = BuffType.Attributes;
        define.ActionTimeRatio = 50;
        Buff buff = new Buff(define);
        buff.DoBuff(RoundManager.Instance.creatures[2]);
        Debug.Log("---------------------------");
        Debug.Log("SpeedUp Character :" + RoundManager.Instance.creatures[2].name);
        RoundManager.Instance.OnUpdate();
        for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
        {
            Creature creature = RoundManager.Instance.creatures[i];
            Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
            creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
        }
    }

    void Update()
    {

    }

}

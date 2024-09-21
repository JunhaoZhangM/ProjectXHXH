using Data;
using Entities;
using Event;
using GameObjectController;
using Managers;
using Model;
using System;
using System.Collections.Generic;

namespace Battle
{
    public class BattleManager : Singleton<BattleManager>
    {
        public List<CharBase> Units = new List<CharBase>();

        public CharBase CurPlayer;

        public List<CharBase> CurTarget;

        public Action OnBattleBegin;

        int entitySum = 0;

        public int CurPoint;  //当前能量豆
        public int MaxPoint;  //能量豆上限

        public void Init()
        {

        }

        public void JoinTeam(List<int> team,TargetType teamType)
        {
            for(int i = 0; i < team.Count; i++)
            {
                if(DataManager.Instance.Characters.TryGetValue(team[i],out CharacterDefine define))
                {
                    CharBase character = new CharBase(define);
                    character.Faction = teamType;
                    Units.Add(character);
                }
            }
        }

        public void JoinBattle()
        {
            List<CharBase> Players = User.Instance.GetCurCharacter();
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].entityID = ++entitySum;
                Units.Add(Players[i]);
            }
            List<int> MosnterID = new List<int>();
            //MosnterID.Add(5);
            //Init(MosnterID, TargetType.Enemy);
            OnBattleBegin?.Invoke();
        }

        public void SetCurPlayer(CharBase Player)
        {
            CurPlayer = Player;
            //EventManager.Instance.Fire("OnPlayerChange", CurPlayer);
        }

        public List<CharBase> GetUnits()
        {
            return Units;
        }
    }
}
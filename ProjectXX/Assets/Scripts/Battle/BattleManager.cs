using Data;
using Entities;
using Event;
using GameObjectController;
using Managers;
using Model;
using System.Collections.Generic;

namespace Battle
{
    public class BattleManager : Singleton<BattleManager>
    {
        public List<CharBase> Units = new List<CharBase>();

        public CharBase CurPlayer;

        public List<CharBase> CurTarget;

        public int CurPoint;  //当前能量豆
        public int MaxPoint;  //能量豆上限

        public void Init(List<int> team,TargetType teamType)
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

        public void Init()
        {
            Units.AddRange(User.Instance.GetCurCharacter());
            List<int> MosnterID = new List<int>();
            //MosnterID.Add(5);
            //Init(MosnterID, TargetType.Enemy);
            RoundManager.Instance.Init();
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
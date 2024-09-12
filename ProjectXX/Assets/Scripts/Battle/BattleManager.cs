using Data;
using Entities;
using Event;
using GameObjectController;
using Managers;
using System.Collections.Generic;

namespace Battle
{
    public class BattleManager : Singleton<BattleManager>
    {
        public List<CharBase> Team = new List<CharBase>();
        public CharBase CurPlayer;

        public void Init(List<int> allied)
        {
            for(int i = 0; i < allied.Count; i++)
            {
                if(DataManager.Instance.Characters.TryGetValue(allied[i],out CharacterDefine define))
                {
                    CharBase character = new CharBase(define);
                    Team.Add(character);
                }
            }
            EventManager.Instance.Fire("OnBattleBegin");
        }

        public void SetCurPlayer(CharBase Player)
        {
            CurPlayer = Player;
            EventManager.Instance.Fire("OnPlayerChange", CurPlayer);
        }
    }
}
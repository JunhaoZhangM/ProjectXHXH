using System.Collections.Generic;
using System.Diagnostics;
using Battle;
using Entities;
using Event;
using Unity.VisualScripting;

namespace Managers
{
    public class ActionTimeCompare : IComparer<CharBase>
    {
        public int Compare(CharBase x, CharBase y)
        {
            if (x == null)
            {
                return y == null ? 0 : -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else
            {
                int retval = x.attributes.CurActionTime.CompareTo(y.attributes.CurActionTime);

                if (retval != 0)
                {
                    return retval;
                }
                else
                {
                    // 取相反数实现SPD的降序排序
                    return -x.attributes.SPD.CompareTo(y.attributes.SPD);
                }
            }
        }
    }

    public enum RoundStatus
    {
        PreSettle,
        PlayerAction,
        ActionExecute,
        RoundEnd
    }

    class RoundManager : Singleton<RoundManager>
    {
        public int round;
        public int maxRound;
        public int accumalteActionTime;

        public RoundStatus roundStatus;

        public CharBase curActionCreature;
        public List<CharBase> creatures = new List<CharBase>();
        public ActionTimeCompare AC = new ActionTimeCompare();

        public RoundManager()
        {
            EventManager.Instance.Subscribe<CharBase>("OnActionComplete", OnActionComplete);
        }

        ~RoundManager()
        {
            EventManager.Instance.UnSubscribe<CharBase>("OnActionComplete", OnActionComplete);
        }

        public void Init()
        {
            round = 0;
            accumalteActionTime = 0;
            creatures = BattleManager.Instance.GetUnits();
            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].attributes.ActionTime = 10000 / creatures[i].attributes.SPD;
                creatures[i].attributes.CurActionTime = (int)creatures[i].attributes.ActionTime;
            }
            creatures.Sort(AC);
            UpdateActionTime(-(int)creatures[0].attributes.ActionTime);
            BattleManager.Instance.SetCurPlayer(creatures[0]);
            EventManager.Instance.Fire("RoundInit", creatures);
            RoundPreSettle();
        }

        public void RoundPreSettle()
        {
            roundStatus = RoundStatus.PreSettle;
            CharBase cha = BattleManager.Instance.CurPlayer;
            cha.OnPreSettle(); 
        }

        public void RoundPlayerAction()
        {
            roundStatus = RoundStatus.PlayerAction;
        }

        public void UpdateActionTime(int time)
        {
            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].attributes.CurActionTime += time;
            }
        }


        public void OnActionComplete(object sender,CharBase creature)
        {
            creatures.Remove(creature);
            creatures.Add(creature);
            creature.attributes.CurActionTime = (int)creature.attributes.ActionTime;
            UpdateActionTime(-(int)creatures[0].attributes.CurActionTime);
            OnUpdate();
        }
        public void OnUpdate()
        {
            creatures.Sort(AC);
            BattleManager.Instance.SetCurPlayer(creatures[0]);
            EventManager.Instance.Fire("ActionTimeUpdate",creatures);
        }
    }
}
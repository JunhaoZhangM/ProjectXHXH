using System.Collections.Generic;
using System.Diagnostics;
using Entities;
using Unity.VisualScripting;

namespace Managers
{
    public class ActionTimeCompare : IComparer<Creature>
    {
        public int Compare(Creature x, Creature y)
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

    class RoundManager : Singleton<RoundManager>
    {
        public int round;
        public int maxRound;
        public int accumalteActionTime;
        public List<Creature> creatures = new List<Creature>();
        public ActionTimeCompare AC = new ActionTimeCompare();
        public void Init()
        {
            round = 0;
            accumalteActionTime = 0;
            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].attributes.ActionTime = 10000 / creatures[i].attributes.SPD;
                creatures[i].attributes.CurActionTime = (int)creatures[i].attributes.ActionTime;
            }
            creatures.Sort(AC);
            UpdateActionTime(-(int)creatures[0].attributes.ActionTime);
        }

        public void UpdateActionTime(int time)
        {
            for (int i = 0; i < creatures.Count; i++)
            {
                creatures[i].attributes.CurActionTime += time;
            }
        }

        public void OnAttack()
        {
            Creature creature = creatures[0];
            creatures.Remove(creature);
            creatures.Add(creature);
            creature.attributes.CurActionTime = (int)creature.attributes.ActionTime;
            UpdateActionTime(-(int)creatures[0].attributes.CurActionTime);
            creatures.Sort(AC);
        }
        public void OnUpdate()
        {
            creatures.Sort(AC);
        }
    }
}
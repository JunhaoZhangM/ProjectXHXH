using Data;
using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    public class BuffManager
    {
        private CharBase Owner;

        public Dictionary<int, Buff> Buffs = new Dictionary<int, Buff>();

        List<int> needRemove = new List<int>();

        public BuffManager(CharBase owner)
        {
            this.Owner = owner;
        }

        public Buff AddBuff(int buffId, CharBase caster)
        {
            Buff buff;
            if (Buffs.TryGetValue(buffId,out buff))
            {
                buff.round = buff.define.LastRound;
                return buff;
            }
            if (DataManager.Instance.Buffs.TryGetValue(buffId,out BuffDefine buffDefine))
            {
                buff = new Buff(buffDefine, Owner, caster);
                Buffs.Add(buffId, buff);
                buff.OnAdd();
                return buff;
            }
            return null;
        }

        public Buff RemoveBuff(int buffId)
        {
            if(Buffs.TryGetValue(buffId,out Buff buff))
            {
                buff.OnRemove();
                Buffs.Remove(buffId);
                return buff;
            }
            return null;
        }

        public void PreSettle()
        {
            foreach(var kv in Buffs)
            {
                kv.Value.OnPreSettle();
            }
        }

        public void OnRoundEnd()
        {
            needRemove.Clear();
            foreach(var kv in Buffs)
            {
                kv.Value.OnRoundEnd();
                if (kv.Value.round == 0)
                {
                    needRemove.Add(kv.Key);
                }
            }
            foreach(var k in needRemove)
            {
                Owner.RemoveBuff(k);
            }
        }

        public void DebugAllBuff()
        {
            foreach(var kv in Buffs)
            {
                Debug.LogFormat("Character:{0} Buff:{1} LastRound:{2}", Owner.name, kv.Value.define.Name, kv.Value.define.LastRound);
            }     
        }
    }
}

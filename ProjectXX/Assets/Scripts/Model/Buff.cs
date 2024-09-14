using System;
using System.Diagnostics;
using Data;
using Entities;

namespace Model
{
    public class Buff
    {
        public int BuffId;
        public BuffDefine define;

        public int round;

        public CharBase Caster;
        public CharBase Owner;


        public Buff(BuffDefine define,CharBase caster,CharBase owner)
        {
            this.define = define;
            BuffId = define.ID;
            Caster = caster;
            Owner = owner;
        }

        public void DoBuff(CharBase target)
        {
            if (define.BuffType == BuffType.Attributes)
            {
                if (define.SpeedRatio > 0)
                {
                    int diff = (int)(target.attributes.CurActionTime - define.SpeedRatio / 100 * target.attributes.ActionTime);
                    target.attributes.CurActionTime = diff > 0 ? diff : 0;
                }
            }
        }

        public void OnAdd()
        {
            
        }

        public void OnRemove()
        {
            
        }

        public void OnPreSettle()
        {
            if(define.BuffType == BuffType.Dot)
            {
                float damage = Caster.attributes.ATK * (100 + define.AtkRatio) / 100; //ÉËº¦¼ÆËã¹«Ê½
                Owner.DoDamage(damage, Caster);
            }
            else if(define.EffectType == EffectType.Ice)
            {

            }
        }
    }
}
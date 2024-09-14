using System;
using Data;
using Event;
using Managers;
using Model;
using UnityEngine;

namespace Entities
{
    public class DamageInfo
    {
        public CharBase Hurt;
        public ElementType type;
        public int damage;
        public bool isCrit;
        public DamageInfo(CharBase hurt, ElementType type,int damage,bool isCrit)
        {
            Hurt = hurt;
            this.type = type;
            this.damage = damage;
            this.isCrit = isCrit;
        }
    }

    public class CharBase : Entity
    {
        public Attributes attributes;

        public SkillManager SkillMgr;
        public BuffManager BuffMgr;

        public CharacterDefine define;
        public TargetType Faction;

        public Action<Buff> OnAddBuff;
        public Action<Buff> OnRemoveBuff;
        public Action<DamageInfo> OnDamage;
        public Action<CharBase> OnDeath;

        public bool aiActive;
        public void OnUpdate()
        {

        }

        public void OnComplete()
        {
            EventManager.Instance.Fire("OnActionComplete", this);
        }

        public void DoSkill()
        {

        }

        public void Death()
        {

        }
        public CharBase(CharacterDefine define)
        {
            this.name = define.Name;
            this.define = define;
            attributes = new Attributes(define);
            SkillMgr = new SkillManager(this);
            BuffMgr = new BuffManager(this);
        }

        public void OnPreSettle()
        {
            BuffMgr.PreSettle();

        }

        public void AddBuff(int buffId,CharBase caster)
        {
            var buff = BuffMgr.AddBuff(buffId, caster);
            if (buff != null && OnAddBuff != null)
            {
                OnAddBuff(buff);
            }
        }

        public void RemoveBuff()
        {

        }

        public void DoDamage(float damage, CharBase caster, bool isCrit = false)
        {
            attributes.HP -= damage;
            DamageInfo damageInfo = new DamageInfo(this, caster.define.ElementType, (int)damage, isCrit);
            OnDamage?.Invoke(damageInfo);
            if (attributes.HP <= 0)
            {
                OnDeath?.Invoke(this);
            }
        }
    }
}
using Data;
using Managers;
using UnityEngine;

namespace Entities
{
    public class CharBase : Entity
    {
        public Attributes attributes;
        public SkillManager SkillMgr;
        public CharacterDefine define;
        public void OnUpdate()
        {

        }
        public void OnAttack()
        {

        }

        public void OnDamage()
        {

        }
        public void OnComplete()
        {

        }

        public void DoSkill()
        {

        }

        public void OnDeath()
        {

        }
        public CharBase(CharacterDefine define)
        {
            this.name = define.Name;
            this.define = define;
            attributes = new Attributes(define);
            SkillMgr = new SkillManager(this);
        }
    }
}
using System;
using Data;
using Entities;
using Managers;

namespace Model
{
    public class Skill
    {
        public SkillDefine define;
        public Skill(SkillDefine define)
        {
            this.define = define;
        }

        public void CastSkill()
        {
            bool castResult = checkCast();

            RoundManager.Instance.OnAttack();
            //for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
            //{
                //CharBase creature = RoundManager.Instance.creatures[i];
                //Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
                //creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
            //}
        }

        public bool checkCast()
        {
            return true;
        }
    }
}
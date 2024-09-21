using System;
using System.Collections.Generic;
using Battle;
using Data;
using Entities;
using Event;
using Managers;

namespace Model
{
    public class Skill
    {
        public SkillDefine define;
        public CharBase Owner;
        public List<CharBase> Target;

        public List<string> Animations;

        public int cdRound;
        public Skill(SkillDefine define,CharBase owner)
        {
            this.define = define;
            Owner = owner;
            Animations = new List<string>(define.SkillAnimation.Split("/"));
        }

        public void CastSkill()
        {
            SkillResult castResult = checkCast(BattleManager.Instance.CurTarget);

            if (castResult == SkillResult.LackOfPoint)
            {

            }else if(castResult == SkillResult.LackOfEnergy)
            {

            }
            else
            {
                
            }

            Owner.PlayAnim(Animations);
            EventManager.Instance.Fire(EventString.OnPlayerActionEnd,Owner);
            //for (int i = 0; i < RoundManager.Instance.creatures.Count; i++)
            //{
                //CharBase creature = RoundManager.Instance.creatures[i];
                //Debug.LogFormat("Character Name : {0}  Speed:{1} ActionTime:{2} CurActionTime:{3}",
                //creature.name, creature.attributes.SPD, creature.attributes.ActionTime, creature.attributes.CurActionTime);
            //}
        }

        public SkillResult checkCast(List<CharBase> target)
        {
            if (define.Point > BattleManager.Instance.CurPoint)
            {
                return SkillResult.LackOfPoint;
            }
            else if (define.Point > Owner.attributes.Energy)
            {
                return SkillResult.LackOfEnergy;
            }
            else return SkillResult.OK;
        }
    }
}
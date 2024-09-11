using System;
using Data;

namespace Model
{
    class Skill
    {
        public SkillDefine define;
        public Skill(SkillDefine define)
        {
            this.define = define;
        }

        public void CastSkill()
        {
            bool castResult = checkCast();
        }

        public bool checkCast()
        {
            return true;
        }
    }
}
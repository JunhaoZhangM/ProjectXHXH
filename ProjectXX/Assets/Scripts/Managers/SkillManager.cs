using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class SkillManager
    {
        public List<Skill> skills = new List<Skill>();

        public CharBase owner;

        public SkillManager(CharBase Owner)
        {
            owner = Owner;
            InitSkills();
        }

        public void InitSkills()
        {
            foreach (var pair in DataManager.Instance.Skills[owner.define.ID])
            {
                Skill skill = new Skill(pair.Value);
                skills.Add(skill);
            }
        }
    }
}

using Entities;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class UISkillSlot : MonoBehaviour
    {
        public Button button;
        Skill skill;
        void Start()
        {
            button.onClick.AddListener(DoSkill);
        }

        void DoSkill()
        {
            skill.CastSkill();
        }

        public void SetSkillInfo(Skill skill)
        {
            this.skill = skill;
        }
    }
}

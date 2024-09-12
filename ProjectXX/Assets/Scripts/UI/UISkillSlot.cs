using Entities;
using Model;
using UnityEngine;
using UnityEngine.UI;

    public class UISkillSlot : MonoBehaviour
    {
        public Button button;
        public Image Icon;
        public Text Name;
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
            Name.text = skill.define.Name;
        }
    }


using UnityEngine;

namespace Entities
{
    public class Creature : Entity
    {
        public Attributes attributes;
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
        public Creature(string name, int spd)
        {
            this.name = name;
            attributes = new Attributes();
            attributes.SPD = spd;
        }
    }
}
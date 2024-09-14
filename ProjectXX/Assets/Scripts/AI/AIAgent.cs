using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AI
{
    public class AIAgent
    {
        public CharBase Owner;
        public AIAgent(CharBase owner)
        {
            Owner = owner;
        }

        public void SetAIActive()
        {
            Owner.aiActive = !Owner.aiActive;
        }

        public void CastSkill()
        {
            Debug.LogFormat("");
        }
    }
}

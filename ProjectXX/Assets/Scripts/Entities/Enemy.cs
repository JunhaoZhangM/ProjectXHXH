using Assets.Scripts.AI;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Enemy : CharBase
    {
        public AIAgent agent;
        public Enemy(CharacterDefine define) : base(define)
        {

        }
    }
}

using Data;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Character : CharBase
    {
        public CharacterDefine define;
        public Character(CharacterDefine define) : base(define)
        {
        }
    }
}

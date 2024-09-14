using Data;
using Entities;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class User : Singleton<User>
    {
        private List<CharBase> Characters = new List<CharBase>();

        public void Init()
        {
            for(int i = 1; i <= 4; i++)
            {
                CharacterDefine define = DataManager.Instance.Characters[i];
                CharBase c = new CharBase(define);
                c.Faction = TargetType.Allied;
                Characters.Add(c);
            }
        }

        public List<CharBase> GetCurCharacter()
        {
            return Characters;
        }

        public void SetCurCharacter(List<CharBase> team)
        {
            Characters = team;
        }
    }
}

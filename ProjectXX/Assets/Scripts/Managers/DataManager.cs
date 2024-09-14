using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Data;
using UnityEngine;

namespace Managers
{
    class DataManager : Singleton<DataManager>
    {
        public string DataPath="Data/";
        public Dictionary<int, CharacterDefine> Characters = null;
        public Dictionary<int, Dictionary<int,SkillDefine>> Skills = null;
        public Dictionary<int, BuffDefine> Buffs = null;

        public DataManager()
        {
            Debug.Log("DataManager << Init");
        }


        public void Load()
        {
            string json = File.ReadAllText(DataPath + "CharacterDefine.txt");
            Characters = JsonConvert.DeserializeObject<Dictionary<int, CharacterDefine>>(json);

            json = File.ReadAllText(DataPath + "SkillDefine.txt");
            Skills = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<int, SkillDefine>>>(json);

            json = File.ReadAllText(DataPath + "BuffDefine.txt");
            Buffs = JsonConvert.DeserializeObject<Dictionary<int, BuffDefine>>(json);
        }
    }
}

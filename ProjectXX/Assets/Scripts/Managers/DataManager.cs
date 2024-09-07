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
        public Dictionary<int, ExampleInfo> Example = null;

        public DataManager()
        {
            Debug.Log("DataManager << Init");
        }


        public void Load()
        {
            string json = File.ReadAllText(DataPath + "ExampleInfo.txt");
            Example = JsonConvert.DeserializeObject<Dictionary<int, ExampleInfo>>(json);
        }
    }
}

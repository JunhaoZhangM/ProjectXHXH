using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using UnityEngine;

namespace Managers
{
    class UIManager : MonoSingleton<UIManager>
    {
        public List<Transform> _Layers = new List<Transform>();

        public Dictionary<string, UIBase> _UIObjects = new Dictionary<string, UIBase>();

        public Transform _UIParent;

        void Awake()
        {
            
        }

        public void SetUIGroup(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject group = new GameObject("Group" + i);
                group.transform.SetParent(_UIParent, false);
                _Layers.Add(group.transform);
            }
        }

        public UIBase OpenUI(string uiName,int groupID)
        {
            if (_UIObjects.ContainsKey(uiName)) return null ;
            GameObject go = PoolManager.Instance.Spawn("UI", uiName) as GameObject;
            if (go == null)
            {
                go = Instantiate(ResourceManager.Instance.LoadUI(uiName)) as GameObject;
            }
            go.transform.SetParent(_Layers[groupID],false);

            UIBase ui = go.GetComponent<UIBase>();
            ui.OnOpen();
            _UIObjects.Add(uiName, ui);

            return ui;
        }

        public void CloseUI(string uiName)
        {
            UIBase ui;
            if(_UIObjects.TryGetValue(uiName,out ui))
            {
                ui.OnClose();
                _UIObjects.Remove(uiName);
                PoolManager.Instance.UnSpawn("UI", uiName, ui.gameObject);
            }
        }
    }
}

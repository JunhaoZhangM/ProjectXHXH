using Battle;
using Entities;
using Event;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Managers;

namespace GameObjectController
{
    class GameObjectManager : MonoSingleton<GameObjectManager>
    {
        public Dictionary<int, GameObject> Entities = new Dictionary<int, GameObject>();
        public List<Transform> SpawnPoints = new List<Transform>();

        protected override void OnStart()
        {
            BattleManager.Instance.OnBattleBegin += OnBattleBegin;
        }

        private void OnDestroy()
        {
            BattleManager.Instance.OnBattleBegin -= OnBattleBegin;
        }

        private void OnBattleBegin()
        {
            StartCoroutine(InitGameObject());
        }

        IEnumerator InitGameObject()
        {
            for(int i = 0; i < BattleManager.Instance.Units.Count; i++)
            {
                CreateGameObject(BattleManager.Instance.Units[i], SpawnPoints[i]);
            }
            yield return null;
        }

        public void CreateGameObject(CharBase creature,Transform point)
        {
            if (Entities.ContainsKey(creature.entityID)) return;

            Object obj = ResourceManager.Instance.Load<Object>(creature.define.ModelResource);
            if(obj == null)
            {
                Debug.LogFormat("Character:{[0]} ModelResource:{[1]} not existed", creature.define.Name, creature.define.ModelResource);
                return;
            }
            GameObject go = (GameObject)Instantiate(obj, point);
            go.name = "Entity_" + creature.entityID + "_" + creature.define.Name;
            Entities[creature.entityID] = go;
            EntityController ec = go.GetComponent<EntityController>();
            if (ec == null) return;
            ec.entity = creature;
            creature.Controller = ec;

            Debug.LogFormat("{0}:{1}",ec.gameObject.name,creature.name);
        }
    }
}

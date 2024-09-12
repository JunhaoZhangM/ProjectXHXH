using Battle;
using Entities;
using Event;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameObjectController
{
    class GameObjectManager : MonoSingleton<GameObjectManager>
    {
        public Dictionary<int, GameObject> Creatures = new Dictionary<int, GameObject>();
        public List<GameObject> Test = new List<GameObject>();

        public void Awake()
        {
            EventManager.Instance.Subscribe<object>("OnBattleBegin", OnBattleBegin);
        }

        private void OnBattleBegin(object arg1, object arg2)
        {
            StartCoroutine(InitGameObject());
        }

        IEnumerator InitGameObject()
        {
            for(int i = 0; i < BattleManager.Instance.Team.Count; i++)
            {
                AssignGameObject(BattleManager.Instance.Team[i], Test[i]);
            }
            yield return null;
        }

        public void AssignGameObject(CharBase creature,GameObject gameObject)
        {
            EntityController ec = gameObject.GetComponent<EntityController>();
            ec.entity = creature;
            creature.Controller = ec;
            Debug.LogFormat("{0}:{1}",ec.gameObject.name,creature.name);
        }
    }
}

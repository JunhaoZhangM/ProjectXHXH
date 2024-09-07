using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    class PoolManager : MonoSingleton<PoolManager>
    {
        public Transform _PoolParent;

        Dictionary<string, PoolBase> _Pools = new Dictionary<string, PoolBase>();

        void Awake()
        {

        }

        private void CreatePool<T>(string name, float releaseTime) where T : PoolBase
        {
            PoolBase pool;
            if (!_Pools.TryGetValue(name, out pool))
            {
                GameObject go = new GameObject(name);
                go.transform.SetParent(_PoolParent);
                pool = go.AddComponent<T>();
                pool.Init(releaseTime);
                _Pools.Add(name, pool);
            }
        }

        public void CreateGameObjectPool(string name, float releaseTime)
        {
            CreatePool<GameObjectPool>(name, releaseTime);
        }

        public Object Spawn(string poolName, string objName)
        {
            PoolBase pool;
            if (_Pools.TryGetValue(poolName, out pool))
            {
                return pool.Spawn(objName);
            }
            return null;
        }

        public void UnSpawn(string poolName, string objName, Object obj)
        {
            PoolBase pool;
            if (_Pools.TryGetValue(poolName, out pool))
            {
                pool.UnSpawn(objName, obj);
            }
        }
    }
}

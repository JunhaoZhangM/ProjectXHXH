using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : PoolBase
{
    public override Object Spawn(string name)
    {
        Object obj = base.Spawn(name);

        if (obj == null) return null;

        GameObject go = obj as GameObject;
        go.SetActive(true);

        return go;
    }

    public override void UnSpawn(string name, Object obj)
    {
        GameObject go = obj as GameObject;
        go.SetActive(false);
        go.transform.SetParent(transform, false);

        base.UnSpawn(name, obj);
    }

    public override void Release()
    {
        base.Release();
        foreach(var pair in _Objects)
        {
            PoolObject po= pair.Value;
            if(System.DateTime.Now.Ticks - po.LastUseTime.Ticks > _ReleaseTime * 10000000)
            {
                Debug.Log("GameObjectPool ReleaseTime: " + System.DateTime.Now);
                Destroy(po._object);
                _Objects.Remove(po.name);
                Release();
                return;
            }
        }
    }

}

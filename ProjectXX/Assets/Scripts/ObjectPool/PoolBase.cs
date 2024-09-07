using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBase : MonoBehaviour
{
    protected float _ReleaseTime;
    protected long _LastReleaseTime;  //10e7¼¶±ð

    protected Dictionary<string, PoolObject> _Objects;

    public void Init(float time)
    {
        _ReleaseTime = time;
        _Objects = new Dictionary<string, PoolObject>();
    }

    public virtual Object Spawn(string name)
    {
        PoolObject po;
        if(_Objects.TryGetValue(name,out po))
        {
            _Objects.Remove(name);
            return po._object;
        }
        return null;
    }

    public virtual void UnSpawn(string name,Object obj)
    {
        PoolObject po = new PoolObject(name, obj);
        _Objects.Add(name, po);
    }

    public virtual void Release()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(System.DateTime.Now.Ticks - _LastReleaseTime> _ReleaseTime * 10000000)
        {
            _LastReleaseTime = System.DateTime.Now.Ticks;
            Release();
        }
    }
}

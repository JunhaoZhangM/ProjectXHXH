using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject
{
    public Object _object;
    public System.DateTime LastUseTime;
    public string name;
    public PoolObject(string name,Object obj)
    {
        _object = obj;
        LastUseTime = System.DateTime.Now;
        this.name = name;
    }
}

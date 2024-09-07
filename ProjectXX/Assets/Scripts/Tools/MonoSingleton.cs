using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public bool Global = true;
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (Global)
        {
            if (instance != null && instance != gameObject.GetComponent<T>())
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = gameObject.GetComponent<T>();
        }
        OnStart();
    }

    protected virtual void OnStart()
    {

    }
}


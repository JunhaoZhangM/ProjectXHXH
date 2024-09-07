using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Singleton<T> where T : new()
{
    private static readonly object _lock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            if (Equals(instance, default(T)))
            {
                lock (_lock)
                {
                    if (Equals(instance, default(T)))
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }
}



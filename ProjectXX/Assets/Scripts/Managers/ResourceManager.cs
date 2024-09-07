using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    class ResourceManager : Singleton<ResourceManager>
    {

        public void Init()
        {

        }

        public Object LoadUI(string name)
        {
            return Resources.Load(AppConst.UIPath + name) ;
        }
    }
}

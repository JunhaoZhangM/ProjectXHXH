using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameObjectController
{
    class EntityController : MonoBehaviour , IEntityController
    { 
        public Entity entity;

        public bool isCurPlayer;

        void FixedUpdate()
        {
            if (entity == null) return;
            entity.UpdateTransform(transform.position, transform.forward);
        }

        public void SetPlayer(bool isPlayer)
        {
            isCurPlayer = isPlayer;
        }

        public void PlayAnim(string anim)
        {
            
        }

        public void PlayEffect(string effect)
        {
            
        }
    }
}

using Entities;
using Spine.Unity;
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

        public SkeletonAnimation anim;

        public bool isCurPlayer;

        public void Start()
        {
            anim.state.SetAnimation(0, "Idle", true);
        }

        void FixedUpdate()
        {
            if (entity == null) return;
            entity.UpdateTransform(transform.position, transform.forward);
        }

        public void SetPlayer(bool isPlayer)
        {
            isCurPlayer = isPlayer;
        }

        public void PlayAnim(List<string> animation)
        {
            anim.state.SetAnimation(0, animation[0], false);
            for (int i = 1; i < animation.Count; i++)
            {
                anim.state.AddAnimation(0, animation[i], false,0f);
            }
            anim.state.AddAnimation(0, "Idle", true,0f);
        }

        public void PlayEffect(string effect)
        {
            
        }
    }
}

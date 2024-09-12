using GameObjectController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class Entity
    {
        public string name;
        public int entityID;

        public Vector3 position;
        public Vector3 direction;

        public IEntityController Controller;

        public void UpdateTransform(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }

    }
}


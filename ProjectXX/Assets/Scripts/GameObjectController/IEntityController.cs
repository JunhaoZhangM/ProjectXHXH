using System.Collections.Generic;

namespace GameObjectController
{
    public interface IEntityController
    {
        void SetPlayer(bool isPlayer);
        void PlayAnim(List<string> anim);
        void PlayEffect(string effect);
    }
}
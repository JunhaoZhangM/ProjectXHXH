namespace GameObjectController
{
    public interface IEntityController
    {
        void SetPlayer(bool isPlayer);
        void PlayAnim(string anim);
        void PlayEffect(string effect);
    }
}
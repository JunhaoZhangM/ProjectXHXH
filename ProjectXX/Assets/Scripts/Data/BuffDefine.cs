namespace Data
{
    public enum BuffType
    {
        Dot,
        Attributes,
    }
    public enum TargetType
    {
        Allied,
        Enemy
    }
    public enum UpdateType
    {
        Self,
        Other,
    }

    public enum EffectType
    {
        Ice,
    }
    public class BuffDefine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LastRound { get; set; }
        /// <summary>
        /// Buff种类是造成伤害，还是增加属性
        /// </summary>
        public BuffType BuffType { get; set; }
        /// <summary>
        /// Buff的目标是友军，还是敌人
        /// </summary>
        public TargetType TargetType { get; set; }
        /// <summary>
        /// Buff的更新是根据被施放者的回合周期，还是根据自身行动的周期
        /// </summary>
        public UpdateType UpdateType { get; set; }
        /// <summary>
        /// 是否有特殊效果，例如冰冻
        /// </summary>
        public EffectType EffectType { get; set; }
        public float AtkRatio { get; set; }
        public float DamageRatio { get; set; }
        public ElementType ElementType { get; set; }
        public float ElementRatio { get; set; }
        public float SpeedRatio { get; set; }
    }
}
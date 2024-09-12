namespace Data
{
    public enum BuffType
    {
        Attack,
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
    public class BuffDefine
    {
        public int BuffId { get; set; }
        public string name { get; set; }
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
        public float AtkRatio { get; set; }
        public float ActionTimeRatio { get; set; }
    }
}
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
        /// Buff����������˺���������������
        /// </summary>
        public BuffType BuffType { get; set; }
        /// <summary>
        /// Buff��Ŀ�����Ѿ������ǵ���
        /// </summary>
        public TargetType TargetType { get; set; }
        /// <summary>
        /// Buff�ĸ����Ǹ��ݱ�ʩ���ߵĻغ����ڣ����Ǹ��������ж�������
        /// </summary>
        public UpdateType UpdateType { get; set; }
        /// <summary>
        /// �Ƿ�������Ч�����������
        /// </summary>
        public EffectType EffectType { get; set; }
        public float AtkRatio { get; set; }
        public float DamageRatio { get; set; }
        public ElementType ElementType { get; set; }
        public float ElementRatio { get; set; }
        public float SpeedRatio { get; set; }
    }
}
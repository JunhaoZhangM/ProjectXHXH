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
        public float AtkRatio { get; set; }
        public float ActionTimeRatio { get; set; }
    }
}
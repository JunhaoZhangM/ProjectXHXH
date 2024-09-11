namespace Data
{
    public enum BuffType
    {
        Attack,
        Attributes,
    }
    public enum TargetType
    {

    }
    public enum UpdateType
    {
        Self,
        Other,
    }
    class BuffDefine
    {
        public int BuffId { get; set; }
        public string name { get; set; }
        public int LastRound { get; set; }
        public BuffType Type { get; set; }
        public float AtkRatio { get; set; }
        public float ActionTimeRatio { get; set; }
    }
}
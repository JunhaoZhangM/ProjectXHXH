namespace Data
{
    class SkillDefine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Atk { get; set; }
        public int Point { get; set; }
        public float Energy { get; set; }
        public SkillType Type { get; set; }
    }
    public enum SkillType
    {
        Normal = 0,
        Special,
        Passive,
        Ultimate
    }
}
using System.Collections.Generic;

namespace Data
{
    public class SkillDefine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int AtkRatio { get; set; }
        public int DamageRatio { get; set; } 
        public List<int> Buff { get; set; }
        public int LockLevel { get; set; }
        public int MaxUpgradeLevel { get; set; }
        public int EnergyRecovery { get; set; }
        public int BreakDamage { get; set; }
        public int Point { get; set; }
        public int Energy { get; set; }
        public SkillType Type { get; set; }
        public TargetType TargetType { get; set; }
        public List<int> FX { get; set; }
    }
    public enum SkillType
    {
        Normal = 0,
        Special,
        Passive,
        Ultimate
    }
}
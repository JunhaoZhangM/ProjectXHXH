using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CharacterDefine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ModelResource { get; set; }
        public string IconResource { get; set; }

        /// <summary>
        /// 最大生命值
        /// </summary>
        public float MaxHP { get; set; }
        /// <summary>
        /// 最大能量值
        /// </summary>
        public float MaxEnergy { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public float ATK { get; set; }
        /// <summary>
        /// 防御力
        /// </summary>
        public float DEF { get; set; }
        /// <summary>
        /// 暴击率
        /// </summary>
        public float CRI { get; set; }
        /// <summary>
        /// 暴击伤害
        /// </summary>
        public float CRDamage { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public float SPD { get; set; }
        /// <summary>
        /// 能量回复效率
        /// </summary>
        public float EnergyRecoveryEfficiency{ get; set; }
        /// <summary>
        /// 效果抵抗
        /// </summary>
        public float EffectResistance { get; set; }
        /// <summary>
        /// 击破特攻
        /// </summary>
        public float BreakDamage { get; set; }
        /// <summary>
        /// 治疗量加成
        /// </summary>
        public float HealAdd { get; set; }
        /// <summary>
        /// 效果命中
        /// </summary>
        public float EffectHit { get; set; }
    }
}

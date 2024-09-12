using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Attributes
    {
        /// <summary>
        /// 最大生命值
        /// </summary>
        public float MaxHP;
        /// <summary>
        /// 当前生命值
        /// </summary>
        public float HP;
        /// <summary>
        /// 最大能量值
        /// </summary>
        public float MaxEnergy;
        /// <summary>
        /// 当前能量值
        /// </summary>
        public float Energy;
        /// <summary>
        /// 攻击力
        /// </summary>
        public float ATK;
        /// <summary>
        /// 防御力
        /// </summary>
        public float DEF;
        /// <summary>
        /// 暴击率
        /// </summary>
        public float CRI;
        /// <summary>
        /// 暴击伤害
        /// </summary>
        public float CRDamage;
        /// <summary>
        /// 速度
        /// </summary>
        public float SPD;
        /// <summary>
        /// 能量回复效率
        /// </summary>
        public float EnergyRecoveryEfficiency;
        /// <summary>
        /// 效果抵抗
        /// </summary>
        public float EffectResistance;
        /// <summary>
        /// 击破特攻
        /// </summary>
        public float BreakDamage;
        /// <summary>
        /// 治疗量加成
        /// </summary>
        public float HealAdd;
        /// <summary>
        /// 效果命中
        /// </summary>
        public float EffectHit;
        /// <summary>
        /// 行动周期
        /// </summary>
        public float ActionTime;

        /// <summary>
        /// 当前行动周期
        /// </summary>
        public float CurActionTime;

        public Attributes(CharacterDefine define)
        {
            MaxHP = define.MaxHP;
            MaxEnergy = define.MaxEnergy;
            ATK = define.ATK;
            DEF = define.DEF;
            CRI = define.CRI;
            CRDamage = define.CRDamage;
            SPD = define.SPD;
            EnergyRecoveryEfficiency = define.EnergyRecoveryEfficiency;
            EffectResistance = define.EffectResistance;
            BreakDamage = define.BreakDamage;
            HealAdd = define.HealAdd;
            EffectHit = define.EffectHit;
        }
    }
}

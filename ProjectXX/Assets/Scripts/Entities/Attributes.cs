using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public enum AttributeType
    {
        MaxHP = 0,
        MaxEnergy = 1,
        ATK = 2,
        DEF,
        CRI,
        CRDamage,
        SPD,
        EnergyRecoveryEfficiency,
        EffectResistance,
        BreakDamage,
        HealAdd,
        EffectHit,
        ActionTime,
        Max
    }
    public class Attributes
    {
        private float[] Data = new float[(int)AttributeType.Max];

        /// <summary>
        /// 最大生命值
        /// </summary>
        public float MaxHP { get { return Data[(int)AttributeType.MaxHP]; } set { Data[(int)AttributeType.MaxHP] = value; } }
        /// <summary>
        /// 最大能量值
        /// </summary>
        public float MaxMP { get { return Data[(int)AttributeType.MaxEnergy]; } set { Data[(int)AttributeType.MaxEnergy] = value; } }
        /// <summary>
        /// 攻击力
        /// </summary>
        public float ATK { get { return Data[(int)AttributeType.ATK]; } set { Data[(int)AttributeType.ATK] = value; } }
        /// <summary>
        /// 防御力
        /// </summary>
        public float DEF { get { return Data[(int)AttributeType.DEF]; } set { Data[(int)AttributeType.DEF] = value; } }
        /// <summary>
        /// 暴击率
        /// </summary>
        public float CRI { get { return Data[(int)AttributeType.CRI]; } set { Data[(int)AttributeType.CRI] = value; } }
        /// <summary>
        /// 暴击伤害
        /// </summary>
        public float CRDamage { get { return Data[(int)AttributeType.CRDamage]; } set { Data[(int)AttributeType.CRDamage] = value; } }
        /// <summary>
        /// 速度
        /// </summary>
        public float SPD { get { return Data[(int)AttributeType.SPD]; } set { Data[(int)AttributeType.SPD] = value; } }
        /// <summary>
        /// 能量回复效率
        /// </summary>
        public float EnergyRecoveryEfficiency
        {
            get { return Data[(int)AttributeType.EnergyRecoveryEfficiency]; }
            set { Data[(int)AttributeType.EnergyRecoveryEfficiency] = value; }
        }
        /// <summary>
        /// 效果抵抗
        /// </summary>
        public float EffectResistance
        {
            get { return Data[(int)AttributeType.EffectResistance]; }
            set { Data[(int)AttributeType.EffectResistance] = value; }
        }
        /// <summary>
        /// 击破特攻
        /// </summary>
        public float BreakDamage
        {
            get { return Data[(int)AttributeType.BreakDamage]; }
            set { Data[(int)AttributeType.BreakDamage] = value; }
        }
        /// <summary>
        /// 治疗量加成
        /// </summary>
        public float HealAdd
        {
            get { return Data[(int)AttributeType.HealAdd]; }
            set { Data[(int)AttributeType.HealAdd] = value; }
        }
        /// <summary>
        /// 效果命中
        /// </summary>
        public float EffectHit
        {
            get { return Data[(int)AttributeType.EffectHit]; }
            set { Data[(int)AttributeType.EffectHit] = value; }
        }

        /// <summary>
        /// 行动周期
        /// </summary>
        public float ActionTime
        {
            get { return Data[(int)AttributeType.ActionTime]; }
            set { Data[(int)AttributeType.ActionTime] = value; }
        }


        public void Reset()
        {
            for (int i = 0; i < (int)AttributeType.Max; i++)
            {
                Data[i] = 0;
            }
        }
    }
}

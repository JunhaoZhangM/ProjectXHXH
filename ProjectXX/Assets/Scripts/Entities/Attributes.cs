using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public enum AttributeType
    {
        MaxHP=0,
        MaxMP=1,
        ATK=2,
        DEF,
        CRI,
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
        /// 最大法力值
        /// </summary>
        public float MaxMP { get { return Data[(int)AttributeType.MaxMP]; } set { Data[(int)AttributeType.MaxMP] = value; } }
        /// <summary>
        /// 攻击力
        /// </summary>
        public float ATK { get { return Data[(int)AttributeType.ATK]; } set { Data[(int)AttributeType.ATK] = value; } }
        /// <summary>
        /// 防御力
        /// </summary>
        public float DEF { get { return Data[(int)AttributeType.MaxHP]; } set { Data[(int)AttributeType.DEF] = value; } }
        /// <summary>
        /// 暴击率
        /// </summary>
        public float CRI { get { return Data[(int)AttributeType.MaxHP]; } set { Data[(int)AttributeType.CRI] = value; } }

        public void Reset()
        {
            for(int i = 0; i < (int)AttributeType.Max; i++)
            {
                Data[i] = 0;
            }
        }
    }
}

using System.Diagnostics;
using Data;
using Entities;

namespace Model
{
    class Buff
    {
        public BuffDefine define;
        public int round;
        public Buff(BuffDefine define)
        {
            this.define = define;
        }

        public void DoBuff(Creature target)
        {
            if (define.Type == BuffType.Attributes)
            {
                if (define.ActionTimeRatio > 0)
                {
                    int diff = (int)(target.attributes.CurActionTime - define.ActionTimeRatio / 100 * target.attributes.ActionTime);
                    target.attributes.CurActionTime = diff > 0 ? diff : 0;
                }
            }
        }
    }
}
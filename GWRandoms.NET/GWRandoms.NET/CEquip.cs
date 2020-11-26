using AlarmCenter.DataCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRandoms.NET
{
    public class CEquip : CEquipBase
    {
        bool _isFirst = true;

        int _interval = 1000;

        /// <summary>
        /// 开关
        /// </summary>
        bool _isOpen = true;

        /// <summary>
        /// 设置值
        /// </summary>
        double _setValue = 0.0D;

        public override bool init(EquipItem item)
        {
            if (!base.init(item))
                return false;

            var param1 = item.communication_time_param.Split('/')[0];

            if (int.TryParse(param1, out var value))
                _interval = value;

            return true;
        }

        public override CommunicationState GetData(CEquipBase pEquip)
        {
            if (!_isFirst)
            {
                Sleep(_interval);
            }
            else
            {
                _isFirst = false;
            }

            // 模拟通讯故障
            if (null != pEquip.Equipitem.communication_param && pEquip.Equipitem.communication_param.StartsWith("broken"))
            {
                var rate = float.Parse(pEquip.Equipitem.communication_param.Split(':')[1]);

                var isBroken = GetRandomBoolean(rate);
                if (isBroken)
                    return CommunicationState.fail;
            }

            return base.GetData(pEquip);
        }

        public override bool GetYC(DataRow r)
        {
            try
            {
                Random random = GetRandom();

                var mainIns = r["main_instruction"].ToString();
                if (mainIns == "Value")
                {
                    SetYCData(r, _setValue);
                    return true;
                }
                else
                {
                    // 范围
                    var range = int.Parse(r["minor_instruction"].ToString());
                    var value = random.NextDouble() * range;
                    SetYCData(r, value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                DataCenter.WriteLogFile("GetYC: " + ex.ToString());
                return false;
            }
        }

        public override bool GetYX(DataRow r)
        {
            try
            {
                var mainIns = r["main_instruction"].ToString();
                if (mainIns == "Open")
                {
                    SetYXData(r, _isOpen);
                    return true;
                }
                else
                {
                    var rate = float.Parse(r["minor_instruction"].ToString());
                    var result = GetRandomBoolean(rate);
                    SetYXData(r, result);
                    return true;
                }
            }
            catch (Exception ex)
            {
                DataCenter.WriteLogFile("GetYX: " + ex.ToString());
                return false;
            }
        }

        public override bool SetParm(string MainInstruct, string MinorInstruct, string Value)
        {
            if (MainInstruct == "Switch")
            {
                _isOpen = bool.Parse(Value);
                return true;
            }
            else if (MainInstruct == "Set")
            {
                _setValue = double.Parse(Value);
                return true;
            }
            else
            {
                return false;
            }
        }

        private Random GetRandom()
            => new Random(Guid.NewGuid().GetHashCode());

        private bool GetRandomBoolean(float rate)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            // 20%几率报警
            var value = random.NextDouble();

            return value <= rate;
        }
    }
}

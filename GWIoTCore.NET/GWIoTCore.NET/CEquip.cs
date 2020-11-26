using AlarmCenter.DataCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GWIoTCore.NET
{
    public class CEquip : CEquipBase
    {
        private int _current = 1;

        private int _increment = 1;

        private int _interval = 1000;

        private Dictionary<string, DateTime> _dicAlarmTime = new Dictionary<string, DateTime>();

        bool _isInit = false;

        public override bool init(EquipItem item)
        {
            if (!_isInit)
            {
                base.init(item);

                _isInit = true;
            }

            return _isInit;
        }

        public override CommunicationState GetData(CEquipBase pEquip)
        {
            Sleep(_interval);

            return base.GetData(pEquip);
        }

        public override bool GetYC(DataRow r)
        {
            _current += _increment;
            SetYCData(r, (double)_current);
            return true;
        }

        public override bool GetYX(DataRow r)
        {
            var main = r["main_instruction"].ToString();
            var minor = r["minor_instruction"].ToString();

            // 通讯故障指令
            if (main == "false")
                return false;

            // 过一段时间后报警 
            var interval = int.Parse(minor);
            var lastAlarmTime = DateTime.Now;
            if (_dicAlarmTime.ContainsKey(main))
            {
                lastAlarmTime = _dicAlarmTime[main];
            }
            _dicAlarmTime[main] = lastAlarmTime;

            if (_dicAlarmTime[main].AddSeconds(interval) < DateTime.Now)
            {
                SetYXData(r, true);
            }
            else
            {
                SetYXData(r, false);
            }

            return true;
        }

        public override bool SetParm(string MainInstruct, string MinorInstruct, string Value)
        {
            _increment = int.Parse(Value);

            return true;
        }
    }
}

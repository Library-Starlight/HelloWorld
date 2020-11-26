using GWDataCenter;
using GWDataCenter.Database;
using System;

namespace GWRandoms.STD
{
    public class CEquip : CEquipBase
    {
        bool _isFirst = true;

        int _interval = 1000;

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

            return base.GetData(pEquip);
        }

        public override bool GetYC(YcpTableRow r)
        {
            try
            {
                Random random = GetRandom();
                var value = random.NextDouble() * 20;

                DataCenter.WriteLogFile($"get yc, equip_no: {r.equip_no}, yx_no: {r.yc_no}, yc_name: {r.yc_nm}, value: {value.ToString()}");
                SetYCData(r, value);
                return true;
            }
            catch (Exception ex)
            {
                DataCenter.WriteLogFile("GetYC: " + ex.ToString());
                return false;
            }
        }

        public override bool GetYX(YxpTableRow r)
        {
            try
            {
                var random = new Random(Guid.NewGuid().GetHashCode());
                var value = random.Next(0, 2);

                var result = value == 1;
                DataCenter.WriteLogFile($"get yx, equip_no: {r.equip_no}, yx_no: {r.yx_no}, yx_name: {r.yx_nm}, value: {result.ToString()}");
                SetYXData(r, result);
                return true;
            }
            catch (Exception ex)
            {
                DataCenter.WriteLogFile("GetYX: " + ex.ToString());
                return false;
            }
        }

        public override bool SetParm(string MainInstruct, string MinorInstruct, string Value)
        {
            DataCenter.WriteLogFile($"set param, main_ins: {MainInstruct}, mino_ins: {MinorInstruct}, value: {Value}");
            return true;
        }

        private static Random GetRandom()
            => new Random(Guid.NewGuid().GetHashCode());

    }
}

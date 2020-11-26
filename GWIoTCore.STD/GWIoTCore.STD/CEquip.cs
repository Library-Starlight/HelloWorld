using GWDataCenter;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace GWIoTCore.STD
{
    public class CEquip : CEquipBase
    {
        public override bool init(EquipItem item)
        {
            var s = StationItem.MyGWDbProvider.serviceProvider.GetService<string>();

            //StationItem
            //DataCenter
            //GWDataCenter.Database.GWDbProvider

            return base.init(item);
        }
    }
}

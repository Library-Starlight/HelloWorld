using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEFDemo.Common
{
    public  class EquipModel
    {
        public int ID { get; set; }
        public string MarkerName { get; set; }
        public int EquipID { get; set; }
        public string AlarmExpress { get; set; }
        public bool IsAlarm { get; set; }
        public int MarkerType { get; set; }
        public string MarkerSize { get; set; }
        public string Position { get; set; }
        public List<YcpModel> YcData { get; set; }
        public List<YxpModel> YxData { get; set; }
        public string InfoData { get; set; }
        public string OffSet { get; set; }
        public string NormalIcon { get; set; }
        public string AlarmIcon { get; set; }
        public int ZoomIcon { get; set; }
        public string ZoomNormalIcon { get; set; }
        public string ZoomAlarmIcon { get; set; }
        public string ZoomIconSize { get; set; }
        public  string ZoomIconOffSet { get; set; }
        public string PopupSize { get; set; }
        public string BindCmd { get; set; }
        public string ProjectName { get; set; }
    }

    public class BigDataEquipModel
    {
        public int ID { get; set; }
        public string MarkerName { get; set; }
        public string Position { get; set; }
    }

    public class YcpModel
    {
        public int YcNo { get; set; }
        public string YcNm { get; set; }
        public string YcValue { get; set; }
        public bool YcIsAlarm { get; set; }
        public string YcUnit { get; set; }
    }

    public class YxpModel
    {
        public int YxNo { get; set; }
        public string YxNm { get; set; }
        public string YxValue { get; set; }
        public bool YxIsAlarm { get; set; }
        public string YxState { get; set; }
    }

    public class MapModel
    {
        public int Zoom { get; set; }
        public string MapStyle { get; set; }
        public string MapCenter { get; set; }
        public string NorthEast { get; set; }
        public string SouthWest { get; set; }
    }

    public class TestModel
    {
        public int ID { get; set; }
        public string MarkerName { get; set; }
        public int EquipID { get; set; }
        public string AlarmExpress { get; set; }
        public int MarkerType { get; set; }
        public string MarkerSize { get; set; }
        public string Position { get; set; }
        public string InfoData { get; set; }
        public string OffSet { get; set; }
        public string NormalIcon { get; set; }
        public string AlarmIcon { get; set; }
        public int ZoomIcon { get; set; }
        public string ZoomNormalIcon { get; set; }
        public string ZoomAlarmIcon { get; set; }
        public string ZoomIconSize { get; set; }
        public string ZoomIconOffSet { get; set; }
        public string PopupSize { get; set; }
        public string BindCmd { get; set; }
        public string ProjectName { get; set; }

    }

}

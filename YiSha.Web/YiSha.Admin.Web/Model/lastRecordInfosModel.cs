using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YiSha.Admin.Web.Model
{
    public class lastRecordInfosModel
    {
        public int id { get; set; }
        public int taskId { get; set; }
        public List<Recitem> recItems { get; set; }
        public int tatolCount { get; set; }
        public int getCount { get; set; }
        public string expires { get; set; }
    }

    public class Recitem
    {
        public string ssrcId { get; set; }
        public string stream { get; set; }
        public string app { get; set; }
        public string vhost { get; set; }
        public int cSeq { get; set; }
        public mediaServerStreamInfo mediaServerStreamInfo { get; set; }
        public string pushStatus { get; set; }
        public string deviceID { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int secrecy { get; set; }
        public string type { get; set; }
    }

    public class mediaServerStreamInfo
    {
        public int rptPort { get; set; }
        public int streamPort { get; set; }
        public string startTime { get; set; }
        public object[] playUrl { get; set; }
        public bool isRecorded { get; set; }
        public object[] playerList { get; set; }
        public string noGb28181Key { get; set; }
    }

    public class NewRecordList
    {
        public int taskId { get; set; }
        public string ssrcId { get; set; }
        public string date_s { get; set; }
        public string date_e { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YiSha.Admin.Web.Model
{
    public class OnlineDeviceModel
    {
        public List<Videochannelmediainfo> videoChannelMediaInfo { get; set; }
        public Request request { get; set; }
        public int total { get; set; }
    }

    public class Request
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }

    public class Videochannelmediainfo
    {
        public Mediaserverstreaminfo mediaServerStreamInfo { get; set; }
        public int id { get; set; }
        public string mainId { get; set; }
        public string mediaServerId { get; set; }
        public string vhost { get; set; }
        public string app { get; set; }
        public string channelName { get; set; }
        public string departmentId { get; set; }
        public string departmentName { get; set; }
        public string pDepartmentId { get; set; }
        public string pDepartmentName { get; set; }
        public string deviceNetworkType { get; set; }
        public string deviceStreamType { get; set; }
        public string methodByGetStream { get; set; }
        public string videoDeviceType { get; set; }
        public bool autoVideo { get; set; }
        public bool autoRecord { get; set; }
        public string ipV4Address { get; set; }
        public string ipV6Address { get; set; }
        public bool hasPtz { get; set; }
        public string deviceId { get; set; }
        public string channelId { get; set; }
        public bool rtpWithTcp { get; set; }
        public bool defaultRtpPort { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
        public bool enabled { get; set; }
        public bool noPlayerBreak { get; set; }
    }

    public class Mediaserverstreaminfo
    {
        public string mediaServerId { get; set; }
        public string mediaServerIp { get; set; }
        public string streamIp { get; set; }
        public string _params { get; set; }
        public int rptPort { get; set; }
        public int streamPort { get; set; }
        public string startTime { get; set; }
        public string vhost { get; set; }
        public string app { get; set; }
        public string stream { get; set; }
        public string[] playUrl { get; set; }
        public int ssrc { get; set; }
        public bool isRecorded { get; set; }
        public string pushSocketType { get; set; }
        public object[] playerList { get; set; }
    }
}

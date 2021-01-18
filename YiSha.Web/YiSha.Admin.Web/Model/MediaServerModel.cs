using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YiSha.Admin.Web.Model
{
    public class MediaServerModel
    {
        public string ipV4Address { get; set; }
        public string ipV6Address { get; set; }
        public int keeperPort { get; set; }
        public string secret { get; set; }
        public string mediaServerId { get; set; }
        public int zlmediakitPid { get; set; }
        public string keepAliveTime { get; set; }
        public object[] recordPathList { get; set; }
        public int rtpPortMin { get; set; }
        public int rtpPortMax { get; set; }
        public Performanceinfo performanceInfo { get; set; }
        public bool isKeeperRunning { get; set; }
        public bool isMediaServerRunning { get; set; }
        public bool useSsl { get; set; }
        public int httpsPort { get; set; }
        public int rtmpsPort { get; set; }
        public int rtspsPort { get; set; }
        public int httpPort { get; set; }
        public int rtmpPort { get; set; }
        public int rtspPort { get; set; }
        public int zlmRecordFileSec { get; set; }
        public string accessKey { get; set; }
        public string serverDateTime { get; set; }
        public Config config { get; set; }
        public object[] mediaServerPlayerList { get; set; }
    }

    public class Performanceinfo
    {
        public string systemType { get; set; }
        public string architecture { get; set; }
        public string osName { get; set; }
        public string frameworkVersion { get; set; }
        public int cpuCores { get; set; }
        public Memoryinfo memoryInfo { get; set; }
        public float cpuLoad { get; set; }
        public Networkstat netWorkStat { get; set; }
        public Driveinfo[] driveInfo { get; set; }
        public string updateTime { get; set; }
    }

    public class Memoryinfo
    {
        public long total { get; set; }
        public long used { get; set; }
        public long free { get; set; }
        public float freePercent { get; set; }
        public string updateTime { get; set; }
    }

    public class Networkstat
    {
        public string mac { get; set; }
        public long totalSendBytes { get; set; }
        public long totalRecvBytes { get; set; }
        public long currentSendBytes { get; set; }
        public long currentRecvBytes { get; set; }
        public string updateTime { get; set; }
    }

    public class Driveinfo
    {
        public string name { get; set; }
        public bool isReady { get; set; }
        public long total { get; set; }
        public long used { get; set; }
        public long free { get; set; }
        public float freePercent { get; set; }
        public string updateTime { get; set; }
    }

    public class Config
    {
        public Datum[] data { get; set; }
        public int code { get; set; }
    }

    public class Datum
    {
        public string apiapiDebug { get; set; }
        public string apidefaultSnap { get; set; }
        public string apisecret { get; set; }
        public string apisnapRoot { get; set; }
        public string ffmpegbin { get; set; }
        public string ffmpegcmd { get; set; }
        public string ffmpeglog { get; set; }
        public string ffmpegsnap { get; set; }
        public string generaladdMuteAudio { get; set; }
        public string generalenableVhost { get; set; }
        public int generalflowThreshold { get; set; }
        public string generalfmp4_demand { get; set; }
        public string generalhls_demand { get; set; }
        public int generalmaxStreamWaitMS { get; set; }
        public string generalmediaServerId { get; set; }
        public int generalmergeWriteMs { get; set; }
        public string generalmodifyStamp { get; set; }
        public string generalpublishToHls { get; set; }
        public string generalpublishToMp4 { get; set; }
        public string generalresetWhenRePlay { get; set; }
        public string generalrtmp_demand { get; set; }
        public string generalrtsp_demand { get; set; }
        public int generalstreamNoneReaderDelayMS { get; set; }
        public string generalts_demand { get; set; }
        public string hlsbroadcastRecordTs { get; set; }
        public int hlsfileBufSize { get; set; }
        public string hlsfilePath { get; set; }
        public int hlssegDur { get; set; }
        public int hlssegNum { get; set; }
        public int hlssegRetain { get; set; }
        public string hookadmin_params { get; set; }
        public string hookenable { get; set; }
        public string hookon_flow_report { get; set; }
        public string hookon_http_access { get; set; }
        public string hookon_play { get; set; }
        public string hookon_publish { get; set; }
        public string hookon_record_mp4 { get; set; }
        public string hookon_record_ts { get; set; }
        public string hookon_rtsp_auth { get; set; }
        public string hookon_rtsp_realm { get; set; }
        public string hookon_server_started { get; set; }
        public string hookon_shell_login { get; set; }
        public string hookon_stream_changed { get; set; }
        public string hookon_stream_none_reader { get; set; }
        public string hookon_stream_not_found { get; set; }
        public int hooktimeoutSec { get; set; }
        public string httpcharSet { get; set; }
        public string httpdirMenu { get; set; }
        public int httpkeepAliveSecond { get; set; }
        public int httpmaxReqSize { get; set; }
        public string httpnotFound { get; set; }
        public int httpport { get; set; }
        public string httprootPath { get; set; }
        public int httpsendBufSize { get; set; }
        public int httpsslport { get; set; }
        public string multicastaddrMax { get; set; }
        public string multicastaddrMin { get; set; }
        public int multicastudpTTL { get; set; }
        public string recordappName { get; set; }
        public string recordfastStart { get; set; }
        public int recordfileBufSize { get; set; }
        public string recordfilePath { get; set; }
        public string recordfileRepeat { get; set; }
        public int recordfileSecond { get; set; }
        public int recordsampleMS { get; set; }
        public int rtmphandshakeSecond { get; set; }
        public int rtmpkeepAliveSecond { get; set; }
        public string rtmpmodifyStamp { get; set; }
        public int rtmpport { get; set; }
        public int rtmpsslport { get; set; }
        public int rtpaudioMtuSize { get; set; }
        public int rtpclearCount { get; set; }
        public int rtpcycleMS { get; set; }
        public int rtpmaxRtpCount { get; set; }
        public int rtpvideoMtuSize { get; set; }
        public string rtp_proxycheckSource { get; set; }
        public string rtp_proxydumpDir { get; set; }
        public int rtp_proxyport { get; set; }
        public int rtp_proxytimeoutSec { get; set; }
        public string rtspauthBasic { get; set; }
        public string rtspdirectProxy { get; set; }
        public int rtsphandshakeSecond { get; set; }
        public int rtspkeepAliveSecond { get; set; }
        public int rtspport { get; set; }
        public int rtspsslport { get; set; }
        public int shellmaxReqSize { get; set; }
        public int shellport { get; set; }
    }
}

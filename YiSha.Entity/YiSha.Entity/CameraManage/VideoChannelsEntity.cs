using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.CameraManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-01-18 10:53
    /// 描 述：设备列表实体类
    /// </summary>
    [Table("videochannels")]
    public class VideoChannelsEntity : BaseEntity
    {
        /// <summary>
        /// 设备的唯一ID
        /// </summary>
        /// <returns></returns>
        public string MainId { get; set; }
        /// <summary>
        /// 流媒体服务器ID
        /// </summary>
        /// <returns></returns>
        public string MediaServerId { get; set; }
        /// <summary>
        /// vhost
        /// </summary>
        /// <returns></returns>
        public string Vhost { get; set; }
        /// <summary>
        /// app
        /// </summary>
        /// <returns></returns>
        public string App { get; set; }
        /// <summary>
        /// 通道名称，整个系统唯一
        /// </summary>
        /// <returns></returns>
        public string ChannelName { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>
        /// <returns></returns>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        /// <returns></returns>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 上级部门代码
        /// </summary>
        /// <returns></returns>
        public string PDepartmentId { get; set; }
        /// <summary>
        /// 上级部门名称
        /// </summary>
        /// <returns></returns>
        public string PDepartmentName { get; set; }
        /// <summary>
        /// 设备的网络类型
        /// </summary>
        /// <returns></returns>
        public string DeviceNetworkType { get; set; }
        /// <summary>
        /// 设备的流类型
        /// </summary>
        /// <returns></returns>
        public string DeviceStreamType { get; set; }
        /// <summary>
        /// 使用哪种方式拉取非rtp设备的流
        /// </summary>
        /// <returns></returns>
        public string MethodByGetStream { get; set; }
        /// <summary>
        /// 设备类型，IPC,NVR,DVR
        /// </summary>
        /// <returns></returns>
        public string VideoDeviceType { get; set; }
        /// <summary>
        /// 是否自动启用推拉流
        /// </summary>
        /// <returns></returns>
        public bool? AutoVideo { get; set; }
        /// <summary>
        /// 是否自动启用录制计划
        /// </summary>
        /// <returns></returns>
        public bool? AutoRecord { get; set; }
        /// <summary>
        /// 录制计划模板名称
        /// </summary>
        /// <returns></returns>
        public string RecordPlanName { get; set; }
        /// <summary>
        /// 设备的ipv4地址
        /// </summary>
        /// <returns></returns>
        public string IpV4Address { get; set; }
        /// <summary>
        /// 设备的ipv6地址
        /// </summary>
        /// <returns></returns>
        public string IpV6Address { get; set; }
        /// <summary>
        /// 设备是否有云台控制
        /// </summary>
        /// <returns></returns>
        public bool? HasPtz { get; set; }
        /// <summary>
        /// GB28181设备的SipDevice.DeviceId
        /// </summary>
        /// <returns></returns>
        public string DeviceId { get; set; }
        /// <summary>
        /// GB28181设备的SipChannel.DeviceId
        /// </summary>
        /// <returns></returns>
        public string ChannelId { get; set; }
        /// <summary>
        /// Rtp设备是否使用Tcp推流
        /// </summary>
        /// <returns></returns>
        public bool? RtpWithTcp { get; set; }
        /// <summary>
        /// 非Rtp设备的视频流源地址
        /// </summary>
        /// <returns></returns>
        public string VideoSrcUrl { get; set; }
        /// <summary>
        /// Rtp设备是否使用流媒体默认rtp端口，如10000端口
        /// </summary>
        /// <returns></returns>
        public bool? DefaultRtpPort { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <returns></returns>
        public bool? Enabled { get; set; }
        /// <summary>
        /// 无人观察时断开流端口，此字段为true时AutoVideo字段必须为Flase
        /// 如果AutoVideo为true,则此字段无效
        /// </summary>
        /// <returns></returns>
        public bool? NoPlayerBreak { get; set; }
    }
}

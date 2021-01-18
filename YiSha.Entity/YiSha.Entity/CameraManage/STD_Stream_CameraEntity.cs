using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.CameraManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-17 22:05
    /// 描 述：设备管理实体类
    /// </summary>
    [Table("Camera")]
    public class STD_Stream_CameraEntity : BaseEntity
    {
        /// <summary>
        /// 摄像头台账ID
        /// </summary>
        /// <returns></returns>
        public string SpjkTZID { get; set; }
        /// <summary>
        /// 摄像头实例ID(自动生成，全局唯一，添加摄像头实例时写null或空字符串)
        /// </summary>
        /// <returns></returns>
        public string CameraId { get; set; }
        /// <summary>
        /// 摄像头名称，添加摄像头实例或者修改摄像头实例时可修改
        /// </summary>
        /// <returns></returns>
        public string CameraName { get; set; }
        /// <summary>
        /// 是否为移动摄像头，如果是移动摄像头，将不再判定它的ip地址是否一致
        /// </summary>
        /// <returns></returns>
        public bool? MobileCamera { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>
        /// <returns></returns>
        public string DeptId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 父部门代码
        /// </summary>
        /// <returns></returns>
        public string PDetpId { get; set; }
        /// <summary>
        /// 父部门名称
        /// </summary>
        /// <returns></returns>
        public string PDetpName { get; set; }
        /// <summary>
        /// 摄像头ip地址
        /// </summary>
        /// <returns></returns>
        public string CameraIpAddress { get; set; }
        /// <summary>
        /// GB28181设备的音视频通道ID
        /// </summary>
        /// <returns></returns>
        public string CameraChannelLable { get; set; }
        /// <summary>
        /// GB28181设备的设备ID
        /// </summary>
        /// <returns></returns>
        public string CameraDeviceLable { get; set; }
        /// <summary>
        /// 摄像头类型GB28181=GB28181设备Rtsp=RTSP设备LiveCast=直播设备None=未知设备
        /// </summary>
        /// <returns></returns>
        public string CameraType { get; set; }
        /// <summary>
        /// 摄像头实例的RTSP地址，如果是RTSP设备，必须填写此地址
        /// </summary>
        /// <returns></returns>
        public string IfRtspUrl { get; set; }
        /// <summary>
        /// 如果是GB28181设备，此项为True时，采用TCP的方式推流，否则采用UDP方式。此项参数与摄备是否支持TCP推流有关，如果不支持TCP推流则使此项参数为False。
        /// </summary>
        /// <returns></returns>
        public bool? IfGb28181Tcp { get; set; }
        /// <summary>
        /// 流媒体服务器ID，指定将音视频流推向哪个流媒体节点
        /// </summary>
        /// <returns></returns>
        public string PushMediaServerId { get; set; }
        /// <summary>
        /// 是否启用自动推流，系统自动发生摄像头是否在线，如果在线且EnableLive为true,系统将自动尝试推流
        /// </summary>
        /// <returns></returns>
        public bool? EnableLive { get; set; }
        /// <summary>
        /// 是否允许PTZ控制（仅支持GB28181设备）
        /// </summary>
        /// <returns></returns>
        public bool? EnablePtz { get; set; }
        /// <summary>
        /// 摄像头实例的创建时间（自动填写，添加时写null即可）
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 摄像头实例的更新时间（自动填写，添加时写null即可）
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// GB28181设备上线时，如果数据库中不存在此设备及通道信息，系统会自动将设备及通道信息写入数据库同时将Activated设备为false,需要通过接口激活这类设备
        /// </summary>
        /// <returns></returns>
        public bool? Activated { get; set; }
    }
}

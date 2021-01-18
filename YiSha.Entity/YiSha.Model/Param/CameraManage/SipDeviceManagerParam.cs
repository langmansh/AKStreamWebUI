using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.CameraManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-17 22:05
    /// 描 述：Sip设备列表查询类
    /// </summary>
    public class SipDeviceManagerParam
    {
        public string deviceID { get; set; }
        public string parentID { get; set; }
        public string sipCameraStatus { get; set; }
    }
}

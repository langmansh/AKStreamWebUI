using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.CameraManage;
using YiSha.Business.CameraManage;
using YiSha.Model.Param.CameraManage;
using Newtonsoft.Json;

namespace YiSha.Admin.Web.Areas.CameraManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-17 22:05
    /// 描 述：设备管理控制器类
    /// </summary>
    [Area("CameraManage")]
    public class CameraSessionManagerController : BaseController
    {
        private STD_Stream_CameraBLL sTD_Stream_CameraBLL = new STD_Stream_CameraBLL();

        #region 视图功能
        [AuthorizeFilter("camera:camerasessionmanager:view")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 获取数据
        ///// <summary>
        ///// 获取流媒体服务列表
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult GetPushMediaList()
        //{
        //    string result = HttpHelper.HttpGet(GlobalContext.SystemConfig.MediaServerUrl + "/System/GetMediaServerList");
        //    var mediaInfo = JsonConvert.DeserializeObject<List<MediaServer>>(result);
        //    TData<List<MediaServer>> obj = new TData<List<MediaServer>>();
        //    obj.Data = mediaInfo;
        //    return Json(obj);
        //}
        /// <summary>
        /// 在线设备列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CameraSessionList(CameraSessionManagerParam param, Pagination pagination)
        {
            TData<List<CameraSession>> obj = new TData<List<CameraSession>>();
            if (param.mediaServerId == "-1")
            {
                obj.Tag = -1;
                obj.Message = "请选择流媒体服务！";
                return Json(obj);
            }
            
            string result = HttpHelper.HttpGet(GlobalContext.SystemConfig.MediaServerUrl + "/MediaServer/GetCameraSessionList?mediaServerId="+ param.mediaServerId);
            var camerasessionlist = JsonConvert.DeserializeObject<List<CameraSession>>(result);
            if (!string.IsNullOrEmpty(param.SpjkTZID))
            {
                camerasessionlist = camerasessionlist.Where(t => t.spjkTZID.Equals(param.SpjkTZID)).ToList();
            }
            obj.Data = camerasessionlist;
            obj.Tag = 1;
            obj.Total = camerasessionlist.Count;
            return Json(obj);
        }
        #endregion

        #region 提交数据

        #endregion
    }

    #region 在线设备列表
    public class CameraSession
    {
        public string cameraId { get; set; }
        public string spjkTZID { get; set; }
        public string mediaServerId { get; set; }
        public string cameraName { get; set; }
        public string cameraDeptId { get; set; }
        public string cameraDeptName { get; set; }
        public string cameraPDeptId { get; set; }
        public string cameraPDeptName { get; set; }
        public string cameraType { get; set; }
        public string clientType { get; set; }
        public Cameraex cameraEx { get; set; }
        public bool isOnline { get; set; }
        public bool isRecord { get; set; }
        public string playUrl { get; set; }
        public string cameraIpAddress { get; set; }
        public float upTime { get; set; }
        public string onlineTime { get; set; }
        public string vhost { get; set; }
        public string app { get; set; }
        public string streamId { get; set; }
        public string mediaServerIp { get; set; }
        public bool forceOffline { get; set; }
    }

    public class Cameraex
    {
        public string mediaServerId { get; set; }
        public string ctype { get; set; }
        public string vhost { get; set; }
        public string app { get; set; }
        public long? streamId { get; set; }
        public string streamServerIp { get; set; }
        public int streamServerPort { get; set; }
        public string sipCameraStatus { get; set; }
        public string pushStreamSocketType { get; set; }
        public Camera camera { get; set; }
        public object inputUrl { get; set; }
    }

    public class Camera
    {
        public int id { get; set; }
        public string ctype { get; set; }
        public object channelID { get; set; }
        public string name { get; set; }
        public string deviceID { get; set; }
        public object nvrID { get; set; }
        public string status { get; set; }
        public int recordStatus { get; set; }
        public object frameRate { get; set; }
        public object audioFomate { get; set; }
        public object videoFomate { get; set; }
        public object realStreamType { get; set; }
        public object cache { get; set; }
        public object longitude { get; set; }
        public object latitude { get; set; }
        public string adddress { get; set; }
        public int isPTZ { get; set; }
        public string endTime { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string owner { get; set; }
        public string civilCode { get; set; }
        public object block { get; set; }
        public int parental { get; set; }
        public int accessType { get; set; }
        public string parentID { get; set; }
        public int safetyWay { get; set; }
        public int registerWay { get; set; }
        public object certNum { get; set; }
        public int certifiable { get; set; }
        public int errCode { get; set; }
        public int secrecy { get; set; }
        public string ipAddress { get; set; }
        public int port { get; set; }
        public object password { get; set; }
        public object ptzType { get; set; }
        public object positionType { get; set; }
        public object roomType { get; set; }
        public object userType { get; set; }
        public object supplyLightType { get; set; }
        public object directionType { get; set; }
        public object resolution { get; set; }
        public object businessGroupID { get; set; }
        public object downloadSpeed { get; set; }
        public object svcSpaceSupportMode { get; set; }
        public object svcTimeSupportMode { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
        public object rtspMain { get; set; }
        public object rtspSub { get; set; }
        public object subordinatePlatform { get; set; }
        public object rtmpStreamKey { get; set; }
        public object exAttribute { get; set; }
        public object voiceTwoWay { get; set; }
    }
    #endregion





}

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
    public class PlaySessionManagerController : BaseController
    {
        private STD_Stream_CameraBLL sTD_Stream_CameraBLL = new STD_Stream_CameraBLL();

        #region 视图功能
        [AuthorizeFilter("camera:playsession:view")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 流媒体服务列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> PlaySessionList(PlaySessionManagerParam param, Pagination pagination)
        {
            TData<List<player>> obj = new TData<List<player>>();
            if (param.mediaServerId == "-1")
            {
                obj.Tag = -1;
                obj.Message = "请选择流媒体服务！";
                return Json(obj);
            }
            
            string result = HttpHelper.HttpGet(GlobalContext.SystemConfig.MediaServerUrl + "/MediaServer/GetPlayerSessionList?mediaServerId=" + param.mediaServerId);
            var playsessionlist = JsonConvert.DeserializeObject<List<player>>(result);

            obj.Data = playsessionlist;
            obj.Tag = 1;
            obj.Total = playsessionlist.Count;
            return Json(obj);
        }
        #endregion

        #region 提交数据

        #endregion
    }

    #region 播放列表
    public class player
    {
        public string cameraId { get; set; }
        public string mediaServerId { get; set; }
        public string clientType { get; set; }
        public string playUrl { get; set; }
        public string playerIp { get; set; }
        public float upTime { get; set; }
        public string onlineTime { get; set; }
        public string vhost { get; set; }
        public string app { get; set; }
        public string streamId { get; set; }
        public string mediaServerIp { get; set; }
        public string sessionId { get; set; }
    }

    #endregion





}

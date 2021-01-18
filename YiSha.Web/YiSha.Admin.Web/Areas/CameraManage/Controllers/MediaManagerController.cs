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
using YiSha.Admin.Web.Model;

namespace YiSha.Admin.Web.Areas.CameraManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-17 22:05
    /// 描 述：设备管理控制器类
    /// </summary>
    [Area("CameraManage")]
    public class MediaManagerController : BaseController
    {
        private STD_Stream_CameraBLL sTD_Stream_CameraBLL = new STD_Stream_CameraBLL();

        #region 视图功能
        [AuthorizeFilter("camera:mediamanager:view")]
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
        public async Task<ActionResult> MediaServerList(MediaManagerParam param, Pagination pagination)
        {
            TData<List<MediaServerModel>> obj = new TData<List<MediaServerModel>>();
            string result = HttpHelper.HttpGet(GlobalContext.SystemConfig.MediaServerUrl + "/MediaServer/GetMediaServerList");
            var medialist = JsonConvert.DeserializeObject<List<MediaServerModel>>(result);

            obj.Data = medialist;
            obj.Tag = 1;
            obj.Total = medialist.Count;
            return Json(obj);
        }
        #endregion

        #region 提交数据

        #endregion
    }

    #region 流媒体服务列表
    public class Rootobject
    {
        public MediaObject[] Property1 { get; set; }
    }

    public class MediaObject
    {
        public string ipaddress { get; set; }
        public int webApiPort { get; set; }
        public int mediaServerHttpPort { get; set; }
        public string secret { get; set; }
        public bool isRunning { get; set; }
        public bool health { get; set; }
        public float uptime { get; set; }
        public string mediaServerId { get; set; }
        public string updateTime { get; set; }
        public string keepAlive { get; set; }
        public string recordFilePath { get; set; }
        //public Config config { get; set; }
    }

    #endregion





}

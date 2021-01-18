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
            TData<List<Videochannelmediainfo>> obj = new TData<List<Videochannelmediainfo>>();
            var pJson = new
            {
                pageIndex = 1,
                pageSize = 16
            };
            var result = await HttpHelper.Post(GlobalContext.SystemConfig.MediaServerUrl + "/MediaServer/GetOnlineStreamInfoList", JsonConvert.SerializeObject(pJson));
            OnlineDeviceModel camerasessionlist = result.ToObject<OnlineDeviceModel>();

            obj.Data = camerasessionlist.videoChannelMediaInfo;
            obj.Tag = 1;
            obj.Total = camerasessionlist.total;
            return Json(obj);
        }
        #endregion

        #region 提交数据

        #endregion
    }





}

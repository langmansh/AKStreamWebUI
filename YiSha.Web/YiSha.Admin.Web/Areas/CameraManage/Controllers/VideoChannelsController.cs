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
    /// 日 期：2021-01-18 10:53
    /// 描 述：设备列表控制器类
    /// </summary>
    [Area("CameraManage")]
    public class VideoChannelsController :  BaseController
    {
        private VideoChannelsBLL videoChannelsBLL = new VideoChannelsBLL();

        #region 视图功能
        [AuthorizeFilter("camera:videochannels:view")]
        public ActionResult VideoChannelsIndex()
        {
            return View();
        }

        public ActionResult VideoChannelsForm()
        {
            return View();
        }

        public ActionResult LiveVideo()
        {
            return View();
        }

        public ActionResult DeviceActived()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("camera:videochannels:search")]
        public async Task<ActionResult> GetListJson(VideoChannelsListParam param)
        {
            TData<List<VideoChannelsEntity>> obj = await videoChannelsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("camera:videochannels:search")]
        public async Task<ActionResult> GetPageListJson(VideoChannelsListParam param, Pagination pagination)
        {
            TData<List<VideoChannelsEntity>> obj = await videoChannelsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<VideoChannelsEntity> obj = await videoChannelsBLL.GetEntity(id);
            return Json(obj);
        }

        /// <summary>
        /// 获取流媒体服务列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMediaList()
        {
            string result = HttpHelper.HttpGet(GlobalContext.SystemConfig.MediaServerUrl + "/MediaServer/GetMediaServerList");
            var mediaInfo = JsonConvert.DeserializeObject<List<MediaServerModel>>(result);
            TData<List<MediaServerModel>> obj = new TData<List<MediaServerModel>>();
            obj.Data = mediaInfo;
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("camera:videochannels:add,camera:videochannels:edit")]
        public async Task<ActionResult> SaveFormJson(VideoChannelsEntity entity)
        {
            TData<string> obj = await videoChannelsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("camera:videochannels:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await videoChannelsBLL.DeleteForm(ids);
            return Json(obj);
        }

        /// <summary>
        /// 激活设备
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthorizeFilter("camera:videochannels:actived")]
        public async Task<ActionResult> ActiveCamera(VideoChannelsEntity entity)
        {
            var result = HttpMethods.Post(GlobalContext.SystemConfig.MediaServerUrl + "/MediaServer/ActiveVideoChannel?mainId=" + entity.MainId, JsonConvert.SerializeObject(entity));
            return Json(result);
        }

        [HttpGet]
        [AuthorizeFilter("camera:videochannels:play")]
        public async Task<ActionResult> LiveVideoPlay(string MediaServerId, string MainId)
        {
            string apiUrl = GlobalContext.SystemConfig.MediaServerUrl + "/MediaServer/StreamLive?mediaServerId=" + MediaServerId + "&mainId=" + MainId;
            string result = HttpMethods.Get(apiUrl);
            return Json(result);
        }
        #endregion
    }
}

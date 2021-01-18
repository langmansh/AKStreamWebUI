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
using YiSha.Model.Result;

namespace YiSha.Admin.Web.Areas.CameraManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-17 22:05
    /// 描 述：设备管理控制器类
    /// </summary>
    [Area("CameraManage")]
    public class SipDeviceManagerController : BaseController
    {
        private STD_Stream_CameraBLL sTD_Stream_CameraBLL = new STD_Stream_CameraBLL();

        #region 视图功能
        [AuthorizeFilter("camera:sipdevicemanager:view")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        ///Sip设备列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SipDeviceList()
        {
            List<ZtreeInfo> sipdevicelist = new List<ZtreeInfo>();
            //获取deciveID
            var deciveidList = await sTD_Stream_CameraBLL.GetDeciveIdList();
            if (deciveidList != null || deciveidList.Count() > 0)
            {
                foreach (var item in deciveidList)
                {
                    string result = HttpMethods.Get(GlobalContext.SystemConfig.MediaServerUrl + "/SipGate/GetSipDeviceList?cameraDeviceLable=" + item.CameraDeviceLable);
                    List<SipDevice> sipdlist = JsonConvert.DeserializeObject<List<SipDevice>>(result);
                    if (sipdlist.Count() > 0)
                    {
                        ZtreeInfo ztree = new ZtreeInfo();
                        ztree.pId = 0;
                        ztree.id = long.Parse(sipdlist[0].crC32);
                        ztree.name = sipdlist[0].deviceId;
                        sipdevicelist.Add(ztree);
                    }
                }
            }

            TData<List<ZtreeInfo>> obj = new TData<List<ZtreeInfo>>();

            obj.Data = sipdevicelist;
            obj.Tag = 1;
            obj.Total = sipdevicelist.Count;
            return Json(obj);
        }

        /// <summary>
        ///Sip设备列表明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SipDeviceDetailList(SipDeviceManagerParam param)
        {
            string channelid = param.deviceID;
            string deviceid = param.parentID;
            string sipstatue = param.sipCameraStatus;
            List<CameraItem> cameraitem = new List<CameraItem>();
            string result = HttpMethods.Get(GlobalContext.SystemConfig.MediaServerUrl + "/SipGate/GetSipDeviceList?cameraDeviceLable=" + deviceid);
            List<SipDevice> sipdlist = JsonConvert.DeserializeObject<List<SipDevice>>(result);
            Cameraexlist[] cml = new Cameraexlist[] { };
            if (sipdlist.Count() > 0)
            {
                cml = sipdlist[0].cameraExList;
                if (!string.IsNullOrEmpty(sipstatue))
                {
                    switch (sipstatue)
                    {
                        case "1":
                            cml = sipdlist[0].cameraExList.Where(t => t.sipCameraStatus.Equals("RealVideo")).ToArray();
                            break;
                        case "0":
                            cml = sipdlist[0].cameraExList.Where(t => t.sipCameraStatus.Equals("Idle")).ToArray();
                            break;
                        default:
                            break;
                    }
                    
                }
                if (!string.IsNullOrEmpty(channelid))
                {
                    cml = cml.Where(t => t.camera.deviceID.Equals(channelid)).ToArray();
                }
                if (!string.IsNullOrEmpty(deviceid))
                {
                    cml = cml.Where(t => t.camera.parentID.Equals(deviceid)).ToArray();
                }
                foreach (var item in cml)
                {
                    item.camera.sipCameraStatus = item.sipCameraStatus;
                    item.camera.streamId = item.streamId;
                    item.camera.mediaServerId = item.mediaServerId;
                    item.camera.pushStreamSocketType = item.pushStreamSocketType;
                    item.camera.streamServerIp = item.streamServerIp;
                    item.camera.streamServerPort = item.streamServerPort;
                    cameraitem.Add(item.camera);
                }
            }
   
            TData<List<CameraItem>> obj = new TData<List<CameraItem>>();

            obj.Data = cameraitem;
            obj.Tag = 1;
            obj.Total = cameraitem.Count;
            return Json(obj);
        }
        #endregion

        #region 提交数据

        #endregion
    }

    #region Sip设备列表
    public class SipDevice
    {
        public string crC32 { get; set; }
        public string deviceId { get; set; }
        public string ipAddress { get; set; }
        public int sipPort { get; set; }
        public Lastsiprequest lastSipRequest { get; set; }
        public Cameraexlist[] cameraExList { get; set; }
        public string lastKeepAliveTime { get; set; }
        public string sipDeviceStatus { get; set; }
        public Alarmlist alarmList { get; set; }
        public string lastUpdateTime { get; set; }
    }

    public class Lastsiprequest
    {
    }

    public class Alarmlist
    {
    }

    public class Cameraexlist
    {
        public string mediaServerId { get; set; }
        public string ctype { get; set; }
        public string vhost { get; set; }
        public string app { get; set; }
        public string streamId { get; set; }
        public string streamServerIp { get; set; }
        public int streamServerPort { get; set; }
        public string sipCameraStatus { get; set; }
        public object pushStreamSocketType { get; set; }
        public CameraItem camera { get; set; }
        public object inputUrl { get; set; }
    }

    public class CameraItem
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
        public string safetyWay { get; set; }
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
        public string sipCameraStatus { get; set; }
        public string streamId { get; set; }
        public string mediaServerId { get; set; }
        public object pushStreamSocketType { get; set; }
        public string streamServerIp { get; set; }
        public int? streamServerPort { get; set; }
    }


    #endregion





}

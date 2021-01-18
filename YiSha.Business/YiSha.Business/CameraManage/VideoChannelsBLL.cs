using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.CameraManage;
using YiSha.Model.Param.CameraManage;
using YiSha.Service.CameraManage;

namespace YiSha.Business.CameraManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-01-18 10:53
    /// 描 述：设备列表业务类
    /// </summary>
    public class VideoChannelsBLL
    {
        private VideoChannelsService videoChannelsService = new VideoChannelsService();

        #region 获取数据
        public async Task<TData<List<VideoChannelsEntity>>> GetList(VideoChannelsListParam param)
        {
            TData<List<VideoChannelsEntity>> obj = new TData<List<VideoChannelsEntity>>();
            obj.Data = await videoChannelsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<VideoChannelsEntity>>> GetPageList(VideoChannelsListParam param, Pagination pagination)
        {
            TData<List<VideoChannelsEntity>> obj = new TData<List<VideoChannelsEntity>>();
            obj.Data = await videoChannelsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<VideoChannelsEntity>> GetEntity(long id)
        {
            TData<VideoChannelsEntity> obj = new TData<VideoChannelsEntity>();
            obj.Data = await videoChannelsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(VideoChannelsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await videoChannelsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await videoChannelsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}

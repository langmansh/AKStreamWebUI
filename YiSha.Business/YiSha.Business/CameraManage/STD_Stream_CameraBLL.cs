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
    /// 日 期：2020-12-17 22:05
    /// 描 述：设备管理业务类
    /// </summary>
    public class STD_Stream_CameraBLL
    {
        private STD_Stream_CameraService sTD_Stream_CameraService = new STD_Stream_CameraService();

        #region 获取数据
        public async Task<TData<List<STD_Stream_CameraEntity>>> GetList(STD_Stream_CameraListParam param)
        {
            TData<List<STD_Stream_CameraEntity>> obj = new TData<List<STD_Stream_CameraEntity>>();
            obj.Data = await sTD_Stream_CameraService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<STD_Stream_CameraEntity>>> GetPageList(STD_Stream_CameraListParam param, Pagination pagination)
        {
            TData<List<STD_Stream_CameraEntity>> obj = new TData<List<STD_Stream_CameraEntity>>();
            obj.Data = await sTD_Stream_CameraService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<STD_Stream_CameraEntity>> GetEntity(long id)
        {
            TData<STD_Stream_CameraEntity> obj = new TData<STD_Stream_CameraEntity>();
            obj.Data = await sTD_Stream_CameraService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<List<STD_Stream_CameraEntity>> GetDeciveIdList()
        {
            return await sTD_Stream_CameraService.GetDeciveIdList();
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(STD_Stream_CameraEntity entity)
        {
            TData<string> obj = new TData<string>();
            await sTD_Stream_CameraService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await sTD_Stream_CameraService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}

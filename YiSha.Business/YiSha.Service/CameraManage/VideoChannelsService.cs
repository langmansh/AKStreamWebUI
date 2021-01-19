using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.CameraManage;
using YiSha.Model.Param.CameraManage;

namespace YiSha.Service.CameraManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-01-18 10:53
    /// 描 述：设备列表服务类
    /// </summary>
    public class VideoChannelsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<VideoChannelsEntity>> GetList(VideoChannelsListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<VideoChannelsEntity>> GetPageList(VideoChannelsListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<List<VideoChannelsEntity>> GetBackPageListJson(VideoChannelsListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<VideoChannelsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<VideoChannelsEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(VideoChannelsEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<VideoChannelsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<VideoChannelsEntity, bool>> ListFilter(VideoChannelsListParam param)
        {
            var expression = LinqExtensions.True<VideoChannelsEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.MainId))
                {
                    expression = expression.And(t => t.MainId.Contains(param.MainId));
                }
            }
            return expression;
        }
        #endregion
    }
}

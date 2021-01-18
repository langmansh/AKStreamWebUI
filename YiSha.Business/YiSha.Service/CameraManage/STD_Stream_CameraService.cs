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
    /// 日 期：2020-12-17 22:05
    /// 描 述：设备管理服务类
    /// </summary>
    public class STD_Stream_CameraService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<STD_Stream_CameraEntity>> GetList(STD_Stream_CameraListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<STD_Stream_CameraEntity>> GetPageList(STD_Stream_CameraListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<STD_Stream_CameraEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<STD_Stream_CameraEntity>(id);
        }

        public async Task<List<STD_Stream_CameraEntity>> GetDeciveIdList()
        {
            var strSql = new StringBuilder();
            strSql.Append("SELECT distinct ");
            strSql.Append(@"
                t.CameraDeviceLable
                ");
            strSql.Append("  FROM Camera t ");
            strSql.Append("  WHERE 1=1 ");

            var list = await this.BaseRepository().FindList<STD_Stream_CameraEntity>(strSql.ToString());
            return list.ToList();
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(STD_Stream_CameraEntity entity)
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
            await this.BaseRepository().Delete<STD_Stream_CameraEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<STD_Stream_CameraEntity, bool>> ListFilter(STD_Stream_CameraListParam param)
        {
            var expression = LinqExtensions.True<STD_Stream_CameraEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.SpjkTZID))
                {
                    expression = expression.And(t => t.SpjkTZID.Equals(param.SpjkTZID));
                }
                if (!string.IsNullOrEmpty(param.ActivedStatus) && param.ActivedStatus != "-1")
                {
                    if (param.ActivedStatus == "0")
                    {
                        expression = expression.And(t => t.CameraId.Contains("unknow") && t.PushMediaServerId.Contains("unknow"));
                    }
                    else
                    {
                        expression = expression.And(t => !t.CameraId.Contains("unknow") && !t.PushMediaServerId.Contains("unknow"));
                    }
                }
            }
            return expression;
        }
        #endregion
    }
}

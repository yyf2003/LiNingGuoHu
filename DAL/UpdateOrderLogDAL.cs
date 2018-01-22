using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Data;

namespace LN.DAL
{
    public class UpdateOrderLogDAL
    {
        public int Add(LN.Model.UpdateOrderLog model)
        {
            string sql = "insert into UpdateOrderLog(PromotionId,StoryBagId,AreaId,UpdateMsg) values(@PromotionId,@StoryBagId,@AreaId,@UpdateMsg);select @@identity";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@PromotionId",model.PromotionId),
                new SqlParameter("@StoryBagId",model.StoryBagId),
                new SqlParameter("@AreaId",model.AreaId),
                new SqlParameter("@UpdateMsg",model.UpdateMsg)
               
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, paras);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public void Update(LN.Model.UpdateOrderLog model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update UpdateOrderLog set ");
            if (model != null)
            {
                List<SqlParameter> paraList = new List<SqlParameter>();
                if (model.AreaId != null)
                {
                    sql.Append(" AreaId=@AreaId,");
                    paraList.Add(new SqlParameter("@AreaId", model.AreaId));
                }
                if (model.PromotionId != null)
                {
                    sql.Append(" PromotionId=@PromotionId,");
                    paraList.Add(new SqlParameter("@PromotionId", model.PromotionId));
                }
                if (model.StoryBagId != null)
                {
                    sql.Append(" StoryBagId=@StoryBagId,");
                    paraList.Add(new SqlParameter("@StoryBagId", model.StoryBagId));
                }
                if (model.UpdateMsg != null)
                {
                    sql.Append(" UpdateMsg=@UpdateMsg,");
                    paraList.Add(new SqlParameter("@UpdateMsg", model.UpdateMsg));
                }
                string sql1 = sql.ToString().TrimEnd(',');
                if (model.Id != null)
                {
                    sql1 += " where Id=@Id";
                    paraList.Add(new SqlParameter("@Id", model.Id));
                    DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql1, paraList.ToArray());
                }
            }
        }

        public DataSet GetList(string where)
        {
            string sql = "select UpdateOrderLog.*,PromotionSonStoryBag.StoryBagName,DepartMentInfo.department from UpdateOrderLog join PromotionSonStoryBag on PromotionSonStoryBag.Id=UpdateOrderLog.StoryBagId join DepartMentInfo on DepartMentInfo.ID=UpdateOrderLog.AreaId";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where "+where;
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }

    }
}

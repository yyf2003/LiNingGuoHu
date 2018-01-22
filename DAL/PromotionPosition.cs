using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    public class PromotionPosition
    {
        public int Add(LN.Model.PromotionPosition model)
        {
            string sql = "insert into PromotionPosition(PromotionId,ProductLineId,Level,Position) values(@PromotionId,@ProductLineId,@Level,@Position);select @@identity";
            SqlParameter[] parameters = new SqlParameter[] { 
               new SqlParameter("@PromotionId",model.PromotionId),
               new SqlParameter("@ProductLineId",model.ProductLineId),
               new SqlParameter("@Level",model.Level),
               new SqlParameter("@Position",model.Position)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, parameters);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public DataSet GetList(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from PromotionPosition");
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where " + where);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public bool Update(LN.Model.PromotionPosition model)
        {
            StringBuilder sql = new StringBuilder();
            List<SqlParameter> paraList = new List<SqlParameter>();
            sql.Append("update PromotionPosition set ");
            if (model != null)
            {
                if (model.Level != null)
                {
                    sql.Append(" Level=@Level,");
                    paraList.Add(new SqlParameter("@Level", model.Level));
                }
                if (model.Position != null)
                {
                    sql.Append(" Position=@Position,");
                    paraList.Add(new SqlParameter("@Position", model.Position));
                }
                string sql1 = sql.ToString().TrimEnd(',');
                if (model.Id != null)
                {
                    sql1 += " where Id=@Id ";
                    paraList.Add(new SqlParameter("@Id", model.Id));
                    return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql1, paraList.ToArray()) > 0;
                }
                else
                    return false;
            }
            else
                return false;
        }
        
          
    }
}

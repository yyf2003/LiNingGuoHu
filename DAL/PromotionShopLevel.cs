using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Collections.Generic;//请先添加引用

namespace LN.DAL
{
    public class PromotionShopLevel
    {
        public DataSet GetList(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,ShopLevelName,ShortName,RackLimitCount from PromotionShopLevel");
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql.Append(" where "+where);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public void Update(LN.Model.PromotionShopLevel model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update PromotionShopLevel set ");
            if (model != null)
            {
                List<SqlParameter> paraList = new List<SqlParameter>();
                if (model.RackLimitCount != null)
                {
                    sql.Append(" RackLimitCount=@RackLimitCount,");
                    paraList.Add(new SqlParameter("@RackLimitCount",model.RackLimitCount));
                }
                if (model.ShopLevelName != null)
                {
                    sql.Append(" ShopLevelName=@ShopLevelName,");
                    paraList.Add(new SqlParameter("@ShopLevelName", model.ShopLevelName));
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
using LN.Model;

namespace LN.DAL
{
    public class RackLimitCountDAL
    {
        public int Add(RackLimitCount model)
        {
            string sql = "insert into RackLimitCount(ShopLevelId,RackSeatId,Count,ShopType) values(@ShopLevelId,@RackSeatId,@Count,@ShopType);select @@identity";
            SqlParameter[] para = new SqlParameter[] { 
               new SqlParameter("@ShopLevelId",model.ShopLevelId),
               new SqlParameter("@RackSeatId",model.RackSeatId),
               new SqlParameter("@Count",model.Count),
               new SqlParameter("@ShopType",model.ShopType)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, para);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public void Update(RackLimitCount model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update RackLimitCount set ");
            if (model != null)
            {
                List<SqlParameter> paraList = new List<SqlParameter>();
                if (model.Count != null)
                {
                    sql.Append(" Count=@Count,");
                    paraList.Add(new SqlParameter("@Count",model.Count));
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
            string sql = "select RackLimitCount.*,PromotionShopLevel.ShortName,POPSeat.seat from RackLimitCount join PromotionShopLevel on PromotionShopLevel.Id=RackLimitCount.ShopLevelId join POPSeat on POPSeat.SeatID=RackLimitCount.RackSeatId";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(),sql);
        }

        public RackLimitCount GetModel(string where)
        {
            string sql = "select top 1 * from RackLimitCount";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sql);
            RackLimitCount model=null;
            if (reader.Read())
            {
                model = new RackLimitCount();
                model.Id = int.Parse(reader["Id"].ToString());
                if (!string.IsNullOrWhiteSpace(reader["ShopLevelId"].ToString()))
                    model.ShopLevelId = int.Parse(reader["ShopLevelId"].ToString());
                else
                    model.ShopLevelId = 0;
                model.RackSeatId = int.Parse(reader["RackSeatId"].ToString());
                if (!string.IsNullOrWhiteSpace(reader["Count"].ToString()))
                    model.Count = int.Parse(reader["Count"].ToString());
                else
                    model.Count = 0;
                model.ShopType = reader["ShopType"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return model;
        }
    }
}

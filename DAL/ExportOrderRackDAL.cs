using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LN.DBUtility;//请先添加引用
using LN.Model;

namespace LN.DAL
{
    public class ExportOrderRackDAL
    {
        public int Add(ExportOrderRack model)
        {
            string sql = "insert into ExportOrderRack(PromitionId,StoryBagId,ShopLevelId,RackIds) values(@PromitionId,@StoryBagId,@ShopLevelId,@RackIds);select @@identity";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",model.PromitionId),
               new SqlParameter("@StoryBagId",model.StoryBagId),
               new SqlParameter("@ShopLevelId",model.ShopLevelId),
               new SqlParameter("@RackIds",model.RackIds)
               
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, paras);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public void Delete(int promitionId, int stortBagId, int shopLevelId)
        {
            string sql = "delete from ExportOrderRack where PromitionId=@PromitionId and StoryBagId=@StoryBagId and ShopLevelId=@ShopLevelId";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",promitionId),
               new SqlParameter("@StoryBagId",stortBagId),
               new SqlParameter("@ShopLevelId",shopLevelId)
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras);
        }

        public void Delete1(int promitionId, string stortBagIds, int shopLevelId)
        {
            string sql = "delete from ExportOrderRack where PromitionId=@PromitionId and StoryBagId in(" + stortBagIds + ") and ShopLevelId=@ShopLevelId";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",promitionId),
               //new SqlParameter("@StoryBagId",stortBagIds),
               new SqlParameter("@ShopLevelId",shopLevelId)
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras);
        }

        public ExportOrderRack GetModel(string where)
        {
            string sql = "select top 1 * from ExportOrderRack";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sql);
            ExportOrderRack model = null;
            if (reader.Read())
            {
                model = new ExportOrderRack();
                if (!string.IsNullOrWhiteSpace(reader["Id"].ToString()))
                    model.Id = int.Parse(reader["Id"].ToString());
                if (!string.IsNullOrWhiteSpace(reader["PromitionId"].ToString()))
                    model.PromitionId = int.Parse(reader["PromitionId"].ToString());
                if (!string.IsNullOrWhiteSpace(reader["StoryBagId"].ToString()))
                    model.StoryBagId = int.Parse(reader["StoryBagId"].ToString());
                if (!string.IsNullOrWhiteSpace(reader["ShopLevelId"].ToString()))
                    model.ShopLevelId = int.Parse(reader["ShopLevelId"].ToString());
                model.RackIds = reader["RackIds"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return model;
        }
    }
}

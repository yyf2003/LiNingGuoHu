using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LN.DBUtility;
using LN.Model;

namespace LN.DAL
{
    public class ExportOriginalOrderRackDAL
    {
        public int Add(ExportOriginalOrderRack model)
        {
            string sql = "insert into ExportOriginalOrderRack(PromitionId,StoryBagId,ShopLevelId,RackIds) values(@PromitionId,@StoryBagId,@ShopLevelId,@RackIds);select @@identity";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",model.PromitionId),
               new SqlParameter("@StoryBagId",model.StoryBagId),
               new SqlParameter("@ShopLevelId",model.ShopLevelId),
               new SqlParameter("@RackIds",model.RackIds)
               
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

        public void Delete(int promitionId, int stortBagId, int shopLevelId)
        {
            string sql = "delete from ExportOriginalOrderRack where PromitionId=@PromitionId and StoryBagId=@StoryBagId and ShopLevelId=@ShopLevelId";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",promitionId),
               new SqlParameter("@StoryBagId",stortBagId),
               new SqlParameter("@ShopLevelId",shopLevelId)
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras);
        }

        public ExportOriginalOrderRack GetModel(string where)
        {
            string sql = "select top 1 * from ExportOriginalOrderRack";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sql);
            ExportOriginalOrderRack model = null;
            if (reader.Read())
            {
                model = new ExportOriginalOrderRack();
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

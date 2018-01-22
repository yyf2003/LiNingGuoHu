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
    public class RepeatShopInUpdateOrderDAL
    {
        public int Add(RepeatShopInUpdateOrder model)
        {
            string sql = "insert into RepeatShopInUpdateOrder(PromitionId,StoryBagId,ShopLevel,BigArea,ShopNo,RepeatNum) values(@PromitionId,@StoryBagId,@ShopLevel,@BigArea,@ShopNo,@RepeatNum);select @@identity";
            SqlParameter[] paras = new SqlParameter[] {
               new SqlParameter("@PromitionId",model.PromitionId),
               new SqlParameter("@StoryBagId",model.StoryBagId),
               new SqlParameter("@ShopLevel",model.ShopLevel),
               new SqlParameter("@BigArea",model.BigArea),
               new SqlParameter("@ShopNo",model.ShopNo),
               new SqlParameter("@RepeatNum",model.RepeatNum)
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

        

        public void Delete(int promitionId, int stortBagId)
        {
            string sql = "delete from RepeatShopInUpdateOrder where PromitionId=@PromitionId and StoryBagId=@StoryBagId";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",promitionId),
               new SqlParameter("@StoryBagId",stortBagId)
               
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras);
        }

        public DataSet GetList(int PromitionId, int StoryBagId)
        {
            string sql = "select * from RepeatShopInUpdateOrder where PromitionId=@PromitionId and StoryBagId=@StoryBagId order by ShopLevel";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",PromitionId),
               new SqlParameter("@StoryBagId",StoryBagId)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paras);
        }

        public DataSet GetList1(int PromitionId, string StoryBagIds)
        {
            if (string.IsNullOrWhiteSpace(StoryBagIds))
                StoryBagIds = "0";
            string sql = "select * from RepeatShopInUpdateOrder where PromitionId=@PromitionId and StoryBagId in(" + StoryBagIds + ") order by ShopLevel";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@PromitionId",PromitionId)
               
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paras);
        }

    }
}

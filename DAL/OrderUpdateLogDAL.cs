using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Data;

namespace LN.DAL
{
    public class OrderUpdateLogDAL
    {
        public int Add(LN.Model.OrderUpdateLog model)
        {
            string sql = "insert into OrderUpdateLog(PromotionId,StoryBagId,Region,RegionId,ShopLevel,TotalRecord,SuccessNum,FailNum,RepeatNum,BigArea) values(@PromotionId,@StoryBagId,@Region,@RegionId,@ShopLevel,@TotalRecord,@SuccessNum,@FailNum,@RepeatNum,@BigArea);select @@identity";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@PromotionId",model.PromotionId),
                new SqlParameter("@StoryBagId",model.StoryBagId),
                new SqlParameter("@Region",model.Region),
                new SqlParameter("@RegionId",model.RegionId),
                new SqlParameter("@ShopLevel",model.ShopLevel),
                new SqlParameter("@TotalRecord",model.TotalRecord),
                new SqlParameter("@SuccessNum",model.SuccessNum),
                new SqlParameter("@FailNum",model.FailNum),
                new SqlParameter("@RepeatNum",model.RepeatNum),
                new SqlParameter("@BigArea",model.BigArea)
               
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

        public void delete(int promotionId, int storyBagId, string bigArea)
        {
            string sql = "delete from OrderUpdateLog where PromotionId=@PromotionId and StoryBagId=@StoryBagId and BigArea=@BigArea";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@PromotionId",promotionId),
                new SqlParameter("@StoryBagId",storyBagId),
                new SqlParameter("@BigArea",bigArea)
                
               
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras);
        }

        public DataSet GetList(string where)
        {
            string sql = @"
                        select Promotion.PromotionName
                        ,PromotionSonStoryBag.StoryBagName
                        ,DepartMentInfo.department
                        ,OrderUpdateLog.ShopLevel
                        ,OrderUpdateLog.TotalRecord
                        ,OrderUpdateLog.SuccessNum
                        ,OrderUpdateLog.FailNum
                        ,OrderUpdateLog.RepeatNum
                        from OrderUpdateLog
                        join Promotion on Promotion.Id = OrderUpdateLog.PromotionId
                        join PromotionSonStoryBag on PromotionSonStoryBag.Id=OrderUpdateLog.StoryBagId
                        join DepartMentInfo on DepartMentInfo.ID=OrderUpdateLog.RegionId

                          ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where "+where;
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }
    }
}

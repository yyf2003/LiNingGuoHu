using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Data;
using System.Text;


namespace LN.DAL
{
    public class PromotionProductLines
    {
        public PromotionProductLines() { }

        public int Add(LN.Model.PromotionProductLines model)
        {
            string sql = "insert into PromotionProductLines(PromotionId,ProductLineId) values(@PromotionId,@ProductLineId);select @@identity";
            SqlParameter[] parameters = new SqlParameter[] {
               new SqlParameter("@PromotionId",model.PromotionId),
               new SqlParameter("@ProductLineId",model.ProductLineId)
             
            };
            object obj= DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, parameters);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public void DeleteByPromotionId(string PromotionId)
        {
            string sql = "delete from PromotionProductLines where PromotionId=@PromotionId";
            SqlParameter[] parameters = new SqlParameter[] {
               new SqlParameter("@PromotionId",PromotionId)
               
             
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, parameters); 
        }

        public void DeleteById(int Id)
        {
            string sql = "delete from PromotionProductLines where Id=@Id";
            SqlParameter[] parameters = new SqlParameter[] {
               new SqlParameter("@Id",Id)
               
             
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, parameters);
        }

        public DataSet GetList(string where)
        {
            StringBuilder sql = new System.Text.StringBuilder();
            sql.Append("select PromotionProductLines.Id, PromotionProductLines.ProductLineId,ProductLineType.ProductTypeID,ProductLineData.ProductLine,ProductLineType.ProductTypeName from PromotionProductLines join ProductLineData on ProductLineData.ProductLineID=PromotionProductLines.ProductLineId join ProductLineType on ProductLineData.TypeId=ProductLineType.ProductTypeID");
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where "+where);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }


    }
}

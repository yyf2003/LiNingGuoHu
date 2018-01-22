using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LN.DBUtility;

namespace LN.DAL
{
    public class PromotionPOPOrder
    {
        public int Add(LN.Model.PromotionPOPOrder model)
        {
            string sql = @"insert into PromotionPOPOrder(ShopID,SeatNum,POPseat,SeatDesc,RealHeight,RealWith,POPHeight,POPWith,POPPlwz,
                           POPPljd,POPArea,POPMaterial,ProductTypeId,ProductLineID,Sexarea,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong,
                           SysTime,AddState,POPMaterialRemark,IsHide,PromotionId) values(@ShopID,@SeatNum,@POPseat,@SeatDesc,@RealHeight,@RealWith,
                           @POPHeight,@POPWith,@POPPlwz,@POPPljd,@POPArea,@POPMaterial,@ProductTypeId,@ProductLineID,@Sexarea,@TwoSided,@Glass,@PlatformWith,
                           @PlatformHeight,@PlatformLong,@SysTime,@AddState,@POPMaterialRemark,@IsHide,@PromotionId);select @@identity";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@ShopID",model.ShopID),
               new SqlParameter("@SeatNum",model.SeatNum),
               new SqlParameter("@POPseat",model.POPseat),
               new SqlParameter("@SeatDesc",model.SeatDesc),
               new SqlParameter("@RealHeight",model.RealHeight),
               new SqlParameter("@RealWith",model.RealWith),
               new SqlParameter("@POPHeight",model.POPHeight),
               new SqlParameter("@POPWith",model.POPWith),
               new SqlParameter("@POPPlwz",model.POPPlwz),
               new SqlParameter("@POPPljd",model.POPPljd),
               new SqlParameter("@POPArea",model.POPArea),
               new SqlParameter("@POPMaterial",model.POPMaterial),
               new SqlParameter("@ProductTypeId",model.ProductTypeId),
               new SqlParameter("@ProductLineID",model.ProductLineID),
               new SqlParameter("@Sexarea",model.Sexarea),
               new SqlParameter("@TwoSided",model.TwoSided),
               new SqlParameter("@Glass",model.Glass),
               new SqlParameter("@PlatformWith",model.PlatformWith),
               new SqlParameter("@PlatformHeight",model.PlatformHeight),
               new SqlParameter("@PlatformLong",model.PlatformLong),
               new SqlParameter("@SysTime",model.SysTime),
               new SqlParameter("@AddState",model.AddState),
               new SqlParameter("@POPMaterialRemark",model.POPMaterialRemark),
               new SqlParameter("@IsHide",model.IsHide),
               new SqlParameter("@PromotionId",model.PromotionId)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, paras);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public DataSet GetList(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from View_PromotionPOPOrder ");
            if (!string.IsNullOrEmpty(where))
            {
                sql.Append(" where "+where);
            }
            sql.Append(" order by PosID,ProductTypeId");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }

        public DataSet LoadOut(string where)
        {
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@where",where)
            };
            return DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "Pro_LoadOutPromotionOrder", paras, "table1");
        }

        public bool DeleteByPromotionId(int pid)
        {
            string sql = "delete from PromotionPOPOrder where PromotionId=@PromotionId";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@PromotionId",pid)
            };
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras) > 0;
        }

        public bool DeleteById(int id)
        {
            string sql = "delete from PromotionPOPOrder where ID=@ID";
            SqlParameter[] paras = new SqlParameter[] { 
              new SqlParameter("@ID",id)
            };
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras) > 0;
        }

        public int GetPageCount(string where)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from PromotionPOPOrder where 1=1 " + where);
            
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql.ToString());
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public DataSet GetPage(string where, int currPage, int pageSize)
        {
            string sql = "select * from (select row_number() over(order by ShopId) row,* from View_PromotionPOPOrder where 1=1 " + where + " ) temp where row between ((@currPage-1)*@pageSize+1) and (@currPage*@pageSize)";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@currPage",currPage),
               new SqlParameter("@pageSize",pageSize)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paras);
        }

        public bool Update(LN.Model.PromotionPOPOrder model)
        {
            StringBuilder sql = new StringBuilder();
            List<SqlParameter> paraList = new List<SqlParameter>();
            sql.Append("update PromotionPOPOrder set ");
            if (model != null)
            {
                if (model.IsConfirm != null)
                {
                    sql.Append(" IsConfirm=@IsConfirm,");
                    paraList.Add(new SqlParameter("@IsConfirm", model.IsConfirm));
                }
                string sql1 = sql.ToString().TrimEnd(',');
                if (model.ID != null)
                {
                    sql1 += " where ID=@ID";
                    paraList.Add(new SqlParameter("@ID", model.ID));
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

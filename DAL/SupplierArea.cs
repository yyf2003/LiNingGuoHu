using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;
using System.Data;

namespace LN.DAL
{
    public class SupplierArea
    {
        public int Add(LN.Model.SupplierArea model)
        {
            string sql = "insert into SupplierArea(SupplierId,DepartmentId,ProvinceId) values(@SupplierId,@DepartmentId,@ProvinceId); select @@identity";
            SqlParameter[] parameters = new SqlParameter[] { 
              new SqlParameter("@SupplierId",model.SupplierId),
              new SqlParameter("@DepartmentId",model.DepartmentId),
              new SqlParameter("@ProvinceId",model.ProvinceId)
             
            };
            object obj= DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, parameters);
            return obj != null ? int.Parse(obj.ToString()) : 0;
        }

        public DataSet GetList(string whereStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SupplierArea ");
            if (whereStr.Trim() != "")
            {
                strSql.Append(" where " + whereStr);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        public bool DeleteBySuppliterId(int supplierId)
        {
            string sql = "delete from SupplierArea where SupplierId=" + supplierId;
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql) > 0;
        }

        public DataSet GetAreaBySupplierId(int id)
        {
            string sql = "select SupplierArea.ProvinceId,SupplierArea.DepartmentId,ProvinceData.ProvinceName from SupplierArea left join ProvinceData on ProvinceData.ProvinceID=SupplierArea.ProvinceId where SupplierArea.SupplierId=" + id;
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }
    }
}

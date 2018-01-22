using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    public class ProvinceInDepartment
    {
        public DataSet GetProvincesByDid(int id)
        {
            string sql = "select ProvinceInDepartment.ProvinceId,ProvinceData.ProvinceName from ProvinceInDepartment join ProvinceData on ProvinceData.ProvinceID=ProvinceInDepartment.ProvinceId where DepartmentId=" + id;
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }

        public DataSet GetList(string where)
        {
            string sql = "select ProvinceInDepartment.ProvinceId,ProvinceData.ProvinceName from ProvinceInDepartment join ProvinceData on ProvinceData.ProvinceID=ProvinceInDepartment.ProvinceId";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql);
        }
    }
}

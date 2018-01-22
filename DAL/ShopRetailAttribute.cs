using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
using System.Collections.Generic;

namespace LN.DAL
{
    /// <summary>
    /// 数据访问类ShopRetailAttribute。
    /// </summary>
    public class ShopRetailAttribute
    {
        public ShopRetailAttribute(){}

		#region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ShopRetailAttribute GetModel(int SA_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SA_Id,SA_Name from ShopRetailAttribute ");
            strSql.Append(" where SA_Id=@SA_Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@SA_Id", SqlDbType.Int,4)};
            parameters[0].Value = SA_Id;

            LN.Model.ShopRetailAttribute model = new LN.Model.ShopRetailAttribute();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.SA_Id = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.SA_Name = reader.GetString(1);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.ShopRetailAttribute> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SA_Id,SA_Name ");
            strSql.Append(" FROM ShopRetailAttribute ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.ShopRetailAttribute model = null;
            List<LN.Model.ShopRetailAttribute> modellist = new List<LN.Model.ShopRetailAttribute>();
            while (reader.Read())
            {
                model = new LN.Model.ShopRetailAttribute();

                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.SA_Id = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.SA_Name = reader.GetString(1);
                }
                modellist.Add(model);
            }

            return modellist;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<LN.Model.ShopRetailAttribute> GetList(int TopNum, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (TopNum > 0)
            {
                strSql.Append(" top " + TopNum.ToString());
            }
            strSql.Append(" SA_Id,SA_Name ");
            strSql.Append(" FROM ShopRetailAttribute ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.ShopRetailAttribute model = null;
            List<LN.Model.ShopRetailAttribute> modellist = new List<LN.Model.ShopRetailAttribute>();
            while (reader.Read())
            {
                model = new LN.Model.ShopRetailAttribute();

                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.SA_Id = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.SA_Name = reader.GetString(1);
                }
                modellist.Add(model);
            }

            return modellist;
        }

        #endregion
    }
}

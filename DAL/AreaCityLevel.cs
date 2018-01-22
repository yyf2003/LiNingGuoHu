using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类AreaCityLevel。
	/// </summary>
	public class AreaCityLevel
	{
		public AreaCityLevel()
		{}
		#region  成员方法


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.AreaCityLevel GetModel(int ACL_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ACL_Id,ACL_Name from AreaCityLevel where ACL_Id=@ACL_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@ACL_Id", SqlDbType.Int,4)};
			parameters[0].Value = ACL_Id;

			LN.Model.AreaCityLevel model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(reader.Read())
			{
                model = new LN.Model.AreaCityLevel();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ACL_Id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.ACL_Name = reader.GetString(1);
			}
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.AreaCityLevel> GetList(string strWhere)
		{
            IList<LN.Model.AreaCityLevel> list = new List<LN.Model.AreaCityLevel>();

			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ACL_Id,ACL_Name FROM AreaCityLevel ");
			if(strWhere.Trim() != "")
			{
				strSql.Append(" where "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.AreaCityLevel model = new LN.Model.AreaCityLevel();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ACL_Id = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.ACL_Name = reader.GetString(1);
                list.Add(model);
            }
            reader.Close();
            return list;
		}

		#endregion  成员方法
	}
}


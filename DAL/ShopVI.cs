using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
using System.Collections.Generic;
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ShopVI。
	/// </summary>
	public class ShopVI
	{
		public ShopVI()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ShopVIID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ShopVI");
			strSql.Append(" where ShopVIID=@ShopVIID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopVIID", SqlDbType.Int,4)};
			parameters[0].Value = ShopVIID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.ShopVI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ShopVI(");
			strSql.Append("ShopVIName)");
			strSql.Append(" values (");
			strSql.Append("@ShopVIName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopVIName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ShopVIName;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ShopVI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ShopVI set ");
			strSql.Append("ShopVIName=@ShopVIName");
			strSql.Append(" where ShopVIID=@ShopVIID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopVIID", SqlDbType.Int,4),
					new SqlParameter("@ShopVIName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ShopVIID;
			parameters[1].Value = model.ShopVIName;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ShopVIID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShopVI ");
			strSql.Append(" where ShopVIID=@ShopVIID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopVIID", SqlDbType.Int,4)};
			parameters[0].Value = ShopVIID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ShopVI GetModel(int ShopVIID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ShopVIID,ShopVIName from ShopVI ");
			strSql.Append(" where ShopVIID=@ShopVIID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopVIID", SqlDbType.Int,4)};
			parameters[0].Value = ShopVIID;

			LN.Model.ShopVI model=new LN.Model.ShopVI();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.ShopVIID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.ShopVIName = reader.GetString(1);
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
        public List<LN.Model.ShopVI> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ShopVIID,ShopVIName ");
			strSql.Append(" FROM ShopVI ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.ShopVI model = null;
            List<LN.Model.ShopVI> modellist = new List<LN.Model.ShopVI>();
            while (reader.Read())
            {
                model = new LN.Model.ShopVI();

                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.ShopVIID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.ShopVIName = reader.GetString(1);
                }
                modellist.Add(model);
            }

            return modellist;
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public List<LN.Model.ShopVI> GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ShopVIID,ShopVIName ");
			strSql.Append(" FROM ShopVI ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.ShopVI model = null;
            List<LN.Model.ShopVI> modellist = new List<LN.Model.ShopVI>();
            while (reader.Read())
            {
                model = new LN.Model.ShopVI();

                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.ShopVIID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.ShopVIName = reader.GetString(1);
                }
                modellist.Add(model);
            }

            return modellist;
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "ShopVI";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}


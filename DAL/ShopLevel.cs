using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ShopLevel。
	/// </summary>
	public class ShopLevel
	{
		public ShopLevel()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "LevelID", "ShopLevel"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LevelID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ShopLevel");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.ShopLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ShopLevel(");
			strSql.Append("ShopLevel)");
			strSql.Append(" values (");
			strSql.Append("@ShopLevel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopLevel", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ShopLevelName;

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
		public void Update(LN.Model.ShopLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ShopLevel set ");
			strSql.Append("ShopLevel=@ShopLevel");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4),
					new SqlParameter("@ShopLevel", SqlDbType.VarChar,20)};
			parameters[0].Value = model.LevelID;
			parameters[1].Value = model.ShopLevelName;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int LevelID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ShopLevel ");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ShopLevel GetModel(int LevelID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LevelID,ShopLevel from ShopLevel ");
			strSql.Append(" where LevelID=@LevelID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelID", SqlDbType.Int,4)};
			parameters[0].Value = LevelID;

			LN.Model.ShopLevel model=new LN.Model.ShopLevel();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LevelID"].ToString()!="")
				{
					model.LevelID=int.Parse(ds.Tables[0].Rows[0]["LevelID"].ToString());
				}
				model.ShopLevelName=ds.Tables[0].Rows[0]["ShopLevel"].ToString();
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LevelID,ShopLevel ");
			strSql.Append(" FROM ShopLevel ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
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
			parameters[0].Value = "ShopLevel";
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


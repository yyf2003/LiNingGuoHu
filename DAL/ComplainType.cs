using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ComplainType。
	/// </summary>
	public class ComplainType
	{
		public ComplainType()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "tID", "ComplainType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int tID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ComplainType");
			strSql.Append(" where tID=@tID ");
			SqlParameter[] parameters = {
					new SqlParameter("@tID", SqlDbType.Int,4)};
			parameters[0].Value = tID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.ComplainType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ComplainType(");
			strSql.Append("tName)");
			strSql.Append(" values (");
			strSql.Append("@tName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tName", SqlDbType.VarChar,100)};
			parameters[0].Value = model.tName;

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
		public void Update(LN.Model.ComplainType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ComplainType set ");
			strSql.Append("tName=@tName");
			strSql.Append(" where tID=@tID ");
			SqlParameter[] parameters = {
					new SqlParameter("@tID", SqlDbType.Int,4),
					new SqlParameter("@tName", SqlDbType.VarChar,100)};
			parameters[0].Value = model.tID;
			parameters[1].Value = model.tName;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int tID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ComplainType ");
			strSql.Append(" where tID=@tID ");
			SqlParameter[] parameters = {
					new SqlParameter("@tID", SqlDbType.Int,4)};
			parameters[0].Value = tID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ComplainType GetModel(int tID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 tID,tName from ComplainType ");
			strSql.Append(" where tID=@tID ");
			SqlParameter[] parameters = {
					new SqlParameter("@tID", SqlDbType.Int,4)};
			parameters[0].Value = tID;

			LN.Model.ComplainType model=new LN.Model.ComplainType();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["tID"].ToString()!="")
				{
					model.tID=int.Parse(ds.Tables[0].Rows[0]["tID"].ToString());
				}
				model.tName=ds.Tables[0].Rows[0]["tName"].ToString();
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
			strSql.Append("select tID,tName ");
			strSql.Append(" FROM ComplainType ");
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
			parameters[0].Value = "ComplainType";
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


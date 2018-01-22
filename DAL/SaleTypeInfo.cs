using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类SaleTypeInfo。
	/// </summary>
	public class SaleTypeInfo
	{
		public SaleTypeInfo()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SaleTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SaleTypeInfo");
			strSql.Append(" where SaleTypeID=@SaleTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4)};
			parameters[0].Value = SaleTypeID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.SaleTypeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SaleTypeInfo(");
			strSql.Append("SaleType)");
			strSql.Append(" values (");
			strSql.Append("@SaleType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SaleType", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.SaleType;

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
		public void Update(LN.Model.SaleTypeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SaleTypeInfo set ");
			strSql.Append("SaleType=@SaleType");
			strSql.Append(" where SaleTypeID=@SaleTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4),
					new SqlParameter("@SaleType", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.SaleTypeID;
			parameters[1].Value = model.SaleType;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SaleTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete SaleTypeInfo ");
			strSql.Append(" where SaleTypeID=@SaleTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4)};
			parameters[0].Value = SaleTypeID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.SaleTypeInfo GetModel(int SaleTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SaleTypeID,SaleType from SaleTypeInfo ");
			strSql.Append(" where SaleTypeID=@SaleTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4)};
			parameters[0].Value = SaleTypeID;

			LN.Model.SaleTypeInfo model=new LN.Model.SaleTypeInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SaleTypeID"].ToString()!="")
				{
					model.SaleTypeID=int.Parse(ds.Tables[0].Rows[0]["SaleTypeID"].ToString());
				}
				model.SaleType=ds.Tables[0].Rows[0]["SaleType"].ToString();
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
			strSql.Append("select SaleTypeID,SaleType ");
			strSql.Append(" FROM SaleTypeInfo ");
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
			parameters[0].Value = "SaleTypeInfo";
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


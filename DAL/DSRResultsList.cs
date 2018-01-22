using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类DSRResultsList。
	/// </summary>
	public class DSRResultsList
	{
		public DSRResultsList()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "DSRResultsList"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DSRResultsList");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.DSRResultsList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DSRResultsList(");
			strSql.Append("DataID,CheckRulesID,CheckResults,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@DataID,@CheckRulesID,@CheckResults,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DataID", SqlDbType.VarChar,50),
					new SqlParameter("@CheckRulesID", SqlDbType.Int,4),
					new SqlParameter("@CheckResults", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.DataID;
			parameters[1].Value = model.CheckRulesID;
			parameters[2].Value = model.CheckResults;
			parameters[3].Value = model.Remarks;

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
		public void Update(LN.Model.DSRResultsList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DSRResultsList set ");
			strSql.Append("DataID=@DataID,");
			strSql.Append("CheckRulesID=@CheckRulesID,");
			strSql.Append("CheckResults=@CheckResults,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@DataID", SqlDbType.VarChar,50),
					new SqlParameter("@CheckRulesID", SqlDbType.Int,4),
					new SqlParameter("@CheckResults", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.DataID;
			parameters[2].Value = model.CheckRulesID;
			parameters[3].Value = model.CheckResults;
			parameters[4].Value = model.Remarks;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete DSRResultsList ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.DSRResultsList GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,DataID,CheckRulesID,CheckResults,Remarks from DSRResultsList ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.DSRResultsList model=new LN.Model.DSRResultsList();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.DataID=ds.Tables[0].Rows[0]["DataID"].ToString();
				if(ds.Tables[0].Rows[0]["CheckRulesID"].ToString()!="")
				{
					model.CheckRulesID=int.Parse(ds.Tables[0].Rows[0]["CheckRulesID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CheckResults"].ToString()!="")
				{
					model.CheckResults=int.Parse(ds.Tables[0].Rows[0]["CheckResults"].ToString());
				}
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
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
            strSql.Append("select DSRCheckType, DSRRules, CheckResults,Remarks, ");
             strSql.Append(" DataID,CheckRulesID ");
            strSql.Append(" FROM View_DSRResultsList ");
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
			parameters[0].Value = "DSRResultsList";
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


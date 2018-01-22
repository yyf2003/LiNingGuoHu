using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����DSRCheckRules��
	/// </summary>
	public class DSRCheckRules
	{
		public DSRCheckRules()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RulesID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DSRCheckRules");
			strSql.Append(" where RulesID=@RulesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RulesID", SqlDbType.Int,4)};
			parameters[0].Value = RulesID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LN.Model.DSRCheckRules model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DSRCheckRules(");
			strSql.Append("DSRCheckType,DSRRules,RulesState)");
			strSql.Append(" values (");
			strSql.Append("@DSRCheckType,@DSRRules,@RulesState)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DSRCheckType", SqlDbType.NChar,20),
					new SqlParameter("@DSRRules", SqlDbType.NVarChar,300),
					new SqlParameter("@RulesState", SqlDbType.Int,4)};
			parameters[0].Value = model.DSRCheckType;
			parameters[1].Value = model.DSRRules;
			parameters[2].Value = model.RulesState;

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
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.DSRCheckRules model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DSRCheckRules set ");
			strSql.Append("DSRCheckType=@DSRCheckType,");
			strSql.Append("DSRRules=@DSRRules,");
			strSql.Append("RulesState=@RulesState");
			strSql.Append(" where RulesID=@RulesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RulesID", SqlDbType.Int,4),
					new SqlParameter("@DSRCheckType", SqlDbType.NChar,20),
					new SqlParameter("@DSRRules", SqlDbType.NVarChar,300),
					new SqlParameter("@RulesState", SqlDbType.Int,4)};
			parameters[0].Value = model.RulesID;
			parameters[1].Value = model.DSRCheckType;
			parameters[2].Value = model.DSRRules;
			parameters[3].Value = model.RulesState;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int RulesID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete DSRCheckRules ");
			strSql.Append(" where RulesID=@RulesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RulesID", SqlDbType.Int,4)};
			parameters[0].Value = RulesID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.DSRCheckRules GetModel(int RulesID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RulesID,DSRCheckType,DSRRules,RulesState from DSRCheckRules ");
			strSql.Append(" where RulesID=@RulesID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RulesID", SqlDbType.Int,4)};
			parameters[0].Value = RulesID;

			LN.Model.DSRCheckRules model=new LN.Model.DSRCheckRules();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RulesID"].ToString()!="")
				{
					model.RulesID=int.Parse(ds.Tables[0].Rows[0]["RulesID"].ToString());
				}
				model.DSRCheckType=ds.Tables[0].Rows[0]["DSRCheckType"].ToString();
				model.DSRRules=ds.Tables[0].Rows[0]["DSRRules"].ToString();
				if(ds.Tables[0].Rows[0]["RulesState"].ToString()!="")
				{
					model.RulesState=int.Parse(ds.Tables[0].Rows[0]["RulesState"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RulesID,DSRCheckType,DSRRules,RulesState ");
			strSql.Append(" FROM DSRCheckRules ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "DSRCheckRules";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}


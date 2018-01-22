using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����SupplierAssignRule��
	/// </summary>
	public class SupplierAssignRule
	{
		public SupplierAssignRule()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "AssignRuleID", "SupplierAssignRule"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int AssignRuleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SupplierAssignRule");
			strSql.Append(" where AssignRuleID=@AssignRuleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4)};
			parameters[0].Value = AssignRuleID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LN.Model.SupplierAssignRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SupplierAssignRule(");
			strSql.Append("AssignRule,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@AssignRule,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignRule", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.AssignRule;
			parameters[1].Value = model.Remarks;

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
		public void Update(LN.Model.SupplierAssignRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SupplierAssignRule set ");
			strSql.Append("AssignRule=@AssignRule,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where AssignRuleID=@AssignRuleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4),
					new SqlParameter("@AssignRule", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.AssignRuleID;
			parameters[1].Value = model.AssignRule;
			parameters[2].Value = model.Remarks;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AssignRuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete SupplierAssignRule ");
			strSql.Append(" where AssignRuleID=@AssignRuleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4)};
			parameters[0].Value = AssignRuleID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.SupplierAssignRule GetModel(int AssignRuleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AssignRuleID,AssignRule,Remarks from SupplierAssignRule ");
			strSql.Append(" where AssignRuleID=@AssignRuleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4)};
			parameters[0].Value = AssignRuleID;

			LN.Model.SupplierAssignRule model=new LN.Model.SupplierAssignRule();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AssignRuleID"].ToString()!="")
				{
					model.AssignRuleID=int.Parse(ds.Tables[0].Rows[0]["AssignRuleID"].ToString());
				}
				model.AssignRule=ds.Tables[0].Rows[0]["AssignRule"].ToString();
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
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
			strSql.Append("select AssignRuleID,AssignRule,Remarks ");
			strSql.Append(" FROM SupplierAssignRule ");
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
			parameters[0].Value = "SupplierAssignRule";
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


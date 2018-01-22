using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����POPScaleData��
	/// </summary>
	public class POPScaleData
	{
		public POPScaleData()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "PhotoScaleID", "POPScaleData"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PhotoScaleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POPScaleData");
			strSql.Append(" where PhotoScaleID=@PhotoScaleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoScaleID", SqlDbType.Int,4)};
			parameters[0].Value = PhotoScaleID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LN.Model.POPScaleData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POPScaleData(");
			strSql.Append("PhotoScale)");
			strSql.Append(" values (");
			strSql.Append("@PhotoScale)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoScale", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PhotoScale;

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
		public void Update(LN.Model.POPScaleData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POPScaleData set ");
			strSql.Append("PhotoScale=@PhotoScale");
			strSql.Append(" where PhotoScaleID=@PhotoScaleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoScaleID", SqlDbType.Int,4),
					new SqlParameter("@PhotoScale", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PhotoScaleID;
			parameters[1].Value = model.PhotoScale;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PhotoScaleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPScaleData ");
			strSql.Append(" where PhotoScaleID=@PhotoScaleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoScaleID", SqlDbType.Int,4)};
			parameters[0].Value = PhotoScaleID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.POPScaleData GetModel(int PhotoScaleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PhotoScaleID,PhotoScale from POPScaleData ");
			strSql.Append(" where PhotoScaleID=@PhotoScaleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoScaleID", SqlDbType.Int,4)};
			parameters[0].Value = PhotoScaleID;

			LN.Model.POPScaleData model=new LN.Model.POPScaleData();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PhotoScaleID"].ToString()!="")
				{
					model.PhotoScaleID=int.Parse(ds.Tables[0].Rows[0]["PhotoScaleID"].ToString());
				}
				model.PhotoScale=ds.Tables[0].Rows[0]["PhotoScale"].ToString();
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
			strSql.Append("select PhotoScaleID,PhotoScale ");
			strSql.Append(" FROM POPScaleData ");
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
			parameters[0].Value = "POPScaleData";
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


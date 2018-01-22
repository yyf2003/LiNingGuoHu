using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
using System.Collections.Generic;
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����ShopType��
	/// </summary>
	public class ShopType
	{
		public ShopType()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ShopType");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LN.Model.ShopType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ShopType(");
			strSql.Append("ShopTypename)");
			strSql.Append(" values (");
			strSql.Append("@ShopTypename)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ShopTypename", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ShopTypename;

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
		public void Update(LN.Model.ShopType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ShopType set ");
			strSql.Append("ShopTypename=@ShopTypename");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ShopTypename", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ShopTypename;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShopType ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.ShopType GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ShopTypename from ShopType ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.ShopType model=new LN.Model.ShopType();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
				if(!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
				{
                    model.ID = reader.GetInt32(0);
				}
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.ShopTypename = reader.GetString(1);
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
        public List<LN.Model.ShopType> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ShopTypename ");
			strSql.Append(" FROM ShopType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.ShopType model = null;
            List<LN.Model.ShopType> modellist = new List<LN.Model.ShopType>();
            while (reader.Read())
            {
                model = new LN.Model.ShopType();

                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.ID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.ShopTypename = reader.GetString(1);
                }
                modellist.Add(model);
            }

            return modellist;
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
        public List<LN.Model.ShopType> GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,ShopTypename ");
			strSql.Append(" FROM ShopType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            LN.Model.ShopType model = null;
            List<LN.Model.ShopType> modellist = new List<LN.Model.ShopType>();
            while (reader.Read())
            {
                model = new LN.Model.ShopType();

                if (!String.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.ID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.ShopTypename = reader.GetString(1);
                }
                modellist.Add(model);
            }

            return modellist;
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
			parameters[0].Value = "ShopType";
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


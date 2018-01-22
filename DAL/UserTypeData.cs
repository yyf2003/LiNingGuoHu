using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����UserTypeData��
	/// </summary>
	public class UserTypeData
	{
		public UserTypeData()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "UserTypeData"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserTypeData");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(LN.Model.UserTypeData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserTypeData(");
			strSql.Append("UserTypeID,Usertype)");
			strSql.Append(" values (");
			strSql.Append("@UserTypeID,@Usertype)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserTypeID", SqlDbType.Int,4),
					new SqlParameter("@Usertype", SqlDbType.VarChar,20)};
			parameters[0].Value = model.UserTypeID;
			parameters[1].Value = model.Usertype;

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
		public void Update(LN.Model.UserTypeData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserTypeData set ");
			strSql.Append("UserTypeID=@UserTypeID,");
			strSql.Append("Usertype=@Usertype");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserTypeID", SqlDbType.Int,4),
					new SqlParameter("@Usertype", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserTypeID;
			parameters[2].Value = model.Usertype;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete UserTypeData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.UserTypeData GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserTypeID,Usertype from UserTypeData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.UserTypeData model=new LN.Model.UserTypeData();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserTypeID"].ToString()!="")
				{
					model.UserTypeID=int.Parse(ds.Tables[0].Rows[0]["UserTypeID"].ToString());
				}
				model.Usertype=ds.Tables[0].Rows[0]["Usertype"].ToString();
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
		public IList<LN.Model.UserTypeData> GetList(string strWhere)
		{
            IList<LN.Model.UserTypeData> list = new List<LN.Model.UserTypeData>();
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ID,UserTypeID,Usertype ");
			strSql.Append(" FROM UserTypeData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" WHERE "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.UserTypeData model = new LN.Model.UserTypeData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.UserTypeID = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.Usertype = reader.GetString(2);
                list.Add(model);
            }
            reader.Close();
            return list;
		}


        /// <summary>
        /// ��ȡָ���û���Ȩ��
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <returns></returns>
        public int GetUserType(string UserID)
        {
            int _return = 0;
            string strSql = string.Format("SELECT TOP 1 [Usertype] FROM [UserInfo] WHERE [UserID] =  {0}", UserID);

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }

		#endregion  ��Ա����
	}
}


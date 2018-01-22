using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类PhysicalCompanyData。
	/// </summary>
	public class PhysicalCompanyData
	{
		public PhysicalCompanyData()
		{}
		#region  成员方法


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.PhysicalCompanyData model)
		{
            int _return = 0;
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyName", SqlDbType.VarChar,100),
					new SqlParameter("@Contactor", SqlDbType.VarChar,20),
					new SqlParameter("@ContactorPhone", SqlDbType.VarChar,20),
					new SqlParameter("@CompanyNameDesc", SqlDbType.VarChar,500),
                    new SqlParameter("@SupplierID", SqlDbType.Int,4)};
			parameters[0].Value = model.CompanyName;
			parameters[1].Value = model.Contactor;
			parameters[2].Value = model.ContactorPhone;
			parameters[3].Value = model.CompanyNameDesc;
            parameters[4].Value = model.SupplierID;
            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "UP_PhysicalCompanyData_ADD", parameters, out _return);

            return _return;

		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(int id,string name,string photo)
		{
            int _return = 0;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("UPDATE PhysicalCompanyData SET ");
			strSql.Append("Contactor=@Contactor,");
			strSql.Append("ContactorPhone=@ContactorPhone  ");
            strSql.Append("WHERE CompanyID=@CompanyID");
            strSql.Append("; SELECT @@ROWCOUNT; ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@Contactor", SqlDbType.VarChar,20),
					new SqlParameter("@ContactorPhone", SqlDbType.VarChar,20)};
            parameters[0].Value = id;
            parameters[1].Value = name;
            parameters[2].Value = photo;
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PhysicalCompanyData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.PhysicalCompanyData GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT TOP 1 ID,CompanyID,CompanyName,Contactor,ContactorPhone,CompanyNameDesc,SupplierID FROM PhysicalCompanyData ");
            strSql.Append(" WHERE CompanyID=@CompanyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            LN.Model.PhysicalCompanyData model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
                model = new LN.Model.PhysicalCompanyData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.CompanyID = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.CompanyName = reader.GetString(2);

                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.Contactor = reader.GetString(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.ContactorPhone = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetString(5)))
                    model.CompanyNameDesc = reader.GetString(5);

                if (!string.IsNullOrEmpty(reader.GetInt32(6).ToString()))
                    model.SupplierID = reader.GetInt32(6);
			}
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public IList<LN.Model.PhysicalCompanyData> GetList(string strWhere)
		{
            IList<LN.Model.PhysicalCompanyData> list = new List<LN.Model.PhysicalCompanyData>();
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT ID,CompanyID,CompanyName,Contactor,ContactorPhone,CompanyNameDesc,SupplierID ");
			strSql.Append(" FROM PhysicalCompanyData ");
			if(strWhere.Trim()!="")
				strSql.Append(" WHERE "+strWhere);

            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.PhysicalCompanyData model = new LN.Model.PhysicalCompanyData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.CompanyID = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.CompanyName = reader.GetString(2);

                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.Contactor = reader.GetString(3);

                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.ContactorPhone = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetString(5)))
                    model.CompanyNameDesc = reader.GetString(5);

                if (!string.IsNullOrEmpty(reader.GetInt32(6).ToString()))
                    model.SupplierID = reader.GetInt32(6);

                list.Add(model);
            }
            reader.Close();
            return list;
		}

		#endregion  成员方法
	}
}


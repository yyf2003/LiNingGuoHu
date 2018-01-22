using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类SupplierInfo。
	/// </summary>
	public class SupplierInfo
	{
		public SupplierInfo()
		{}
		#region  成员方法


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.SupplierInfo model)
		{
            int _return = 0;
			SqlParameter[] parameters = {
					new SqlParameter("@SupplierName", SqlDbType.NVarChar,100),
					new SqlParameter("@Contacter", SqlDbType.VarChar,50),
					new SqlParameter("@ContactPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ContacterRole", SqlDbType.VarChar,50),
					new SqlParameter("@SupplierState", SqlDbType.Int,4),
                    new SqlParameter("@PostCode", SqlDbType.VarChar,50),
                    new SqlParameter("@PostAddress", SqlDbType.VarChar,200),
                    new SqlParameter("@StaffNum", SqlDbType.Int,4),
                    new SqlParameter("@LicensePath", SqlDbType.VarChar,200),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,1000),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime,8)};
			parameters[0].Value = model.SupplierName;
			parameters[1].Value = model.Contacter;
			parameters[2].Value = model.ContactPhone;
			parameters[3].Value = model.ContacterRole;
			parameters[4].Value = model.SupplierState;
            parameters[5].Value = model.PostCode;
            parameters[6].Value = model.PostAddress;
            parameters[7].Value = model.StaffNum;
            parameters[8].Value = model.LicensePath;
			parameters[9].Value = model.Remarks;
            parameters[10].Value = model.CreateDate;
            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(),"P_AddSupplierInfo", parameters, out _return);
			if (obj == null)
			{
				return 0;
			}
			else
			{
                return Convert.ToInt32(_return);
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.SupplierInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SupplierInfo set ");
			strSql.Append("SupplierName=@SupplierName,");
			strSql.Append("Contacter=@Contacter,");
			strSql.Append("ContactPhone=@ContactPhone,");
			strSql.Append("ContacterRole=@ContacterRole,");
			strSql.Append("SupplierState=@SupplierState,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where SupplierID=@SupplierID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@SupplierName", SqlDbType.NVarChar,100),
					new SqlParameter("@Contacter", SqlDbType.NChar,10),
					new SqlParameter("@ContactPhone", SqlDbType.NChar,20),
					new SqlParameter("@ContacterRole", SqlDbType.NChar,20),
					new SqlParameter("@SupplierState", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.SupplierID;
			parameters[1].Value = model.SupplierName;
			parameters[2].Value = model.Contacter;
			parameters[3].Value = model.ContactPhone;
			parameters[4].Value = model.ContacterRole;
			parameters[5].Value = model.SupplierState;
			parameters[6].Value = model.Remarks;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SupplierID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete SupplierInfo ");
			strSql.Append(" where SupplierID=@SupplierID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4)};
			parameters[0].Value = SupplierID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.SupplierInfo GetModel(int SupplierID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT [SupplierID],[SupplierName],[Contacter],[ContactPhone],[ContacterRole],[SupplierState],[PostCode],[PostAddress],[Remarks],[CreateDate],[ShortName] FROM [SupplierInfo] ");
			strSql.Append(" where SupplierID=@SupplierID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4)};
			parameters[0].Value = SupplierID;

            LN.Model.SupplierInfo model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
                model = new LN.Model.SupplierInfo();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.SupplierID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.SupplierName = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.Contacter = reader.GetString(2);

                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.ContactPhone = reader.GetString(3);

                if (!string.IsNullOrEmpty(reader.GetValue(4).ToString()))
                    model.ContacterRole = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.SupplierState = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetValue(6).ToString()))
                    model.PostCode = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetValue(7).ToString()))
                    model.PostAddress = reader.GetString(7);

                if (!string.IsNullOrEmpty(reader.GetValue(8).ToString()))
                    model.Remarks = reader.GetString(8);

                if (!string.IsNullOrEmpty(reader.GetValue(9).ToString()))
                    model.CreateDate = reader.GetDateTime(9);
                if (!string.IsNullOrEmpty(reader.GetValue(10).ToString()))
                    model.ShortName = reader.GetString(10);
			}
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public IList<LN.Model.SupplierInfo> GetList(string strWhere)
		{
            IList<LN.Model.SupplierInfo> list = new List<LN.Model.SupplierInfo>();
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT [SupplierID],[SupplierName],[Contacter],[ContactPhone],[ContacterRole],[SupplierState],[PostCode],[PostAddress],[Remarks],[CreateDate],[ShortName] ");
            strSql.Append(" FROM [SupplierInfo] where SupplierState=1");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.SupplierInfo model = new LN.Model.SupplierInfo();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.SupplierID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.SupplierName = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.Contacter = reader.GetString(2);

                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.ContactPhone = reader.GetString(3);

                if (!string.IsNullOrEmpty(reader.GetValue(4).ToString()))
                    model.ContacterRole = reader.GetString(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.SupplierState = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetValue(6).ToString()))
                    model.PostCode = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetValue(7).ToString()))
                    model.PostAddress = reader.GetString(7);

                if (!string.IsNullOrEmpty(reader.GetValue(8).ToString()))
                    model.Remarks = reader.GetString(8);

                if (!string.IsNullOrEmpty(reader.GetValue(9).ToString()))
                    model.CreateDate = reader.GetDateTime(9);
                if (!string.IsNullOrEmpty(reader.GetValue(10).ToString()))
                    model.ShortName = reader.GetString(10);
                list.Add(model);
            }
            reader.Close();
            return list;

		}
        /// <summary>
        /// 放弃一级客户
        /// </summary>
        /// <param name="supplierID"></param>
        /// <param name="beizhu"></param>
        public void GiveUpSup(int supplierID,string beizhu)
        {
            string sqlStr = "update SupplierInfo set SupplierState=0,Remarks='" + beizhu + "' where SupplierID="+supplierID;
            DbHelperSQL.Query(DbHelperSQL.connectionString(), sqlStr);
        }

        /// <summary>
        /// 获取指定用户所属一级客户的编号和用户的权限
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>所属一级客户的编号和用户的权限</returns>
        public IList<int> GetSupplierID(string UserID)
        {
            IList<int> list = null;
            string strSql = string.Format("SELECT TOP 1 [SupplierID],[TypeID] FROM [SupplierUserManage] WHERE [UserID] = {0}",UserID);
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql);
            if (reader.Read())
            {
                list = new List<int>();
                list.Add(reader.GetInt32(0));
                list.Add(reader.GetInt32(1));
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 获取指定用户的供应商编号和最新POP发起ID
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回POPID，SupplierID</returns>
        public IList<string> GetPOPIDAndSIDByUserID(int userid)
        {
            IList<string> list = new List<string>();
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = userid;
            SqlDataReader reader = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "P_GetPOPIDAndSIDByUserID", parameters);
            if (reader.Read())
            {
                list.Add(reader.GetString(0));
                list.Add(reader.GetInt32(1).ToString());
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 根据供应商负责人的用户名获取供应商Id  add by mhj 2012.2.5
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetSupplierIdByUserName(string userName)
        {
            string strSql = "select top 1 SupplierID from SupplierInfo where Contacter like '%" + userName + "%'";
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql);
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            else
            {
                return 0;
            }
        }


		#endregion  成员方法
	}
}


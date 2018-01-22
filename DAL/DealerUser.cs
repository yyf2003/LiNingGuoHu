using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类DealerUser。
	/// </summary>
	public class DealerUser
	{
		public DealerUser()
		{}
		#region  成员方法


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.DealerUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DealerUser(");
			strSql.Append("UserID,DealerID)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@DealerID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar ,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.DealerID;

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
		public void Update(LN.Model.DealerUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DealerUser set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("DealerID=@DealerID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.DealerID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete DealerUser ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.DealerUser GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UserID,DealerID from DealerUser ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            LN.Model.DealerUser model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
			{
                model = new LN.Model.DealerUser();
				if(!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.UserID = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.DealerID = reader.GetString (2);
			}
            reader.Close();
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public IList<LN.Model.DealerUser> GetList(string strWhere)
		{
            IList<LN.Model.DealerUser> list = new List<LN.Model.DealerUser>();

			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserID,DealerID ");
			strSql.Append(" FROM DealerUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.DealerUser model = new LN.Model.DealerUser();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.UserID = reader.GetInt32(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.DealerID = reader.GetString(2);

                list.Add(model);
            }
            reader.Close();
            return list;
		}

        /// <summary>
        /// 通过用户编号获取一级客户号
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回一级客户号</returns>
        public DataTable  GetDealerIdByUserID(int userid)
        {
            string _return = String.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DealerID,dealername  from View_DealerUser ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = userid;

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);

            DataTable dt = ds.Tables[0];

            return dt;
        }


		#endregion  成员方法
	}
}


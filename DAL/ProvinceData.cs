using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ProvinceData。
	/// </summary>
	public class ProvinceData
	{
		public ProvinceData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ProvinceID", "ProvinceData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProvinceID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProvinceData");
			strSql.Append(" where ProvinceID=@ProvinceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.Int,4)};
			parameters[0].Value = ProvinceID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LN.Model.ProvinceData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProvinceData(");
			strSql.Append("ProvinceID,AreaID,ProvinceName)");
			strSql.Append(" values (");
			strSql.Append("@ProvinceID,@AreaID,@ProvinceName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ProvinceID;
			parameters[1].Value = model.AreaID;
			parameters[2].Value = model.ProvinceName;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ProvinceData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProvinceData set ");
			strSql.Append("AreaID=@AreaID,");
			strSql.Append("ProvinceName=@ProvinceName");
			strSql.Append(" where ProvinceID=@ProvinceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ProvinceID;
			parameters[1].Value = model.AreaID;
			parameters[2].Value = model.ProvinceName;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProvinceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ProvinceData ");
			strSql.Append(" where ProvinceID=@ProvinceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.Int,4)};
			parameters[0].Value = ProvinceID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ProvinceData GetModel(int ProvinceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProvinceID,AreaID,ProvinceName from ProvinceData ");
			strSql.Append(" where ProvinceID=@ProvinceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProvinceID", SqlDbType.Int,4)};
			parameters[0].Value = ProvinceID;

			LN.Model.ProvinceData model=new LN.Model.ProvinceData();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AreaID"].ToString()!="")
				{
					model.AreaID=int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
				}
				model.ProvinceName=ds.Tables[0].Rows[0]["ProvinceName"].ToString();
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
        public IList<LN.Model.ProvinceData> GetList(string strWhere)
        {
            IList<LN.Model.ProvinceData> list = new List<LN.Model.ProvinceData>();
            string strSql = "SELECT ProvinceID,AreaID,ProvinceName,VMmaster,VMphone FROM ProvinceData ";
            if (strWhere.Trim() != "")
            {
                strSql += " WHERE " + strWhere;
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql);
            while (reader.Read())
            {
                LN.Model.ProvinceData model = new LN.Model.ProvinceData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ProvinceID = reader.GetInt32(0);
                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.AreaID = reader.GetInt32(1);
                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.ProvinceName = reader.GetString(2);
                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.VMmaster = reader.GetString(3);
                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.VMphone = reader.GetString(4);
                list.Add(model);
            }
            reader.Close();
            return list;
        }

		#endregion  成员方法
	}
}


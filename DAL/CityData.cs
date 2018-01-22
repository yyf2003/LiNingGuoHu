using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类CityData。
	/// </summary>
	public class CityData
	{
		public CityData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "CItyID", "CityData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CItyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CityData");
			strSql.Append(" where CItyID=@CItyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CItyID", SqlDbType.Int,4)};
			parameters[0].Value = CItyID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.CityData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CityData(");
			strSql.Append("AreaID,ProvinceID,CityName,CityLevel)");
			strSql.Append(" values (");
			strSql.Append("@AreaID,@ProvinceID,@CityName,@CityLevel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityName", SqlDbType.VarChar,20),
					new SqlParameter("@CityLevel", SqlDbType.NChar,10)};
			parameters[0].Value = model.AreaID;
			parameters[1].Value = model.ProvinceID;
			parameters[2].Value = model.CityName;
			parameters[3].Value = model.CityLevel;
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
		public void Update(LN.Model.CityData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CityData set ");
			strSql.Append("AreaID=@AreaID,");
			strSql.Append("ProvinceID=@ProvinceID,");
			strSql.Append("CityName=@CityName,");
			strSql.Append("CityLevel=@CityLevel");
			strSql.Append(" where CItyID=@CItyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CItyID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityName", SqlDbType.VarChar,20),
					new SqlParameter("@CityLevel", SqlDbType.NChar,10)};
			parameters[0].Value = model.CItyID;
			parameters[1].Value = model.AreaID;
			parameters[2].Value = model.ProvinceID;
			parameters[3].Value = model.CityName;
			parameters[4].Value = model.CityLevel;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CItyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete CityData ");
			strSql.Append(" where CItyID=@CItyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CItyID", SqlDbType.Int,4)};
			parameters[0].Value = CItyID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.CityData GetModel(int CItyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CItyID,AreaID,ProvinceID,CityName,CityLevel from CityData ");
			strSql.Append(" where CItyID=@CItyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CItyID", SqlDbType.Int,4)};
			parameters[0].Value = CItyID;

			LN.Model.CityData model=new LN.Model.CityData();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CItyID"].ToString()!="")
				{
					model.CItyID=int.Parse(ds.Tables[0].Rows[0]["CItyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AreaID"].ToString()!="")
				{
					model.AreaID=int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
				}
				model.CityName=ds.Tables[0].Rows[0]["CityName"].ToString();
				model.CityLevel=ds.Tables[0].Rows[0]["CityLevel"].ToString();
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
        public IList<LN.Model.CityData> GetList(string strWhere)
		{
            IList<LN.Model.CityData> list = new List<LN.Model.CityData>();
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT CItyID,AreaID,ProvinceID,CityName,CityLevel ");
			strSql.Append(" FROM CityData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" WHERE "+strWhere);
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.CityData model = new LN.Model.CityData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.CItyID = reader.GetInt32(0);
                if (!string.IsNullOrEmpty(reader.GetInt32(1).ToString()))
                    model.AreaID = reader.GetInt32(1);
                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.ProvinceID = reader.GetInt32(2);
                if (!string.IsNullOrEmpty(reader.GetString(3)))
                    model.CityName = reader.GetString(3);
                if (!string.IsNullOrEmpty(reader.GetString(4)))
                    model.CityLevel = reader.GetString(4);
                list.Add(model);
            }
            reader.Close();
            return list;
		}

        /// <summary>
        /// 根据省份得到城市简单信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCityList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CItyID,CityName ");
            strSql.Append(" FROM CityData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString()).Tables[0];
        }

		#endregion  成员方法
	}
}


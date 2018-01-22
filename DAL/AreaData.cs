using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类AreaData。
	/// </summary>
	public class AreaData
	{
		public AreaData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "AreaID", "AreaData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AreaID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AreaData");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4)};
			parameters[0].Value = AreaID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.AreaData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AreaData(");
			strSql.Append("AreaName)");
			strSql.Append(" values (");
			strSql.Append("@AreaName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.AreaName;

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
		public void Update(LN.Model.AreaData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AreaData set ");
			strSql.Append("AreaName=@AreaName");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@AreaName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.AreaID;
			parameters[1].Value = model.AreaName;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AreaID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete AreaData ");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4)};
			parameters[0].Value = AreaID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.AreaData GetModel(int AreaID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 AreaID,AreaName,department from AreaData ");
			strSql.Append(" where AreaID=@AreaID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4)};
			parameters[0].Value = AreaID;

			LN.Model.AreaData model=new LN.Model.AreaData();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AreaID"].ToString()!="")
				{
					model.AreaID=int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
				}
				model.AreaName=ds.Tables[0].Rows[0]["AreaName"].ToString();
                model.DepartMent = ds.Tables[0].Rows[0]["DepartMent"].ToString();
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
        public IList<LN.Model.AreaData> GetList(string strWhere)
		{
            IList<LN.Model.AreaData> list = new List<LN.Model.AreaData>();
            string strSql = "SELECT AreaID,AreaName,department FROM AreaData ";
			if(strWhere.Trim()!="")
			{
				strSql += " WHERE " + strWhere;
			}
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql);
            while (reader.Read())
            {
                LN.Model.AreaData model = new LN.Model.AreaData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.AreaID = reader.GetInt32(0);
                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.AreaName = reader.GetString(1);
                if (!string.IsNullOrEmpty(reader.GetString(2)))
                    model.DepartMent = reader.GetString(2);
                list.Add(model);
            }
            reader.Close();
            return list;
		}

		/*
		/// <summary>
		/// 分页获取数据列表
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
			parameters[0].Value = "AreaData";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}


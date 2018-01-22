using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类TownData。
	/// </summary>
	public class TownData
	{
		public TownData()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TownData");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.TownData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TownData(");
			strSql.Append("TownID,TownName,CityID)");
			strSql.Append(" values (");
			strSql.Append("@TownID,@TownName,@CityID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TownID", SqlDbType.Int,4),
					new SqlParameter("@TownName", SqlDbType.VarChar,50),
					new SqlParameter("@CityID", SqlDbType.Int,4)};
			parameters[0].Value = model.TownID;
			parameters[1].Value = model.TownName;
			parameters[2].Value = model.CityID;

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
		public void Update(LN.Model.TownData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TownData set ");
			strSql.Append("TownID=@TownID,");
			strSql.Append("TownName=@TownName,");
			strSql.Append("CityID=@CityID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TownID", SqlDbType.Int,4),
					new SqlParameter("@TownName", SqlDbType.VarChar,50),
					new SqlParameter("@CityID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.TownID;
			parameters[2].Value = model.TownName;
			parameters[3].Value = model.CityID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete TownData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public LN.Model.TownData GetModel(int Townid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,TownID,TownName,CityID from TownData ");
            strSql.Append(" where TownID=@Townid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Townid", SqlDbType.Int,4)};
            parameters[0].Value = Townid;

            LN.Model.TownData model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (reader.Read())
            {
                model = new LN.Model.TownData();
                if (!string.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.ID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.TownID = reader.GetInt32(1);
                }
                model.TownName = reader.GetValue(2).ToString();
                if (!string.IsNullOrEmpty(reader.GetValue(3).ToString()))
                {
                    model.CityID = reader.GetInt32(3);
                }
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.TownData> GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,TownID,TownName,CityID ");
			strSql.Append(" FROM TownData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}

            LN.Model.TownData model = null;
            List<LN.Model.TownData> modellist = new List<LN.Model.TownData>();
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                model = new LN.Model.TownData();
                if (!string.IsNullOrEmpty(reader.GetValue(0).ToString()))
                {
                    model.ID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetValue(1).ToString()))
                {
                    model.TownID = reader.GetInt32(1);
                }
                model.TownName = reader.GetValue(2).ToString();
                if (!string.IsNullOrEmpty(reader.GetValue(3).ToString()))
                {
                    model.CityID = reader.GetInt32(3);
                }
                modellist.Add(model);
            }
            return modellist;
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
			parameters[0].Value = "TownData";
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


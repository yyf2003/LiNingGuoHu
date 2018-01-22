using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ErrLog。
	/// </summary>
	public class ErrLog
	{
		public ErrLog()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "ErrLog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ErrLog");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.ErrLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ErrLog(");
			strSql.Append("ErrID,ErrDec,ErrTime,ErrPage)");
			strSql.Append(" values (");
			strSql.Append("@ErrID,@ErrDec,@ErrTime,@ErrPage)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ErrID", SqlDbType.NChar,50),
					new SqlParameter("@ErrDec", SqlDbType.VarChar,500),
					new SqlParameter("@ErrTime", SqlDbType.DateTime),
					new SqlParameter("@ErrPage", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ErrID;
			parameters[1].Value = model.ErrDec;
			parameters[2].Value = model.ErrTime;
			parameters[3].Value = model.ErrPage;

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
		public void Update(LN.Model.ErrLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ErrLog set ");
			strSql.Append("ErrID=@ErrID,");
			strSql.Append("ErrDec=@ErrDec,");
			strSql.Append("ErrTime=@ErrTime,");
			strSql.Append("ErrPage=@ErrPage");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ErrID", SqlDbType.NChar,50),
					new SqlParameter("@ErrDec", SqlDbType.VarChar,500),
					new SqlParameter("@ErrTime", SqlDbType.DateTime),
					new SqlParameter("@ErrPage", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ErrID;
			parameters[2].Value = model.ErrDec;
			parameters[3].Value = model.ErrTime;
			parameters[4].Value = model.ErrPage;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ErrLog ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ErrLog GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ErrID,ErrDec,ErrTime,ErrPage from ErrLog ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.ErrLog model=new LN.Model.ErrLog();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.ErrID=ds.Tables[0].Rows[0]["ErrID"].ToString();
				model.ErrDec=ds.Tables[0].Rows[0]["ErrDec"].ToString();
				if(ds.Tables[0].Rows[0]["ErrTime"].ToString()!="")
				{
					model.ErrTime=DateTime.Parse(ds.Tables[0].Rows[0]["ErrTime"].ToString());
				}
				model.ErrPage=ds.Tables[0].Rows[0]["ErrPage"].ToString();
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ErrID,ErrDec,ErrTime,ErrPage ");
			strSql.Append(" FROM ErrLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
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
			parameters[0].Value = "ErrLog";
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


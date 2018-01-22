using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类AssignUser。
	/// </summary>
	public class AssignUser
	{
		public AssignUser()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "AssignUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AssignUser");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.AssignUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AssignUser(");
			strSql.Append("UpmanagerID,ManagedID,ManagedRole)");
			strSql.Append(" values (");
			strSql.Append("@UpmanagerID,@ManagedID,@ManagedRole)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UpmanagerID", SqlDbType.Int,4),
					new SqlParameter("@ManagedID", SqlDbType.Int,4),
					new SqlParameter("@ManagedRole", SqlDbType.Int,4)};
			parameters[0].Value = model.UpmanagerID;
			parameters[1].Value = model.ManagedID;
			parameters[2].Value = model.ManagedRole;

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
		public void Update(LN.Model.AssignUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AssignUser set ");
			strSql.Append("UpmanagerID=@UpmanagerID,");
			strSql.Append("ManagedID=@ManagedID,");
			strSql.Append("ManagedRole=@ManagedRole");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UpmanagerID", SqlDbType.Int,4),
					new SqlParameter("@ManagedID", SqlDbType.Int,4),
					new SqlParameter("@ManagedRole", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UpmanagerID;
			parameters[2].Value = model.ManagedID;
			parameters[3].Value = model.ManagedRole;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete AssignUser ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.AssignUser GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,UpmanagerID,ManagedID,ManagedRole from AssignUser ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.AssignUser model=new LN.Model.AssignUser();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpmanagerID"].ToString()!="")
				{
					model.UpmanagerID=int.Parse(ds.Tables[0].Rows[0]["UpmanagerID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ManagedID"].ToString()!="")
				{
					model.ManagedID=int.Parse(ds.Tables[0].Rows[0]["ManagedID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ManagedRole"].ToString()!="")
				{
					model.ManagedRole=int.Parse(ds.Tables[0].Rows[0]["ManagedRole"].ToString());
				}
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
			strSql.Append("select ID,UpmanagerID,ManagedID,ManagedRole ");
			strSql.Append(" FROM AssignUser ");
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
			parameters[0].Value = "AssignUser";
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


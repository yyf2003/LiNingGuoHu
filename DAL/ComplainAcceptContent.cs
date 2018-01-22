using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ComplainAcceptContent。
	/// </summary>
	public class ComplainAcceptContent
	{
		public ComplainAcceptContent()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "aID", "ComplainAcceptContent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int aID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ComplainAcceptContent");
			strSql.Append(" where aID=@aID ");
			SqlParameter[] parameters = {
					new SqlParameter("@aID", SqlDbType.Int,4)};
			parameters[0].Value = aID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.ComplainAcceptContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ComplainAcceptContent(");
			strSql.Append("cID,acceptUserID,aInfo,AttachmentInfo,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@cID,@acceptUserID,@aInfo,@AttachmentInfo,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@cID", SqlDbType.Int,4),
					new SqlParameter("@acceptUserID", SqlDbType.Int,4),
					new SqlParameter("@aInfo", SqlDbType.Text),
					new SqlParameter("@AttachmentInfo", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.cID;
			parameters[1].Value = model.acceptUserID;
			parameters[2].Value = model.aInfo;
			parameters[3].Value = model.AttachmentInfo;
			parameters[4].Value = model.CreateTime;

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
		public void Update(LN.Model.ComplainAcceptContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ComplainAcceptContent set ");
			strSql.Append("cID=@cID,");
			strSql.Append("acceptUserID=@acceptUserID,");
			strSql.Append("aInfo=@aInfo,");
			strSql.Append("AttachmentInfo=@AttachmentInfo,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where aID=@aID ");
			SqlParameter[] parameters = {
					new SqlParameter("@aID", SqlDbType.Int,4),
					new SqlParameter("@cID", SqlDbType.Int,4),
					new SqlParameter("@acceptUserID", SqlDbType.Int,4),
					new SqlParameter("@aInfo", SqlDbType.Text),
					new SqlParameter("@AttachmentInfo", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.aID;
			parameters[1].Value = model.cID;
			parameters[2].Value = model.acceptUserID;
			parameters[3].Value = model.aInfo;
			parameters[4].Value = model.AttachmentInfo;
			parameters[5].Value = model.CreateTime;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int aID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ComplainAcceptContent ");
			strSql.Append(" where aID=@aID ");
			SqlParameter[] parameters = {
					new SqlParameter("@aID", SqlDbType.Int,4)};
			parameters[0].Value = aID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ComplainAcceptContent GetModel(int aID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 aID,cID,acceptUserID,aInfo,AttachmentInfo,CreateTime from ComplainAcceptContent ");
			strSql.Append(" where aID=@aID ");
			SqlParameter[] parameters = {
					new SqlParameter("@aID", SqlDbType.Int,4)};
			parameters[0].Value = aID;

			LN.Model.ComplainAcceptContent model=new LN.Model.ComplainAcceptContent();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["aID"].ToString()!="")
				{
					model.aID=int.Parse(ds.Tables[0].Rows[0]["aID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cID"].ToString()!="")
				{
					model.cID=int.Parse(ds.Tables[0].Rows[0]["cID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["acceptUserID"].ToString()!="")
				{
					model.acceptUserID=int.Parse(ds.Tables[0].Rows[0]["acceptUserID"].ToString());
				}
				model.aInfo=ds.Tables[0].Rows[0]["aInfo"].ToString();
				model.AttachmentInfo=ds.Tables[0].Rows[0]["AttachmentInfo"].ToString();
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
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
			strSql.Append("select aID,cID,acceptUserID,aInfo,AttachmentInfo,CreateTime ");
			strSql.Append(" FROM ComplainAcceptContent ");
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
			parameters[0].Value = "ComplainAcceptContent";
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


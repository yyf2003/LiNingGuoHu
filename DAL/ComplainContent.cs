using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ComplainContent。
	/// </summary>
	public class ComplainContent
	{
		public ComplainContent()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "cID", "ComplainContent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ComplainContent");
			strSql.Append(" where cID=@cID ");
			SqlParameter[] parameters = {
					new SqlParameter("@cID", SqlDbType.Int,4)};
			parameters[0].Value = cID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.ComplainContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ComplainContent(");
			strSql.Append("cInfo,tID,userID,acceptUserID,acceptNumber,AttachmentInfo,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@cInfo,@tID,@userID,@acceptUserID,@acceptNumber,@AttachmentInfo,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@cInfo", SqlDbType.Text),
					new SqlParameter("@tID", SqlDbType.Int,4),
					new SqlParameter("@userID", SqlDbType.Int,4),
					new SqlParameter("@acceptUserID", SqlDbType.VarChar,200),
					new SqlParameter("@acceptNumber", SqlDbType.Int,4),
					new SqlParameter("@AttachmentInfo", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.cInfo;
			parameters[1].Value = model.tID;
			parameters[2].Value = model.userID;
			parameters[3].Value = model.acceptUserID;
			parameters[4].Value = model.acceptNumber;
			parameters[5].Value = model.AttachmentInfo;
			parameters[6].Value = model.CreateTime;

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
		public void Update(LN.Model.ComplainContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ComplainContent set ");
			strSql.Append("cInfo=@cInfo,");
			strSql.Append("tID=@tID,");
			strSql.Append("userID=@userID,");
			strSql.Append("acceptUserID=@acceptUserID,");
			strSql.Append("acceptNumber=@acceptNumber,");
			strSql.Append("AttachmentInfo=@AttachmentInfo,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where cID=@cID ");
			SqlParameter[] parameters = {
					new SqlParameter("@cID", SqlDbType.Int,4),
					new SqlParameter("@cInfo", SqlDbType.Text),
					new SqlParameter("@tID", SqlDbType.Int,4),
					new SqlParameter("@userID", SqlDbType.Int,4),
					new SqlParameter("@acceptUserID", SqlDbType.VarChar,200),
					new SqlParameter("@acceptNumber", SqlDbType.Int,4),
					new SqlParameter("@AttachmentInfo", SqlDbType.VarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.cID;
			parameters[1].Value = model.cInfo;
			parameters[2].Value = model.tID;
			parameters[3].Value = model.userID;
			parameters[4].Value = model.acceptUserID;
			parameters[5].Value = model.acceptNumber;
			parameters[6].Value = model.AttachmentInfo;
			parameters[7].Value = model.CreateTime;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int cID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ComplainContent ");
			strSql.Append(" where cID=@cID ");
			SqlParameter[] parameters = {
					new SqlParameter("@cID", SqlDbType.Int,4)};
			parameters[0].Value = cID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ComplainContent GetModel(int cID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 cID,cInfo,tID,userID,acceptUserID,acceptNumber,AttachmentInfo,CreateTime from ComplainContent ");
			strSql.Append(" where cID=@cID ");
			SqlParameter[] parameters = {
					new SqlParameter("@cID", SqlDbType.Int,4)};
			parameters[0].Value = cID;

			LN.Model.ComplainContent model=new LN.Model.ComplainContent();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["cID"].ToString()!="")
				{
					model.cID=int.Parse(ds.Tables[0].Rows[0]["cID"].ToString());
				}
				model.cInfo=ds.Tables[0].Rows[0]["cInfo"].ToString();
				if(ds.Tables[0].Rows[0]["tID"].ToString()!="")
				{
					model.tID=int.Parse(ds.Tables[0].Rows[0]["tID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["userID"].ToString()!="")
				{
					model.userID=int.Parse(ds.Tables[0].Rows[0]["userID"].ToString());
				}
				model.acceptUserID=ds.Tables[0].Rows[0]["acceptUserID"].ToString();
				if(ds.Tables[0].Rows[0]["acceptNumber"].ToString()!="")
				{
					model.acceptNumber=int.Parse(ds.Tables[0].Rows[0]["acceptNumber"].ToString());
				}
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
			strSql.Append("select cID,cInfo,tID,userID,acceptUserID,acceptNumber,AttachmentInfo,CreateTime ");
			strSql.Append(" FROM ComplainContent ");
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
			parameters[0].Value = "ComplainContent";
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


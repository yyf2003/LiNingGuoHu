using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类POPStage。
	/// </summary>
	public class POPStage
	{
		public POPStage()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "StageID", "POPStage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StageID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POPStage");
			strSql.Append(" where StageID=@StageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StageID", SqlDbType.Int,4)};
			parameters[0].Value = StageID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.POPStage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POPStage(");
			strSql.Append("SupplierID,POPID,POPMaterial,POPprice,ExamUserID,ExamDate)");
			strSql.Append(" values (");
			strSql.Append("@SupplierID,@POPID,@POPMaterial,@POPprice,@ExamUserID,@ExamDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.Int,4),
					new SqlParameter("@POPMaterial", SqlDbType.VarChar,20),
					new SqlParameter("@POPprice", SqlDbType.Float,8),
					new SqlParameter("@ExamUserID", SqlDbType.Int,4),
					new SqlParameter("@ExamDate", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SupplierID;
			parameters[1].Value = model.POPID;
			parameters[2].Value = model.POPMaterial;
			parameters[3].Value = model.POPprice;
			parameters[4].Value = model.ExamUserID;
			parameters[5].Value = model.ExamDate;

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
		public void Update(LN.Model.POPStage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POPStage set ");
			strSql.Append("SupplierID=@SupplierID,");
			strSql.Append("POPID=@POPID,");
			strSql.Append("POPMaterial=@POPMaterial,");
			strSql.Append("POPprice=@POPprice,");
			strSql.Append("ExamUserID=@ExamUserID,");
			strSql.Append("ExamDate=@ExamDate");
			strSql.Append(" where StageID=@StageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StageID", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.Int,4),
					new SqlParameter("@POPMaterial", SqlDbType.VarChar,20),
					new SqlParameter("@POPprice", SqlDbType.Float,8),
					new SqlParameter("@ExamUserID", SqlDbType.Int,4),
					new SqlParameter("@ExamDate", SqlDbType.VarChar,50)};
			parameters[0].Value = model.StageID;
			parameters[1].Value = model.SupplierID;
			parameters[2].Value = model.POPID;
			parameters[3].Value = model.POPMaterial;
			parameters[4].Value = model.POPprice;
			parameters[5].Value = model.ExamUserID;
			parameters[6].Value = model.ExamDate;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int StageID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete POPStage ");
			strSql.Append(" where StageID=@StageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StageID", SqlDbType.Int,4)};
			parameters[0].Value = StageID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPStage GetModel(int StageID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StageID,SupplierID,POPID,POPMaterial,POPprice,ExamUserID,ExamDate from POPStage ");
			strSql.Append(" where StageID=@StageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StageID", SqlDbType.Int,4)};
			parameters[0].Value = StageID;

			LN.Model.POPStage model=new LN.Model.POPStage();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StageID"].ToString()!="")
				{
					model.StageID=int.Parse(ds.Tables[0].Rows[0]["StageID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SupplierID"].ToString()!="")
				{
					model.SupplierID=int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POPID"].ToString()!="")
				{
					model.POPID=int.Parse(ds.Tables[0].Rows[0]["POPID"].ToString());
				}
				model.POPMaterial=ds.Tables[0].Rows[0]["POPMaterial"].ToString();
				if(ds.Tables[0].Rows[0]["POPprice"].ToString()!="")
				{
					model.POPprice=decimal.Parse(ds.Tables[0].Rows[0]["POPprice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExamUserID"].ToString()!="")
				{
					model.ExamUserID=int.Parse(ds.Tables[0].Rows[0]["ExamUserID"].ToString());
				}
				model.ExamDate=ds.Tables[0].Rows[0]["ExamDate"].ToString();
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
			strSql.Append("select StageID,SupplierID,POPID,POPMaterial,POPprice,ExamUserID,ExamDate ");
			strSql.Append(" FROM POPStage ");
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
			parameters[0].Value = "POPStage";
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


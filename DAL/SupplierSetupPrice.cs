using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类SupplierSetupPrice。
	/// </summary>
	public class SupplierSetupPrice
	{
		public SupplierSetupPrice()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SupplierSetupPrice");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.SupplierSetupPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SupplierSetupPrice(");
			strSql.Append("supplierID,setupMoney,SysTime,SubmitUserID)");
			strSql.Append(" values (");
			strSql.Append("@supplierID,@setupMoney,@SysTime,@SubmitUserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@supplierID", SqlDbType.Int,4),
					new SqlParameter("@setupMoney", SqlDbType.Float,8),
					new SqlParameter("@SysTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4)};
			parameters[0].Value = model.supplierID;
			parameters[1].Value = model.setupMoney;
			parameters[2].Value = model.SysTime;
			parameters[3].Value = model.SubmitUserID;

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
		public void Update(LN.Model.SupplierSetupPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SupplierSetupPrice set ");
			strSql.Append("supplierID=@supplierID,");
			strSql.Append("setupMoney=@setupMoney,");
			strSql.Append("SysTime=@SysTime,");
			strSql.Append("SubmitUserID=@SubmitUserID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@supplierID", SqlDbType.Int,4),
					new SqlParameter("@setupMoney", SqlDbType.Float,8),
					new SqlParameter("@SysTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.supplierID;
			parameters[2].Value = model.setupMoney;
			parameters[3].Value = model.SysTime;
			parameters[4].Value = model.SubmitUserID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SupplierSetupPrice ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.SupplierSetupPrice GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,supplierID,setupMoney,SysTime,SubmitUserID from SupplierSetupPrice ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.SupplierSetupPrice model=new LN.Model.SupplierSetupPrice();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["supplierID"].ToString()!="")
				{
					model.supplierID=int.Parse(ds.Tables[0].Rows[0]["supplierID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["setupMoney"].ToString()!="")
				{
					model.setupMoney=decimal.Parse(ds.Tables[0].Rows[0]["setupMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SysTime"].ToString()!="")
				{
					model.SysTime=DateTime.Parse(ds.Tables[0].Rows[0]["SysTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SubmitUserID"].ToString()!="")
				{
					model.SubmitUserID=int.Parse(ds.Tables[0].Rows[0]["SubmitUserID"].ToString());
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
			strSql.Append("select ID,supplierID,setupMoney,SysTime,SubmitUserID ");
			strSql.Append(" FROM SupplierSetupPrice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,supplierID,setupMoney,SysTime,SubmitUserID ");
			strSql.Append(" FROM SupplierSetupPrice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "SupplierSetupPrice";
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类supplier_POPIDsetupPrice。
	/// </summary>
	public class supplier_POPIDsetupPrice
	{
		public supplier_POPIDsetupPrice()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from supplier_POPIDsetupPrice");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.supplier_POPIDsetupPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into supplier_POPIDsetupPrice(");
			strSql.Append("POPID,supplierID,setupMoney)");
			strSql.Append(" values (");
			strSql.Append("@POPID,@supplierID,@setupMoney)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@supplierID", SqlDbType.Int,4),
					new SqlParameter("@setupMoney", SqlDbType.Float,8)};
			parameters[0].Value = model.POPID;
			parameters[1].Value = model.supplierID;
			parameters[2].Value = model.setupMoney;

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
		public void Update(LN.Model.supplier_POPIDsetupPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update supplier_POPIDsetupPrice set ");
			strSql.Append("POPID=@POPID,");
			strSql.Append("supplierID=@supplierID,");
			strSql.Append("setupMoney=@setupMoney");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@supplierID", SqlDbType.Int,4),
					new SqlParameter("@setupMoney", SqlDbType.Float,8)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.POPID;
			parameters[2].Value = model.supplierID;
			parameters[3].Value = model.setupMoney;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from supplier_POPIDsetupPrice ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.supplier_POPIDsetupPrice GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,POPID,supplierID,setupMoney from supplier_POPIDsetupPrice ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.supplier_POPIDsetupPrice model=new LN.Model.supplier_POPIDsetupPrice();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.POPID=ds.Tables[0].Rows[0]["POPID"].ToString();
				if(ds.Tables[0].Rows[0]["supplierID"].ToString()!="")
				{
					model.supplierID=int.Parse(ds.Tables[0].Rows[0]["supplierID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["setupMoney"].ToString()!="")
				{
					model.setupMoney=decimal.Parse(ds.Tables[0].Rows[0]["setupMoney"].ToString());
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
			strSql.Append("select ID,POPID,supplierID,setupMoney ");
			strSql.Append(" FROM supplier_POPIDsetupPrice ");
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
			strSql.Append(" ID,POPID,supplierID,setupMoney ");
			strSql.Append(" FROM supplier_POPIDsetupPrice ");
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
			parameters[0].Value = "supplier_POPIDsetupPrice";
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


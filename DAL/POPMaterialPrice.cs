using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
using System.Collections;
using System.Collections.Generic;
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类POPMaterialPrice。
	/// </summary>
	public class POPMaterialPrice
	{
		public POPMaterialPrice()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PriceID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POPMaterialPrice");
			strSql.Append(" where PriceID=@PriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceID", SqlDbType.Int,4)};
			parameters[0].Value = PriceID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.POPMaterialPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POPMaterialPrice(");
            strSql.Append("SupplierID,MateriaID,POPprice,UserID,SysTime)");
			strSql.Append(" values (");
            strSql.Append("@SupplierID,@MateriaID,@POPprice,@UserID,@SysTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@MateriaID", SqlDbType.Int,4),
					new SqlParameter("@POPprice", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@SysTime", SqlDbType.DateTime)};
			parameters[0].Value = model.SupplierID;
            parameters[1].Value = model.MateriaID;
			parameters[2].Value = model.POPprice;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.SysTime;

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
		public void Update(LN.Model.POPMaterialPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POPMaterialPrice set ");
			strSql.Append("SupplierID=@SupplierID,");
            strSql.Append("MateriaID=@MateriaID,");
			strSql.Append("POPprice=@POPprice,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("SysTime=@SysTime");
			strSql.Append(" where PriceID=@PriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceID", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@MateriaID", SqlDbType.Int,4),
					new SqlParameter("@POPprice", SqlDbType.Decimal,9),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@SysTime", SqlDbType.DateTime)};
			parameters[0].Value = model.PriceID;
			parameters[1].Value = model.SupplierID;
            parameters[2].Value = model.MateriaID;
			parameters[3].Value = model.POPprice;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.SysTime;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PriceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from POPMaterialPrice ");
			strSql.Append(" where PriceID=@PriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceID", SqlDbType.Int,4)};
			parameters[0].Value = PriceID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPMaterialPrice GetModel(int PriceID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 PriceID,SupplierID,MateriaID,POPprice,UserID,SysTime from POPMaterialPrice ");
			strSql.Append(" where PriceID=@PriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceID", SqlDbType.Int,4)};
			parameters[0].Value = PriceID;

			LN.Model.POPMaterialPrice model=new LN.Model.POPMaterialPrice();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PriceID"].ToString()!="")
				{
					model.PriceID=int.Parse(ds.Tables[0].Rows[0]["PriceID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SupplierID"].ToString()!="")
				{
					model.SupplierID=int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
				}
                if (ds.Tables[0].Rows[0]["MateriaID"].ToString() != "")
				{
                    model.MateriaID = int.Parse(ds.Tables[0].Rows[0]["MateriaID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POPprice"].ToString()!="")
				{
					model.POPprice=decimal.Parse(ds.Tables[0].Rows[0]["POPprice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SysTime"].ToString()!="")
				{
					model.SysTime=DateTime.Parse(ds.Tables[0].Rows[0]["SysTime"].ToString());
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
            strSql.Append("select PriceID,SupplierID,MateriaID,MateriaPro,POPprice,UserID,SysTime ");
            strSql.Append(" FROM View_POPMaterialPrice ");
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
            strSql.Append(" PriceID,SupplierID,MateriaID,POPprice,UserID,SysTime ");
			strSql.Append(" FROM POPMaterialPrice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}
        /// <summary>
        /// 更新供应商材料价格
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdatePrice_supplier(List<Hashtable> htlist)
        {
            List<string> strlist = new List<string>();
            foreach (Hashtable  ht in htlist)
            {
                string sqlstr = "update POPMaterialPrice set popprice=" + ht["price"].ToString() + ",UserID=" + ht["UserID"].ToString() + ",Systime=getdate() where supplierid=" + ht["sid"].ToString() + " and MateriaID=" + ht["MID"].ToString();
                strlist.Add(sqlstr);
            }

            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strlist);
        }
        /// <summary>
        /// 更新供应商材料价格---整体修改
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdatePrice_all(List<Hashtable> htlist)
        {
            List<string> strlist = new List<string>();
            foreach (Hashtable ht in htlist)
            {
                string sqlstr = "update POPMaterialPrice set popprice=" + ht["price"].ToString() + ",UserID=" + ht["UserID"].ToString() + ",Systime=getdate() where   MateriaID=" + ht["MID"].ToString();
                strlist.Add(sqlstr);
            }
            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strlist);
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
			parameters[0].Value = "POPMaterialPrice";
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


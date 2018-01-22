using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类DSRExamData。
	/// </summary>
	public class DSRExamData
	{
		public DSRExamData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "DSRExamData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DSRExamData");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.DSRExamData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DSRExamData(");
			strSql.Append("POPID,CheckUserID,AreaID,ProvinceID,CityID,ShopID,CheckDate,SysDateTime,YesCount,NoCount,DataID)");
			strSql.Append(" values (");
			strSql.Append("@POPID,@CheckUserID,@AreaID,@ProvinceID,@CityID,@ShopID,@CheckDate,@SysDateTime,@YesCount,@NoCount,@DataID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@CheckUserID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@SysDateTime", SqlDbType.DateTime),
					new SqlParameter("@YesCount", SqlDbType.Int,4),
					new SqlParameter("@NoCount", SqlDbType.Int,4),
					new SqlParameter("@DataID", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.POPID;
			parameters[1].Value = model.CheckUserID;
			parameters[2].Value = model.AreaID;
			parameters[3].Value = model.ProvinceID;
			parameters[4].Value = model.CityID;
			parameters[5].Value = model.ShopID;
			parameters[6].Value = model.CheckDate;
			parameters[7].Value = model.SysDateTime;
			parameters[8].Value = model.YesCount;
			parameters[9].Value = model.NoCount;
			parameters[10].Value = model.DataID;

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
		public void Update(LN.Model.DSRExamData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DSRExamData set ");
			strSql.Append("POPID=@POPID,");
			strSql.Append("CheckUserID=@CheckUserID,");
			strSql.Append("AreaID=@AreaID,");
			strSql.Append("ProvinceID=@ProvinceID,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("ShopID=@ShopID,");
			strSql.Append("CheckDate=@CheckDate,");
			strSql.Append("SysDateTime=@SysDateTime,");
			strSql.Append("YesCount=@YesCount,");
			strSql.Append("NoCount=@NoCount,");
			strSql.Append("DataID=@DataID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@CheckUserID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@SysDateTime", SqlDbType.DateTime),
					new SqlParameter("@YesCount", SqlDbType.Int,4),
					new SqlParameter("@NoCount", SqlDbType.Int,4),
					new SqlParameter("@DataID", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.POPID;
			parameters[2].Value = model.CheckUserID;
			parameters[3].Value = model.AreaID;
			parameters[4].Value = model.ProvinceID;
			parameters[5].Value = model.CityID;
			parameters[6].Value = model.ShopID;
			parameters[7].Value = model.CheckDate;
			parameters[8].Value = model.SysDateTime;
			parameters[9].Value = model.YesCount;
			parameters[10].Value = model.NoCount;
			parameters[11].Value = model.DataID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete DSRExamData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.DSRExamData GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,POPID,CheckUserID,AreaID,ProvinceID,CityID,ShopID,CheckDate,SysDateTime,YesCount,NoCount,DataID from DSRExamData ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.DSRExamData model=new LN.Model.DSRExamData();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POPID"].ToString()!="")
				{
					model.POPID=ds.Tables[0].Rows[0]["POPID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CheckUserID"].ToString()!="")
				{
					model.CheckUserID=int.Parse(ds.Tables[0].Rows[0]["CheckUserID"].ToString());
				}
				model.AreaID=ds.Tables[0].Rows[0]["AreaID"].ToString();
				if(ds.Tables[0].Rows[0]["ProvinceID"].ToString()!="")
				{
					model.ProvinceID=int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CityID"].ToString()!="")
				{
					model.CityID=int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ShopID"].ToString()!="")
				{
					model.ShopID=int.Parse(ds.Tables[0].Rows[0]["ShopID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CheckDate"].ToString()!="")
				{
					model.CheckDate=DateTime.Parse(ds.Tables[0].Rows[0]["CheckDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SysDateTime"].ToString()!="")
				{
					model.SysDateTime=DateTime.Parse(ds.Tables[0].Rows[0]["SysDateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["YesCount"].ToString()!="")
				{
					model.YesCount=int.Parse(ds.Tables[0].Rows[0]["YesCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NoCount"].ToString()!="")
				{
					model.NoCount=int.Parse(ds.Tables[0].Rows[0]["NoCount"].ToString());
				}
				model.DataID=ds.Tables[0].Rows[0]["DataID"].ToString();
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
			strSql.Append("select * ");
            strSql.Append(" FROM View_DSRExamData ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}
        /// <summary>
        /// 根据条件得到 相应区域 所检查店铺的数据 包括 供应商安装 自主安装 总数量的统计
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet EveryAreaCheckShopCount(string strWhere)
        {
            SqlParameter[] sqlpara ={
                new SqlParameter ("@strwhere",SqlDbType.VarChar,300)
            };
            sqlpara[0].Value = strWhere;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "EveryAreaCheckShop", sqlpara, "ds");
            return ds;
        }
        /// <summary>
        /// 存检查结果
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertResult(List<string> list)
        {
            try
            {
                DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), list);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 得到DSR分析的结果
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetResultlist(Hashtable ht)
        {
            SqlParameter[] paras ={ 
            
                 new SqlParameter("@supplerID",SqlDbType.Int,4),
                 new SqlParameter("@beginDate",SqlDbType.VarChar,20),
                 new SqlParameter("@endDate",SqlDbType.VarChar,20),
                 new SqlParameter("@POPID",SqlDbType.VarChar,50),
                 new SqlParameter("@areaID",SqlDbType.Int,4),
                 new SqlParameter("@provinceID",SqlDbType.Int,4),
                 new SqlParameter("@cityID",SqlDbType.Int,4),
                 new SqlParameter("@DsrCheckname",SqlDbType.VarChar,20),
                 new SqlParameter("@boolstall",SqlDbType.VarChar,20),
                 new SqlParameter("@department",SqlDbType.VarChar,10) 
            };

            paras[0].Value = int.Parse(ht["supplerID"].ToString());
            paras[1].Value = ht["beginDate"].ToString();
            paras[2].Value = ht["endDate"].ToString();
            paras[3].Value = ht["POPID"].ToString();
            paras[4].Value = int.Parse(ht["areaID"].ToString());
            paras[5].Value = int.Parse(ht["provinceID"].ToString());
            paras[6].Value = int.Parse(ht["cityID"].ToString());
            paras[7].Value = ht["checkname"].ToString();
            paras[8].Value = ht["boolstall"].ToString();
            paras[9].Value = ht["department"].ToString();

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "DSRCheckResult", paras, "dt");
           
            return ds;
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
			parameters[0].Value = "DSRExamData";
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


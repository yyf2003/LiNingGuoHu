using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类ProductLineData。
	/// </summary>
	public class ProductLineData
	{
		public ProductLineData()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ProductLineID", "ProductLineData"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary> 
		public bool Exists(int ProductLineID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductLineData");
			strSql.Append(" where ProductLineID=@ProductLineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductLineID", SqlDbType.Int,4)};
			parameters[0].Value = ProductLineID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.ProductLineData model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] parameters = {
					new SqlParameter("@ProductName", SqlDbType.VarChar,100),
                    new SqlParameter("@TypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductLine;
            parameters[1].Value = model.TypeID;
            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "P_AddProductLineDate", parameters, out _return);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(_return);
            }
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ProductLineData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductLineData set ");
			strSql.Append("ProductLine=@ProductLine");
			strSql.Append(" where ProductLineID=@ProductLineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductLineID", SqlDbType.Int,4),
					new SqlParameter("@ProductLine", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ProductLineID;
			parameters[1].Value = model.ProductLine;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductLineID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ProductLineData ");
			strSql.Append(" where ProductLineID=@ProductLineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductLineID", SqlDbType.Int,4)};
			parameters[0].Value = ProductLineID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ProductLineData GetModel(int ProductLineID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductLineID,ProductLine from ProductLineData ");
			strSql.Append(" where ProductLineID=@ProductLineID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductLineID", SqlDbType.Int,4)};
			parameters[0].Value = ProductLineID;

            LN.Model.ProductLineData model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(reader.Read())
            {
                model = new LN.Model.ProductLineData();
                if (!string.IsNullOrEmpty(reader.GetInt16(0).ToString()))
                {
                    model.ProductLineID = reader.GetInt16(0);
                }
                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.ProductLine = reader.GetString(1);
				
			}
            reader.Close();
            return model;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.ProductLineData> GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ProductLineID,ProductLine,TypeID,isDelete ,ProductTypeName");
            strSql.Append(" FROM View_productline ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            List<LN.Model.ProductLineData> modelList = new List<LN.Model.ProductLineData>();
            while (reader.Read())
            {
                LN.Model.ProductLineData model;
                model = new LN.Model.ProductLineData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                {
                    model.ProductLineID = reader.GetInt32(0);
                }
                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.ProductLine = reader.GetString(1);
                if (reader.GetValue(2) != null)
                    model.TypeID = reader.GetInt32(2);
                if (reader.GetValue(3) != null)
                    model.IsDelete = reader.GetInt32(3);
                if (reader.GetValue(4) != null)
                    model.ProductTypeName = reader.GetString(4);
                modelList.Add(model);

            }
            reader.Close();
            return modelList;
        }
        
        /// <summary>
        /// 获得数据AJAX分页列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取直属客户列表集合</returns>
        public DataTable GetListPageByWhere(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = GetTableListSqlExec.GetList(model, out TotalNumber);
            if (dt != null)
                return dt;
            else
                return null;

        }
        /// <summary>
        /// 得到相应发起POP的故事包类型
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable getPOPProductTypelist(string POPID)
        {
            string proline = new LN.DAL.POPLaunch().GetProline(POPID);
            string strWhere = " ProductLineID in (" + proline + ")";
            SqlParameter[] paras ={
                 new SqlParameter("@strWhere",SqlDbType.VarChar,500)
            };
            paras[0].Value = strWhere;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetPOPProductLineType", paras, "temp");
            return ds.Tables[0];
        }

        /// <summary>
        /// 得到相应发起POP的故事包类型
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable getPOPProductTypelist(string POPID,string SeatName)
        {
            DataTable dt = null; 
            SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.NVarChar,50),
                    new SqlParameter("@SEAT", SqlDbType.NVarChar,100)};
            parameters[0].Value = POPID;
            parameters[1].Value = SeatName;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetProductType", parameters, "TableName");
            if (ds != null)
                dt = ds.Tables[0];

            return dt;
        }


        /// <summary>
        /// 得到相应发起POP的故事包
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable GetPOPproductLineByTypeID(string POPID, int typeid)
        {
            string proline = new LN.DAL.POPLaunch().GetProline(POPID);
            string strWhere = " ProductLineID in (" + proline + ")";
            SqlParameter[] paras ={
                 new SqlParameter("@strWhere",SqlDbType.VarChar,500),
                new SqlParameter("@TypeID",SqlDbType.Int,4)
            };
            paras[0].Value = strWhere;
            paras[1].Value = typeid;
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetPOPproductLineByTypeID", paras, "temp");
            return ds.Tables[0];
        }
        /// <summary>
        /// 得到所有产品系列的名称 不包括重复的
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDistinctLine(string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select distinct Productline from productLineData");
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
		#endregion  成员方法
	}
}


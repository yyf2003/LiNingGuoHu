using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类ShippingSpeedData。
    /// </summary>
    public class ShippingSpeedData
    {
        public ShippingSpeedData()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(List<string> strSql)
        {
            int _return = 0;
            try
            {
                _return = DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), strSql);
            }
            catch (Exception)
            {
                _return = 0;
            }

            return _return;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ShippingSpeedData ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ShippingSpeedData GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[GoodsOrderNO],[POPCount],[CompanyID],[FHDate],[OperatorID],[DealerID],[SupplierID],[ShopID],[IsState],[Remars],");
            strSql.Append("(SELECT TOP 1 CompanyName FROM PhysicalCompanyData WHERE CompanyID = s.CompanyID) AS CompanyName, ");
            strSql.Append("(SELECT TOP 1 [DealerName] FROM DealerInfo WHERE DealerID = s.DealerID) AS DealerName,");
            strSql.Append("(SELECT TOP 1 [SupplierName] FROM SupplierInfo WHERE SupplierID = s.SupplierID) AS SupplierName,");
            strSql.Append("(SELECT TOP 1 [ShopName] FROM ShopInfo WHERE ShopID = s.ShopID) AS ShopName,");
            strSql.Append(" FROM ShippingSpeedData AS s ");
            strSql.Append(" WHERE s.ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            LN.Model.ShippingSpeedData model = null;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);

            if (reader.Read())
            {
                model = new LN.Model.ShippingSpeedData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.GoodsOrderNO = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.POPCount = reader.GetInt32(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.CompanyID = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetDateTime(4).ToString()))
                    model.FHDate = reader.GetDateTime(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.OperatorID = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.DealerID = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetInt32(7).ToString()))
                    model.SupplierID = reader.GetInt32(7);

                if (!string.IsNullOrEmpty(reader.GetInt32(8).ToString()))
                    model.ShopID = reader.GetInt32(8);

                if (!string.IsNullOrEmpty(reader.GetString(9)))
                    model.IsState = reader.GetString(9);

                if (!string.IsNullOrEmpty(reader.GetString(10)))
                    model.Remars = reader.GetString(10);

                if (!string.IsNullOrEmpty(reader.GetString(11)))
                    model.CompanyName = reader.GetString(11);

                if (!string.IsNullOrEmpty(reader.GetString(12)))
                    model.DealerName = reader.GetString(12);

                if (!string.IsNullOrEmpty(reader.GetString(13)))
                    model.SupplierName = reader.GetString(13);

                if (!string.IsNullOrEmpty(reader.GetString(14)))
                    model.ShopName = reader.GetString(14);


            }
            reader.Close();
            return model;
        }
        /// <summary>
        /// 收货操作
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="rdate"></param>
        /// <param name="userid"></param>
        /// <param name="fs"></param>
        /// <param name="pj"></param>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public int RecevieGoods(string POPID, string rdate, string userid, string fs, string pj, string shopid)
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append("update ShippingSpeedData");
            sqlstr.Append(" set GetInState='已收货'");
            sqlstr.Append(",GetInUserID=" + userid);
            sqlstr.Append(",SHScore=" + fs);
            sqlstr.Append(",SHDate='" + rdate + "'");
            sqlstr.Append(",GetInFeedBack='" + pj + "'");
            sqlstr.Append(" where POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) and goodsorderno in (" + shopid + ")");

            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sqlstr.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.ShippingSpeedData> GetList(string strWhere)
        {
            IList<LN.Model.ShippingSpeedData> list = new List<LN.Model.ShippingSpeedData>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[GoodsOrderNO],[POPCount],[CompanyID],[FHDate],[OperatorID],[DealerID],[SupplierID],[ShopID],[IsState],[Remars],");
            strSql.Append("(SELECT TOP 1 CompanyName FROM PhysicalCompanyData WHERE CompanyID = s.CompanyID) AS CompanyName, ");
            strSql.Append("(SELECT TOP 1 [DealerName] FROM DealerInfo WHERE DealerID = s.DealerID) AS DealerName,");
            strSql.Append("(SELECT TOP 1 [SupplierName] FROM SupplierInfo WHERE SupplierID = s.SupplierID) AS SupplierName,");
            strSql.Append("(SELECT TOP 1 [ShopName] FROM ShopInfo WHERE ShopID = s.ShopID) AS ShopName,");
            strSql.Append(" FROM ShippingSpeedData AS s ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            SqlDataReader reader = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString());
            while (reader.Read())
            {
                LN.Model.ShippingSpeedData model = new LN.Model.ShippingSpeedData();
                if (!string.IsNullOrEmpty(reader.GetInt32(0).ToString()))
                    model.ID = reader.GetInt32(0);

                if (!string.IsNullOrEmpty(reader.GetString(1)))
                    model.GoodsOrderNO = reader.GetString(1);

                if (!string.IsNullOrEmpty(reader.GetInt32(2).ToString()))
                    model.POPCount = reader.GetInt32(2);

                if (!string.IsNullOrEmpty(reader.GetInt32(3).ToString()))
                    model.CompanyID = reader.GetInt32(3);

                if (!string.IsNullOrEmpty(reader.GetDateTime(4).ToString()))
                    model.FHDate = reader.GetDateTime(4);

                if (!string.IsNullOrEmpty(reader.GetInt32(5).ToString()))
                    model.OperatorID = reader.GetInt32(5);

                if (!string.IsNullOrEmpty(reader.GetString(6)))
                    model.DealerID = reader.GetString(6);

                if (!string.IsNullOrEmpty(reader.GetInt32(7).ToString()))
                    model.SupplierID = reader.GetInt32(7);

                if (!string.IsNullOrEmpty(reader.GetInt32(8).ToString()))
                    model.ShopID = reader.GetInt32(8);

                if (!string.IsNullOrEmpty(reader.GetString(9)))
                    model.IsState = reader.GetString(9);

                if (!string.IsNullOrEmpty(reader.GetString(10)))
                    model.Remars = reader.GetString(10);

                if (!string.IsNullOrEmpty(reader.GetString(11)))
                    model.CompanyName = reader.GetString(11);

                if (!string.IsNullOrEmpty(reader.GetString(12)))
                    model.DealerName = reader.GetString(12);

                if (!string.IsNullOrEmpty(reader.GetString(13)))
                    model.SupplierName = reader.GetString(13);

                if (!string.IsNullOrEmpty(reader.GetString(14)))
                    model.ShopName = reader.GetString(14);

                list.Add(model);
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 返回ShippingSpeedData中的数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPDataDone(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) from ShippingSpeedData where 1=1 ");
            if (strWhere != "")
            {
                sb.Append(" and " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sb.ToString());
            if (obj != null)
            {
                return (int)obj;
            }
            else
            {
                return 0;
            }

        }


        /// <summary>
        /// 得到已经发送pop数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPData(int SupplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  count(distinct shopid) from ShippingSpeedData ");
            if (SupplierID > 0)
            {
                sb.Append("  where SupplierID = " + SupplierID.ToString());
            }
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sb.ToString());
            if (obj != null)
            {
                return (int)obj;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// 分析的POP列表，得到所有的发货的pop信息
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataSet GetShippingPOPDataInfo(int shopid,string popid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select * from  popinfo,imagetopop where  popinfo.id=imagetopop.popinfoid and  imagetopop.shopid = " + shopid +" and popid='"+popid+"'");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }
        
        /// <summary>
        /// 一级客户查找已经安装的店铺列表
        /// </summary>
        /// <param name="DealerID">一级客户编号</param>
        /// <param name="FXID">直属客户编号</param>
        /// <param name="ShopID">店铺编号</param>
        /// <param name="ShopName">店铺名称</param>
        /// <param name="OrderField">排序字段</param>
        /// <param name="pageSize">每页显示店铺列表的个数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="TotalRecord">店铺数量</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetConfirmShopListByDealerID(string DealerID, string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalNumber)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.VarChar,20),
                    new SqlParameter("@FXID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopName", SqlDbType.VarChar,200),
                    new SqlParameter("@OrderField", SqlDbType.VarChar,1000),
                    new SqlParameter("@pageSize", SqlDbType.Int,4),
                    new SqlParameter("@pageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalRecord", SqlDbType.Int,4)};
            parameters[0].Value = DealerID;
            parameters[1].Value = FXID;
            parameters[2].Value = ShopID;
            parameters[3].Value = ShopName;
            parameters[4].Value = OrderField;
            parameters[5].Value = pageSize;
            parameters[6].Value = pageIndex;
            parameters[7].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetConfirmShopListByDealerID", parameters, "tb");
            if (ds != null)
                dt = ds.Tables[0];
            TotalNumber = (int)parameters[7].Value;

            return dt;
        }

        /// <summary>
        /// 直属客户查找已经安装的店铺列表
        /// </summary>
        /// <param name="FXID">直属客户编号</param>
        /// <param name="ShopID">店铺编号</param>
        /// <param name="ShopName">店铺名称</param>
        /// <param name="OrderField">排序字段</param>
        /// <param name="pageSize">每页显示店铺列表的个数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="TotalRecord">店铺数量</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetConfirmShopListByFXID(string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalNumber)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
                    new SqlParameter("@FXID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopID", SqlDbType.VarChar,20),
                    new SqlParameter("@ShopName", SqlDbType.VarChar,200),
                    new SqlParameter("@OrderField", SqlDbType.VarChar,1000),
                    new SqlParameter("@pageSize", SqlDbType.Int,4),
                    new SqlParameter("@pageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalRecord", SqlDbType.Int,4)};
            parameters[0].Value = FXID;
            parameters[1].Value = ShopID;
            parameters[2].Value = ShopName;
            parameters[3].Value = OrderField;
            parameters[4].Value = pageSize;
            parameters[5].Value = pageIndex;
            parameters[6].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetConfirmShopListByFXID", parameters, "tb");
            if (ds != null)
                dt = ds.Tables[0];
            TotalNumber = (int)parameters[6].Value;

            return dt;
        }
        /// <summary>
        /// 得到收发货表中的店铺的基本信息
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetSubList(string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select areaname 省区,provincename 省份,cityname 市,view_shopinfo.posid 店铺编号,view_shopinfo.shopname 店铺名称,linkman 店长,linkphone 店长电话,shopmaster 店铺负责人,shopmasterphone 负责人电话,shopphone 店铺电话,dealername 一级客户,suppliername 供应商 from view_shopinfo ,View_shippingSpeed where view_shopinfo.shopid=View_shippingSpeed.shopid ");
            if (StrWhere.Length > 0)
                sb.Append(StrWhere);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// 得到相应的发货单号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetFHID(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select GoodsOrderNO from ShippingSpeedData ");
            if (strWhere.Length > 0)
            {
                sb.Append(" where "+strWhere);
            }
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// 得到发货列表
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetFHAnaysis(string strwhere, string popid, string fhtype,string beginDate,string endDate)
        {
            SqlParameter[] para ={ 
               new SqlParameter("@strWhere",SqlDbType.VarChar,2000),
               new SqlParameter("@POPID",SqlDbType.VarChar,30),
               new SqlParameter("@FHType",SqlDbType.VarChar,20),
               new SqlParameter("@beginDate",SqlDbType.VarChar,40),
               new SqlParameter("@endDate",SqlDbType.VarChar,40)
            };
            para[0].Value = strwhere;
            para[1].Value = popid;
            para[2].Value = fhtype;
            if (beginDate.Length > 0)
                para[3].Value = beginDate+" 00:00:00";
            else
                para[3].Value = "";
            if (endDate.Length > 0)
                para[4].Value =endDate+" 00:00:00";
            else
                para[4].Value = "";
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "Pro_supplierFHAnalysis", para, "ds");
            return ds;
        }

        /// <summary>
        /// 得到收货列表
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetSHAnaysis(string strwhere)
        {
            SqlParameter[] para ={ 
               new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            
            };
            para[0].Value = strwhere;


            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "Pro_ShopSHAnalysis", para, "ds");
            return ds;
        }
        #endregion  成员方法
    }
}


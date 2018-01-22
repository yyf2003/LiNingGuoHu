using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
/// <summary>
/// 模块名称：列表分页显示所用的SQL查询
/// 编写人：秦浩
/// 编写时间：2009-05-04
/// 版本号：1.0.0.1
/// </summary>
namespace LN.DAL
{
    /// <summary>
    /// 列表分页显示所用的SQL查询
    /// </summary>
    public class GetTableListSqlExec
    {

        /// <summary>
        /// 显示指定供应商所供应的店铺
        /// </summary>
        /// <param name="sid">供应商编号</param>
        /// <returns>返回获取店铺列表的查询字符串</returns>
        public static string strGetSupplierAssignRecordSql(string sid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT s.[ID],");
            sb.Append("(SELECT TOP 1 [ProvinceName] FROM [ProvinceData] WHERE [ProvinceID] = s.AssignProID) AS ProvinceName,");
            sb.Append("(SELECT TOP 1 [CityName] FROM [CityData] WHERE [CItyID] = s.AssignCityID) AS CityName,");
            sb.Append("(SELECT TOP 1 [Shopname] FROM [ShopInfo] WHERE [ShopID] = s.AssignShopID) AS Shopname,");
            sb.Append("[AssignShopID] FROM [SupplierAssignRecord] AS s WHERE s.[SupplierID] = " + sid);

            return sb.ToString();
        }

        /// <summary>
        /// 显示指定用户所在供应商的材料列表
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>返回获取店铺列表的查询字符串</returns>
        public static string strGetSupplierMaterialSql(string uid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT [MateriaID],[MateriaPro],[SupplierID],[IsDelete],[issupport] FROM [POPMateriaData] ");
            //sb.Append("WHERE [SupplierID] = (SELECT TOP 1 [SupplierID] FROM [SupplierUserManage] ");
            //sb.Append(" WHERE [UserID] = " + uid + ")");

            return sb.ToString();
        }

        /// <summary>
        /// 查询指定供应商的人员列表
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回获取人员列表的查询字符串</returns>
        public static string strGetSupplierUserSql(string SupplierID, string strWhere)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT (SELECT TOP 1 UserID FROM SupplierUserManage WHERE UserID=u.UserID) AS UserID,Username,Sex,UserEmail,UserAddress,UserPhone,UserMobel,UserDesc,TypeID ");
            sb.AppendFormat(" FROM SupplierUserManage,UserInfo AS u  WHERE SupplierUserManage.UserID=u.UserID AND u.UserState=1 AND SupplierUserManage.SupplierID={0}", SupplierID);
            if (strWhere != null)
            {
                sb.Append(strWhere);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取供应商负责的店铺列表（不排序）
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="strWhere">搜索条件</param>
        /// <returns>返回店铺列表的查询字符串</returns>
        public static string strShopListBySupplierID(string SupplierID, string strWhere)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT  ROW_NUMBER() OVER (ORDER BY [PosID],[ShopID],[DealerName],[FXName]) AS SNumberID,[ShopID],[PosID],[Shopname],[ProvinceID],[CityID],[DealerID],[FXID],[ProvinceName],[DealerName],[CityName],(select count(*) from imageToPOP where shopid=view_shopinfo.shopid) POPSumNum  from view_shopinfo where [ShopID] IN (SELECT DISTINCT [AssignShopID] ");
            sb.Append(" FROM [SupplierAssignRecord] WHERE [SupplierID] = "+SupplierID+") AND ");
            sb.Append("ExamState=1 and [ShopID] NOT IN (SELECT [ShopID] FROM [ShippingSpeedData] WHERE  [POPID]=(SELECT TOP 1 POPID FROM POPLaunch where steps=0  ORDER BY ID DESC))");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sb.Append(strWhere);                
            }
            
            return sb.ToString();
        }


        /// <summary>
        /// 获取供应商负责的店铺列表（排序）
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="strWhere">搜索条件</param>
        /// <returns>返回店铺列表的查询字符串</returns>
        public static string strShopListBySuppliersID(string SupplierID, string strWhere)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT  ROW_NUMBER() OVER (ORDER BY [PosID],[ShopID],[DealerName],[FXName]) AS SNumberID,[ShopID],[PosID],[Shopname],[ProvinceID],[CityID],[DealerID],[FXID],[ProvinceName],[DealerName],[CityName],(select count(*) from imageToPOP where shopid=view_shopinfo.shopid) POPSumNum  from view_shopinfo where [ShopID] IN (SELECT DISTINCT [AssignShopID] ");
            sb.Append(" FROM [SupplierAssignRecord] WHERE [SupplierID] = " + SupplierID + ") AND ");
            sb.Append("ExamState=1 and [ShopID] NOT IN (SELECT [ShopID] FROM [ShippingSpeedData] WHERE  [POPID]=(SELECT TOP 1 POPID FROM POPLaunch where steps=0  ORDER BY ID DESC))");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sb.Append(strWhere);                
            }
            sb.Append(" order by [PosID],[ShopID],[DealerName],[FXName]");

            return sb.ToString();
        }

        /// <summary>
        /// 得到要收货的店铺信息列表
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <param name="POPID"></param>
        /// <param name="childstr"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static string strReceiveGoodsShoplist( string strWhere)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select  goodsorderno,FHDate,DealerID,SupplierName,count(*) ShopCount,Remars  from dbo.View_shippingSpeed where 1=1 ");
                   
            if (!string.IsNullOrEmpty(strWhere))
            {
                sb.Append(strWhere);
            }
            sb.Append("   group by goodsorderno,FHDate,DealerID,SupplierName  ,Remars");
            return sb.ToString();
        }
        /// <summary>
        /// 获取查询发货分析的列表
        /// </summary>
        /// <param name="strWhere">搜索条件</param>
        /// <returns></returns>
        public static string strGetShippingSpeedData(string strWhere, string POPID, string IsState)
        {
            StringBuilder sb = new StringBuilder();
            string st1 = "";
            string st2 = "";

            if (!string.IsNullOrEmpty(POPID))
            {
                st1 = "and POPID='" + POPID + "'";
            }
            if (!string.IsNullOrEmpty(IsState))
            {
                st2 = "and IsState='" + IsState + "'";
            }
            sb.Append(" select [ShopID]  ,[PosID] ,[Shopname] ,[ProvinceID],[CityID] ,[SaleTypeID],[Boolinstall],[DealerID],[ShopState],SupplierID  ");
            sb.Append(" ,(select IsState from ShippingSpeedData where a.shopid=ShippingSpeedData.Shopid " + st1 + st2 + "  ) as istate   ");
            sb.Append(",(select FHDate from ShippingSpeedData where a.shopid=ShippingSpeedData.Shopid  " + st1 + st2 + ") as FHDate   ");
            sb.Append(",(select SHDate from ShippingSpeedData where a.shopid=ShippingSpeedData.Shopid " + st1 + st2 + " ) as SHDate  ");
            sb.Append(",(select POPCount from ShippingSpeedData where a.shopid=ShippingSpeedData.Shopid  " + st1 + st2 + ") as POPCount ");
            sb.Append(",(select POPID from ShippingSpeedData where a.shopid=ShippingSpeedData.Shopid  " + st1 + st2 + ") as POPID  ");
            sb.Append(",(select GetInState from ShippingSpeedData where a.shopid=ShippingSpeedData.Shopid " + st1 + st2 + " ) as GetInState ");
            sb.Append("  from shopinfo as a,SupplierAssignRecord as b  where ShopState=1 and ExamState=1 and a.shopid=b.AssignShopID ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sb.Append("and 1=1 " + strWhere);
            }

            return sb.ToString();
        }


        /// <summary>
        /// 得到POPInfo List
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static string strGetPOPInfo(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = "where  1=1 " + strWhere;
            }
            sb.Append(" select POPInfo.[ID], POPInfo.[ShopID]   ,[SeatNum],[POPseat],[SeatDesc],[POPHeight],[POPWith] ,[POPArea]  ");
            sb.Append("   ,[POPMaterial],[ProductLineID],[Sexarea],[TwoSided],[Glass],[PlatformWith],[PlatformHeight]  ");
            sb.Append("   ,[PlatformLong],shopname,Posid from POPInfo ");
            sb.Append("  inner join shopinfo	");
            sb.Append(" on POPInfo.shopid =shopinfo.shopid ");
            sb.Append("   where POPInfo.shopid in ");
            sb.Append("   (  select shopid from ShopInfo " + strWhere + ") ");  
            return sb.ToString(); 
        }

        /// <summary>
        /// 查询指定供应商的人员列表
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回获取人员列表的查询字符串</returns>
        public static string strGetDistributorsInfoSql(string FXID, string FXName, string DealerName,string DealerID,string dept,string areaID,string ProId,string cityId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ROW_NUMBER() OVER (ORDER BY FXID ASC) AS SNumberID, ");
            sb.Append(" [FXID],[FXName],[FXContactor],[FXPhone],[FXtel], DealerName FROM [DistributorsInfo] ");
            sb.Append(" INNER JOIN [DealerInfo] ON DistributorsInfo.DealerID = DealerInfo.DealerID left join areadata on [DistributorsInfo].areaID=areaData.areaID WHERE 1=1 ");
            if (FXID.Trim() != "")
                sb.AppendFormat(" AND FXID='{0}'", FXID);
            if (FXName.Trim() != "")
                sb.AppendFormat(" AND FXName LIKE '%{0}%'", FXName);
            if (DealerName.Trim() != "")
                sb.AppendFormat(" AND DealerName LIKE '%{0}%'", DealerName);
            if (DealerID.Trim() != "")
                sb.AppendFormat(" and [DistributorsInfo].DealerID like '%{0}%'",DealerID);
            if (dept.Trim() != "0")
                sb.AppendFormat(" and department='{0}'",dept);
            if (areaID != "0")
            {
                //sb.AppendFormat(" and DistributorsInfo.areaID={0}", areaID);
                sb.AppendFormat(" and DistributorsInfo.areaID in ({0})", areaID);
            }
            if (ProId != "0")
                sb.AppendFormat(" and DistributorsInfo.provinceID={0}",ProId);
            if (cityId != "0")
                sb.AppendFormat(" and DistributorsInfo.cityID={0}",cityId);
            return sb.ToString();
        }

        /// <summary>
        /// 查询故事包列表
        /// </summary>
        /// <param name="PName">故事包名称</param>
        /// <param name="TypeID">所属品类编号</param>
        /// <returns>返回获取故事包列表的查询字符串</returns>
        public static string strGetStoryBagListSql(string PName, string TypeID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ROW_NUMBER() OVER (ORDER BY ProductLineID DESC) AS SNumberID, ");
            sb.Append(" [ProductLineID],[ProductLine],[TypeID],[ProductTypeName],[IsDelete] FROM [ProductLineData] ");
            sb.Append(" INNER JOIN [ProductLineType] ON ProductLineData.TypeID = ProductLineType.ProductTypeID WHERE 1=1 ");
            if (TypeID.Trim() != "0")
                sb.AppendFormat(" AND TypeID={0}", TypeID);
            if (PName.Trim() != "")
                sb.AppendFormat(" AND ProductLine LIKE '%{0}%'", PName);

            return sb.ToString();
        }

        /// <summary>
        /// 得到公总共需要发货的数量
        /// </summary>
        /// <param name="strWhere">要查询的条件</param>
        /// <returns>返回的数量int类型</returns>
        public static int GetSupplierNeedShippingCount(string strWhere)
        {
            int num = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("select Count(*) from dbo.View_SupplierAssignRecord where ShopState=1 and ExamState=1  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sb.Append(strWhere);
            }

            SqlDataReader readr = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), sb.ToString());
            if (readr.Read())
            {
                if (!string.IsNullOrEmpty(readr.GetInt32(0).ToString()))
                {
                    num = int.Parse(readr.GetInt32(0).ToString());
                }
            }
            readr.Close();
            return num;
        }

        

        /// <summary>
        /// 根据制定分页实体参数，得到指定列表集合
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回指定列表集合</returns>
        public static DataTable GetList(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
					new SqlParameter("@SelectSql", SqlDbType.VarChar,5000),
                    new SqlParameter("@OrderField", SqlDbType.VarChar,1000),
                    new SqlParameter("@pageSize", SqlDbType.Int,4),
                    new SqlParameter("@pageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalRecord", SqlDbType.Int,4)};
            parameters[0].Value = model.SelectSql;
            parameters[1].Value = model.OrderField;
            parameters[2].Value = model.pageSize;
            parameters[3].Value = model.pageIndex;
            parameters[4].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "sp_GetPage2005ForSql", parameters, "tb");
            if (ds != null)
                dt = ds.Tables[0];
            TotalNumber = (int)parameters[4].Value;

            return dt;
        }


        /// <summary>
        /// 返回查询的数据列表
        /// </summary>
        /// <param name="StrSql"></param>
        /// <returns></returns>
        public static DataSet GetAnalysisDataWithSql(string StrSql)
        {
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), StrSql);
        }
        /// <summary>
        /// 得到相应发起POP的开始时间
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static string GetPOPOfBegindate(string sqlstr)
        {
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sqlstr);
          return obj.ToString();
        }

    }
}

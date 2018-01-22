using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类AssignRecord。
    /// </summary>
    public class SupplierAssignRecord
    {
        public SupplierAssignRecord()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "ID", "AssignRecord");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SupplierAssignRecord");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SupplierAssignRecord");
            strSql.Append(" where ");
            strSql.Append(strWhere);


            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.SupplierAssignRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SupplierAssignRecord(");
            strSql.Append("SupplierID,AssignRuleID,AssignProID,AssignCityID,AssignShopID,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@SupplierID,@AssignRuleID,@AssignProID,@AssignCityID,@AssignShopID,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4),
					new SqlParameter("@AssignProID", SqlDbType.Int,4),
					new SqlParameter("@AssignCityID", SqlDbType.Int,4),
					new SqlParameter("@AssignShopID", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.VarChar,500)};
            parameters[0].Value = model.SupplierID;
            parameters[1].Value = model.AssignRuleID;
            parameters[2].Value = model.AssignProID;
            parameters[3].Value = model.AssignCityID;
            parameters[4].Value = model.AssignShopID;
            parameters[5].Value = model.Remarks;

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
        public void Update(LN.Model.SupplierAssignRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SupplierAssignRecord set ");
            strSql.Append("SupplierID=@SupplierID,");
            strSql.Append("AssignRuleID=@AssignRuleID,");
            strSql.Append("AssignProID=@AssignProID,");
            strSql.Append("AssignCityID=@AssignCityID,");
            strSql.Append("AssignShopID=@AssignShopID,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@AssignRuleID", SqlDbType.Int,4),
					new SqlParameter("@AssignProID", SqlDbType.Int,4),
					new SqlParameter("@AssignCityID", SqlDbType.Int,4),
					new SqlParameter("@AssignShopID", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SupplierID;
            parameters[2].Value = model.AssignRuleID;
            parameters[3].Value = model.AssignProID;
            parameters[4].Value = model.AssignCityID;
            parameters[5].Value = model.AssignShopID;
            parameters[6].Value = model.Remarks;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SupplierAssignRecord ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.SupplierAssignRecord GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SupplierID,AssignRuleID,AssignProID,AssignCityID,AssignShopID,Remarks from SupplierAssignRecord ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.SupplierAssignRecord model = new LN.Model.SupplierAssignRecord();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SupplierID"].ToString() != "")
                {
                    model.SupplierID = int.Parse(ds.Tables[0].Rows[0]["SupplierID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignRuleID"].ToString() != "")
                {
                    model.AssignRuleID = int.Parse(ds.Tables[0].Rows[0]["AssignRuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignProID"].ToString() != "")
                {
                    model.AssignProID = int.Parse(ds.Tables[0].Rows[0]["AssignProID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignCityID"].ToString() != "")
                {
                    model.AssignCityID = int.Parse(ds.Tables[0].Rows[0]["AssignCityID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignShopID"].ToString() != "")
                {
                    model.AssignShopID = int.Parse(ds.Tables[0].Rows[0]["AssignShopID"].ToString());
                }
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SupplierID,AssignRuleID,AssignProID,AssignCityID,AssignShopID,Remarks ");
            strSql.Append(" FROM SupplierAssignRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// 根据分配的城市 将所在城市的店铺ID 放到 SupplierAssignRecord 表中
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="cityIDlist"></param>
        /// <returns></returns>
        public bool allotshop(string gid, string PosIDlist, string dept, string areaIDlist, string Prolist)
        {
            List<string> list = new List<string>();
            StringBuilder delsql = new StringBuilder();
            delsql.Append("delete SupplierAssignRecord where SupplierID=" + gid);

            list.Add(delsql.ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [SupplierAssignRecord]");
            strSql.Append("([SupplierID]");
            strSql.Append(",[AssignRuleID]");
            strSql.Append(",[AssignProID]");
            strSql.Append(",[AssignCityID]");
            strSql.Append(",[AssignShopID]");
            strSql.Append(",[Remarks])");
            strSql.Append("SELECT ");
            strSql.Append(gid);
            strSql.Append(",0");
            strSql.Append(",provinceID");
            strSql.Append(",Cityid");
            strSql.Append(",Shopid");
            strSql.Append(",areaid ");
            strSql.Append("FROM view_shopinfo WHERE 1=1 ");
            if (dept.Length > 0)
            {
                strSql.Append(" AND department in (" + dept + ") ");
            }
            if (areaIDlist.Length > 0)
            {
                strSql.Append(" AND areaid in (" + areaIDlist + ") ");
            }
            if (Prolist.Length > 0)
            {
                strSql.Append(" AND provinceID in (" + Prolist + ") ");

            }
            if (PosIDlist.Length > 0)
            {
                strSql.Append(" AND shopid in (" + PosIDlist + ") ");
            }
            
            list.Add(strSql.ToString());
            try
            {
                DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), list);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        ///// <summary>
        ///// 根据分配的城市 将所在城市的店铺ID 放到 SupplierAssignRecord 表中
        ///// </summary>
        ///// <param name="gid"></param>
        ///// <param name="cityIDlist"></param>
        ///// <returns></returns>
        //public bool allotshop(string gid, string PosIDlist, string dept, string areaIDlist, string Prolist)
        //{
        //    List<string> list = new List<string>();
        //    StringBuilder delsql = new StringBuilder();
        //    delsql.Append("delete SupplierAssignRecord where SupplierID=" + gid);

        //    list.Add(delsql.ToString());
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into SupplierAssignRecord (SupplierID,AssignShopID,AssignRuleID,AssignProID,AssignCityID,Remarks)");
        //    if (PosIDlist.Length > 0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where shopid in (" + PosIDlist + ") ");
        //    }
        //    else if (Prolist.Length>0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where provinceID in (" + Prolist + ") ");

        //    }
        //    else if (areaIDlist.Length > 0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where areaid in (" + areaIDlist + ") ");
        //    }
        //    else if (dept.Length > 0)
        //    {
        //        strSql.Append(" select '" + gid + "' ,Shopid,0,provinceID,Cityid,areaid from view_shopinfo where department in (" + dept + ") ");
        //    }
        //    list.Add(strSql.ToString());
        //    try
        //    {
        //        DbHelperSQL.ExecuteSqlTran(list);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}
        /// <summary>
        /// 得到店铺所属的供应商
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public string GetSuplierID(string shopid)
        {
            string returnstr = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 SupplierID from SupplierAssignRecord where shopid=" + shopid);

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
            if (obj != null)
            {
                returnstr = (string)obj;
            }
            return returnstr;

        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="strWhere"></param>
      /// <returns></returns>
        public string GetSuplierIDbyArea(string strWhere)
        {
            string returnstr = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct top 1 SupplierID from SupplierAssignRecord ");

            if (strWhere.Length > 0)
            {
                strSql.Append(" where ");
                strSql.Append(strWhere);
            }
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
            if (obj != null)
            {
                returnstr = obj.ToString();
            }
            return returnstr;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetSuplierIDListbyArea(string AreaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SupplierID from SupplierAssignRecord ");
            //strSql.AppendFormat(" where Remarks = '{0}'  group by SupplierID", AreaID);
            strSql.AppendFormat(" where Remarks in ({0})  group by SupplierID", AreaID);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());

            return ds.Tables[0];

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetAssignRecordByID(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = GetTableListSqlExec.GetList(model, out TotalNumber);
            if (dt != null)
                return dt;
            else
                return null;

        }
        /// <summary>
        /// 根据店铺得到供应商信息
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public DataTable GetSpplierAssignRecordWithShopID(int ShopID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,SupplierID,SupplierName,AssignProID,ProvinceName,AssignCityID,Cityname,AssignShopID,ShopName,Remarks ");
            strSql.Append(" FROM View_SupplierAssignRecord ");
            strSql.Append(" where  AssignShopID =" + ShopID);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// 根据供应商得到管理的店铺数据数量
        /// </summary>
        /// <param name="Supplierid"></param>
        /// <returns></returns>
        public int GetShopData(int Supplierid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  select count(*) from SupplierAssignRecord ");
            if (Supplierid > 0)
            {
                sb.Append(" where SupplierID = " + Supplierid.ToString());
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
        /// 从视图中得到数据。 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getdatafromView(string strWhere)
        {// posid ,shopname ShopMaster ShopMasterPhone dealername SupplierName
            StringBuilder sb = new StringBuilder();
            sb.Append("select *  from View_SupplierAssignRecord ");
            if (strWhere.Length > 0)
                sb.Append(string.Format(" where shopstate=1 and  {0} ",strWhere));

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 得到供应商的供应区域
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable GetSupplierArea(int supplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select areaname,areaid from areadata where areaid in ( select distinct areaid from View_SupplierAssignRecord");
            if (supplierID > 0)
                sb.Append(string.Format(" where supplierid={0}",supplierID));
            sb.Append(")");
            sb.Append(" order by areaid");
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        public DataTable GetSupplierPro(int supplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select provincename,areaid,provinceID from provinceData where provinceID in ( select  distinct AssignProID from SupplierAssignRecord ");
            if (supplierID > 0)
                sb.Append(string.Format(" where supplierid={0}", supplierID));
            sb.Append(") order by areaid");
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 根据供应商的ID得到供应商所有负责的区域的POP信息
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable Getsupplier_popinfo(int supplierID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   SELECT  ");
            sb.Append(" [PosID] 店铺编号 ,[Shopname] 店铺名称,[Shopsamplename] 店铺简称 ,[PostAddress] 店铺邮政地址,[PostCode] 店铺邮编,[ShopPhone] 店铺固定电话,[LinkMan] 店长,[LinkPhone] 店长移动电话,[Email] 店长email,[FaxNumber] 店铺传真号码 ");
            sb.Append(" ,[Boolinstall] 是否李宁公司统一支持安装,[DealerID] 一级客户编号,[DealerName] 一级客户名,(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as 店铺状态,[DepartMent] 部门名称 ");
            sb.Append(" ,[AreaName] 区域名称,[ProvinceName] 省名称,[cityname] 地级城市名称,[cityLevel] 地市级城市级别_市场定义,[townName] 区县级城市名称,TownLevel 区县级城市级别_市场定义 ,[ShopMaster] 店铺零售负责人 ");
            sb.Append(" ,[ShopMasterPhone] 店铺零售负责人移动电话,(select shoptypename from shoptype where id=view_shopinfo.shoptype) as  店铺类型 ");
            sb.Append(" ,shoplevel 店铺级别,[ShopVI] 店铺形象属性,[ShopArea] 营业面积,[DSRMaster] 李宁DSR负责人,[DSRMasterPhone] 李宁DSR负责人电话,[VMMaster] 李宁省区VM负责人,[VMMasterPhone] 李宁省区VM负责人电话,Department_Master 李宁大区VM经理,department_MasterPhone 李宁大区VM经理电话,[FXID] 直属客户编号,[FXName] 直属客户名 ");
            sb.Append(" ,[CustomerGroupID] 上级客户集团编号,[CustomerGroupName] 上级客户级别,[ShopOwnerShip] 店铺产权关系,[CustomerCard] 客户身份,[SeatNum] POP编号,[POPseat] POP类型,[SeatDesc] 位置描述 ");
            sb.Append(" ,producttypename 故事包大类,View_ProductLine.productline POP故事包,[RealHeight] POP实际制作高,[RealWith] POP实际制作宽,[POPHeight] POP可视画面高,[POPWith] POP可视画面宽,[POPPlwz] POP可视画面位置,[POPPljd] POP可视画面偏离角度,[POPArea] POP面积,[POPMaterial] POP材质,[Sexarea] 男女区域,[TwoSided] 是否为双面 ");
            sb.Append(" ,[Glass] 是否粘贴于玻璃上,[PlatformWith] 橱窗空间进深mm,[PlatformHeight] 橱窗空间长度mm,[PlatformLong] 橱窗空间面积 ");
            sb.Append(" FROM  ((View_ShopInfo inner join popinfo on View_ShopInfo.shopid=popinfo.shopid) ");
            sb.Append(" left join View_ProductLine on POPInfo.ProductLineID = dbo.View_ProductLine.ProductLineID) ");

            if (supplierID > 0)
            {
                sb.Append(string.Format(" where supplierID={0}", supplierID));
            }

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }



        public DataTable GetSuplierByProvinceId(int provinceid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SupplierAssignRecord.SupplierID,SupplierInfo.SupplierName,SupplierInfo.ShortName from SupplierAssignRecord join SupplierInfo on SupplierInfo.SupplierID=SupplierAssignRecord.SupplierID");
            strSql.AppendFormat(" where AssignProID = {0}  group by SupplierID", provinceid);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());

            return ds.Tables[0];

        }


        #endregion  成员方法
    }
}


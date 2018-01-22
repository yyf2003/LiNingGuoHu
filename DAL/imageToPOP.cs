using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
	/// <summary>
	/// 数据访问类imageToPOP。
	/// </summary>
	public class imageToPOP
	{
		public imageToPOP()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from imageToPOP");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LN.Model.imageToPOP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into imageToPOP(");
			strSql.Append("POPID,POPinfoID,imageID,prolineID,shopid,sysTime)");
			strSql.Append(" values (");
			strSql.Append("@POPID,@POPinfoID,@imageID,@prolineID,@shopid,@sysTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@imageID", SqlDbType.Int,4),
					new SqlParameter("@prolineID", SqlDbType.Int,4),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@sysTime", SqlDbType.DateTime)};
			parameters[0].Value = model.POPID;
			parameters[1].Value = model.POPinfoID;
			parameters[2].Value = model.imageID;
			parameters[3].Value = model.prolineID;
			parameters[4].Value = model.shopid;
			parameters[5].Value = model.sysTime;

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
        /// 更新图片地址 add by mhj 2012.2.5
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type">0为更新前图片，1更新后图片</param>
        /// <returns></returns>
        public int UpdateImage(LN.Model.imageToPOP model, int type)
        {
            string strSql = "";
            if (type == 1)
            {
                strSql = "update imageToPOP set NewImageUrl_Small='" + model.NewImageUrl_Small + "',NewImageUrl_Big='" + model.NewImageUrl_Big + "' where id=" + model.ID;
            }
            else
            {
                strSql = "update imageToPOP set OldImageUrl_Small='" + model.OldImageUrl_Small + "',OldImageUrl_Big='" + model.OldImageUrl_Big + "' where id=" + model.ID;
            }
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.imageToPOP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update imageToPOP set ");
			strSql.Append("POPID=@POPID,");
			strSql.Append("POPinfoID=@POPinfoID,");
			strSql.Append("imageID=@imageID,");
			strSql.Append("prolineID=@prolineID,");
			strSql.Append("shopid=@shopid,");
			strSql.Append("sysTime=@sysTime");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@imageID", SqlDbType.Int,4),
					new SqlParameter("@prolineID", SqlDbType.Int,4),
					new SqlParameter("@shopid", SqlDbType.Int,4),
					new SqlParameter("@sysTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.POPID;
			parameters[2].Value = model.POPinfoID;
			parameters[3].Value = model.imageID;
			parameters[4].Value = model.prolineID;
			parameters[5].Value = model.shopid;
			parameters[6].Value = model.sysTime;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from imageToPOP ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string str)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from imageToPOP ");
            strSql.Append(" where  "+ str);

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString());
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.imageToPOP GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,POPID,POPinfoID,imageID,prolineID,shopid,sysTime from imageToPOP ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			LN.Model.imageToPOP model=new LN.Model.imageToPOP();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.POPID=ds.Tables[0].Rows[0]["POPID"].ToString();
				if(ds.Tables[0].Rows[0]["POPinfoID"].ToString()!="")
				{
					model.POPinfoID=int.Parse(ds.Tables[0].Rows[0]["POPinfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["imageID"].ToString()!="")
				{
					model.imageID=int.Parse(ds.Tables[0].Rows[0]["imageID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["prolineID"].ToString()!="")
				{
					model.prolineID=int.Parse(ds.Tables[0].Rows[0]["prolineID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["shopid"].ToString()!="")
				{
					model.shopid=int.Parse(ds.Tables[0].Rows[0]["shopid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sysTime"].ToString()!="")
				{
					model.sysTime=DateTime.Parse(ds.Tables[0].Rows[0]["sysTime"].ToString());
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
			strSql.Append("select ID,POPID,POPinfoID,imageID,prolineID,shopid,sysTime ");
			strSql.Append(" FROM imageToPOP ");
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
			strSql.Append(" ID,POPID,POPinfoID,imageID,prolineID,shopid,sysTime ");
			strSql.Append(" FROM imageToPOP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
		}

        public DataTable getShoplist(string str)
        {
            string strsql = "SELECT [AreaName] 省区,[ProvinceName] 省 ,[cityname] 市 ,[PosID] 店铺编号 ,[Shopname] 店铺名称 ,[ShopAddress] 店铺地址 ,[ShopOpenDate] 开店日期";
            strsql += "   ,[LinkMan]  店长,[LinkPhone] 店长联系电话,[Email] email,[PostAddress] 邮政地址,[PostCode] 邮编,[FaxNumber] 传真";

            strsql += "  ,[DealerID] 一级客户编号,[DealerName] 一级客户,[FXID]  直属客户编号,[FXName] 直属客户,[ShopLevel] 店铺级别,[ShopMaster] 店铺负责人";
            strsql += " ,[ShopMasterPhone] 负责人联系方式";
            strsql += "  ,[ShopArea] 店铺面积,[DSRMaster] DSR负责人,[DSRMasterPhone] DSR负责人电话 ";
            strsql += " ,[VMMasterPhone] VM负责人,[VMMaster]  VM负责人电话";
            strsql += "  ,[ShopPhone]  店铺电话,[CustomerGroupID] 客户集团编号,[CustomerGroupName] 客户集团";

            strsql += " FROM [View_ShopInfo] where "+str;



            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql);
            DataTable dt1 = new DataTable();
            dt1 = ds.Tables[0];
            ds.Tables.Clear();
            return dt1;
        }

        public DataTable GetshoplistNO(string str)
        {
            string strsql1 = "SELECT [AreaName] 省区,[ProvinceName] 省 ,[cityname] 市 ,[PosID] 店铺编号 ,[Shopname] 店铺名称 ,[ShopAddress] 店铺地址 ,[ShopOpenDate] 开店日期";
            strsql1 += "   ,[LinkMan]  店长,[LinkPhone] 店长联系电话,[Email] email,[PostAddress] 邮政地址,[PostCode] 邮编,[FaxNumber] 传真";

            strsql1 += "  ,[DealerID] 一级客户编号,[DealerName] 一级客户,[FXID]  直属客户编号,[FXName] 直属客户,[ShopLevel] 店铺级别,[ShopMaster] 店铺负责人";
            strsql1 += " ,[ShopMasterPhone] 负责人联系方式";
            strsql1 += "  ,[ShopArea] 店铺面积,[DSRMaster] DSR负责人,[DSRMasterPhone] DSR负责人电话 ";
            strsql1 += " ,[VMMasterPhone] VM负责人,[VMMaster]  VM负责人电话";
            strsql1 += "  ,[ShopPhone]  店铺电话,[CustomerGroupID] 客户集团编号,[CustomerGroupName] 客户集团";

            strsql1 += " FROM [View_ShopInfo] where "+str;

            DataSet ds1 = DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql1);
            DataTable dt=new DataTable();
            dt= ds1.Tables[0];
            ds1.Tables.Clear();
            return dt;
        }
        /// <summary>
        /// 得到各个供应商所得到的订单数量
        /// </summary>
        /// <returns></returns>
        public DataTable Supplier_POPcount(string strwhere)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" select a.supplierid,[SupplierName],[Contacter],[ContactPhone],popcount from supplierinfo a,(select  c.[SupplierID],count(POPinfoID) as popcount ");
            sb.Append("  from imagetopop inner join  dbo.SupplierAssignRecord c on AssignShopID=shopid inner join areadata on c.remarks=areadata.areaid  ");
            sb.Append(strwhere);
            sb.Append(" group by c.supplierID) b where a.supplierid=b.supplierid ");
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// 得到各个图片的POP的数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_popcountByimg(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select imagetopop.imageID, smallImageUrl,ImageLevel,count(popinfoID) popcount, imageUrl from imagetopop,SupplierAssignRecord,dbo.POPImageData where AssignShopID=shopid  and imagetopop.imageid=POPImageData.ImageID  ");
            if (strWhere.Length > 0)
                sb.Append(strWhere);

            sb.Append(" group by smallImageUrl, imageUrl,ImageLevel,imagetopop.imageID ");

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 根据条件导出订单 每张pop信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable supplier_orderdaochu(string strWhere, string POPID)
        {
            StringBuilder sb = new StringBuilder();

            //modify by mhj 2012.06.12 去掉多余字段
            sb.Append(" SELECT ");
            //sb.Append("[PosID] 店铺编号 ,[Shopname] 店铺名称,[Shopsamplename] 店铺简称 ,[PostAddress] 店铺邮政地址,[PostCode] 店铺邮编,[ShopPhone] 店铺固定电话");
            sb.Append("[PosID] 店铺编号 ,[Shopname] 店铺名称,[Shopsamplename] 店铺简称 ,[PostAddress] 店铺邮政地址");
            sb.Append(",[cityname] 地市级城市名称,(SELECT [TCL_Name] FROM [TownCityLevel] where [TCL_Id]=view_shopinfo.ACL_ID) as 地市级城市级别_市场定义");
            sb.Append(",[townName] 区县级城市名称,(SELECT [ACL_Name] FROM [AreaCityLevel] where [ACL_Id]=view_shopinfo.ACL_Id) as 区县级城市级别_市场定义 ");
            sb.Append(",[ProvinceName] 省名称,[AreaName] 区域名称,[DepartMent] 部门名称,(select shoptypename from shoptype where id=view_shopinfo.shoptype) as  店铺类型");
            sb.Append(",[ShopOwnerShip] 店铺产权关系,( select top 1 SaleType from saletypeInfo where SaleTypeID= view_shopinfo.SaleTypeID) as 店铺零售属性,shoplevel 店铺级别,(SELECT [ShopVIName] FROM [ShopVI] where [ShopVIID]=view_shopinfo.[ShopVI]) as 店铺形象属性");
            //sb.Append(",(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as 店铺状态 ,[CustomerCard] 客户身份");
            sb.Append(",(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as 店铺状态 ,[ShopArea] 营业面积,[CustomerCard] 客户身份");
            //sb.Append(",[FXID] 直属客户编号,[FXName] 直属客户名,(SELECT TOP 1 [FXContactor] FROM [DistributorsInfo] where [FXID]=view_shopinfo.FXID) as 直属客户POP负责人姓名");
            sb.Append(",[FXID] 直属客户编号,[FXName] 直属客户名");
            //sb.Append(",(SELECT TOP 1 [FXPhone] FROM [DistributorsInfo] where [FXID]=view_shopinfo.FXID) as 直属客户POP负责人移动电话");
            //sb.Append(",[DealerID] 一级客户编号,[DealerName] 一级客户名,(SELECT TOP 1 [Contactor] FROM [DealerInfo] where [DealerID]=view_shopinfo.DealerID) as 一级客户POP负责人姓名");
            sb.Append(",[DealerID] 一级客户编号,[DealerName] 一级客户名");
            //sb.Append(",(SELECT TOP 1 [ContactorPhone] FROM [DealerInfo] where [DealerID]=view_shopinfo.DealerID) as 一级客户POP负责人移动电话");
            //sb.Append(",[CustomerGroupID] 上级客户集团编号,[CustomerGroupName] 上级客户级别,[LinkMan] 店长,[LinkPhone] 店长移动电话,[Email] 店长email,[ShopMaster] 店铺零售负责人,[ShopMasterPhone] 店铺零售负责人移动电话");
            sb.Append(",[CustomerGroupID] 上级客户集团编号");

            //sb.Append(",[Boolinstall] 是否李宁公司统一支持安装,[VMMaster] 李宁省区VM负责人,[VMMasterPhone] 李宁省区VM负责人移动电话,Department_Master 李宁大区VM经理,department_MasterPhone 李宁大区VM经理移动电话");
            sb.Append(",[Boolinstall] 是否李宁公司统一支持安装");

            //sb.Append(",[DSRMaster] 李宁DSR负责人,[DSRMasterPhone] 李宁DSR负责人移动电话 ");
            sb.Append(",(select supplierName from supplierinfo where supplierID=view_shopinfo.supplierID) as 所属POP供应商 , ");
            sb.Append("(select count(*) from popinfo where  popinfo.shopid=view_shopinfo.shopid and examstate=1 and IsHide=0) 店铺POP总数量 ,");
            sb.Append("(select count(*) from popinfo where  popinfo.shopid=view_shopinfo.shopid and popinfo.IsHide=0 and  popinfo.id not in (select popinfoid from imagetopop where popinfoid=popinfo.id and imagetopop.popid='" + POPID + "' ) and examstate=1) 店铺未提交订单的POP数量 ,");
            sb.Append("[SeatNum] POP编号,[POPseat] POP类型,[SeatDesc] 位置描述,");
            sb.Append("(select top 1 [imagelevel] from (select POPImageData.[imagelevel],imagetopop.popinfoid from  POPImageData inner join imagetopop on imagetopop.imageid=POPImageData.imageid  where POPImageData.popid='" + POPID + "' and imagetopop.popinfoid=popinfo.id) b where popinfo.id=b.popinfoid) 图片编号 ");
            sb.Append(",producttypename 故事包大类,View_ProductLine.productline POP故事包,[POPMaterial] POP材质,[POPMaterialRemark] 材质备注,[RealWith] POP实际制作宽mm,[RealHeight] POP实际制作高mm,[POPWith] POP可视画面宽mm,[POPHeight] POP可视画面高mm,[POPPlwz] POP可视画面位置,[POPPljd] POP可视画面偏离角度,[POPArea] POP面积,[Sexarea] 男女区域,[TwoSided] 是否为双面 ");
            sb.Append(",[Glass] 是否粘贴与玻璃表面,[PlatformWith] 橱窗空间进深mm,[PlatformHeight] 橱窗空间长度mm,[PlatformLong] 橱窗空间面积  ");
            sb.Append(",c.sysTime as 提交订单时间 ");
            sb.Append("FROM  View_ShopInfo inner join popinfo on View_ShopInfo.shopid=popinfo.shopid ");
            sb.Append("left join View_ProductLine on POPInfo.ProductLineID = dbo.View_ProductLine.ProductLineID ");
            sb.Append("  inner join (select distinct popinfoid,imageID,sysTime from imagetopop where popid='" + POPID + "') c on popinfo.id=c.popinfoid ");
            if (strWhere.Length > 0)
                sb.Append(" where " + strWhere);
            sb.Append("  order by posid ");
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// 得到没有提交订单的店铺列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShop(string strWhere)
        {
            StringBuilder sb = new StringBuilder();


            //sb.Append(" SELECT  shopid 系统编号,");
            sb.Append(" SELECT  ");
            sb.Append("(SELECT COUNT(ID) FROM imageToPOP WHERE POPID IN (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) AND shopid=ShopInfo.shopid) as 已提交订单个数, ");
            sb.Append("(SELECT COUNT(ID) FROM POPInfo WHERE  ShopID=ShopInfo.shopid and IsHide=0) as POP总数, ");
            sb.Append("[PosID] 店铺编号 ,[Shopname] 店铺名称,[Shopsamplename] 店铺简称 ,[PostAddress] 店铺邮政地址,[PostCode] 店铺邮编,[ShopPhone] 店铺固定电话,[LinkMan] 店长,[LinkPhone] 店长移动电话,[Email] 店长email,[FaxNumber] 店铺传真号码,");
            sb.Append("[Boolinstall] 是否李宁公司统一支持安装,[DealerID] 一级客户编号,");
            sb.Append("(SELECT TOP 1 [DealerName] FROM [DealerInfo] where [DealerID]=ShopInfo.[DealerID]) 一级客户名,");
            sb.Append("(select shopstate from shopstateinfo where id=ShopInfo.shopstate) as 店铺状态,");
            sb.Append("(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) 部门名称,");
            sb.Append("(SELECT TOP 1 [AreaName] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) 区域名称,");
            sb.Append("(SELECT TOP 1 [ProvinceName] FROM [ProvinceData] WHERE [ProvinceID]=ShopInfo.[ProvinceID]) 省名称,");
            sb.Append("(SELECT TOP 1 [CityName] FROM [CityData] WHERE [CItyID]=ShopInfo.[CityID]) 地市级城市名称,");
            sb.Append("(SELECT TOP 1 [TCL_Name] FROM [TownCityLevel] WHERE [TCL_Id]=ShopInfo.[TCL_Id]) 地市级城市级别_市场定义,");
            sb.Append("(SELECT TOP 1 [TownName] FROM [TownData] WHERE [TownID]=ShopInfo.[TownID]) 区县级城市名称,");
            sb.Append("(SELECT TOP 1 [ACL_Name] FROM [AreaCityLevel] where [ACL_ID]=ShopInfo.[ACL_ID]) 区县级城市级别_市场定义,");
            sb.Append("[ShopMaster] 店铺零售负责人,[ShopMasterPhone] 店铺零售负责人移动电话, ");
            sb.Append("(select shoptypename from shoptype where id=ShopInfo.shoptype) as  店铺类型, ");
            sb.Append("(SELECT top 1 [ShopLevel] FROM [ShopLevel] where [LevelID]=ShopInfo.[ShopLevelID]) 店铺级别,");
            sb.Append("(SELECT top 1 [ShopVIName] FROM [ShopVI] where [ShopVIID]=ShopInfo.[ShopVI]) 店铺形象属性,");
            sb.Append("[ShopArea] 营业面积,[DSRMaster] 李宁DSR负责人,[DSRMasterPhone] 李宁DSR负责人电话,[VMMaster] 李宁省区VM负责人,[VMMasterPhone] 李宁省区VM负责人电话,");
            sb.Append("(SELECT top 1 [Department_Master] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) 李宁大区VM经理,");
            sb.Append("(SELECT top 1 [department_MasterPhone] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) 李宁大区VM经理电话,");
            sb.Append("[FXID] 直属客户编号,(SELECT TOP 1 [FXName] FROM [DistributorsInfo] WHERE [FXID]=ShopInfo.[FXID]) 直属客户名,[CustomerGroupID] 上级客户集团编号,[CustomerGroupName] 上级客户级别,[ShopOwnerShip] 店铺产权关系,[CustomerCard] 客户身份,");
            sb.Append("(select TOP 1 supplierName from supplierinfo where supplierID=(SELECT TOP 1 [SupplierID] FROM [SupplierAssignRecord] where [AssignShopID]=ShopInfo.ShopID)) 供应商,");
            sb.Append("shopid 系统编号 ");
            sb.Append(" from ShopInfo ");
            if (strWhere.Trim().Length > 0)
                sb.Append(strWhere);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 得到没有提交订单的店铺列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShopNew(string strWhere,string POPID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT  ");
            sb.AppendFormat("(SELECT COUNT(ID) FROM imageToPOP WHERE POPID ='{0}' AND shopid=ShopInfo.shopid) as 已提交订单个数,", POPID);
            sb.Append("(SELECT COUNT(ID) FROM POPInfo WHERE  ShopID=ShopInfo.shopid and IsHide=0) as POP总数,");
            sb.Append("[PosID] 店铺编号 ,[Shopname] 店铺名称,[Shopsamplename] 店铺简称 ,[PostAddress] 店铺邮政地址,[PostCode] 店铺邮编,[ShopPhone] 店铺固定电话,[LinkMan] 店长,[LinkPhone] 店长移动电话,[Email] 店长email,[FaxNumber] 店铺传真号码,");
            sb.Append("[Boolinstall] 是否李宁公司统一支持安装,[DealerID] 一级客户编号,");
            sb.Append("(SELECT TOP 1 [DealerName] FROM [DealerInfo] where [DealerID]=ShopInfo.[DealerID]) 一级客户名,");
            sb.Append("(SELECT TOP 1 shopstate from shopstateinfo where id=ShopInfo.shopstate) 店铺状态,");
            sb.Append("(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) 部门名称,");
            sb.Append("(SELECT TOP 1 [AreaName] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) 区域名称,");
            sb.Append("(SELECT TOP 1 [ProvinceName] FROM [ProvinceData] WHERE [ProvinceID]=ShopInfo.[ProvinceID]) 省名称,");
            sb.Append("(SELECT TOP 1 [CityName] FROM [CityData] WHERE [CItyID]=ShopInfo.[CityID]) 地市级城市名称,");
            sb.Append("(SELECT TOP 1 [TCL_Name] FROM [TownCityLevel] WHERE [TCL_Id]=ShopInfo.[TCL_Id]) 地市级城市级别_市场定义,");
            sb.Append("(SELECT TOP 1 [TownName] FROM [TownData] WHERE [TownID]=ShopInfo.[TownID]) 区县级城市名称,");
            sb.Append("(SELECT TOP 1 [ACL_Name] FROM [AreaCityLevel] where [ACL_ID]=ShopInfo.[ACL_ID]) 区县级城市级别_市场定义,");
            sb.Append("[ShopMaster] 店铺零售负责人,[ShopMasterPhone] 店铺零售负责人移动电话,");
            sb.Append("(select shoptypename from shoptype where id=ShopInfo.shoptype) as  店铺类型,");
            sb.Append("(SELECT TOP 1 [ShopLevel] FROM [ShopLevel] where [LevelID]=ShopInfo.[ShopLevelID]) 店铺级别,");
            sb.Append("(SELECT TOP 1 [ShopVIName] FROM [ShopVI] where [ShopVIID]=ShopInfo.[ShopVI]) 店铺形象属性,");
            sb.Append("[ShopArea] 营业面积,[DSRMaster] 李宁DSR负责人,[DSRMasterPhone] 李宁DSR负责人电话,[VMMaster] 李宁省区VM负责人,[VMMasterPhone] 李宁省区VM负责人电话,");
            sb.Append("(SELECT TOP 1 [Department_Master] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) 李宁大区VM经理,");
            sb.Append("(SELECT TOP 1 [department_MasterPhone] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) 李宁大区VM经理电话,");
            sb.Append("[FXID] 直属客户编号,(SELECT TOP 1 [FXName] FROM [DistributorsInfo] WHERE [FXID]=ShopInfo.[FXID]) 直属客户名,[CustomerGroupID] 上级客户集团编号,[CustomerGroupName] 上级客户级别,[ShopOwnerShip] 店铺产权关系,[CustomerCard] 客户身份,");
            sb.Append("(SELECT TOP 1 supplierName from supplierinfo where supplierID=(SELECT TOP 1 [SupplierID] FROM [SupplierAssignRecord] where [AssignShopID]=ShopInfo.ShopID)) 供应商, ");
            sb.Append(" ShopInfo.shopid 系统编号 ");
            sb.AppendFormat(" from ShopInfo  inner join areadata on shopinfo.areaid=areadata.areaid INNER JOIN (select POPChangeSet.shopid from POPChangeSet LEFT JOIN  (select distinct ShopID from imageToPOP where POPID='{0}') AS imageToPOPS ", POPID);
            sb.AppendFormat(" on POPChangeSet.shopid=imageToPOPS.ShopID where POPChangeSet.POPID='{0}' and imageToPOPS.ShopID is null) AS imagetoPOPSL ON ShopInfo.shopid = imagetoPOPSL.shopid", POPID);
            if (strWhere.Trim().Length > 0)
                sb.Append(strWhere);
                        
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
		
        /// <summary>
        /// 判断指定POP是否已经被提交
        /// </summary>
        /// <param name="POPInfoID">POP编号</param>
        /// <returns></returns>
        public int IsExist(string POPInfoID)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM imageToPOPTemp WHERE POPID IN (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) AND POPinfoID={0}", POPInfoID);

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }



		#endregion  成员方法
	}
}


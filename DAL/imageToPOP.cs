using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
	/// <summary>
	/// ���ݷ�����imageToPOP��
	/// </summary>
	public class imageToPOP
	{
		public imageToPOP()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
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
		/// ����һ������
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
        /// ����ͼƬ��ַ add by mhj 2012.2.5
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type">0Ϊ����ǰͼƬ��1���º�ͼƬ</param>
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
		/// ����һ������
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
		/// ɾ��һ������
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
        /// ɾ��һ������
        /// </summary>
        public void Delete(string str)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from imageToPOP ");
            strSql.Append(" where  "+ str);

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString());
        }

		/// <summary>
		/// �õ�һ������ʵ��
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
		/// ��������б�
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
		/// ���ǰ��������
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
            string strsql = "SELECT [AreaName] ʡ��,[ProvinceName] ʡ ,[cityname] �� ,[PosID] ���̱�� ,[Shopname] �������� ,[ShopAddress] ���̵�ַ ,[ShopOpenDate] ��������";
            strsql += "   ,[LinkMan]  �곤,[LinkPhone] �곤��ϵ�绰,[Email] email,[PostAddress] ������ַ,[PostCode] �ʱ�,[FaxNumber] ����";

            strsql += "  ,[DealerID] һ���ͻ����,[DealerName] һ���ͻ�,[FXID]  ֱ���ͻ����,[FXName] ֱ���ͻ�,[ShopLevel] ���̼���,[ShopMaster] ���̸�����";
            strsql += " ,[ShopMasterPhone] ��������ϵ��ʽ";
            strsql += "  ,[ShopArea] �������,[DSRMaster] DSR������,[DSRMasterPhone] DSR�����˵绰 ";
            strsql += " ,[VMMasterPhone] VM������,[VMMaster]  VM�����˵绰";
            strsql += "  ,[ShopPhone]  ���̵绰,[CustomerGroupID] �ͻ����ű��,[CustomerGroupName] �ͻ�����";

            strsql += " FROM [View_ShopInfo] where "+str;



            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql);
            DataTable dt1 = new DataTable();
            dt1 = ds.Tables[0];
            ds.Tables.Clear();
            return dt1;
        }

        public DataTable GetshoplistNO(string str)
        {
            string strsql1 = "SELECT [AreaName] ʡ��,[ProvinceName] ʡ ,[cityname] �� ,[PosID] ���̱�� ,[Shopname] �������� ,[ShopAddress] ���̵�ַ ,[ShopOpenDate] ��������";
            strsql1 += "   ,[LinkMan]  �곤,[LinkPhone] �곤��ϵ�绰,[Email] email,[PostAddress] ������ַ,[PostCode] �ʱ�,[FaxNumber] ����";

            strsql1 += "  ,[DealerID] һ���ͻ����,[DealerName] һ���ͻ�,[FXID]  ֱ���ͻ����,[FXName] ֱ���ͻ�,[ShopLevel] ���̼���,[ShopMaster] ���̸�����";
            strsql1 += " ,[ShopMasterPhone] ��������ϵ��ʽ";
            strsql1 += "  ,[ShopArea] �������,[DSRMaster] DSR������,[DSRMasterPhone] DSR�����˵绰 ";
            strsql1 += " ,[VMMasterPhone] VM������,[VMMaster]  VM�����˵绰";
            strsql1 += "  ,[ShopPhone]  ���̵绰,[CustomerGroupID] �ͻ����ű��,[CustomerGroupName] �ͻ�����";

            strsql1 += " FROM [View_ShopInfo] where "+str;

            DataSet ds1 = DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql1);
            DataTable dt=new DataTable();
            dt= ds1.Tables[0];
            ds1.Tables.Clear();
            return dt;
        }
        /// <summary>
        /// �õ�������Ӧ�����õ��Ķ�������
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
        /// �õ�����ͼƬ��POP������
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
        /// ���������������� ÿ��pop��Ϣ
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable supplier_orderdaochu(string strWhere, string POPID)
        {
            StringBuilder sb = new StringBuilder();

            //modify by mhj 2012.06.12 ȥ�������ֶ�
            sb.Append(" SELECT ");
            //sb.Append("[PosID] ���̱�� ,[Shopname] ��������,[Shopsamplename] ���̼�� ,[PostAddress] ����������ַ,[PostCode] �����ʱ�,[ShopPhone] ���̶̹��绰");
            sb.Append("[PosID] ���̱�� ,[Shopname] ��������,[Shopsamplename] ���̼�� ,[PostAddress] ����������ַ");
            sb.Append(",[cityname] ���м���������,(SELECT [TCL_Name] FROM [TownCityLevel] where [TCL_Id]=view_shopinfo.ACL_ID) as ���м����м���_�г�����");
            sb.Append(",[townName] ���ؼ���������,(SELECT [ACL_Name] FROM [AreaCityLevel] where [ACL_Id]=view_shopinfo.ACL_Id) as ���ؼ����м���_�г����� ");
            sb.Append(",[ProvinceName] ʡ����,[AreaName] ��������,[DepartMent] ��������,(select shoptypename from shoptype where id=view_shopinfo.shoptype) as  ��������");
            sb.Append(",[ShopOwnerShip] ���̲�Ȩ��ϵ,( select top 1 SaleType from saletypeInfo where SaleTypeID= view_shopinfo.SaleTypeID) as ������������,shoplevel ���̼���,(SELECT [ShopVIName] FROM [ShopVI] where [ShopVIID]=view_shopinfo.[ShopVI]) as ������������");
            //sb.Append(",(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as ����״̬ ,[CustomerCard] �ͻ����");
            sb.Append(",(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as ����״̬ ,[ShopArea] Ӫҵ���,[CustomerCard] �ͻ����");
            //sb.Append(",[FXID] ֱ���ͻ����,[FXName] ֱ���ͻ���,(SELECT TOP 1 [FXContactor] FROM [DistributorsInfo] where [FXID]=view_shopinfo.FXID) as ֱ���ͻ�POP����������");
            sb.Append(",[FXID] ֱ���ͻ����,[FXName] ֱ���ͻ���");
            //sb.Append(",(SELECT TOP 1 [FXPhone] FROM [DistributorsInfo] where [FXID]=view_shopinfo.FXID) as ֱ���ͻ�POP�������ƶ��绰");
            //sb.Append(",[DealerID] һ���ͻ����,[DealerName] һ���ͻ���,(SELECT TOP 1 [Contactor] FROM [DealerInfo] where [DealerID]=view_shopinfo.DealerID) as һ���ͻ�POP����������");
            sb.Append(",[DealerID] һ���ͻ����,[DealerName] һ���ͻ���");
            //sb.Append(",(SELECT TOP 1 [ContactorPhone] FROM [DealerInfo] where [DealerID]=view_shopinfo.DealerID) as һ���ͻ�POP�������ƶ��绰");
            //sb.Append(",[CustomerGroupID] �ϼ��ͻ����ű��,[CustomerGroupName] �ϼ��ͻ�����,[LinkMan] �곤,[LinkPhone] �곤�ƶ��绰,[Email] �곤email,[ShopMaster] �������۸�����,[ShopMasterPhone] �������۸������ƶ��绰");
            sb.Append(",[CustomerGroupID] �ϼ��ͻ����ű��");

            //sb.Append(",[Boolinstall] �Ƿ�������˾ͳһ֧�ְ�װ,[VMMaster] ����ʡ��VM������,[VMMasterPhone] ����ʡ��VM�������ƶ��绰,Department_Master ��������VM����,department_MasterPhone ��������VM�����ƶ��绰");
            sb.Append(",[Boolinstall] �Ƿ�������˾ͳһ֧�ְ�װ");

            //sb.Append(",[DSRMaster] ����DSR������,[DSRMasterPhone] ����DSR�������ƶ��绰 ");
            sb.Append(",(select supplierName from supplierinfo where supplierID=view_shopinfo.supplierID) as ����POP��Ӧ�� , ");
            sb.Append("(select count(*) from popinfo where  popinfo.shopid=view_shopinfo.shopid and examstate=1 and IsHide=0) ����POP������ ,");
            sb.Append("(select count(*) from popinfo where  popinfo.shopid=view_shopinfo.shopid and popinfo.IsHide=0 and  popinfo.id not in (select popinfoid from imagetopop where popinfoid=popinfo.id and imagetopop.popid='" + POPID + "' ) and examstate=1) ����δ�ύ������POP���� ,");
            sb.Append("[SeatNum] POP���,[POPseat] POP����,[SeatDesc] λ������,");
            sb.Append("(select top 1 [imagelevel] from (select POPImageData.[imagelevel],imagetopop.popinfoid from  POPImageData inner join imagetopop on imagetopop.imageid=POPImageData.imageid  where POPImageData.popid='" + POPID + "' and imagetopop.popinfoid=popinfo.id) b where popinfo.id=b.popinfoid) ͼƬ��� ");
            sb.Append(",producttypename ���°�����,View_ProductLine.productline POP���°�,[POPMaterial] POP����,[POPMaterialRemark] ���ʱ�ע,[RealWith] POPʵ��������mm,[RealHeight] POPʵ��������mm,[POPWith] POP���ӻ����mm,[POPHeight] POP���ӻ����mm,[POPPlwz] POP���ӻ���λ��,[POPPljd] POP���ӻ���ƫ��Ƕ�,[POPArea] POP���,[Sexarea] ��Ů����,[TwoSided] �Ƿ�Ϊ˫�� ");
            sb.Append(",[Glass] �Ƿ�ճ���벣������,[PlatformWith] �����ռ����mm,[PlatformHeight] �����ռ䳤��mm,[PlatformLong] �����ռ����  ");
            sb.Append(",c.sysTime as �ύ����ʱ�� ");
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
        /// �õ�û���ύ�����ĵ����б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShop(string strWhere)
        {
            StringBuilder sb = new StringBuilder();


            //sb.Append(" SELECT  shopid ϵͳ���,");
            sb.Append(" SELECT  ");
            sb.Append("(SELECT COUNT(ID) FROM imageToPOP WHERE POPID IN (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) AND shopid=ShopInfo.shopid) as ���ύ��������, ");
            sb.Append("(SELECT COUNT(ID) FROM POPInfo WHERE  ShopID=ShopInfo.shopid and IsHide=0) as POP����, ");
            sb.Append("[PosID] ���̱�� ,[Shopname] ��������,[Shopsamplename] ���̼�� ,[PostAddress] ����������ַ,[PostCode] �����ʱ�,[ShopPhone] ���̶̹��绰,[LinkMan] �곤,[LinkPhone] �곤�ƶ��绰,[Email] �곤email,[FaxNumber] ���̴������,");
            sb.Append("[Boolinstall] �Ƿ�������˾ͳһ֧�ְ�װ,[DealerID] һ���ͻ����,");
            sb.Append("(SELECT TOP 1 [DealerName] FROM [DealerInfo] where [DealerID]=ShopInfo.[DealerID]) һ���ͻ���,");
            sb.Append("(select shopstate from shopstateinfo where id=ShopInfo.shopstate) as ����״̬,");
            sb.Append("(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) ��������,");
            sb.Append("(SELECT TOP 1 [AreaName] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) ��������,");
            sb.Append("(SELECT TOP 1 [ProvinceName] FROM [ProvinceData] WHERE [ProvinceID]=ShopInfo.[ProvinceID]) ʡ����,");
            sb.Append("(SELECT TOP 1 [CityName] FROM [CityData] WHERE [CItyID]=ShopInfo.[CityID]) ���м���������,");
            sb.Append("(SELECT TOP 1 [TCL_Name] FROM [TownCityLevel] WHERE [TCL_Id]=ShopInfo.[TCL_Id]) ���м����м���_�г�����,");
            sb.Append("(SELECT TOP 1 [TownName] FROM [TownData] WHERE [TownID]=ShopInfo.[TownID]) ���ؼ���������,");
            sb.Append("(SELECT TOP 1 [ACL_Name] FROM [AreaCityLevel] where [ACL_ID]=ShopInfo.[ACL_ID]) ���ؼ����м���_�г�����,");
            sb.Append("[ShopMaster] �������۸�����,[ShopMasterPhone] �������۸������ƶ��绰, ");
            sb.Append("(select shoptypename from shoptype where id=ShopInfo.shoptype) as  ��������, ");
            sb.Append("(SELECT top 1 [ShopLevel] FROM [ShopLevel] where [LevelID]=ShopInfo.[ShopLevelID]) ���̼���,");
            sb.Append("(SELECT top 1 [ShopVIName] FROM [ShopVI] where [ShopVIID]=ShopInfo.[ShopVI]) ������������,");
            sb.Append("[ShopArea] Ӫҵ���,[DSRMaster] ����DSR������,[DSRMasterPhone] ����DSR�����˵绰,[VMMaster] ����ʡ��VM������,[VMMasterPhone] ����ʡ��VM�����˵绰,");
            sb.Append("(SELECT top 1 [Department_Master] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) ��������VM����,");
            sb.Append("(SELECT top 1 [department_MasterPhone] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) ��������VM����绰,");
            sb.Append("[FXID] ֱ���ͻ����,(SELECT TOP 1 [FXName] FROM [DistributorsInfo] WHERE [FXID]=ShopInfo.[FXID]) ֱ���ͻ���,[CustomerGroupID] �ϼ��ͻ����ű��,[CustomerGroupName] �ϼ��ͻ�����,[ShopOwnerShip] ���̲�Ȩ��ϵ,[CustomerCard] �ͻ����,");
            sb.Append("(select TOP 1 supplierName from supplierinfo where supplierID=(SELECT TOP 1 [SupplierID] FROM [SupplierAssignRecord] where [AssignShopID]=ShopInfo.ShopID)) ��Ӧ��,");
            sb.Append("shopid ϵͳ��� ");
            sb.Append(" from ShopInfo ");
            if (strWhere.Trim().Length > 0)
                sb.Append(strWhere);
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// �õ�û���ύ�����ĵ����б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Supplier_NoSubmitOrderShopNew(string strWhere,string POPID)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT  ");
            sb.AppendFormat("(SELECT COUNT(ID) FROM imageToPOP WHERE POPID ='{0}' AND shopid=ShopInfo.shopid) as ���ύ��������,", POPID);
            sb.Append("(SELECT COUNT(ID) FROM POPInfo WHERE  ShopID=ShopInfo.shopid and IsHide=0) as POP����,");
            sb.Append("[PosID] ���̱�� ,[Shopname] ��������,[Shopsamplename] ���̼�� ,[PostAddress] ����������ַ,[PostCode] �����ʱ�,[ShopPhone] ���̶̹��绰,[LinkMan] �곤,[LinkPhone] �곤�ƶ��绰,[Email] �곤email,[FaxNumber] ���̴������,");
            sb.Append("[Boolinstall] �Ƿ�������˾ͳһ֧�ְ�װ,[DealerID] һ���ͻ����,");
            sb.Append("(SELECT TOP 1 [DealerName] FROM [DealerInfo] where [DealerID]=ShopInfo.[DealerID]) һ���ͻ���,");
            sb.Append("(SELECT TOP 1 shopstate from shopstateinfo where id=ShopInfo.shopstate) ����״̬,");
            sb.Append("(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) ��������,");
            sb.Append("(SELECT TOP 1 [AreaName] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid]) ��������,");
            sb.Append("(SELECT TOP 1 [ProvinceName] FROM [ProvinceData] WHERE [ProvinceID]=ShopInfo.[ProvinceID]) ʡ����,");
            sb.Append("(SELECT TOP 1 [CityName] FROM [CityData] WHERE [CItyID]=ShopInfo.[CityID]) ���м���������,");
            sb.Append("(SELECT TOP 1 [TCL_Name] FROM [TownCityLevel] WHERE [TCL_Id]=ShopInfo.[TCL_Id]) ���м����м���_�г�����,");
            sb.Append("(SELECT TOP 1 [TownName] FROM [TownData] WHERE [TownID]=ShopInfo.[TownID]) ���ؼ���������,");
            sb.Append("(SELECT TOP 1 [ACL_Name] FROM [AreaCityLevel] where [ACL_ID]=ShopInfo.[ACL_ID]) ���ؼ����м���_�г�����,");
            sb.Append("[ShopMaster] �������۸�����,[ShopMasterPhone] �������۸������ƶ��绰,");
            sb.Append("(select shoptypename from shoptype where id=ShopInfo.shoptype) as  ��������,");
            sb.Append("(SELECT TOP 1 [ShopLevel] FROM [ShopLevel] where [LevelID]=ShopInfo.[ShopLevelID]) ���̼���,");
            sb.Append("(SELECT TOP 1 [ShopVIName] FROM [ShopVI] where [ShopVIID]=ShopInfo.[ShopVI]) ������������,");
            sb.Append("[ShopArea] Ӫҵ���,[DSRMaster] ����DSR������,[DSRMasterPhone] ����DSR�����˵绰,[VMMaster] ����ʡ��VM������,[VMMasterPhone] ����ʡ��VM�����˵绰,");
            sb.Append("(SELECT TOP 1 [Department_Master] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) ��������VM����,");
            sb.Append("(SELECT TOP 1 [department_MasterPhone] FROM [DepartMentInfo] where [department]=(SELECT TOP 1 [DepartMent] FROM [AreaData] WHERE [AreaID]=ShopInfo.[areaid])) ��������VM����绰,");
            sb.Append("[FXID] ֱ���ͻ����,(SELECT TOP 1 [FXName] FROM [DistributorsInfo] WHERE [FXID]=ShopInfo.[FXID]) ֱ���ͻ���,[CustomerGroupID] �ϼ��ͻ����ű��,[CustomerGroupName] �ϼ��ͻ�����,[ShopOwnerShip] ���̲�Ȩ��ϵ,[CustomerCard] �ͻ����,");
            sb.Append("(SELECT TOP 1 supplierName from supplierinfo where supplierID=(SELECT TOP 1 [SupplierID] FROM [SupplierAssignRecord] where [AssignShopID]=ShopInfo.ShopID)) ��Ӧ��, ");
            sb.Append(" ShopInfo.shopid ϵͳ��� ");
            sb.AppendFormat(" from ShopInfo  inner join areadata on shopinfo.areaid=areadata.areaid INNER JOIN (select POPChangeSet.shopid from POPChangeSet LEFT JOIN  (select distinct ShopID from imageToPOP where POPID='{0}') AS imageToPOPS ", POPID);
            sb.AppendFormat(" on POPChangeSet.shopid=imageToPOPS.ShopID where POPChangeSet.POPID='{0}' and imageToPOPS.ShopID is null) AS imagetoPOPSL ON ShopInfo.shopid = imagetoPOPSL.shopid", POPID);
            if (strWhere.Trim().Length > 0)
                sb.Append(strWhere);
                        
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
            return ds.Tables[0];
        }
		
        /// <summary>
        /// �ж�ָ��POP�Ƿ��Ѿ����ύ
        /// </summary>
        /// <param name="POPInfoID">POP���</param>
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



		#endregion  ��Ա����
	}
}


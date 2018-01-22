using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类ShopInfo。
    /// </summary>
    public class ShopInfo
    {
        public ShopInfo()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "shopid", "ShopInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ShopInfo");
            strSql.Append(" where PosID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.ShopInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("[Username],[Sex],[Usertype],[UserPassword],[UserEmail],[UserAddress],[UserPhone],[UserMobel],[UserState],[UserDesc],[userofarea])");
            strSql.Append(" values (");
            strSql.Append("@PosID,'',7,'000000','','',@LinkPhone,@LinkPhone,1,'',@areaid);");

            //add by mhj 20130531
            strSql.Append("update UserInfo set userid=@@IDENTITY where id=@@IDENTITY;");

            strSql.Append("insert into ShopInfo(");
            strSql.Append("PosID,Shopname,ShopAddress,ShopOpenDate,ShopCloseDate,CloseUserID,ProvinceID,CityID,TownID,ShopLevelID,SaleTypeID,LinkMan,LinkPhone,ShopMaster,ShopMasterPhone,Email,PostAddress,PostCode,FaxNumber,Boolinstall,DealerID,ShopState,ExamState,VMMaster,VMMasterPhone,DSRMaster,DSRMasterPhone,ShopArea,ShopVI,ShopType,FXID,ShopPhone,areaid,customerGroupID,customergroupname,shopsamplename,shopownership,customercard,ACL_ID,TCL_ID)");
            strSql.Append(" values (");
            strSql.Append("@PosID,@Shopname,@ShopAddress,@ShopOpenDate,@ShopCloseDate,@CloseUserID,@ProvinceID,@CityID,@TownID,@ShopLevelID,@SaleTypeID,@LinkMan,@LinkPhone,@ShopMaster,@ShopMasterPhone,@Email,@PostAddress,@PostCode,@FaxNumber,@Boolinstall,@DealerID,@ShopState,@ExamState,@VMMaster,@VMMasterPhone,@DSRMaster,@DSRMasterPhone,@ShopArea,@ShopVI,@ShopType,@FXID,@ShopPhone,@areaid,@customerGroupID,@customergroupname,@shopsamplename,@shopownership,@customercard,@ACL_ID,@TCL_ID)");

            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
		
					new SqlParameter("@PosID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopname", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopAddress", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopOpenDate", SqlDbType.VarChar,50),
					new SqlParameter("@ShopCloseDate", SqlDbType.VarChar,50),
					new SqlParameter("@CloseUserID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@TownID", SqlDbType.Int,4),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkPhone", SqlDbType.VarChar,80),
					new SqlParameter("@ShopMaster", SqlDbType.VarChar,50),
					new SqlParameter("@ShopMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
					new SqlParameter("@FaxNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Boolinstall", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@ShopState", SqlDbType.Int,4),
					new SqlParameter("@ExamState", SqlDbType.Int,4),
					new SqlParameter("@VMMaster", SqlDbType.VarChar,50),
					new SqlParameter("@VMMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMaster", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShopArea", SqlDbType.Float,8),
					new SqlParameter("@ShopVI", SqlDbType.Int,4),
					new SqlParameter("@ShopType", SqlDbType.Int,4),
                    new SqlParameter("@FXID",SqlDbType.VarChar,50),
                    new SqlParameter("@ShopPhone",SqlDbType.VarChar,50),
                    new SqlParameter("@areaid",SqlDbType.Int,4),
                    new SqlParameter("@customerGroupID",SqlDbType.VarChar,50),
                    new SqlParameter("@customergroupname",SqlDbType.VarChar,50),
                    new SqlParameter("@Shopsamplename",SqlDbType.VarChar,50),
                    new SqlParameter("@ShopOwnerShip",SqlDbType.VarChar,50),
                    new SqlParameter("@CustomerCard",SqlDbType.VarChar,50),
					new SqlParameter("@ACL_ID", SqlDbType.Int,4),
					new SqlParameter("@TCL_ID", SqlDbType.Int,4)
            };


            parameters[0].Value = model.PosID;
            parameters[1].Value = model.Shopname;
            parameters[2].Value = model.ShopAddress;
            parameters[3].Value = model.ShopOpenDate;
            if (string.IsNullOrEmpty(model.ShopCloseDate))
            {
                parameters[4].Value = "";
            }
            else
            {
                parameters[4].Value = model.ShopCloseDate;
            }
            if (string.IsNullOrEmpty(model.CloseUserID.ToString()))
            {
                parameters[5].Value = 0;
            }
            else
            {
                parameters[5].Value = model.CloseUserID;
            }

            parameters[6].Value = model.ProvinceID;
            parameters[7].Value = model.CityID;
            parameters[8].Value = model.TownID;
            parameters[9].Value = model.ShopLevelID;
            parameters[10].Value = model.SaleTypeID;
            parameters[11].Value = model.LinkMan;
            parameters[12].Value = model.LinkPhone;
            parameters[13].Value = model.ShopMaster;
            parameters[14].Value = model.ShopMasterPhone;
            parameters[15].Value = model.Email;
            parameters[16].Value = model.PostAddress;
            parameters[17].Value = model.PostCode;
            parameters[18].Value = model.FaxNumber;
            parameters[19].Value = model.Boolinstall;
            parameters[20].Value = model.DealerID;
            parameters[21].Value = model.ShopState;

            if (string.IsNullOrEmpty(model.ExamState.ToString()))
            {
                parameters[22].Value = 0;//未被审批
            }
            else
            {
                parameters[22].Value = model.ExamState;
            }
            parameters[23].Value = model.VMMaster;
            parameters[24].Value = model.VMMasterPhone;
            parameters[25].Value = model.DSRMaster;
            parameters[26].Value = model.DSRMasterPhone;
            parameters[27].Value = model.ShopArea;
            parameters[28].Value = model.ShopVI;
            parameters[29].Value = model.ShopType;
            parameters[30].Value = model.Fxid;
            parameters[31].Value = model.ShopPhone;
            parameters[32].Value = model.AreaID;
            parameters[33].Value = model.CustomerGroupID;
            parameters[34].Value = model.CustomerGroupName;
            parameters[35].Value = model.ShopSampleName;
            parameters[36].Value = model.ShopOwnerShip;
            parameters[37].Value = model.CustomerCard;
            parameters[38].Value = model.ACL_ID;
            parameters[39].Value = model.TCL_ID;
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
        /// 更新部分数据
        /// </summary>
        public void UpdateSub(LN.Model.ShopInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShopInfo set ");
            strSql.Append("ShopID=@ShopID,");
            strSql.Append("PosID=@PosID,");
            strSql.Append("Shopname=@Shopname,");
            strSql.Append("ShopAddress=@ShopAddress,");
            strSql.Append("ShopOpenDate=@ShopOpenDate,");
            strSql.Append("ShopLevelID=@ShopLevelID,");
            strSql.Append("SaleTypeID=@SaleTypeID,");
            strSql.Append("LinkMan=@LinkMan,");
            strSql.Append("LinkPhone=@LinkPhone,");
            strSql.Append("Email=@Email,");
            strSql.Append("PostAddress=@PostAddress,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("FaxNumber=@FaxNumber,");
            strSql.Append("Boolinstall=@Boolinstall,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("VMMaster=@VMMaster,");
            strSql.Append("VMMasterPhone=@VMMasterPhone,");
            strSql.Append("DSRMaster=@DSRMaster,");
            strSql.Append("DSRMasterPhone=@DSRMasterPhone,");
            strSql.Append("ShopArea=@ShopArea,");
            strSql.Append("ShopVI=@ShopVI,");
            strSql.Append("ShopType=@ShopType,");
            strSql.Append("FXID=@FXID,");
            strSql.Append("ShopPhone=@ShopPhone ");
            strSql.Append(" where ShopID=@ShopID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
                	new SqlParameter("@PosID", SqlDbType.VarChar,10),
					new SqlParameter("@Shopname", SqlDbType.NVarChar ,200),
					new SqlParameter("@ShopAddress", SqlDbType.VarChar,10),
					new SqlParameter("@ShopOpenDate", SqlDbType.VarChar,20),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkPhone", SqlDbType.VarChar,80),
                    new SqlParameter("@ShopMaster", SqlDbType.VarChar,20),
					new SqlParameter("@ShopMasterPhone", SqlDbType.VarChar,80),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@FaxNumber", SqlDbType.VarChar,20),
					new SqlParameter("@Boolinstall", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
                    new SqlParameter("@VMMaster", SqlDbType.VarChar,50),
					new SqlParameter("@VMMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMaster", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShopArea", SqlDbType.Float,8),
					new SqlParameter("@ShopVI", SqlDbType.Int,4),
					new SqlParameter("@ShopType", SqlDbType.Int,4),
                    new SqlParameter("@FXID", SqlDbType.VarChar,50),
                    new SqlParameter("@ShopPhone", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ShopID;
            parameters[2].Value = model.PosID;
            parameters[3].Value = model.Shopname;
            parameters[4].Value = model.ShopAddress;
            parameters[5].Value = model.ShopOpenDate;
            parameters[6].Value = model.ShopLevelID;
            parameters[7].Value = model.SaleTypeID;
            parameters[8].Value = model.LinkMan;
            parameters[9].Value = model.LinkPhone;
            parameters[10].Value = model.ShopMaster;
            parameters[11].Value = model.ShopMasterPhone;
            parameters[12].Value = model.Email;
            parameters[13].Value = model.PostAddress;
            parameters[14].Value = model.PostCode;
            parameters[15].Value = model.FaxNumber;
            parameters[16].Value = model.Boolinstall;
            parameters[17].Value = model.DealerID;
            parameters[18].Value = model.VMMaster;
            parameters[19].Value = model.VMMasterPhone;
            parameters[20].Value = model.DSRMaster;
            parameters[21].Value = model.DSRMasterPhone;
            parameters[22].Value = model.ShopArea;
            parameters[23].Value = model.ShopVI;
            parameters[24].Value = model.ShopType;
            parameters[25].Value = model.Fxid;
            parameters[26].Value = model.ShopPhone;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete ShopInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }
        /// <summary>
        /// 店铺负责人确认店铺信息
        /// </summary>
        /// <returns></returns>
        public bool ConfirmShopInfo(int ShopID)
        {
            string strSql = "update shopinfo set ExamState=1 where Shopid=@ShopID";
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4)};
            parameters[0].Value = ShopID;

            try
            {
                DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }
        /// <summary>
        /// 关闭店铺
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public bool CloseShopState(int ShopID, int CloseUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update shopinfo set ShopState=0,CloseUserID= @CloseUserID  where Shopid=@ShopID;");
            strSql.Append("update UserInfo set [UserState]=0  where [UserName]=(select top 1 PosID from shopinfo where Shopid=@ShopID );");
            strSql.Append("delete POPChangeSet where POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) and ShopID=@ShopID;");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4),
                    new SqlParameter("@CloseUserID", SqlDbType.Int,4)
            };
            parameters[0].Value = ShopID;
            parameters[1].Value = CloseUserID;

            try
            {
                DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 关闭/新开/整改/维持 店铺
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public bool ChangeShopState(int ShopID, int CloseUserID, int ShopState)
        {
            //系统当前只需要修改店铺,关闭和打开两种 即 0 1
            //用户状态为0 1 ,所有update userinfo 时使用ShopState店铺状态更新用户状态
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update shopinfo set ShopState=@ShopState,CloseUserID= @CloseUserID  where Shopid=@ShopID;");
            strSql.Append("update UserInfo set [UserState]=@ShopState  where [UserName]=(select top 1 PosID from shopinfo where Shopid=@ShopID );");
            strSql.Append("delete POPChangeSet where POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) and ShopID=@ShopID;");

            //add by mhj 20130606
            strSql.Append("delete imageToPOPTemp where POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) and ShopID=@ShopID;");
            strSql.Append("delete imageToPOP where POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()) and ShopID=@ShopID;");

            SqlParameter[] parameters = {
                    new SqlParameter("@ShopState",SqlDbType.Int,4),
					new SqlParameter("@ShopID", SqlDbType.Int,4),
                    new SqlParameter("@CloseUserID", SqlDbType.Int,4)
            };
            parameters[0].Value = ShopState;
            parameters[1].Value = ShopID;
            parameters[2].Value = CloseUserID;

            try
            {
                DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ShopInfo GetModel(int ShopID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ShopID,PosID,Shopname,ShopAddress,ShopOpenDate,ShopCloseDate,CloseUserID,ProvinceID,CityID,ShopLevelID,SaleTypeID,LinkMan,LinkPhone,ShopMaster,ShopMasterPhone,Email,PostAddress,PostCode,FaxNumber,Boolinstall,DealerID,FXID,ShopState,ExamState,ShopPhone from ShopInfo ");
            strSql.Append(" where ShopID=@ShopID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4)};
            parameters[0].Value = ShopID;

            LN.Model.ShopInfo model = new LN.Model.ShopInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopID"].ToString() != "")
                {
                    model.ShopID = int.Parse(ds.Tables[0].Rows[0]["ShopID"].ToString());
                }
                model.PosID = ds.Tables[0].Rows[0]["PosID"].ToString();
                model.Shopname = ds.Tables[0].Rows[0]["Shopname"].ToString();
                model.ShopAddress = ds.Tables[0].Rows[0]["ShopAddress"].ToString();
                model.ShopOpenDate = ds.Tables[0].Rows[0]["ShopOpenDate"].ToString();
                model.ShopCloseDate = ds.Tables[0].Rows[0]["ShopCloseDate"].ToString();
                if (ds.Tables[0].Rows[0]["CloseUserID"].ToString() != "")
                {
                    model.CloseUserID = int.Parse(ds.Tables[0].Rows[0]["CloseUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProvinceID"].ToString() != "")
                {
                    model.ProvinceID = int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CityID"].ToString() != "")
                {
                    model.CityID = int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopLevelID"].ToString() != "")
                {
                    model.ShopLevelID = int.Parse(ds.Tables[0].Rows[0]["ShopLevelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleTypeID"].ToString() != "")
                {
                    model.SaleTypeID = int.Parse(ds.Tables[0].Rows[0]["SaleTypeID"].ToString());
                }
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                model.LinkPhone = ds.Tables[0].Rows[0]["LinkPhone"].ToString();
                model.ShopMaster = ds.Tables[0].Rows[0]["ShopMaster"].ToString();
                model.ShopMasterPhone = ds.Tables[0].Rows[0]["ShopMasterPhone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.PostAddress = ds.Tables[0].Rows[0]["PostAddress"].ToString();
                model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                model.FaxNumber = ds.Tables[0].Rows[0]["FaxNumber"].ToString();
                if (ds.Tables[0].Rows[0]["Boolinstall"].ToString() != "")
                {
                    model.Boolinstall = int.Parse(ds.Tables[0].Rows[0]["Boolinstall"].ToString());
                }
                model.DealerID = ds.Tables[0].Rows[0]["DealerID"].ToString();
                model.Fxid = ds.Tables[0].Rows[0]["FXID"].ToString();
                if (ds.Tables[0].Rows[0]["ShopState"].ToString() != "")
                {
                    model.ShopState = int.Parse(ds.Tables[0].Rows[0]["ShopState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExamState"].ToString() != "")
                {
                    model.ExamState = int.Parse(ds.Tables[0].Rows[0]["ExamState"].ToString());
                }
                model.ShopPhone = ds.Tables[0].Rows[0]["ShopPhone"].ToString();
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
            strSql.Append("select ShopID,PosID,Shopname,ShopAddress,ShopOpenDate,ShopCloseDate,CloseUserID,ProvinceID,CityID,(select townname from towndata where townid=View_Shopinfo.townid) TownName,ShopLevelID,LinkMan,LinkPhone,ShopMaster,ShopMasterPhone,Email,PostAddress,PostCode,FaxNumber,Boolinstall,DealerID, ShopState,ExamState,ProvinceName,CityName,DealerName,ShopLevel,VMMaster,VMMasterPhone,DSRMaster,DSRMasterPhone,ShopArea,ShopVI,(select ShopVIName from ShopVI where View_Shopinfo.ShopVI=ShopVIID) as ShopVIName, ShopType,(select ShopTypename from ShopType where View_Shopinfo.ShopType=ID) as  ShopTypename,FXID, FXname,ShopPhone,areaid,areaname,CustomerGroupID,CustomerGroupName,ShopOwnerShip,CustomerCard,Shopsamplename,saletypeid,VMExamState,VMExamUserID, VMExamDate,[ACL_Id],[TCL_Id],SaleType ");
            strSql.Append(",DepartMent,townid ");
            strSql.Append(" FROM View_Shopinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }
        /// <summary>
        /// 获得一部分数据列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetSublist(string StrWhere)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select ShopID,PosID,Shopname,ProvinceName,CityName,dealername,PostAddress,shopPhone,FXName ");
            strsql.Append(" FROM View_Shopinfo ");
            if (StrWhere.Trim() != "")
            {
                strsql.Append(" where " + StrWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql.ToString());
        }
        /// <summary>
        /// 得到自动完成列表的店铺名称
        /// </summary>
        /// <param name="strShopName"></param>
        /// <returns></returns>
        public DataSet GetAutoComplateShopname(string strShopName)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("   select top 10  Shopname from ShopInfo ");
            if (!string.IsNullOrEmpty(strShopName))
            {
                sb.Append("where Shopname like '" + strShopName + "%'");
            }

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

        }
        /// <summary>
        /// 得到店铺和pop信息
        /// </summary>
        /// <param name="hdt"></param>
        /// <returns></returns>
        public DataTable GetShop_POP_infolist(Hashtable hdt)
        {
            IDataParameter[] dataList = new IDataParameter[]
            {
                new SqlParameter("@PosID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopName",SqlDbType.VarChar,200),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@CityID",SqlDbType.Int,4),
                new SqlParameter("@Install",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopLevelID",SqlDbType.Int,4),
                new SqlParameter("@shoptypeid",SqlDbType.Int,4),
                new SqlParameter("@SaleTypeID",SqlDbType.Int,4),
                new SqlParameter("@StateID",SqlDbType.Int,4),
                new SqlParameter("@Fxid",SqlDbType.VarChar,50),
                new SqlParameter("@department",SqlDbType.VarChar,10),
                new SqlParameter("@areaid",SqlDbType.VarChar,50),
                new SqlParameter("@Citylevel",SqlDbType.VarChar,10),
                new SqlParameter("@townlevel",SqlDbType.VarChar,10),
                new SqlParameter("@CusCard",SqlDbType.VarChar,10),
                new SqlParameter("@CusID",SqlDbType.VarChar,10),
                new SqlParameter("@CusLevel",SqlDbType.VarChar,100),
                new SqlParameter("@CusShip",SqlDbType.VarChar,100),
                new SqlParameter("@shopArea",SqlDbType.Float,10),
                new SqlParameter("@Popseat",SqlDbType.VarChar,50),
                new SqlParameter("@ProductType",SqlDbType.Int,4),
                new SqlParameter("@POPline",SqlDbType.VarChar,50),
                new SqlParameter("@POParea",SqlDbType.Float,10),
                new SqlParameter("@PfJS",SqlDbType.Float,10),
                new SqlParameter("@Pfcd",SqlDbType.Float,10),
                new SqlParameter("@Pfmj",SqlDbType.Float,10),
                new SqlParameter("@supplierID",SqlDbType.Int,4)
            };

            dataList[0].Value = hdt["pid"].ToString();
            dataList[1].Value = hdt["sname"].ToString();
            dataList[2].Value = int.Parse(hdt["proid"].ToString());
            dataList[3].Value = int.Parse(hdt["cityid"].ToString());
            dataList[4].Value = int.Parse(hdt["installID"].ToString());
            dataList[5].Value = hdt["dealerid"].ToString();
            dataList[6].Value = int.Parse(hdt["ShopLevel"].ToString());
            dataList[7].Value = int.Parse(hdt["typeid"].ToString());
            dataList[8].Value = int.Parse(hdt["saleid"].ToString());
            dataList[9].Value = int.Parse(hdt["stateID"].ToString());
            dataList[10].Value = hdt["Fxid"].ToString();
            dataList[11].Value = hdt["department"].ToString();
            dataList[12].Value = hdt["areaid"].ToString();
            dataList[13].Value = hdt["Citylevel"].ToString();
            dataList[14].Value = hdt["townlevel"].ToString();
            dataList[15].Value = hdt["CusCard"].ToString();
            dataList[16].Value = hdt["CusID"].ToString();
            dataList[17].Value = hdt["CusLevel"].ToString();
            dataList[18].Value = hdt["CusShip"].ToString();
            dataList[19].Value = float.Parse(hdt["shopArea"].ToString());
            dataList[20].Value = hdt["Popseat"].ToString();
            dataList[21].Value = int.Parse(hdt["ProductType"].ToString());
            dataList[22].Value = hdt["POPline"].ToString();
            dataList[23].Value = float.Parse(hdt["POParea"].ToString());
            dataList[24].Value = float.Parse(hdt["PfJS"].ToString());
            dataList[25].Value = float.Parse(hdt["Pfcd"].ToString());
            dataList[26].Value = float.Parse(hdt["Pfmj"].ToString());
            dataList[27].Value = float.Parse(hdt["supplierID"].ToString());
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetShop_POP_InfoList", dataList, "shoplist");
            return ds.Tables[0];
        }

        /// <summary>
        /// 得到店铺信息
        /// </summary>
        /// <param name="hdt"></param>
        /// <returns></returns>
        public DataTable GetShop_infolist(Hashtable hdt)
        {
            IDataParameter[] dataList = new IDataParameter[]
            {
                new SqlParameter("@PosID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopName",SqlDbType.VarChar,200),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@CityID",SqlDbType.Int,4),
                new SqlParameter("@Install",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopLevelID",SqlDbType.Int,4),
                new SqlParameter("@shoptypeid",SqlDbType.Int,4),
                new SqlParameter("@SaleTypeID",SqlDbType.Int,4),
                new SqlParameter("@StateID",SqlDbType.Int,4),
                new SqlParameter("@Fxid",SqlDbType.VarChar,50),
                new SqlParameter("@department",SqlDbType.VarChar,10),
                new SqlParameter("@areaid",SqlDbType.VarChar,50),
                new SqlParameter("@Citylevel",SqlDbType.VarChar,10),
                new SqlParameter("@townlevel",SqlDbType.VarChar,10),
                new SqlParameter("@CusCard",SqlDbType.VarChar,10),
                new SqlParameter("@CusID",SqlDbType.VarChar,10),
                new SqlParameter("@CusLevel",SqlDbType.VarChar,100),
                new SqlParameter("@CusShip",SqlDbType.VarChar,100),
                new SqlParameter("@shopArea",SqlDbType.Float,10),
                new SqlParameter("@supplierID",SqlDbType.Int,4)
            };

            dataList[0].Value = hdt["pid"].ToString();
            dataList[1].Value = hdt["sname"].ToString();
            dataList[2].Value = int.Parse(hdt["proid"].ToString());
            dataList[3].Value = int.Parse(hdt["cityid"].ToString());
            dataList[4].Value = int.Parse(hdt["installID"].ToString());
            dataList[5].Value = hdt["dealerid"].ToString();
            dataList[6].Value = int.Parse(hdt["ShopLevel"].ToString());
            dataList[7].Value = int.Parse(hdt["typeid"].ToString());
            dataList[8].Value = int.Parse(hdt["saleid"].ToString());
            dataList[9].Value = int.Parse(hdt["stateID"].ToString());
            dataList[10].Value = hdt["Fxid"].ToString();
            dataList[11].Value = hdt["department"].ToString();
            dataList[12].Value = hdt["areaid"].ToString();
            dataList[13].Value = hdt["Citylevel"].ToString();
            dataList[14].Value = hdt["townlevel"].ToString();
            dataList[15].Value = hdt["CusCard"].ToString();
            dataList[16].Value = hdt["CusID"].ToString();
            dataList[17].Value = hdt["CusLevel"].ToString();
            dataList[18].Value = hdt["CusShip"].ToString();
            dataList[19].Value = float.Parse(hdt["shopArea"].ToString());
            dataList[20].Value = float.Parse(hdt["supplierID"].ToString());
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetShop_InfoList", dataList, "shoplist");

            return ds.Tables[0];
        }
        /// <summary>
        /// 得到店铺列表
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">记录总数目</param>
        /// <returns></returns>
        public DataTable GetInfolist(Hashtable hdt, ref int TotalNumber)
        {
            IDataParameter[] dataList = new IDataParameter[]
            {
                new SqlParameter("@PosID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopName",SqlDbType.VarChar,200),
                new SqlParameter("@ProvinceID",SqlDbType.VarChar,20),
                new SqlParameter("@CityID",SqlDbType.VarChar,20),
                new SqlParameter("@Install",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopLevelID",SqlDbType.Int,4),
                new SqlParameter("@SaleTypeID",SqlDbType.Int,4),

                new SqlParameter("@OrderField",SqlDbType.VarChar,200),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@TotalRecord",SqlDbType.Int,4),

                new SqlParameter("@StateID",SqlDbType.Int,4),
                new SqlParameter("@Fxid",SqlDbType.VarChar,50),
                new SqlParameter("@Dsrmaster",SqlDbType.VarChar,50),
                new SqlParameter("@department",SqlDbType.VarChar,10),
                new SqlParameter("@AreaID",SqlDbType.VarChar,50),

                //add by mhj 2012.2.4
                new SqlParameter("@specialType",SqlDbType.Int,4)
            };
            dataList[0].Value = hdt["pid"].ToString();
            dataList[1].Value = hdt["sname"].ToString();
            dataList[2].Value = hdt["proid"].ToString();
            dataList[3].Value = hdt["cityid"].ToString();
            dataList[4].Value = int.Parse(hdt["installID"].ToString());
            dataList[5].Value = hdt["dealerid"].ToString();
            dataList[6].Value = int.Parse(hdt["typeid"].ToString());
            dataList[7].Value = int.Parse(hdt["saleid"].ToString());
            dataList[8].Value = "shopid desc";
            dataList[9].Value = int.Parse(hdt["PageSize"].ToString());
            dataList[10].Value = int.Parse(hdt["pageindex"].ToString());
            dataList[11].Direction = ParameterDirection.Output;
            dataList[12].Value = int.Parse(hdt["stateID"].ToString());
            dataList[13].Value = hdt["Fxid"].ToString();
            if (hdt["dsrmaster"] != null)
                dataList[14].Value = hdt["dsrmaster"].ToString();
            else
                dataList[14].Value = "";
            if (hdt["department"] != null)
                dataList[15].Value = hdt["department"].ToString();
            else
                dataList[15].Value = "0";
            if (hdt["AreaID"] != null)
                dataList[16].Value = hdt["AreaID"].ToString();
            else
                dataList[16].Value = "0";

            //add by mhj 2012.2.4
            if (hdt["specialType"] != null)
                dataList[17].Value = int.Parse(hdt["specialType"].ToString());
            else
                dataList[17].Value = -1;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetShopInfoList", dataList, "shoplist");
            TotalNumber = Convert.ToInt16(dataList[11].Value);
            return ds.Tables[0];
        }


        /// <summary>
        /// 得到店铺列表
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">记录总数目</param>
        /// <returns></returns>
        public DataTable GetShopInfoByPOPIDAndShopID(Hashtable hdt, ref int TotalNumber)
        {
            IDataParameter[] dataList = new IDataParameter[]
            {
                new SqlParameter("@PosID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopName",SqlDbType.VarChar,200),
                new SqlParameter("@ProvinceID",SqlDbType.VarChar,20),
                new SqlParameter("@CityID",SqlDbType.VarChar,20),
                new SqlParameter("@Install",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopLevelID",SqlDbType.Int,4),
                new SqlParameter("@SaleTypeID",SqlDbType.Int,4),
                new SqlParameter("@POPID",SqlDbType.VarChar,20),



                new SqlParameter("@OrderField",SqlDbType.VarChar,200),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@TotalRecord",SqlDbType.Int,4),

                new SqlParameter("@StateID",SqlDbType.Int,4),
                new SqlParameter("@Fxid",SqlDbType.VarChar,50),
                new SqlParameter("@Dsrmaster",SqlDbType.VarChar,50),
                new SqlParameter("@department",SqlDbType.VarChar,10),
                new SqlParameter("@AreaID",SqlDbType.VarChar,50),

                new SqlParameter("@supplierId",SqlDbType.Int,4),//add by mhj 2012.2.5
                new SqlParameter("@specialType",SqlDbType.Int,4)//add by mhj 2012.2.5
            };
            dataList[0].Value = hdt["pid"].ToString();
            dataList[1].Value = hdt["sname"].ToString();
            dataList[2].Value = hdt["proid"].ToString();
            dataList[3].Value = hdt["cityid"].ToString();
            dataList[4].Value = int.Parse(hdt["installID"].ToString());
            dataList[5].Value = hdt["dealerid"].ToString();
            dataList[6].Value = int.Parse(hdt["typeid"].ToString());
            dataList[7].Value = int.Parse(hdt["saleid"].ToString());

            dataList[8].Value = hdt["popID"].ToString();
            dataList[9].Value = "shopid desc";
            dataList[10].Value = int.Parse(hdt["PageSize"].ToString());
            dataList[11].Value = int.Parse(hdt["pageindex"].ToString());
            dataList[12].Direction = ParameterDirection.Output;
            dataList[13].Value = int.Parse(hdt["stateID"].ToString());
            dataList[14].Value = hdt["Fxid"].ToString();
            if (hdt["dsrmaster"] != null)
                dataList[15].Value = hdt["dsrmaster"].ToString();
            else
                dataList[15].Value = "";
            if (hdt["department"] != null)
                dataList[16].Value = hdt["department"].ToString();
            else
                dataList[16].Value = "0";
            if (hdt["AreaID"] != null)
                dataList[17].Value = hdt["AreaID"].ToString();
            else
                dataList[17].Value = "0";

            //add by mhj 2012.2.5
            if (hdt["supplierId"] != null)
                dataList[18].Value = hdt["supplierId"].ToString();
            else
                dataList[18].Value = 0;
            if (hdt["specialType"] != null)
                dataList[19].Value = hdt["specialType"].ToString();
            else
                dataList[19].Value = -1;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "ShopOrderformPreview", dataList, "shoplist");
            TotalNumber = Convert.ToInt16(dataList[12].Value);
            return ds.Tables[0];
        }

        /// <summary>
        /// 得到店铺列表
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">记录总数目</param>
        /// <returns></returns>
        public DataTable GetShopPOPSetupList(Hashtable hdt, ref int TotalNumber)
        {
            IDataParameter[] dataList = new IDataParameter[]
            {
                new SqlParameter("@PosID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopName",SqlDbType.VarChar,200),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@CityID",SqlDbType.Int,4),
                new SqlParameter("@Install",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopLevelID",SqlDbType.Int,4),
                new SqlParameter("@SaleTypeID",SqlDbType.Int,4),

                new SqlParameter("@OrderField",SqlDbType.VarChar,200),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@TotalRecord",SqlDbType.Int,4),
                new SqlParameter("@StateID",SqlDbType.Int,4),
                new SqlParameter("@SupplierID",SqlDbType.Int,4),
                new SqlParameter("@IsState",SqlDbType.VarChar,50),
                new SqlParameter("@GetInState",SqlDbType.VarChar,50),
                new SqlParameter("@FXID",SqlDbType.VarChar,50)
            };
            dataList[0].Value = hdt["pid"].ToString();
            dataList[1].Value = hdt["sname"].ToString();
            dataList[2].Value = int.Parse(hdt["proid"].ToString());
            dataList[3].Value = int.Parse(hdt["cityid"].ToString());
            dataList[4].Value = int.Parse(hdt["installID"].ToString());
            dataList[5].Value = hdt["dealerid"].ToString();
            dataList[6].Value = int.Parse(hdt["typeid"].ToString());
            dataList[7].Value = int.Parse(hdt["saleid"].ToString());
            dataList[8].Value = "shopid desc";
            dataList[9].Value = int.Parse(hdt["PageSize"].ToString());
            dataList[10].Value = int.Parse(hdt["pageindex"].ToString());
            dataList[11].Direction = ParameterDirection.Output;
            dataList[12].Value = int.Parse(hdt["stateID"].ToString());
            dataList[13].Value = int.Parse(hdt["SupplierID"].ToString());
            dataList[14].Value = "安装到店";
            dataList[15].Value = "已收货";
            dataList[16].Value = hdt["fxid"].ToString();
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetShopPOPSetupList", dataList, "shoplist");
            TotalNumber = Convert.ToInt16(dataList[11].Value);
            return ds.Tables[0];
        }

        public DataTable GetNoPOPinfo_shoplist()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("  SELECT  ");
            sb.Append(" [PosID] 店铺编号 ,[Shopname] 店铺名称,[Shopsamplename] 店铺简称 ,[PostAddress] 店铺邮政地址,[PostCode] 店铺邮编,[ShopPhone] 店铺固定电话,[LinkMan] 店长,[LinkPhone] 店长移动电话,[Email] 店长email,[FaxNumber] 店铺传真号码 ");
            sb.Append("  ,[Boolinstall] 是否李宁公司统一支持安装,[DealerID] 一级客户编号,[DealerName] 一级客户名,(select shopstate from shopstateinfo where id=view_shopinfo.shopstate) as 店铺状态,[DepartMent] 部门名称 ");
            sb.Append("  ,[AreaName] 区域名称,[ProvinceName] 省名称,[cityname] 地级城市名称,[cityLevel] 地市级城市级别_市场定义,[townName] 区县级城市名称,TownLevel 区县级城市级别_市场定义 ,[ShopMaster] 店铺零售负责人 ");
            sb.Append("  ,[ShopMasterPhone] 店铺零售负责人移动电话,(select shoptypename from shoptype where id=view_shopinfo.shoptype) as  店铺类型 ");
            sb.Append("   ,shoplevel 店铺级别,[ShopVI] 店铺形象属性,[ShopArea] 营业面积,[DSRMaster] 李宁DSR负责人,[DSRMasterPhone] 李宁DSR负责人电话,[VMMaster] 李宁省区VM负责人,[VMMasterPhone] 李宁省区VM负责人电话,Department_Master 李宁大区VM经理,department_MasterPhone 李宁大区VM经理电话,[FXID] 直属客户编号,[FXName] 直属客户名 ");
            sb.Append("  ,[CustomerGroupID] 上级客户集团编号,[CustomerGroupName] 上级客户级别,[ShopOwnerShip] 店铺产权关系,[CustomerCard] 客户身份,(select supplierName from supplierinfo where supplierID=view_shopinfo.supplierID) as 供应商  ");
            sb.Append("  FROM  View_ShopInfo ");
            sb.Append("   where shopid not in(select distinct shopid from popinfo) and examState=1");

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString()).Tables[0];
        }
        /// <summary>
        /// 得到店铺列表
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">记录总数目</param>
        /// <returns></returns>
        public DataTable GetShopPOPSetupJudgeList(Hashtable hdt, ref int TotalNumber)
        {
            IDataParameter[] dataList = new IDataParameter[]
            {
                new SqlParameter("@PosID",SqlDbType.VarChar,20),
                new SqlParameter("@ShopName",SqlDbType.VarChar,200),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@CityID",SqlDbType.Int,4),
                new SqlParameter("@POPID",SqlDbType.VarChar,100),
                new SqlParameter("@DealerID",SqlDbType.VarChar,20),
                new SqlParameter("@SupplierID",SqlDbType.Int,4),

                new SqlParameter("@OrderField",SqlDbType.VarChar,200),
                new SqlParameter("@pageSize",SqlDbType.Int,4),
                new SqlParameter("@pageIndex",SqlDbType.Int,4),
                new SqlParameter("@TotalRecord",SqlDbType.Int,4),
                new SqlParameter("@JudgeState",SqlDbType.Int,4),
                new SqlParameter("@FXID",SqlDbType.VarChar,50)
            };
            dataList[0].Value = hdt["pid"].ToString();
            dataList[1].Value = hdt["sname"].ToString();
            dataList[2].Value = int.Parse(hdt["proid"].ToString());
            dataList[3].Value = int.Parse(hdt["cityid"].ToString());
            dataList[4].Value = hdt["popid"].ToString();
            dataList[5].Value = hdt["dealerid"].ToString();
            dataList[6].Value = int.Parse(hdt["SupplierID"].ToString());

            dataList[7].Value = "shopid desc";
            dataList[8].Value = int.Parse(hdt["PageSize"].ToString());
            dataList[9].Value = int.Parse(hdt["pageindex"].ToString());
            dataList[10].Direction = ParameterDirection.Output;
            dataList[11].Value = int.Parse(hdt["state"].ToString());
            dataList[12].Value = hdt["FXID"].ToString();
            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetShopPOPSetupJudgeList", dataList, "shoplist");
            TotalNumber = Convert.ToInt16(dataList[10].Value);
            return ds.Tables[0];
        }

        /// <summary>
        /// 根据登录人信息.得到管理的店铺
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public DataTable GetShopInfoWithShopMaster(string User)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ShopID,PosID,Shopname,ShopAddress,ShopOpenDate,ShopCloseDate,CloseUserID,ProvinceID,CityID,ShopLevelID,LinkMan,LinkPhone,ShopMasterPhone,Email,PostAddress,PostCode,FaxNumber,Boolinstall,DealerID,ShopState,ExamState,ProvinceName,CityName,DealerName,ShopLevel ");
            strSql.Append(" FROM View_Shopinfo where PosID ='" + User + "'  ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 获取供应商负责的店铺列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetShopListBySupplierID(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = GetTableListSqlExec.GetList(model, out TotalNumber);
            if (dt != null)
                return dt;
            else
                return null;
        }

        /// <summary>
        /// 获取供应商负责的店铺列表（不分页）不排序
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetAllShopListBySupplierID(string hidSupplierID, string strWhere)
        {
            string strSql = GetTableListSqlExec.strShopListBySupplierID(hidSupplierID, strWhere);
            DataTable dt = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql).Tables[0];
            if (dt != null)
                return dt;
            else
                return null;
        }

        /// <summary>
        /// 获取供应商负责的店铺列表（不分页）排序
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetAllShopListBySuppliersID(string hidSupplierID, string strWhere)
        {
            string strSql = GetTableListSqlExec.strShopListBySuppliersID(hidSupplierID, strWhere);
            DataTable dt = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql).Tables[0];
            if (dt != null)
                return dt;
            else
                return null;
        }

        /// <summary>
        /// 得到店铺信息根据供应商ID
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetShopInfoWithSupplierID(string strWhere)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from View_SupplierAssignRecord  where 1= 1");
            if (strWhere != "")
            {
                sb.Append(strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }

        /// <summary>
        /// 获取指定编号的名称
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="POPID">POP发起ID</param>
        /// <param name="DealreID">一级客户编号</param>
        /// <returns>返回各项名称集合</returns>
        public DataTable GetInfoByID(int ShopID, int SupplierID, string POPID, string DealreID)
        {
            DataTable dt = null;
            IDataParameter[] param = new IDataParameter[]
            {
                new SqlParameter("@ShopID",SqlDbType.Int,4),
                new SqlParameter("@SupplierID",SqlDbType.Int,4),
                new SqlParameter("@POPID",SqlDbType.VarChar,50),
                new SqlParameter("@DealreID",SqlDbType.VarChar,50)
            };
            param[0].Value = ShopID;
            param[1].Value = SupplierID;
            param[2].Value = POPID;
            param[3].Value = DealreID;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "GetInfoByID", param, "tb");
            if (ds != null)
                dt = ds.Tables[0];
            return dt;
        }
        /// <summary>
        /// 部门经理更新店铺的审核状态
        /// </summary>
        /// <param name="StrWhere"></param>
        public void UpdateExamState(int examState, string UserID, string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update shopinfo set ExamState=" + examState + " where ");
            sb.Append(StrWhere);
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }
        /// <summary>
        /// 省区VM审核新增店铺
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void VMUpdateExamState(int examState, string UserID, string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update shopinfo set VMExamState=" + examState + ",VMExamUserID=" + UserID + ",VMExamDate=CONVERT(varchar(30), GETDATE(), 20) where ");
            sb.Append(StrWhere);
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }


        public void Update(LN.Model.EditShopInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ShopInfo set ");
            strSql.Append("ShopID=@ShopID,");
            strSql.Append("PosID=@PosID,");
            strSql.Append("Shopname=@Shopname,");
            strSql.Append("ShopAddress=@ShopAddress,");
            strSql.Append("ShopOpenDate=@ShopOpenDate,");
            strSql.Append("ShopCloseDate=@ShopCloseDate,");
            strSql.Append("CloseUserID=@CloseUserID,");
            strSql.Append("ProvinceID=@ProvinceID,");
            strSql.Append("CityID=@CityID,");
            strSql.Append("TownID=@TownID,");
            strSql.Append("ShopLevelID=@ShopLevelID,");
            strSql.Append("SaleTypeID=@SaleTypeID,");
            strSql.Append("LinkMan=@LinkMan,");
            strSql.Append("LinkPhone=@LinkPhone,");
            strSql.Append("ShopMaster=@ShopMaster,");
            strSql.Append("ShopMasterPhone=@ShopMasterPhone,");
            strSql.Append("Email=@Email,");
            strSql.Append("PostAddress=@PostAddress,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("FaxNumber=@FaxNumber,");
            strSql.Append("Boolinstall=@Boolinstall,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("FXID=@FXID,");
            strSql.Append("CustomerGroupID=@CustomerGroupID,");
            strSql.Append("CustomerGroupName=@CustomerGroupName,");
            strSql.Append("ShopState=@ShopState,");
            strSql.Append("ExamState=@ExamState,");
            strSql.Append("VMMaster=@VMMaster,");
            strSql.Append("VMMasterPhone=@VMMasterPhone,");
            strSql.Append("DSRMaster=@DSRMaster,");
            strSql.Append("DSRMasterPhone=@DSRMasterPhone,");
            strSql.Append("ShopArea=@ShopArea,");
            strSql.Append("ShopVI=@ShopVI,");
            strSql.Append("ShopType=@ShopType,");
            strSql.Append("ShopPhone=@ShopPhone,");
            strSql.Append("areaid=@areaid");
            strSql.Append(" where ShopID=@ShopID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4),
					new SqlParameter("@PosID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopname", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopAddress", SqlDbType.NVarChar,300),
					new SqlParameter("@ShopOpenDate", SqlDbType.VarChar,50),
					new SqlParameter("@ShopCloseDate", SqlDbType.VarChar,50),
					new SqlParameter("@CloseUserID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceID", SqlDbType.Int,4),
					new SqlParameter("@CityID", SqlDbType.Int,4),
					new SqlParameter("@TownID", SqlDbType.Int,4),
					new SqlParameter("@ShopLevelID", SqlDbType.Int,4),
					new SqlParameter("@SaleTypeID", SqlDbType.Int,4),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkPhone", SqlDbType.VarChar,80),
					new SqlParameter("@ShopMaster", SqlDbType.VarChar,50),
					new SqlParameter("@ShopMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@PostAddress", SqlDbType.VarChar,500),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
					new SqlParameter("@FaxNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Boolinstall", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.VarChar,50),
					new SqlParameter("@FXID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerGroupName", SqlDbType.VarChar,300),
					new SqlParameter("@ShopState", SqlDbType.Int,4),
					new SqlParameter("@ExamState", SqlDbType.Int,4),
					new SqlParameter("@VMMaster", SqlDbType.VarChar,50),
					new SqlParameter("@VMMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMaster", SqlDbType.VarChar,50),
					new SqlParameter("@DSRMasterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@ShopArea", SqlDbType.Float,8),
					new SqlParameter("@ShopVI", SqlDbType.Int,4),
					new SqlParameter("@ShopType", SqlDbType.Int,4),
					new SqlParameter("@ShopPhone", SqlDbType.VarChar,50),
					new SqlParameter("@areaid", SqlDbType.Int,4)};

            parameters[0].Value = model.ShopID;
            parameters[1].Value = model.PosID;
            parameters[2].Value = model.Shopname;
            parameters[3].Value = model.ShopAddress;
            parameters[4].Value = model.ShopOpenDate;
            parameters[5].Value = model.ShopCloseDate;
            parameters[6].Value = model.CloseUserID;
            parameters[7].Value = model.ProvinceID;
            parameters[8].Value = model.CityID;
            parameters[9].Value = model.TownID;
            parameters[10].Value = model.ShopLevelID;
            parameters[11].Value = model.SaleTypeID;
            parameters[12].Value = model.LinkMan;
            parameters[13].Value = model.LinkPhone;
            parameters[14].Value = model.ShopMaster;
            parameters[15].Value = model.ShopMasterPhone;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.PostAddress;
            parameters[18].Value = model.PostCode;
            parameters[19].Value = model.FaxNumber;
            parameters[20].Value = model.Boolinstall;
            parameters[21].Value = model.DealerID;
            parameters[22].Value = model.FXID;
            parameters[23].Value = model.CustomerGroupID;
            parameters[24].Value = model.CustomerGroupName;
            parameters[25].Value = model.ShopState;
            parameters[26].Value = model.ExamState;
            parameters[27].Value = model.VMMaster;
            parameters[28].Value = model.VMMasterPhone;
            parameters[29].Value = model.DSRMaster;
            parameters[30].Value = model.DSRMasterPhone;
            parameters[31].Value = model.ShopArea;
            parameters[32].Value = model.ShopVI;
            parameters[33].Value = model.ShopType;
            parameters[34].Value = model.ShopPhone;
            parameters[35].Value = model.areaid;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 将editshopinfo的信息copy到shopinfo表中
        /// </summary>
        /// <param name="shopid"></param>
        public void copyshopinfo(string shopid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("insert into shopinfo ");
            sb.Append(" select [ShopID],[PosID],[Shopname],[Shopsamplename],[ShopAddress],[ShopOpenDate],[ShopCloseDate]");
            sb.Append(" ,[CloseUserID],[ProvinceID],[CityID],[TownID],[ShopLevelID],[SaleTypeID],[LinkMan],[LinkPhone],[ShopMaster]");
            sb.Append(" ,[ShopMasterPhone],[Email],[PostAddress],[PostCode],[FaxNumber],[Boolinstall],[DealerID],[FXID],[CustomerGroupID]");
            sb.Append(" ,[CustomerGroupName],[ShopState],[ExamState],[VMMaster],[VMMasterPhone],[DSRMaster] ");
            sb.Append(",[DSRMasterPhone],[ShopArea],[ShopVI],[ShopType],[ShopPhone],[areaid],[ShopOwnerShip],[CustomerCard],VMExamState,VMExamUserID,VMExamDate ");
            sb.Append(string.Format(" FROM Editshopinfo where shopid={0}", shopid));

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sb.ToString());
        }
        /// <summary>
        /// 通过PosID得到相应的店铺名称
        /// </summary>
        /// <param name="PosID"></param>
        /// <returns></returns>
        public DataTable GetShopNameByPosID(string PosID)
        {
            string strsql = "select PosID, shopname from shopinfo ";
            if (PosID.Length > 0)
                strsql += "where PosID like '%" + PosID + "%'";
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strsql);
            return ds.Tables[0];
        }

        /// <summary>
        /// 判断指定店铺是否是FOS店
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>返回1：是，0：否</returns>
        public int GetSaleTypeID(int ShopID)
        {
            int IsFOS = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM ShopInfo");
            strSql.AppendFormat(" WHERE ShopID={0} AND SaleTypeID=9 ", ShopID.ToString());

            //SqlParameter[] parameters = {
            //        new SqlParameter("@ShopID", SqlDbType.Int,4)};


            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString());
            if (obj != null)
                IsFOS = Convert.ToInt32(obj);

            return IsFOS;

        }


        #endregion  成员方法
    }
}


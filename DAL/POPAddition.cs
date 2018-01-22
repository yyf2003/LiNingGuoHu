using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类POPAddition。
    /// </summary>
    public class POPAddition
    {
        public POPAddition()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID(DbHelperSQL.connectionString(), "AddID", "POPAddition");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AddID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from POPAddition");
            strSql.Append(" where AddID=@AddID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AddID", SqlDbType.Int,4)};
            parameters[0].Value = AddID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 判断以个POP是否已经增补过
        /// </summary>
        /// <param name="POPInfoID"></param>
        /// <returns></returns>
        public string CheckPOP(string POPInfoID,string POPID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from POPAddition");
            strSql.Append(" where POPInfoID=@POPInfoID and POPID=@POPID");
            SqlParameter[] parameters = {
					new SqlParameter("@POPInfoID", SqlDbType.Int,4),
                    new SqlParameter("@POPID", SqlDbType.VarChar,30)
            };
            parameters[0].Value = POPInfoID;
            parameters[1].Value = POPID;
            if (DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters))
            {
                return "1";
            }
            return "0";

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.POPAddition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into POPAddition(");
            strSql.Append("POPID,Shopid,POPinfoID,PhotoUrl,AddUserID,Des,AddType,AddObject,ProlineID)");
            strSql.Append(" values (");
            strSql.Append("@POPID,@Shopid,@POPinfoID,@PhotoUrl,@AddUserID,@Des,@AddType,@AddObject,@ProlineID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopid", SqlDbType.Int,4),
					new SqlParameter("@POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@PhotoUrl", SqlDbType.VarChar,150),
					new SqlParameter("@AddUserID", SqlDbType.Int,4),
					new SqlParameter("@Des", SqlDbType.VarChar,400),
                new SqlParameter("@AddType", SqlDbType.VarChar,50),
                new SqlParameter("@AddObject", SqlDbType.VarChar,50),
                new SqlParameter("@ProlineID", SqlDbType.Int,4)
            };
            parameters[0].Value = model.POPID;
            parameters[1].Value = model.Shopid;
            parameters[2].Value = model.POPinfoID;
            parameters[3].Value = model.PhotoUrl;
            parameters[4].Value = model.AddUserID;
            parameters[5].Value = model.Des;
            parameters[6].Value = model.Addtype;
            parameters[7].Value = model.AddObject;
            parameters[8].Value = model.ProLineID;
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
        public void Update(LN.Model.POPAddition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPAddition set ");
            strSql.Append("POPID=@POPID,");
            strSql.Append("Shopid=@Shopid,");
            strSql.Append("POPinfoID=@POPinfoID,");
            strSql.Append("PhotoUrl=@PhotoUrl,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("AddUserID=@AddUserID,");
            strSql.Append("ExamState=@ExamState,");
            strSql.Append("ExamUserID=@ExamUserID, ");
            strSql.Append("Des=@Des");

            strSql.Append(" where AddID=@AddID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AddID", SqlDbType.Int,4),
					new SqlParameter("@POPID", SqlDbType.VarChar,50),
					new SqlParameter("@Shopid", SqlDbType.Int,4),
					new SqlParameter("@POPinfoID", SqlDbType.Int,4),
					new SqlParameter("@PhotoUrl", SqlDbType.VarChar,150),
					new SqlParameter("@AddDate", SqlDbType.VarChar,20),
					new SqlParameter("@AddUserID", SqlDbType.Int,4),
					new SqlParameter("@ExamState", SqlDbType.Int,4),
					new SqlParameter("@ExamUserID", SqlDbType.Int,4),
                    new SqlParameter ("@Des",SqlDbType.VarChar ,200)};
            parameters[0].Value = model.AddID;
            parameters[1].Value = model.POPID;
            parameters[2].Value = model.Shopid;
            parameters[3].Value = model.POPinfoID;
            parameters[4].Value = model.PhotoUrl;
            parameters[5].Value = model.AddDate;
            parameters[6].Value = model.AddUserID;
            parameters[7].Value = model.ExamState;
            parameters[8].Value = model.ExamUserID;
            parameters[9].Value = model.Des;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// 部门经理审核原损补单的POP情况
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="Undes"></param>
        /// <param name="ExamState"></param>
        /// <param name="AddID"></param>
        public void UpdateAddition(int Userid, string Undes, int ExamState, int AddID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPAddition set ");
            strSql.Append("ExamState=@ExamState,");
            strSql.Append("ExamUserID=@ExamUserID, ");
            strSql.Append("UnDes=@UnDes");
            strSql.Append(" where AddID=@AddID ");
            SqlParameter[] parameters = {
                 	new SqlParameter("@AddID", SqlDbType.Int,4),
                 	new SqlParameter("@ExamState", SqlDbType.Int,4),
					new SqlParameter("@ExamUserID", SqlDbType.Int,4),
                 new SqlParameter("@UnDes", SqlDbType.VarChar ,200)
             };
            parameters[0].Value = AddID;
            parameters[1].Value = ExamState;
            parameters[2].Value = Userid;
            parameters[3].Value = Undes;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }
        /// <summary>
        /// 区域VM审核原损补单的POP情况
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="Undes"></param>
        /// <param name="ExamState"></param>
        /// <param name="AddID"></param>
        public void VMUpdateAddition(int Userid, string Undes, int ExamState, int AddID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPAddition set ");
            strSql.Append("VMExamState=@VMExamState,");
            strSql.Append("VMExamUserID=@VMExamUserID, ");
            strSql.Append("VMUnDes=@VMUnDes,");
            strSql.Append("VMExamTime=CONVERT(varchar(30), GETDATE(), 20) ");
            strSql.Append(" where AddID=@AddID ");
            SqlParameter[] parameters = {
                new SqlParameter("@AddID", SqlDbType.Int,4),
                new SqlParameter("@VMExamState", SqlDbType.Int,4),
				new SqlParameter("@VMExamUserID", SqlDbType.Int,4),
                new SqlParameter("@VMUnDes", SqlDbType.VarChar ,200)
             };
            parameters[0].Value = AddID;
            parameters[1].Value = ExamState;
            parameters[2].Value = Userid;
            parameters[3].Value = Undes;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }




        /// <summary>
        /// 一级客户发货
        /// </summary>
        /// <param name="UserID">操作人ID</param>
        /// <param name="Add">操作的POPAddion ID</param>
        /// <param name="SendTime">发货时间</param>
        /// <param name="State">发货状态</param>
        /// <param name="GoodsOrderNo">发货单号</param>
        /// <param name="CompanyID">物流公司ID</param>
        /// <param name="SendDes">发货描述</param>
        public void SendPOPAddition(int UserID, int Add, string SendTime, int State, string GoodsOrderNo, int CompanyID, string SendDes)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update POPAddition set ");
            strSql.Append("SendUser=@SendUser,");
            strSql.Append("State=@State ,");
            strSql.Append("SendTime=@SendTime ,");
            strSql.Append("GoodsOrderNo=@GoodsOrderNo ,");
            strSql.Append("CompanyID=@CompanyID ,");
            strSql.Append("SendDes=@SendDes ");
            strSql.Append(" where AddID=@AddID ");
            SqlParameter[] parameters = {
                 	new SqlParameter("@SendUser", SqlDbType.Int,4),
                 	new SqlParameter("@State", SqlDbType.Int,4),
                 	new SqlParameter("@SendTime", SqlDbType.VarChar ,20), 
					new SqlParameter("@GoodsOrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@SendDes", SqlDbType.VarChar,20),
					new SqlParameter("@AddID", SqlDbType.Int,4)

             };
            parameters[0].Value = UserID;
            parameters[1].Value = State;
            parameters[2].Value = SendTime;
            parameters[3].Value = GoodsOrderNo;
            parameters[4].Value = CompanyID;
            parameters[5].Value = SendDes;
            parameters[6].Value = Add;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }




        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int AddID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete POPAddition ");
            strSql.Append(" where AddID=@AddID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AddID", SqlDbType.Int,4)};
            parameters[0].Value = AddID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.POPAddition GetModel(int AddID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AddID,POPID,Shopid,POPinfoID,PhotoUrl,AddDate,AddUserID,ExamState,ExamUserID,Des,UnDes from POPAddition ");
            strSql.Append(" where AddID=@AddID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AddID", SqlDbType.Int,4)};
            parameters[0].Value = AddID;

            LN.Model.POPAddition model = new LN.Model.POPAddition();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AddID"].ToString() != "")
                {
                    model.AddID = int.Parse(ds.Tables[0].Rows[0]["AddID"].ToString());
                }
                model.POPID = ds.Tables[0].Rows[0]["POPID"].ToString();
                if (ds.Tables[0].Rows[0]["Shopid"].ToString() != "")
                {
                    model.Shopid = int.Parse(ds.Tables[0].Rows[0]["Shopid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["POPinfoID"].ToString() != "")
                {
                    model.POPinfoID = int.Parse(ds.Tables[0].Rows[0]["POPinfoID"].ToString());
                }
                model.PhotoUrl = ds.Tables[0].Rows[0]["PhotoUrl"].ToString();
                model.AddDate = ds.Tables[0].Rows[0]["AddDate"].ToString();
                model.Des = ds.Tables[0].Rows[0]["Des"].ToString();
                model.UnDes = ds.Tables[0].Rows[0]["UnDes"].ToString();
                if (ds.Tables[0].Rows[0]["AddUserID"].ToString() != "")
                {
                    model.AddUserID = int.Parse(ds.Tables[0].Rows[0]["AddUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExamState"].ToString() != "")
                {
                    model.ExamState = int.Parse(ds.Tables[0].Rows[0]["ExamState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExamUserID"].ToString() != "")
                {
                    model.ExamUserID = int.Parse(ds.Tables[0].Rows[0]["ExamUserID"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AddID,POPID,Shopid,POPinfoID,PhotoUrl,AddDate,AddUserID,ExamState,ExamUserID,Des,UnDes ");
            strSql.Append(" FROM POPAddition ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }




        /// <summary>
        /// 根据店铺名称得到店铺的增补数据
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public DataSet GetPOPAdditionList(string shopid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select [POPseat],[POPMaterial],RealHeight,RealWith,[POPHeight],[POPWith],[POPArea],[examstate],[PhotoUrl],[Des],[UnDes],[Addid],posid,shopid,shopname,dealerid,dealername,seatnum,POPPlwz,POPpljd from view_popaddition where 1=1 ");
            if (!string.IsNullOrEmpty(shopid))
            {
                sb.Append(" and shopid = " + shopid);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }
        /// <summary>
        /// 得到增补的POP的信息列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetPOPExamlist(string StrWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select [POPseat],[POPMaterial],RealHeight,RealWith,[POPHeight],[POPWith],[POPArea],[examstate],[PhotoUrl],[Des],[UnDes],[Addid],posid,shopid,shopname,dealerid,dealername,seatnum,POPPlwz,POPpljd,VMExamState,VMExamUserID, VMExamTime, VMUnDes from view_popaddition  ");
            if (!string.IsNullOrEmpty(StrWhere))
            {
                sb.Append(" where ");
                sb.Append(StrWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }

        /// <summary>
        /// 根据查询语句得到要处理的增补POP数据
        /// </summary>
        /// <param name="strWhere">限定条件</param>
        /// <returns></returns>
        public DataSet GetExamPOPAddition(string strWhere,string POPID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   select distinct count(b.shopid) as POPcount,sum(POPArea) as Totalarea,sum(POPArea*POPPrice) as totalPrice, ");
            sb.Append("  a.Shopid, Suppliername,provincename,cityname,shopname,Posid, dealername ");
            sb.Append("  from dbo.View_POPChangeSetInfo  a,POPAddition b  where a.ID=b.POPinfoID and a.POPID='" + POPID + "' and b.POPID='" + POPID + "' ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sb.Append(strWhere);
            }
            sb.Append("group by SupplierName ,provincename,cityname,shopname,Posid,a.dealerid,a.Shopid,dealername  ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

        }

        /// <summary>
        /// 根据查询语句得到要发货的增补POP数据
        /// </summary>
        /// <param name="strWhere">限定条件</param>
        /// <returns></returns>
        public DataSet GetSendPOPAddition(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   select POPAddition.Addid, POPAddition.shopid,POPAddition.UnDes, ShopInfo.PosID,Shopname,ProvinceID,CityID,DealerID,Boolinstall,ShopType,SaleTypeID,DealerID,SupplierID ");
            sb.Append(" from dbo.SupplierAssignRecord,dbo.ShopInfo,dbo.POPAddition ");
            sb.Append(" where AssignShopID=shopinfo.shopid and POPAddition.shopid=shopinfo.shopid and POPAddition.ExamState=1 and POPAddition.State=0  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sb.Append(strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());


        }

        /// <summary>
        /// 得到POPInfo的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetPOPInfoList(string strWhere)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = "where " + strWhere;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("   select * from POPInfo where shopid in (  ");
            sb.Append("select shopid from ShopInfo  " + strWhere + ") ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }

        /// <summary>
        /// 得到要发货的POPAddition的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="AddID"></param> 
        /// <returns></returns>
        public DataSet GetPOPInfoToSend(string POPID, int AddID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("     select * from popinfo  ");
            sb.Append("  where ID in(select popinfoid from POPAddition where examstate =1 and  POPID ='" + POPID + "' and Addid =" + AddID + ") ");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }

        /// <summary>
        /// 得到增补 已发货但还为收货的店铺列表
        /// </summary>
        /// <param name="Supplierid"></param>
        /// <param name="posid"></param>
        /// <param name="shopname"></param>
        /// <param name="dealerid"></param>
        /// <param name="GoodsOrderNo"></param>
        /// <returns></returns>
        public string GetNoReceiveGoodList(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select distinct count(Suppliername) POPCount,Shopid,Suppliername,provincename,cityname,shopname,Posid,(select dealername from dealerinfo where Dealerid=a.dealerid) as dealername from dbo.View_SupplierAssignRecord  a,POPAddition b where a.AssignShopID=b.shopid");//AssignShopID=26
            
            if (strWhere.Length > 0)
            {
                sb.Append(strWhere);
            }
            sb.Append(" group by SupplierName ,provincename,cityname,shopname,Posid,a.dealerid,Shopid");
            return sb.ToString();
        }
        /// <summary>
        /// 得到店铺没有收获 的 POP 列表
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataSet GetNoReceivePOPlist(string shopid,string POPID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [SeatNum],[POPseat],[POPHeight],[SeatDesc],[POPWith],[POPArea],[POPMaterial],[ProductLineID],[Sexarea],[ProductLine],b.addid FROM [View_POPinfo] a, POPAddition b where a.id=b.POPinfoID");

            sb.Append(" and POPID='"+POPID+"'");
            sb.Append(" and b.shopid="+shopid);

            sb.Append(" and b.ExamState=1 and b.state=0");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }
        /// <summary>
        /// 收货
        /// </summary>
        /// <param name="alist"></param>
        /// <param name="username"></param>
        /// <param name="shdate"></param>
        /// <param name="fenshu"></param>
        /// <param name="pingjia"></param>
        public void POPReceive(ArrayList alist,string username,string shdate,string fenshu,string pingjia)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < alist.Count; i++)
            {
                list.Add("update POPAddition set [State]=2, AcceptUser='" + username + "',AcceptTime='" + shdate + "',AcceptDes='" + pingjia + "',AcceptFen=" + fenshu + " where addid=" + alist[i].ToString());
            }

            DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), list);
        }
        /// <summary>
        /// 得到店铺的增补的pop
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataSet GetAddEveryPOPlist(string shopid,string POPID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select b.POPID,SeatNum,seatDesc,ProductLine,POPMaterial,POPArea,Sexarea,POPWith,POPHeight,POPseat,POParea*POPprice as totalprice,AddDate,[state],realheight,realwith,POPplwz,POPpljd,TwoSided,Glass,PlatformWith,PlatformHeight,PlatformLong from dbo.View_POPChangeSetInfo  a,POPAddition b where a.ID=b.POPinfoID ");
            if (!"0".Equals(POPID))
            {
                sb.Append(" and a.POPID='" + POPID+ "'");
                sb.Append(" and b.POPID='" + POPID + "'");
            }
            sb.Append(" and b.shopid=" + shopid + "and b.Examstate = 1");

            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());
        }
        ///// <summary>
        ///// 得到每个店铺的POP的数量
        ///// </summary>
        ///// <param name="StrWhere"></param>
        ///// <returns></returns>
        //public DataTable getShopPOP(string StrWhere,Model.PageModel model,out int totalnum)
        //{
        //    string str = "select view_imgtopop.shopid,posid,shopname, count(posid) popcount,sum(POPArea) totalarea,isnull(ShippingSpeedData.GetInState,'未发货') recevieState from view_imgtopop left join ShippingSpeedData  on view_imgtopop.shopid=ShippingSpeedData.shopid   ";
        //    if (StrWhere.Length > 0)
        //    {
        //        str += " where " + StrWhere;
        //    }
        //    str += " group by view_imgtopop.shopid,ShippingSpeedData.GetInState,posid,shopname";
        //    int totalcount = 0;
        //    model.SelectSql = str;
        //    DataTable dt= GetTableListSqlExec.GetList(model,out totalcount);
        //    totalnum = totalcount;
           
        //    return dt;
        //}
        /// <summary>
        /// 得到每个店铺的POP的数量
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable getShopPOP(string StrWhere, Model.PageModel model, out int totalnum)
        {
            string str = "select shopid,posid,shopname, count(posid) popcount,sum(POPArea) totalarea from view_popinfo ";
            if (StrWhere.Length > 0)
            {
                str += " where " + StrWhere;
            }
            str += "  group by  shopid,posid,shopname ";
            int totalcount = 0;
            model.SelectSql = str;
            DataTable dt = GetTableListSqlExec.GetList(model, out totalcount);
            totalnum = totalcount;

            return dt;
        }

        //判断是否可以进行pop的增补 在规定范围能增补 返回true 不能返回false
        public bool BoolPOPadd(int addday)
        {
            StringBuilder str = new StringBuilder();
          //  select top 1 datediff( day,begindate,getdate() )-20 from poplaunch order by id desc 
            str.Append(string.Format( "select top 1 datediff( day,begindate,getdate() )-{0} from poplaunch order by id desc ",addday));
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), str.ToString());
            if (obj == null)
                return false;
            else
            {
                if (int.Parse(obj.ToString()) <= 0)
                    return true;
                else
                    return false;
            }

        }
        /// <summary>
        /// 得到原损补单分析数据
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataSet GetAddPOPAddition(string strwhere)
        {
            SqlParameter[] para ={
                new SqlParameter("@strWhere",SqlDbType.VarChar,2000)
            };

            para[0].Value = strwhere;

            DataSet ds = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "Pro_POPAllAnalysis", para, "ds");
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
            parameters[0].Value = "POPAddition";
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


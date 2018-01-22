using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
using System.Collections;
using System.Text;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类POPAddition 的摘要说明。
    /// </summary>
    public class POPAddition
    {
        private readonly LN.DAL.POPAddition dal = new LN.DAL.POPAddition();
        public POPAddition()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AddID)
        {
            return dal.Exists(AddID);
        }

        /// <summary>
        /// 判断以个POP是否已经增补过
        /// </summary>
        /// <param name="POPInfoID"></param>
        /// <returns></returns>
        public string CheckPOP(string POPInfoID,string POPID)
        {
            return dal.CheckPOP(POPInfoID,POPID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.POPAddition model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.POPAddition model)
        {
            dal.Update(model);
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
            dal.SendPOPAddition(UserID, Add, SendTime, State, GoodsOrderNo, CompanyID, SendDes);
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
            dal.UpdateAddition(Userid, Undes, ExamState, AddID);
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
            dal.VMUpdateAddition(Userid, Undes, ExamState, AddID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int AddID)
        {

            dal.Delete(AddID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.POPAddition GetModel(int AddID)
        {

            return dal.GetModel(AddID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 根据查询语句得到要处理的增补POP数据
        /// </summary>
        /// <param name="strWhere">限定条件</param>
        /// <returns></returns>
        public DataSet GetExamPOPAddition(string strWhere, string POPID)
        {
            return dal.GetExamPOPAddition(strWhere, POPID);
        }
            /// <summary>
        /// 得到增补的POP的信息列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetPOPExamlist(string StrWhere)
        {
            return dal.GetPOPExamlist(StrWhere);
        }
        /// <summary>
        /// 根据查询语句得到要发货的增补POP数据
        /// </summary>
        /// <param name="strWhere">限定条件</param>
        /// <returns></returns>
        public DataSet GetSendPOPAddition(string strWhere)
        {
            return dal.GetSendPOPAddition(strWhere);
        }

        /// <summary>
        /// 得到要发货的POPAddition的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="AddID"></param> 
        /// <returns></returns>
        public DataSet GetPOPInfoToSend(string POPID, int AddID)
        {
            return dal.GetPOPInfoToSend(POPID, AddID);
        }

        /// <summary>
        /// 根据店铺名称得到店铺的增补数据
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public DataSet GetPOPAdditionList(string shopid)
        {
            return dal.GetPOPAdditionList(shopid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPAddition> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.POPAddition> modelList = new List<LN.Model.POPAddition>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.POPAddition model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.POPAddition();
                    if (ds.Tables[0].Rows[n]["AddID"].ToString() != "")
                    {
                        model.AddID = int.Parse(ds.Tables[0].Rows[n]["AddID"].ToString());
                    }
                    model.POPID = ds.Tables[0].Rows[n]["POPID"].ToString();
                    if (ds.Tables[0].Rows[n]["Shopid"].ToString() != "")
                    {
                        model.Shopid = int.Parse(ds.Tables[0].Rows[n]["Shopid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["POPinfoID"].ToString() != "")
                    {
                        model.POPinfoID = int.Parse(ds.Tables[0].Rows[n]["POPinfoID"].ToString());
                    }
                    model.PhotoUrl = ds.Tables[0].Rows[n]["PhotoUrl"].ToString();
                    model.AddDate = ds.Tables[0].Rows[n]["AddDate"].ToString();
                    model.Des = ds.Tables[0].Rows[n]["Des"].ToString();
                    if (ds.Tables[0].Rows[n]["AddUserID"].ToString() != "")
                    {
                        model.AddUserID = int.Parse(ds.Tables[0].Rows[n]["AddUserID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExamState"].ToString() != "")
                    {
                        model.ExamState = int.Parse(ds.Tables[0].Rows[n]["ExamState"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExamUserID"].ToString() != "")
                    {
                        model.ExamUserID = int.Parse(ds.Tables[0].Rows[n]["ExamUserID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 得到POPInfo的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetPOPInfoList(string strWhere)
        {
            return dal.GetPOPInfoList(strWhere);
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
            return dal.GetNoReceiveGoodList(strWhere);
        }
            /// <summary>
        /// 得到店铺没有收获 的 POP 列表
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataSet GetNoReceivePOPlist(string shopid, string POPID)
        {
            return dal.GetNoReceivePOPlist(shopid ,POPID);
        }
             /// <summary>
        /// 收货
        /// </summary>
        /// <param name="alist"></param>
        /// <param name="username"></param>
        /// <param name="shdate"></param>
        /// <param name="fenshu"></param>
        /// <param name="pingjia"></param>
        public void POPReceive(ArrayList alist, string username, string shdate, string fenshu, string pingjia)
        {
            dal.POPReceive(alist,  username,  shdate,  fenshu,  pingjia);
        }

        public string GetAnalysisstr(Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select sum(POPcount) POPcount,sum(Totalarea) Totalarea,sum(totalPrice) totalPrice,shopid,suppliername,provincename,cityname,shopname,posid,dealername from (select distinct count(shopid) as POPcount,sum(POPArea) as Totalarea,");
            sb.Append("((select  distinct top 1 poparea*popprice from View_popprice where materiapro=View_POPAddition.POPMaterial and POPID=View_POPAddition.POPID  )) as totalPrice,");
            sb.Append("Shopid, Suppliername,provincename,cityname,shopname,Posid, dealername,popid from View_POPAddition  where 1=1 ");
            
            if (ht["POPID"].ToString()!="0")
            {
                sb.Append(" and View_POPAddition.POPID='" + ht["POPID"].ToString() + "'");
            }
            if (ht["PosCode"].ToString().Length > 0)
            {
                sb.Append(" and Posid='" + ht["PosCode"].ToString() + "'");
            }
            if (ht["Shopname"].ToString().Length > 0)
            {
                sb.Append(" and shopname like '%" + ht["Shopname"].ToString() + "%'");
            }
            if (ht["SupplierID"].ToString() != "0")
            {
                sb.Append(" and View_POPAddition.supplierid = " + ht["SupplierID"].ToString());
            }
            if (ht["DealerID"].ToString() != "0")
            {
                sb.Append(" and DealerID = '" + ht["DealerID"].ToString()+"'");
            }

            //if (ht["areaID"].ToString() != "-1")
            //{
            //    sb.Append(" and a.areaID = " + ht["areaID"].ToString());
            //}
            if (ht["ProvinceID"].ToString() != "0")
            {
                sb.Append(" and ProvinceID = " + ht["ProvinceID"].ToString());
            }
            if (ht["CityID"].ToString() != "0")
            {
                sb.Append(" and CityID = " + ht["CityID"].ToString());
            }
            if (ht["Examstate"].ToString() != "-1")
            {
                sb.Append(" and View_POPAddition.Examstate = " + ht["Examstate"].ToString());
            }
            //if (ht["send"].ToString() != "-1")
            //{
            //    sb.Append(" and state = " + ht["send"].ToString());
            //}
            if (ht["year"] != null)
                sb.Append(" and year(adddate)="+ht["year"].ToString());
            sb.Append(" group by SupplierName ,provincename,cityname,shopname,Posid,dealerid,Shopid,dealername,POPMaterial,poparea,POPID) as a  group by shopid,suppliername,provincename,cityname,shopname,posid,dealername ");
            return sb.ToString();
        }

        
        /// <summary>
        /// 得到店铺的增补的pop
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataSet GetAddEveryPOPlist(string shopid, string POPID)
        {
            return dal.GetAddEveryPOPlist(shopid,POPID);
        }

            /// <summary>
        /// 得到每个店铺的POP的数量
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable getShopPOP(string StrWhere, Model.PageModel model,out int totalnum)
        {
            return dal.getShopPOP(StrWhere, model,out  totalnum);
        }
          //判断是否可以进行pop的增补
        public bool BoolPOPadd(int addday)
        {
            return dal.BoolPOPadd(addday);
        }

              /// <summary>
        /// 得到原损补单分析数据
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataSet GetAddPOPAddition(string strwhere)
        {
            return dal.GetAddPOPAddition(strwhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}


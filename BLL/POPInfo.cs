using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
using System.Text;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPInfo 的摘要说明。
	/// </summary>
	public class POPInfo
	{
        private readonly LN.DAL.POPInfo dal = new LN.DAL.POPInfo();
		public POPInfo()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

                /// <summary>
        /// 得到店铺内所有pop的信息
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataTable GetPOPByshopid(string shopid)
        {
            return dal.GetPOPByshopid(shopid);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(LN.Model.POPInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public void Update(LN.Model.POPInfo model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdatePOP(LN.Model.POPInfo model)
        {
            return dal.UpdatePOP(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public LN.Model.POPInfo GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		   /// <summary>
        /// 获得数据列表返回DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            return dal.GetListDataSet(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPInfo> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrder(string strWhere)
        {
            return dal.GetListOrder(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShop(string ShopID)
        {
            return dal.GetListOrderByShop(ShopID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShopID(string strWhere)
        {
            return dal.GetListOrderByShopID(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShopIDNew(string ShopID)
        {
            return dal.GetListOrderByShopIDNew(ShopID);
        }
	
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPInfo> GetAllList()
		{
			return GetList("");
		}
          /// <summary>
        /// 查看数据库中是否存在此 位置编号
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="seatnum"></param>
        /// <returns></returns>
        public int GetOnlyNum(string shopid, string seatnum)
        {
            return dal.GetOnlyNum(shopid,seatnum);
        }
             /// <summary>
        /// 得到有未审批POP的店铺信息
        /// </summary>
        /// <param name="htable"></param>
        /// <returns></returns>
        public DataTable GetExamPOP(Hashtable htable, ref int TotalNumber)
        {
            return dal.GetExamPOP(htable,ref  TotalNumber);
        }

                /// <summary>
        /// 确认店铺没有审批的POP
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public bool ExamShopPOP(List<string> IDlist, string userID)
        {
            return dal.ExamShopPOP(IDlist,userID);
        }
        /// <summary>
        /// 省区VM审核季度新增POP信息
        /// </summary>
        /// <param name="ExamState"></param>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        public bool VMExamPOPState(string ExamState, string ID, string UserID)
        {
           return  dal.VMExamPOPState(ExamState, ID, UserID);
        }
        /// <summary>
        /// 放弃Pop信息 将审批状态改为-1 即为放弃
        /// </summary>
        /// <param name="ID"></param>
        public void giveupPOP(string ID,string UserID)
        {
            dal.giveupPOP(ID, UserID);
        }
		
        /// <summary>
        /// 供应商查找指定店铺的安装POP信息列表，以便上传图片
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="ShopName">店铺名称</param>
        /// <param name="PosID">POS编号</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetPOPListByShopID(string SupplierID, string ShopID)
        {
            return dal.GetPOPListByShopID(SupplierID, ShopID);
        }

        /// <summary>
        /// VM管理员审核指定店铺的安装POP图片信息列表
        /// </summary>
        /// <param name="POPID">发起的POP编号</param>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetPOPJudgeListByShopID(string POPID, string SupplierID, string ShopID)
        {
            return dal.GetPOPJudgeListByShopID(POPID, SupplierID, ShopID);
        }

        /// <summary>
        /// 得到店铺的POP详细信息
        /// </summary>
        /// <param name="htable"></param>
        /// <returns></returns>
        public DataTable GetShopPOPInfoList(Hashtable htable)
        {
            return dal.GetShopPOPInfoList(htable);
        }
           /// <summary>
        /// 更新POP的属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pro"></param>
        public void Update_type(string id, string pro,string material)
        {
            dal.Update_type(id, pro, material);
        }
        /// <summary>
        /// 得到新增店铺pop的数据
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetNewaddPOPCount(Hashtable ht)
        {
            StringBuilder sb=new StringBuilder();
          
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
                sb.Append(" and view_popinfo.supplierid = " + ht["SupplierID"].ToString());
            }
            if (ht["DealerID"].ToString() != "0")
            {
                sb.Append(" and DealerID = '" + ht["DealerID"].ToString() + "'");
            }
            if (ht["areaID"].ToString() != "-1" && ht["areaID"].ToString() != "0")
            {
                //sb.Append(" and areaID = " + ht["areaID"].ToString());
                sb.AppendFormat(" and areaID in ({0})", ht["areaID"].ToString());
            }
            if (ht["ProvinceID"].ToString() != "0")
            {
                sb.Append(" and ProvinceID = " + ht["ProvinceID"].ToString());
            }
            if (ht["CityID"].ToString() != "0")
            {
                sb.Append(" and CityID = " + ht["CityID"].ToString());
            }
            if (ht["protype"].ToString() != "0")
            {
                sb.Append(" and typeid=" + ht["protype"].ToString());
            }
            if (ht["proline"].ToString() != "0")
                sb.Append(" and ProductLine='" + ht["proline"].ToString() + "'");
            if (ht["year"] != null)
                sb.Append(" and year(SysTime)=" + ht["year"].ToString());
            if (ht["beginDate"] != null && ht["beginDate"].ToString()!="")
                sb.Append(" and SysTime>='" + DateTime.Parse(ht["beginDate"].ToString()) + "'");
            if (ht["endDate"] != null && ht["endDate"].ToString() != "")
                sb.Append(" and SysTime<='" + DateTime.Parse(ht["endDate"].ToString()) + "'");
            return dal.GetNewaddPOPCount(sb.ToString());
        }

        /// <summary>
        /// 得到店铺要按照的数量
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="Popid"></param>
        /// <returns></returns>
        public int Getsetupcount(string shopid, string Popid)
        {
            return dal.Getsetupcount(shopid, Popid);
        }

              /// <summary>
        /// 得到新加pop的位置编号
        /// </summary>
        /// <returns></returns>
        public string Getnextseatnum(string shopid)
        {
            return dal.Getnextseatnum(shopid);
        }

        /// <summary>
        /// 判断指定店铺的POP是否全部审核通过
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>是否全部审核</returns>
        public int IsAllExamByShopID(int ShopID)
        {
            return dal.IsAllExamByShopID(ShopID);
        }

        /// <summary>
        /// 隐藏指定画面的POP信息
        /// </summary>
        /// <param name="imgIDList">画面编号集合</param>
        /// <returns>是否隐藏成功</returns>
        public int UpdateIsHide(string imgIDList)
        {
            return dal.UpdateIsHide(imgIDList);
        }

        public DataSet GetDSList(string whereStr)
        {
            return dal.GetDSList(whereStr);
        }

        public int GetMaxPOPNumByShopId(int shopId)
        {
            return dal.GetMaxPOPNumByShopId(shopId);
        }


		#endregion  成员方法
	}
}


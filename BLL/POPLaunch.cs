using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPLaunch 的摘要说明。
	/// </summary>
	public class POPLaunch
	{
		private readonly LN.DAL.POPLaunch dal=new LN.DAL.POPLaunch();
		public POPLaunch()
		{}
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.POPLaunch model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.POPLaunch model)
		{
			dal.Update(model);
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
		public LN.Model.POPLaunch GetModel(string popID)
		{

            return dal.GetModel(popID);
		}

 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.POPLaunch> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 得到发起pop所涉及到的故事包
        /// </summary>
        /// <param name="popid"></param>
        /// <returns></returns>
        public string GetProline(string popid)
        {
            return dal.GetProline(popid);
        }

        /// <summary>
        /// 更新完成的步骤
        /// </summary>
        /// <param name="step"></param>
        /// <param name="POPID"></param>
        public void Updatesteps(int step, string POPID)
        {
            dal.Updatesteps(step,POPID);
        }

           /// <summary>
        /// 得到摸个POP完成的步骤
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public int getsetps(string POPID)
        {
            return dal.getsetps(POPID);
        }
        /// <summary>
        /// 得到全部的ＰＯＰＩＤ
        /// </summary>
        /// <returns></returns>
        public List<string> GetPOPID()
        {
            return dal.GetPOPID();
        }

        /// <summary>
        /// 得到全部的ＰＯＰＩＤ
        /// </summary>
        /// <returns></returns>
        public IList<LN.Model.POPLaunch> GetPOPIDList()
        {
            return dal.GetPOPIDList();
        }

        /// <summary>
        /// 得到最新的ＰＯＰＩＤ
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewPOPID()
        {
            return dal.GetNewPOPID();
        }

        /// <summary>
        /// pop 分析 按照店铺
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet POPAnalysis(Hashtable ht, string Procedurename, out int totalnum)
        {
            return dal.POPAnalysis(ht,Procedurename,out totalnum);
        }
             /// <summary>
        /// 根据产品大类与产品系列进行分析
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet POPAnalysisByPro(Hashtable ht)
        {
            return dal.POPAnalysisByPro(ht);
        }
            /// <summary>
        /// 材料和故事包分析 得到每个店铺所产生的POP
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="totalnum"></param>
        /// <returns></returns>
        public DataTable EveryShopPOP(Hashtable ht, out int totalnum)
        {
            return dal.EveryShopPOP(ht,out totalnum);
        }
        /// <summary>
        /// 查看上一期POP是否结束
        /// </summary>
        /// <returns></returns>
        public string GetLastEndDate()
        {
            return dal.GetLastEndDate();
        }

        /// <summary>
        /// 得到最新发起的POP
        /// </summary>
        public LN.Model.POPLaunch GetNewestModel()
        {
            return dal.GetNewestModel();
        }
        /// <summary>
        /// 得到最新的POPID
        /// </summary>
        /// <returns></returns>
        public string GetLastPOPID()
        {
            return dal.GetLastPOPID();
        }
             /// <summary>
        /// 得到每期发起POP的数量和总面积
        /// </summary>
        /// <param name="POPID">pop发起ID</param>
        /// <param name="sid">供应商ID</param>
        /// <returns></returns>
        public DataTable GetTotalPOPList(string POPID, string sid,string prolist)
        {
            return dal.GetTotalPOPList(POPID, sid, prolist);
        }
              /// <summary>
        /// 得到每次发起pop每个店铺的pop数量面积
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="sid"></param>
        /// <param name="prolist"></param>
        /// <returns></returns>
        public DataTable GetPOPlaunchshopPOPlist(string POPID, string sid, string prolist, int pageindex, int pagesize, out int TotalNumber)
        {
            return dal.GetPOPlaunchshopPOPlist(POPID, sid, prolist, pageindex, pagesize,out TotalNumber);
        }
              /// <summary>
        /// 如果需要报价 则进行报价 
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="userID"></param>
        public void SetPOPprice(string POPID, string userID)
        {
            dal.SetPOPprice(POPID, userID);
        }
        /// <summary>
        /// 删除为发起完成的POP
        /// </summary>
        /// <param name="popid"></param>
        public void delpoplaunch(string popid)
        {
            dal.delpoplaunch(popid);
        }
		#endregion  成员方法
	}
}


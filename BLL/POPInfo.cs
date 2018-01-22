using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
using System.Text;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPInfo ��ժҪ˵����
	/// </summary>
	public class POPInfo
	{
        private readonly LN.DAL.POPInfo dal = new LN.DAL.POPInfo();
		public POPInfo()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

                /// <summary>
        /// �õ�����������pop����Ϣ
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataTable GetPOPByshopid(string shopid)
        {
            return dal.GetPOPByshopid(shopid);
        }
		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(LN.Model.POPInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(LN.Model.POPInfo model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// ����һ������
        /// </summary>
        public int UpdatePOP(LN.Model.POPInfo model)
        {
            return dal.UpdatePOP(model);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
        public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public LN.Model.POPInfo GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		   /// <summary>
        /// ��������б���DataSet
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListDataSet(string strWhere)
        {
            return dal.GetListDataSet(strWhere);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPInfo> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrder(string strWhere)
        {
            return dal.GetListOrder(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShop(string ShopID)
        {
            return dal.GetListOrderByShop(ShopID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShopID(string strWhere)
        {
            return dal.GetListOrderByShopID(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.POPInfo> GetListOrderByShopIDNew(string ShopID)
        {
            return dal.GetListOrderByShopIDNew(ShopID);
        }
	
		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPInfo> GetAllList()
		{
			return GetList("");
		}
          /// <summary>
        /// �鿴���ݿ����Ƿ���ڴ� λ�ñ��
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="seatnum"></param>
        /// <returns></returns>
        public int GetOnlyNum(string shopid, string seatnum)
        {
            return dal.GetOnlyNum(shopid,seatnum);
        }
             /// <summary>
        /// �õ���δ����POP�ĵ�����Ϣ
        /// </summary>
        /// <param name="htable"></param>
        /// <returns></returns>
        public DataTable GetExamPOP(Hashtable htable, ref int TotalNumber)
        {
            return dal.GetExamPOP(htable,ref  TotalNumber);
        }

                /// <summary>
        /// ȷ�ϵ���û��������POP
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public bool ExamShopPOP(List<string> IDlist, string userID)
        {
            return dal.ExamShopPOP(IDlist,userID);
        }
        /// <summary>
        /// ʡ��VM��˼�������POP��Ϣ
        /// </summary>
        /// <param name="ExamState"></param>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        public bool VMExamPOPState(string ExamState, string ID, string UserID)
        {
           return  dal.VMExamPOPState(ExamState, ID, UserID);
        }
        /// <summary>
        /// ����Pop��Ϣ ������״̬��Ϊ-1 ��Ϊ����
        /// </summary>
        /// <param name="ID"></param>
        public void giveupPOP(string ID,string UserID)
        {
            dal.giveupPOP(ID, UserID);
        }
		
        /// <summary>
        /// ��Ӧ�̲���ָ�����̵İ�װPOP��Ϣ�б��Ա��ϴ�ͼƬ
        /// </summary>
        /// <param name="SupplierID">��Ӧ�̱��</param>
        /// <param name="ShopName">��������</param>
        /// <param name="PosID">POS���</param>
        /// <returns>�����б���</returns>
        public DataTable GetPOPListByShopID(string SupplierID, string ShopID)
        {
            return dal.GetPOPListByShopID(SupplierID, ShopID);
        }

        /// <summary>
        /// VM����Ա���ָ�����̵İ�װPOPͼƬ��Ϣ�б�
        /// </summary>
        /// <param name="POPID">�����POP���</param>
        /// <param name="SupplierID">��Ӧ�̱��</param>
        /// <param name="ShopID">���̱��</param>
        /// <returns>�����б���</returns>
        public DataTable GetPOPJudgeListByShopID(string POPID, string SupplierID, string ShopID)
        {
            return dal.GetPOPJudgeListByShopID(POPID, SupplierID, ShopID);
        }

        /// <summary>
        /// �õ����̵�POP��ϸ��Ϣ
        /// </summary>
        /// <param name="htable"></param>
        /// <returns></returns>
        public DataTable GetShopPOPInfoList(Hashtable htable)
        {
            return dal.GetShopPOPInfoList(htable);
        }
           /// <summary>
        /// ����POP������
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pro"></param>
        public void Update_type(string id, string pro,string material)
        {
            dal.Update_type(id, pro, material);
        }
        /// <summary>
        /// �õ���������pop������
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
        /// �õ�����Ҫ���յ�����
        /// </summary>
        /// <param name="shopid"></param>
        /// <param name="Popid"></param>
        /// <returns></returns>
        public int Getsetupcount(string shopid, string Popid)
        {
            return dal.Getsetupcount(shopid, Popid);
        }

              /// <summary>
        /// �õ��¼�pop��λ�ñ��
        /// </summary>
        /// <returns></returns>
        public string Getnextseatnum(string shopid)
        {
            return dal.Getnextseatnum(shopid);
        }

        /// <summary>
        /// �ж�ָ�����̵�POP�Ƿ�ȫ�����ͨ��
        /// </summary>
        /// <param name="ShopID">���̱��</param>
        /// <returns>�Ƿ�ȫ�����</returns>
        public int IsAllExamByShopID(int ShopID)
        {
            return dal.IsAllExamByShopID(ShopID);
        }

        /// <summary>
        /// ����ָ�������POP��Ϣ
        /// </summary>
        /// <param name="imgIDList">�����ż���</param>
        /// <returns>�Ƿ����سɹ�</returns>
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


		#endregion  ��Ա����
	}
}


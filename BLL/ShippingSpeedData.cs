using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���ShippingSpeedData ��ժҪ˵����
    /// </summary>
    public class ShippingSpeedData
    {
        private readonly LN.DAL.ShippingSpeedData dal = new LN.DAL.ShippingSpeedData();
        public ShippingSpeedData()
        { }
        #region  ��Ա����

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(List<string> strSql)
        {
            return dal.Add(strSql);
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
        public LN.Model.ShippingSpeedData GetModel(int ID)
        {

            return dal.GetModel(ID);
        }



        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.ShippingSpeedData> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
 
        
        /// <summary>
        /// ����ShippingSpeedData�е�����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPDataDone(string strWhere)
        {
            return dal.GetShippingPOPDataDone(strWhere);
        }
        /// <summary>
        /// �õ��Ѿ�����pop����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPData(int SupplierID)
        {
            return dal.GetShippingPOPData(SupplierID);
        }
            /// <summary>
        /// �ջ�����
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="rdate"></param>
        /// <param name="userid"></param>
        /// <param name="fs"></param>
        /// <param name="pj"></param>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public int RecevieGoods(string POPID, string rdate, string userid, string fs, string pj, string shopid)
        {
            return dal.RecevieGoods(POPID,  rdate,  userid,  fs,  pj,  shopid);
        }

         /// <summary>
        /// ������POP�б�
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataSet GetShippingPOPDataInfo(int shopid, string popid)
        {
            return dal.GetShippingPOPDataInfo(shopid, popid);
        }

        /// <summary>
        /// һ���ͻ������Ѿ���װ�ĵ����б�
        /// </summary>
        /// <param name="DealerID">һ���ͻ����</param>
        /// <param name="FXID">ֱ���ͻ����</param>
        /// <param name="ShopID">���̱��</param>
        /// <param name="ShopName">��������</param>
        /// <param name="OrderField">�����ֶ�</param>
        /// <param name="pageSize">ÿҳ��ʾ�����б�ĸ���</param>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="TotalRecord">��������</param>
        /// <returns>�����б���</returns>
        public DataTable GetConfirmShopListByDealerID(string DealerID, string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalRecord)
        {
            return dal.GetConfirmShopListByDealerID(DealerID, FXID, ShopID, ShopName, OrderField, pageSize, pageIndex, ref TotalRecord);
        }

        /// <summary>
        /// ֱ���ͻ������Ѿ���װ�ĵ����б�
        /// </summary>
        /// <param name="FXID">ֱ���ͻ����</param>
        /// <param name="ShopID">����POS_Code���</param>
        /// <param name="ShopName">��������</param>
        /// <param name="OrderField">�����ֶ�</param>
        /// <param name="pageSize">ÿҳ��ʾ�����б�ĸ���</param>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="TotalRecord">��������</param>
        /// <returns>�����б���</returns>
        public DataTable GetConfirmShopListByFXID(string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalNumber)
        {
            return dal.GetConfirmShopListByFXID(FXID, ShopID, ShopName, OrderField, pageSize, pageIndex, ref TotalNumber);
        }
             /// <summary>
        /// �õ��շ������еĵ��̵Ļ�����Ϣ
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetSubList(string StrWhere)
        {
            return dal.GetSubList(StrWhere);
        }

           /// <summary>
        /// �õ���Ӧ�ķ�������
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetFHID(string strWhere)
        {
            return dal.GetFHID(strWhere);
        }

            /// <summary>
        /// �õ������б�
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetFHAnaysis(string strwhere, string popid, string fhtype,string beginDate,string endDate)
        {
            return dal.GetFHAnaysis(strwhere, popid, fhtype, beginDate,endDate);
        }

        /// <summary>
        /// �õ��ջ��б�
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetSHAnaysis(string strwhere)
        {
            return dal.GetSHAnaysis(strwhere);
        }
        #endregion  ��Ա����
    }
}


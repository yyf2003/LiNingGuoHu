using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���ShopInfo ��ժҪ˵����
    /// </summary>
    public class ShopInfo
    {
        private readonly LN.DAL.ShopInfo dal = new LN.DAL.ShopInfo();
        public ShopInfo()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.ShopInfo model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// ���²�������
        /// </summary>
        /// <param name="model"></param>
        public void UpdateSub(LN.Model.ShopInfo model)
        {
            dal.UpdateSub(model);
        }
        public void Update(LN.Model.EditShopInfo model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }
        /// <summary>
        /// ���̸�����ȷ�ϵ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public bool ConfirmShopInfo(int ShopID)
        {
            return dal.ConfirmShopInfo(ShopID);
        }
        /// <summary>
        /// �رյ���
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public bool CloseShopState(int ShopID, int CloseUserID)
        {
            return dal.CloseShopState(ShopID, CloseUserID);
        }
        /// <summary>
        /// �ر�/�¿� ����
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public bool ChangeShopState(int ShopID, int CloseUserID, int ShopState)
        {
            return dal.ChangeShopState(ShopID, CloseUserID, ShopState);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.ShopInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���һ���������б�
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetSublist(string StrWhere)
        {
            return dal.GetSublist(StrWhere);
        }
        /// <summary>
        /// �õ��Զ�����б�ĵ�������
        /// </summary>
        /// <param name="strShopName"></param>
        /// <returns></returns>
        public DataSet GetAutoComplateShopname(string strShopName)
        {
            return dal.GetAutoComplateShopname(strShopName);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.ShopInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.ShopInfo> modelList = new List<LN.Model.ShopInfo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.ShopInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.ShopInfo();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ShopID"].ToString() != "")
                    {
                        model.ShopID = int.Parse(ds.Tables[0].Rows[n]["ShopID"].ToString());
                    }
                    model.PosID = ds.Tables[0].Rows[n]["PosID"].ToString();
                    model.Shopname = ds.Tables[0].Rows[n]["Shopname"].ToString();
                    model.ShopAddress = ds.Tables[0].Rows[n]["ShopAddress"].ToString();
                    model.ShopOpenDate = ds.Tables[0].Rows[n]["ShopOpenDate"].ToString();
                    model.ShopCloseDate = ds.Tables[0].Rows[n]["ShopCloseDate"].ToString();
                    if (ds.Tables[0].Rows[n]["CloseUserID"].ToString() != "")
                    {
                        model.CloseUserID = int.Parse(ds.Tables[0].Rows[n]["CloseUserID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ProvinceID"].ToString() != "")
                    {
                        model.ProvinceID = int.Parse(ds.Tables[0].Rows[n]["ProvinceID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[n]["CityID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ShopLevelID"].ToString() != "")
                    {
                        model.ShopLevelID = int.Parse(ds.Tables[0].Rows[n]["ShopLevelID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SaleTypeID"].ToString() != "")
                    {
                        model.SaleTypeID = int.Parse(ds.Tables[0].Rows[n]["SaleTypeID"].ToString());
                    }
                    model.LinkMan = ds.Tables[0].Rows[n]["LinkMan"].ToString();
                    model.LinkPhone = ds.Tables[0].Rows[n]["LinkPhone"].ToString();
                    model.ShopMaster = ds.Tables[0].Rows[n]["ShopMaster"].ToString();
                    model.ShopMasterPhone = ds.Tables[0].Rows[n]["ShopMasterPhone"].ToString();
                    model.Email = ds.Tables[0].Rows[n]["Email"].ToString();
                    model.PostAddress = ds.Tables[0].Rows[n]["PostAddress"].ToString();
                    model.PostCode = ds.Tables[0].Rows[n]["PostCode"].ToString();
                    model.FaxNumber = ds.Tables[0].Rows[n]["FaxNumber"].ToString();
                    if (ds.Tables[0].Rows[n]["Boolinstall"].ToString() != "")
                    {
                        model.Boolinstall = int.Parse(ds.Tables[0].Rows[n]["Boolinstall"].ToString());
                    }
                    model.DealerID = ds.Tables[0].Rows[n]["DealerID"].ToString();
                    model.Fxid = ds.Tables[0].Rows[n]["FXID"].ToString();
                    if (ds.Tables[0].Rows[n]["ShopState"].ToString() != "")
                    {
                        model.ShopState = int.Parse(ds.Tables[0].Rows[n]["ShopState"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExamState"].ToString() != "")
                    {
                        model.ExamState = int.Parse(ds.Tables[0].Rows[n]["ExamState"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// �õ����̺�pop��Ϣ
        /// </summary>
        /// <param name="hdt"></param>
        /// <returns></returns>
        public DataTable GetShop_POP_infolist(Hashtable hdt)
        {
            return dal.GetShop_POP_infolist(hdt);
        }

        /// <summary>
        /// �õ�������Ϣ
        /// </summary>
        /// <param name="hdt"></param>
        /// <returns></returns>
        public DataTable GetShop_infolist(Hashtable hdt)
        {
            return dal.GetShop_infolist(hdt);
        }
        /// <summary>
        /// �õ� ���������б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfolist(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetInfolist(hdt, ref TotalNumber);
        }

        /// <summary>
        /// �õ� ���������б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopInfoByPOPIDAndShopID(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetShopInfoByPOPIDAndShopID(hdt, ref TotalNumber);
        }

        /// <summary>
        /// �õ������б�
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">��¼����Ŀ</param>
        /// <returns></returns>
        public DataTable GetShopPOPSetupList(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetShopPOPSetupList(hdt, ref TotalNumber);
        }

        /// <summary>
        /// �õ������б�
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">��¼����Ŀ</param>
        /// <returns></returns>
        public DataTable GetShopPOPSetupJudgeList(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetShopPOPSetupJudgeList(hdt, ref TotalNumber);
        }

        /// <summary>
        /// ���ݵ�¼����Ϣ.�õ�����ĵ���
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public DataTable GetShopInfoWithShopMaster(string User)
        {
            return dal.GetShopInfoWithShopMaster(User);
        }
        /// <summary>
        /// �������AJAX��ҳ�б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡ�����б���</returns>
        public DataTable GetShopListBySupplierID(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetShopListBySupplierID(model, out TotalNumber);
        }

        /// <summary>
        /// ��ȡ��Ӧ�̸���ĵ����б�����ҳ��������
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡ�����б���</returns>
        public DataTable GetAllShopListBySupplierID(string hidSupplierID, string strWhere)
        {
            return dal.GetAllShopListBySupplierID(hidSupplierID, strWhere);
        }

        /// <summary>
        /// ��ȡ��Ӧ�̸���ĵ����б�����ҳ������
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡ�����б���</returns>
        public DataTable GetAllShopListBySuppliersID(string hidSupplierID, string strWhere)
        {
            return dal.GetAllShopListBySuppliersID(hidSupplierID, strWhere);
        }

        /// <summary>
        /// �õ�������Ϣ���ݹ�Ӧ��ID
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetShopInfoWithSupplierID(string strWhere)
        {
            return dal.GetShopInfoWithSupplierID(strWhere);
        }

        /// <summary>
        /// ��ȡָ����ŵ�����
        /// </summary>
        /// <param name="ShopID">���̱��</param>
        /// <param name="SupplierID">��Ӧ�̱��</param>
        /// <param name="POPID">POP����ID</param>
        /// <param name="DealreID">һ���ͻ����</param>
        /// <returns>���ظ������Ƽ���</returns>
        public DataTable GetInfoByID(int ShopID, int SupplierID, string POPID, string DealreID)
        {
            return dal.GetInfoByID(ShopID, SupplierID, POPID, DealreID);
        }
        /// <summary>
        /// ���µ��̵����״̬
        /// </summary>
        /// <param name="StrWhere"></param>
        public void UpdateExamState(int examState, string UserID, string StrWhere)
        {
            dal.UpdateExamState(examState, UserID, StrWhere);
        }
        /// <summary>
        /// ʡ��VM�����������
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void VMUpdateExamState(int examState, string UserID, string StrWhere)
        {
            dal.VMUpdateExamState(examState, UserID, StrWhere);
        }
        /// <summary>
        /// ͨ��PosID�õ���Ӧ�ĵ�������
        /// </summary>
        /// <param name="PosID"></param>
        /// <returns></returns>
        public DataTable GetShopNameByPosID(string PosID)
        {
            return dal.GetShopNameByPosID(PosID);
        }

        /// <summary>
        /// �ж�ָ�������Ƿ���FOS��
        /// </summary>
        /// <param name="ShopID">���̱��</param>
        /// <returns>����1���ǣ�0����</returns>
        public int GetSaleTypeID(int ShopID)
        {
            return dal.GetSaleTypeID(ShopID);
        }
        #endregion  ��Ա����
    }
}


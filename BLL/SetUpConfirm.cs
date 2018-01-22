using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���SetUpConfirm ��ժҪ˵����
    /// </summary>
    public class SetUpConfirm
    {
        private readonly LN.DAL.SetUpConfirm dal = new LN.DAL.SetUpConfirm();
        public SetUpConfirm()
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
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.SetUpConfirm model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.SetUpConfirm model)
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
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.SetUpConfirm GetModel(int ID)
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
        /// ����ͼ�ﷵ�����ݽ��
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListFromView(string strWhere)
        {
            return dal.GetListFromView(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.SetUpConfirm> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.SetUpConfirm> modelList = new List<LN.Model.SetUpConfirm>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.SetUpConfirm model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.SetUpConfirm();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["DealerID"].ToString() != "")
                    {
                        model.DealerID = ds.Tables[0].Rows[n]["DealerID"].ToString();
                    }
                    if (ds.Tables[0].Rows[n]["Shopid"].ToString() != "")
                    {
                        model.Shopid = int.Parse(ds.Tables[0].Rows[n]["Shopid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SupplierID"].ToString() != "")
                    {
                        model.SupplierID = int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["POPID"].ToString() != "")
                    {
                        model.POPID = ds.Tables[0].Rows[n]["POPID"].ToString();
                    }
                    if (ds.Tables[0].Rows[n]["SetUpCount"].ToString() != "")
                    {
                        model.SetUpCount = int.Parse(ds.Tables[0].Rows[n]["SetUpCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SetUpState"].ToString() != "")
                    {
                        model.SetUpState = int.Parse(ds.Tables[0].Rows[n]["SetUpState"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["OperatorID"].ToString() != "")
                    {
                        model.OperatorID = int.Parse(ds.Tables[0].Rows[n]["OperatorID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Boolinstall"].ToString() != "")
                    {
                        model.Boolinstall = int.Parse(ds.Tables[0].Rows[n]["Boolinstall"].ToString());
                    }
                    model.OperatorDate = ds.Tables[0].Rows[n]["OperatorDate"].ToString();
                    model.SetUpDesc = ds.Tables[0].Rows[n]["SetUpDesc"].ToString();
                    model.PicUrl = ds.Tables[0].Rows[n]["PicUrl"].ToString();
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
        /// ���ز�ѯ�İ�װ��������
        /// </summary>
        /// <param name="SupplierID">��Ӧ��ID</param>
        /// <param name="DealerID">һ���ͻ�ID</param>
        /// <param name="AreaID">����ID</param>
        /// <param name="ProviceID">ʡ��ID</param>
        /// <param name="CityID">��ID</param>
        /// <param name="Boolinstall">�Ƿ�֧�ְ�װ  1 ֧�� 0 ����֧�֣�������װ</param>
        /// <returns></returns>
        public DataTable GetSetUpConfirmSearch(int SupplierID, string DealerID,string FXID, int AreaID, int ProviceID, int CityID,string popid,string begindate,string enddate,string department,int boolinstall)
        {
            return dal.GetSetUpConfirmSearch(SupplierID, DealerID, FXID, AreaID, ProviceID, CityID, popid,begindate, enddate, department, boolinstall);
        }
        /// <summary>
        /// ��ѯ�Ѿ���ɰ�װ������
        /// </summary>
        /// <param name="DealerID">һ���ͻ�ID</param>
        /// <param name="SupplierID">��Ӧ��ID</param>
        /// <param name="POPID">POPID</param>
        /// <param name="Boolinstall">��װ����</param>
        /// <returns></returns>
        public DataTable GetSetUpConfirmSearch2(string DealerID, int SupplierID, string POPID, int Boolinstall)
        {
            return dal.GetSetUpConfirmSearch2(DealerID, SupplierID, POPID, Boolinstall);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
    }
}


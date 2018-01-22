using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���DealerInfo ��ժҪ˵����
    /// </summary>
    public class DealerInfo
    {
        private readonly LN.DAL.DealerInfo dal = new LN.DAL.DealerInfo();
        public DealerInfo()
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
        public int Add(LN.Model.DealerInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.DealerInfo model)
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
        public LN.Model.DealerInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �ӵ��̱��г��е�IDɸѡ�õ�һ���ͻ����б�
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerInfoListBy(string CityID)
        {
            return dal.GetDealerInfoListBy(CityID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.DealerInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.DealerInfo> modelList = new List<LN.Model.DealerInfo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.DealerInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.DealerInfo();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["DealerID"].ToString() != "")
                    {
                        model.DealerID = ds.Tables[0].Rows[n]["DealerID"].ToString();
                    }
                    model.DealerName = ds.Tables[0].Rows[n]["DealerName"].ToString();
                    if (ds.Tables[0].Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(ds.Tables[0].Rows[n]["AreaID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ProvinceID"].ToString() != "")
                    {
                        model.ProvinceID = int.Parse(ds.Tables[0].Rows[n]["ProvinceID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[n]["CityID"].ToString());
                    }
                    model.Contactor = ds.Tables[0].Rows[n]["Contactor"].ToString();
                    model.ContactorPhone = ds.Tables[0].Rows[n]["ContactorPhone"].ToString();
                    model.Address = ds.Tables[0].Rows[n]["Address"].ToString();
                    model.PostAddress = ds.Tables[0].Rows[n]["PostAddress"].ToString();
                    model.DealerChannel = ds.Tables[0].Rows[n]["DealerChannel"].ToString();
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
        /// �õ�һ���ͻ����б�
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerInfoList(string StrWhere)
        {
            return dal.GetDealerInfoList(StrWhere);
        }
        /// <summary>
        /// �õ�һ���ͻ�ID��һ���ͻ�����
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerName(string StrWhere)
        {
            return dal.GetDealerName(StrWhere);
        }
        /// <summary>
        /// �õ�һ���ͻ�ID��һ���ͻ�����ͨ����¼������
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerByUserName(string StrWhere)
        {
            return dal.GetDealerByUserName(StrWhere);
        }
        /// <summary>
        /// ��ȡָ����Ӧ������Ӧ��һ���ͻ�����
        /// </summary>
        /// <param name="SupplierID">��Ӧ�̱��</param>
        /// <returns></returns>
        public DataTable GetDealerNameBySupplierID(string SupplierID)
        {
            return dal.GetDealerNameBySupplierID(SupplierID);
        }
        /// <summary>
        /// ���ž����������һ���ͻ�
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void ExamNewdealer(int examState, int UserID, string StrWhere)
        {
            dal.ExamNewdealer(examState, UserID, StrWhere);
        }
        /// <summary>
        /// ����VM�����������һ���ͻ�
        /// </summary>
        /// <param name="examstate"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void VMExamNewDealer(int examState, int UserID, string StrWhere)
        {
            dal.VMExamNewDealer(examState, UserID, StrWhere);
        }
        #endregion  ��Ա����
    }
}


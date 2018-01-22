using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���DistributorsInfo ��ժҪ˵����
    /// </summary>
    public class DistributorsInfo
    {
        private readonly LN.DAL.DistributorsInfo dal = new LN.DAL.DistributorsInfo();
        public DistributorsInfo()
        { }
        #region  ��Ա����
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
        public int Add(LN.Model.DistributorsInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.DistributorsInfo model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(string FXID)
        {
            return dal.Delete(FXID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.DistributorsInfo GetModel(string FXID)
        {

            return dal.GetModel(FXID);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.DistributorsInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.DistributorsInfo> DataTableToList(DataTable dt)
        {
            List<LN.Model.DistributorsInfo> modelList = new List<LN.Model.DistributorsInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.DistributorsInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.DistributorsInfo();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.FXID = dt.Rows[n]["FXID"].ToString();
                    model.FXName = dt.Rows[n]["FXName"].ToString();
                    model.FXContactor = dt.Rows[n]["FXContactor"].ToString();
                    model.FXPhone = dt.Rows[n]["FXPhone"].ToString();
                    model.FXtel = dt.Rows[n]["FXtel"].ToString();
                    model.DealerID = dt.Rows[n]["DealerID"].ToString();
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
        /// ���ݳ��е�id��ȡֱ���ͻ����б�
        /// </summary>
        /// <param name="CityID"></param>
        public DataTable GetFXinfolistBy(string CityID)
        {
            return dal.GetFXinfolistBy(CityID);
        }

        /// <summary>
        /// ���ݳ��е�id��ȡֱ���ͻ����б�
        /// </summary>
        /// <param name="CityID"></param>
        public DataTable GetFXinfolistsBy(string DealerID)
        {
            return dal.GetFXinfolistsBy(DealerID);
        }

        /// <summary>
        /// ���������õ�ֱ���ͻ���ID��ֱ���ͻ�����
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetIDName(string strWhere)
        {
            return dal.GetIDName(strWhere);
        }

        /// <summary>
        /// ��ȡָ���û��Ƿ���ֱ���ͻ�
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <returns>����ֱ���ͻ����</returns>
        public string GetFXIdByUserID(string UserID)
        {
            return dal.GetFXIdByUserID(UserID);
        }

        /// <summary>
        /// �������AJAX��ҳ�б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡֱ���ͻ��б���</returns>
        public DataTable GetListPageByWhere(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetListPageByWhere(model, out TotalNumber);
        }
        /// <summary>
        /// ����FXID�õ�һ��ֱ���ͻ�����ϸ��Ϣ
        /// </summary>
        /// <param name="FXID"></param>
        /// <returns></returns>
        public DataTable GetOneFX(string FXID)
        {
            return dal.GetOneFX(FXID);
        }

        /// <summary>
        ///  �õ�Ҫ������ֱ���ͻ�
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetFXinfolist(string strwhere)
        {
            return dal.GetFXinfolist(strwhere);
        }
        /// <summary>
        /// ���ž������ֱ���ͻ�����������һ���ͻ�
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="userID"></param>
        /// <param name="Strwhere"></param>
        public void ExamFXofDealer(string examState, string userID, string Strwhere)
        {
            dal.ExamFXofDealer(examState, userID, Strwhere);
        }
        /// <summary>
        /// ʡ��VM���ֱ���ͻ�����������һ���ͻ�
        /// </summary>
        /// <param name="VMexamState"></param>
        /// <param name="UserID"></param>
        /// <param name="Strwhere"></param>
        public void VMExamFXofDealer(string VMexamState, string UserID, string Strwhere)
        {
            dal.VMExamFXofDealer(VMexamState, UserID, Strwhere);
        }
        #endregion  ��Ա����
    }
}


using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���POPReprotDamage ��ժҪ˵����
    /// </summary>
    public class POPReprotDamage
    {
        private readonly LN.DAL.POPReprotDamage dal = new LN.DAL.POPReprotDamage();
        public POPReprotDamage()
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
        public int Add(LN.Model.POPReprotDamage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.POPReprotDamage model)
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
        /// VM��鱨��
        /// </summary>
        /// <param name="UserID">VM UserID</param>
        /// <param name="VMDesc">����</param>
        /// <param name="date">�������</param>
        public void VMCheckReprotDamage(int UserID, string VMDesc, string date, int ID)
        {
            dal.VMCheckReprotDamage(UserID, VMDesc, date, ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.POPReprotDamage GetModel(int ID)
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
        /// ��������б�
        /// </summary>
        public List<LN.Model.POPReprotDamage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.POPReprotDamage> modelList = new List<LN.Model.POPReprotDamage>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.POPReprotDamage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.POPReprotDamage();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ShopID"].ToString() != "")
                    {
                        model.ShopID = int.Parse(ds.Tables[0].Rows[n]["ShopID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SupplierID"].ToString() != "")
                    {
                        model.SupplierID = int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UpUserID"].ToString() != "")
                    {
                        model.UpUserID = int.Parse(ds.Tables[0].Rows[n]["UpUserID"].ToString());
                    }
                    model.UpPOPDate = ds.Tables[0].Rows[n]["UpPOPDate"].ToString();
                    model.PhotoPath = ds.Tables[0].Rows[n]["PhotoPath"].ToString();
                    model.ShopDesc = ds.Tables[0].Rows[n]["ShopDesc"].ToString();
                    if (ds.Tables[0].Rows[n]["DSRState"].ToString() != "")
                    {
                        model.DSRState = int.Parse(ds.Tables[0].Rows[n]["DSRState"].ToString());
                    }
                    model.DSRDesc = ds.Tables[0].Rows[n]["DSRDesc"].ToString();

                    model.DSRDate = ds.Tables[0].Rows[n]["DSRDate"].ToString();

                    if (ds.Tables[0].Rows[n]["VMState"].ToString() != "")
                    {
                        model.VMState = int.Parse(ds.Tables[0].Rows[n]["VMState"].ToString());
                    }
                    model.VMDate = ds.Tables[0].Rows[n]["VMDate"].ToString();
                    model.VMDesc = ds.Tables[0].Rows[n]["VMDesc"].ToString();
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
        /// �õ�POP��������
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetPopReportDamageData(string strWhere)
        {
            return dal.GetPopReportDamageData(strWhere);
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


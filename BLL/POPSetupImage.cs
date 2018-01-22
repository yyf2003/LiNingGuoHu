using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���POPSetupImage ��ժҪ˵����
    /// </summary>
    public class POPSetupImage
    {
        private readonly LN.DAL.POPSetupImage dal = new LN.DAL.POPSetupImage();
        public POPSetupImage()
        { }
        #region  ��Ա����

        /// <summary>
        /// �������ݣ����ӣ��޸ģ�
        /// </summary>
        public int Operate(List<string> strSql)
        {
            return dal.Operate(strSql);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.POPSetupImage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(LN.Model.POPSetupImage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int i_Id)
        {

            dal.Delete(i_Id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.POPSetupImage GetModel(int i_ShopId, int i_SupplierID, string i_POPID)
        {

            return dal.GetModel(i_ShopId, i_SupplierID, i_POPID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
       
        #endregion  ��Ա����
    }
}


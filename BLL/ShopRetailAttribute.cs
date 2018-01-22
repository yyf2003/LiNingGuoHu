using System;
using System.Collections.Generic;
using System.Text;

namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���ShopVI ��ժҪ˵����
    /// </summary>
    public class ShopRetailAttribute
    {
        private readonly LN.DAL.ShopRetailAttribute dal = new LN.DAL.ShopRetailAttribute();

        public ShopRetailAttribute(){}

        #region  ��Ա����

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.ShopRetailAttribute GetModel(int SA_Id)
        {
            return dal.GetModel(SA_Id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.ShopRetailAttribute> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public List<LN.Model.ShopRetailAttribute> GetList(int TopNum, string strWhere, string filedOrder)
        {
            return dal.GetList(TopNum, strWhere, filedOrder);
        }

        #endregion
    }
}

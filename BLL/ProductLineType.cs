using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���ProductLineType ��ժҪ˵����
    /// </summary>
    public class ProductLineType
    {
        private readonly LN.DAL.ProductLineType dal = new LN.DAL.ProductLineType();
        public ProductLineType()
        { }
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(string typeName, int isDelete)
        {
            return dal.Add(typeName,isDelete);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.ProductLineType model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ProductTypeID)
        {

            dal.Delete(ProductTypeID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.ProductLineType GetModel(int ProductTypeID)
        {

            return dal.GetModel(ProductTypeID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.ProductLineType> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion  ��Ա����
    }
}


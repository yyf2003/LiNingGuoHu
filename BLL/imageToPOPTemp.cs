using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���imageToPOPTemp ��ժҪ˵����
    /// </summary>
    public class imageToPOPTemp
    {
        private readonly LN.DAL.imageToPOPTemp dal = new LN.DAL.imageToPOPTemp();
        public imageToPOPTemp()
        { }
        #region  ��Ա����

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.imageToPOPTemp model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string str)
        {

            dal.Delete(str);
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
        /// �жϵ���POP�Ƿ�ȫ���ύ����
        /// </summary>
        /// <param name="POPID">ָ��POP������</param>
        /// <param name="ShopID">���̱��</param>
        /// <returns>�����Ƿ�ȫ���ύ����</returns>
        public int POPUniformSubmit(string ShopID)
        {
            return dal.POPUniformSubmit(ShopID);
        }


        #endregion  ��Ա����
    }
}


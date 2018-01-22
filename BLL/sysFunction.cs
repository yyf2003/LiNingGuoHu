using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���sysFunction ��ժҪ˵����
    /// </summary>
    public class sysFunction
    {
        private readonly LN.DAL.sysFunction dal = new LN.DAL.sysFunction();

        public sysFunction()
        { }
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.sysFunction model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.sysFunction model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// ��ȡ�ϼ����ܱ��
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns>���ر�ż���</returns>
        public IList<int> GetupIdGroup(string strWhere)
        {
            return dal.GetupIdGroup(strWhere);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.sysFunction GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.sysFunction> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
       
        #endregion  ��Ա����
    }
}


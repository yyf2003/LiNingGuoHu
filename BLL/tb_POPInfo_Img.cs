using System;
using System.Data;
using System.Collections.Generic;

namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���tb_POPInfo_Img ��ժҪ˵����
    /// </summary>
    public class tb_POPInfo_Img
    {
        private readonly LN.DAL.tb_POPInfo_Img dal = new LN.DAL.tb_POPInfo_Img();
        public tb_POPInfo_Img()
        { }
        #region  ��Ա����

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.tb_POPInfo_Img model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// �ж�ָ��POP�Ƿ��ϴ�ͼƬ
        /// </summary>
        /// <param name="POPInfoID">ָ��POP���</param>
        /// <returns>�����Ƿ��ϴ�ͼƬ</returns>
        public int IsExistByPOPInfoID(int POPInfoID)
        {
            return dal.IsExistByPOPInfoID(POPInfoID);
        }

        /// <summary>
        /// ����ָ��������ȡ���ͼƬ��Ϣ
        /// </summary>
        /// <param name="strWhere">��������</param>
        /// <returns>���ػ�ȡ���ͼƬ��Ϣ</returns>
        public IList<LN.Model.tb_POPInfo_Img> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace LN.BLL
{
    public class UpLoadEffectImg
    {
        private readonly LN.DAL.UpLoadEffectImg dal = new LN.DAL.UpLoadEffectImg();
        public UpLoadEffectImg(){}

        #region  ��Ա����

        /// <summary>
        /// ������������
        /// </summary>
        public int Operate(List<string> strSql)
        {
            return dal.Operate(strSql);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.UpLoadEffectImg> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable GetListName(string strWhere)
        {
            return dal.GetListName(strWhere);
        }



        #endregion
    }
}

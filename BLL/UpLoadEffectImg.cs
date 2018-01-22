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

        #region  成员方法

        /// <summary>
        /// 批量操作数据
        /// </summary>
        public int Operate(List<string> strSql)
        {
            return dal.Operate(strSql);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.UpLoadEffectImg> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListName(string strWhere)
        {
            return dal.GetListName(strWhere);
        }



        #endregion
    }
}

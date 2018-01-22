using System;
using System.Data;
using System.Collections.Generic;

namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类tb_POPInfo_Img 的摘要说明。
    /// </summary>
    public class tb_POPInfo_Img
    {
        private readonly LN.DAL.tb_POPInfo_Img dal = new LN.DAL.tb_POPInfo_Img();
        public tb_POPInfo_Img()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.tb_POPInfo_Img model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 判断指定POP是否上传图片
        /// </summary>
        /// <param name="POPInfoID">指定POP编号</param>
        /// <returns>返回是否上传图片</returns>
        public int IsExistByPOPInfoID(int POPInfoID)
        {
            return dal.IsExistByPOPInfoID(POPInfoID);
        }

        /// <summary>
        /// 根据指定条件获取相关图片信息
        /// </summary>
        /// <param name="strWhere">搜索条件</param>
        /// <returns>返回获取相关图片信息</returns>
        public IList<LN.Model.tb_POPInfo_Img> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion
    }
}

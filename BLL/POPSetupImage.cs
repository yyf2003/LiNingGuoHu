using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类POPSetupImage 的摘要说明。
    /// </summary>
    public class POPSetupImage
    {
        private readonly LN.DAL.POPSetupImage dal = new LN.DAL.POPSetupImage();
        public POPSetupImage()
        { }
        #region  成员方法

        /// <summary>
        /// 操作数据（增加，修改）
        /// </summary>
        public int Operate(List<string> strSql)
        {
            return dal.Operate(strSql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.POPSetupImage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(LN.Model.POPSetupImage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int i_Id)
        {

            dal.Delete(i_Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.POPSetupImage GetModel(int i_ShopId, int i_SupplierID, string i_POPID)
        {

            return dal.GetModel(i_ShopId, i_SupplierID, i_POPID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
       
        #endregion  成员方法
    }
}


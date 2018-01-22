using System;

namespace LN.Model
{
    /// <summary>
    /// 实体类SupplierUserManage 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SupplierUserManage
    {
        private int _id;
        private int _supplierid;
        private int _userid;
        private int _typeid;

        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 权限  --  2：供应商管理员 ,   1：供应商(可修改) ,  0：供应商(可查看)
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
    }
}

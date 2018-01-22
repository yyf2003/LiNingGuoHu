using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    public class PageModel
    {
        /// <summary>
        /// 构造器
        /// </summary>
        public PageModel() { }

        private string _selectsql;
        private string _orderfield;
        private int _pagesize;
        private int _pageindex;
        private int _totalrecord;

        /// <summary>
        /// 查询数据库SQL语句
        /// </summary>
        public string SelectSql
        {
            set { _selectsql = value; }
            get { return _selectsql; }
        }

        /// <summary>
        /// 排序字段(必须!支持多字段)
        /// </summary>
        public string OrderField
        {
            set { _orderfield = value; }
            get { return _orderfield; }
        }

        /// <summary>
        /// 每页多少条记录
        /// </summary>
        public int pageSize
        {
            set { _pagesize = value; }
            get { return _pagesize; }
        }

        /// <summary>
        /// 指定当前为第几页
        /// </summary>
        public int pageIndex
        {
            set { _pageindex = value; }
            get { return _pageindex; }
        }

        /// <summary>
        /// 返回总记录数
        /// </summary>
        public int TotalRecord
        {
            set { _totalrecord = value; }
            get { return _totalrecord; }
        }
    }
}

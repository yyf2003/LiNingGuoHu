using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    public class PageModel
    {
        /// <summary>
        /// ������
        /// </summary>
        public PageModel() { }

        private string _selectsql;
        private string _orderfield;
        private int _pagesize;
        private int _pageindex;
        private int _totalrecord;

        /// <summary>
        /// ��ѯ���ݿ�SQL���
        /// </summary>
        public string SelectSql
        {
            set { _selectsql = value; }
            get { return _selectsql; }
        }

        /// <summary>
        /// �����ֶ�(����!֧�ֶ��ֶ�)
        /// </summary>
        public string OrderField
        {
            set { _orderfield = value; }
            get { return _orderfield; }
        }

        /// <summary>
        /// ÿҳ��������¼
        /// </summary>
        public int pageSize
        {
            set { _pagesize = value; }
            get { return _pagesize; }
        }

        /// <summary>
        /// ָ����ǰΪ�ڼ�ҳ
        /// </summary>
        public int pageIndex
        {
            set { _pageindex = value; }
            get { return _pageindex; }
        }

        /// <summary>
        /// �����ܼ�¼��
        /// </summary>
        public int TotalRecord
        {
            set { _totalrecord = value; }
            get { return _totalrecord; }
        }
    }
}

using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    public class Base_set
    {
        public Base_set()
        {
        }
        /// <summary>
        /// 得到相应设置的数值
        /// </summary>
        /// <param name="Base_type"></param>
        /// <returns></returns>
        public int GetBase_value(string Base_type)
        {
            string sqlstr = "select Base_value  from Base_set where Base_type='"+Base_type+"'";

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sqlstr);

            if (obj == null)
            {
                return 0;
            }
            else
            {
                return (int)obj;
            }
        }
        /// <summary>
        /// 更新相应的设置
        /// </summary>
        /// <param name="base_value"></param>
        /// <param name="Base_type"></param>
        public void update_base(int base_value,string Base_username, string Base_type)
        {
            string sqlstr = "udpate Base_type set Base_value=" + base_value + ",Base_username='"+Base_username+"',Base_time=getdate() where Base_type='"+Base_type+"'";

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sqlstr);
        }
    }
}

using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    public class Base_set
    {
        public Base_set()
        {
        }
        /// <summary>
        /// �õ���Ӧ���õ���ֵ
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
        /// ������Ӧ������
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

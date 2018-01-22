using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用

namespace LN.DAL
{
    public class UserInAreaDAL
    {
        public int Add(LN.Model.UserInArea model)
        {
            string sql = "insert into UserInArea(UserId,AreaId) values(@UserId,@AreaId);select @@identity";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@UserId",model.UserId),
               new SqlParameter("@AreaId",model.AreaId)
            };
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), sql, paras);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public void DeleteByUserId(int userId)
        {
            string sql = "delete from UserInArea where UserId=@UserId";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@UserId",userId)
            };
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql, paras);
        }

        public DataSet GetList(int userId)
        {
            string sql = "select * from UserInArea where UserId=@UserId";
            SqlParameter[] paras = new SqlParameter[] { 
               new SqlParameter("@UserId",userId)
            };
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql, paras);
        }

        /// <summary>
        /// 根据登录人的ID得到这个人属于哪个省区
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetAreaByUserId(string userid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("select * from areadata where areaid in (select AreaId from UserInArea where userid={0})", userid));

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
    }
}

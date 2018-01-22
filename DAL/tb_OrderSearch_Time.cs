using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//请先添加引用
namespace LN.DAL
{
    /// <summary>
    /// 数据访问类tb_OrderSearch_Time。
    /// </summary>
    public class tb_OrderSearch_Time
    {
        public tb_OrderSearch_Time() { }

        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.tb_OrderSearch_Time model)
        {
            int _return = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tb_OrderSearch_Time(");
            strSql.Append("TIME_POPID,TIME_SearchTime,TIME_USERID)");
            strSql.Append(" VALUES (");
            strSql.Append("@TIME_POPID,@TIME_SearchTime,@TIME_USERID)");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TIME_POPID", SqlDbType.NVarChar,100),
					new SqlParameter("@TIME_SearchTime", SqlDbType.DateTime),
                    new SqlParameter("@TIME_USERID", SqlDbType.Int,4)};
            parameters[0].Value = model.TIME_POPID;
            parameters[1].Value = model.TIME_SearchTime;
            parameters[2].Value = model.TIME_USERID;

            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;
        }

        /// <summary>
        /// 根据POPID获取最后下载订单的时间
        /// </summary>
        /// <param name="POPID">制定POPID</param>
        /// <returns>返回时间</returns>
        public string GetOrderSearchByPOPID(string POPID,int UserID)
        {
            string _return = String.Empty;
            SqlParameter[] parameters = {
					new SqlParameter("@POPID", SqlDbType.NVarChar,100),
                    new SqlParameter("@USERID", SqlDbType.Int,4)};
            parameters[0].Value = POPID;
            parameters[1].Value = UserID;

            SqlDataReader reader = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "SP_GetOrderSearchTime", parameters);
            if (reader.Read())
            {
                //_return = reader.GetString(0).Trim();
                _return = reader[0].ToString().Trim();
            }
            reader.Close();

            return _return;
        }

        #endregion
    }
}

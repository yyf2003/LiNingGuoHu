using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    /// <summary>
    /// ���ݷ�����tb_OrderSearch_Time��
    /// </summary>
    public class tb_OrderSearch_Time
    {
        public tb_OrderSearch_Time() { }

        #region  ��Ա����

        /// <summary>
        /// ����һ������
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
        /// ����POPID��ȡ������ض�����ʱ��
        /// </summary>
        /// <param name="POPID">�ƶ�POPID</param>
        /// <returns>����ʱ��</returns>
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

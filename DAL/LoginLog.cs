using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    /// <summary>
    /// ���ݷ�����LoginLog��
    /// </summary>
    public class LoginLog
    {
        public LoginLog()
        { }
        #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LoginLog");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.LoginLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LoginLog(");
            strSql.Append("LoginUserID,LoginIP,Result)");
            strSql.Append(" values (");
            strSql.Append("@LoginUserID,@LoginIP,@Result)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginUserID", SqlDbType.NChar,20),
					new SqlParameter("@LoginIP", SqlDbType.NChar,20),
					new SqlParameter("@Result", SqlDbType.NChar,20), 
            };
            parameters[0].Value = model.LoginUserID;
            parameters[1].Value = model.LoginIP;
            parameters[2].Value = model.Result;
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.LoginLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LoginLog set ");
            strSql.Append("LoginUserID=@LoginUserID,");
            strSql.Append("LoginTime=@LoginTime,");
            strSql.Append("LoginIP=@LoginIP,");
            strSql.Append("Result=@Result");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@LoginUserID", SqlDbType.NChar,20),
					new SqlParameter("@LoginTime", SqlDbType.DateTime),
					new SqlParameter("@LoginIP", SqlDbType.NChar,20),
					new SqlParameter("@Result", SqlDbType.NChar,20),
            
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LoginUserID;
            parameters[2].Value = model.LoginTime;
            parameters[3].Value = model.LoginIP;
            parameters[4].Value = model.Result;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LoginLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.LoginLog GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,LoginUserID,LoginTime,LoginIP,Result from LoginLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.LoginLog model = new LN.Model.LoginLog();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.LoginUserID = ds.Tables[0].Rows[0]["LoginUserID"].ToString();
                model.LoginTime = ds.Tables[0].Rows[0]["LoginTime"].ToString();
                model.LoginIP = ds.Tables[0].Rows[0]["LoginIP"].ToString();
                model.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,LoginUserID,LoginTime,LoginIP,Result ");
            strSql.Append(" FROM LoginLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }
        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "LoginLog";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����
    }
}


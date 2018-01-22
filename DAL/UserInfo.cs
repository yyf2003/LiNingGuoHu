using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LN.DBUtility;//�����������
namespace LN.DAL
{
    /// <summary>
    /// ���ݷ�����UserInfo��
    /// </summary>
    public class UserInfo
    {
        public UserInfo()
        { }
        #region  ��Ա����

        /// <summary>
        /// ��ʼ���û�����Ϊ000000
        /// </summary>
        /// <param name="username">����ID</param>
        /// <returns>�ɹ�/ʧ��</returns>
        public int UpdateUserInfoPwd(string ShopID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set UserPassword='000000' where username=(select posid from ShopInfo where shopid=@ShopID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopID", SqlDbType.Int,4)};
            parameters[0].Value = ShopID;
            return DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }
        /// <summary>
        /// �ж��û��Ƿ����
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool ExistsWithUserName(string UserName,int? userId=null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where Username=@Username and UserState=1");
            if (userId != null && userId > 0)
            {
                strSql.AppendFormat(" and ID !={0}", userId);
            }
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar ,20)};
            parameters[0].Value = UserName;
            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// �ж��û��Ƿ��¼�ɹ�
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public bool ExistsUser(string User, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where Username=@Username and UserPassword =@UserPassword and UserState=1");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar ,20),
					new SqlParameter("@UserPassword", SqlDbType.VarChar ,18) 
            };
            parameters[0].Value = User;
            parameters[1].Value = Pwd;
            return DbHelperSQL.Exists(DbHelperSQL.connectionString(), strSql.ToString(), parameters);

        }

        /// <summary>
        /// ��֤�û���¼
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        public int CheckUserLogin(string UserName, string UserPwd)
        {
            int _return = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar  ,100),
					new SqlParameter("@UserPwd", SqlDbType.VarChar,50) 
            };
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;

            object obj = DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "sp_User_Login", parameters, out _return);
            if (obj != null)
                _return = Convert.ToInt32(obj);

            return _return;

        }
        /// <summary>
        /// �����û�����ѯ�û�����
        /// </summary>
        /// <param name="UserName">�û���/��¼��</param>
        /// <returns>�û�����</returns>
        public LN.Model.UserInfo CheckUserLogin(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from UserInfo where UserName=@UserName");
            SqlParameter[] parameters = { new SqlParameter("@UserName", UserName) };
            SqlDataReader dr = DbHelperSQL.ExecuteReader(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            LN.Model.UserInfo u = null;
            if (dr.Read())
            {
                u = new LN.Model.UserInfo();
                u.ID = Convert.ToInt32(dr["ID"]);
                u.UserID = Convert.ToInt32(dr["UserID"]);
                u.Username = dr["Username"].ToString();
                u.UserPassword = dr["UserPassword"].ToString();
                u.UserState = Convert.ToInt32(dr["UserState"]);
                u.Userofarea = Convert.ToInt32(dr["Userofarea"]);
            }
            dr.Close();
            dr.Dispose();
            return u;
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("Username,Sex,Usertype,UserPassword,UserEmail,UserAddress,UserPhone,UserMobel,UserState,UserDesc,userofarea)");
            strSql.Append(" values (");
            strSql.Append("@Username,@Sex,@Usertype,@UserPassword,@UserEmail,@UserAddress,@UserPhone,@UserMobel,@UserState,@UserDesc,@userofarea)");
            strSql.Append("update [UserInfo] set userid =id where id=@@IDENTITY");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@Usertype", SqlDbType.VarChar,10),
					new SqlParameter("@UserPassword", SqlDbType.VarChar,18),
					new SqlParameter("@UserEmail", SqlDbType.VarChar,50),
					new SqlParameter("@UserAddress", SqlDbType.VarChar,200),
					new SqlParameter("@UserPhone", SqlDbType.VarChar,50),
					new SqlParameter("@UserMobel", SqlDbType.VarChar,20),
					new SqlParameter("@UserState", SqlDbType.Int,4),
					new SqlParameter("@UserDesc", SqlDbType.VarChar,500),
                    new SqlParameter("@userofarea",SqlDbType.Int,4)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.Sex;
            parameters[2].Value = model.Usertype;
            parameters[3].Value = model.UserPassword;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.UserAddress;
            parameters[6].Value = model.UserPhone;
            parameters[7].Value = model.UserMobel;
            parameters[8].Value = model.UserState;
            parameters[9].Value = model.UserDesc;
            parameters[10].Value = model.Userofarea;
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// ��ӹ�Ӧ����Ա
        /// </summary>
        /// <param name="model">��Աʵ��</param>
        /// <param name="SupplierID">������Ӧ��</param>
        /// <param name="UserType">Ȩ�ޣ����޸Ļ�ֻ��ѯ��</param>
        /// <returns></returns>
        public int AddSupplierUser(LN.Model.UserInfo model, int SupplierID, int UserType)
        {
            int _return = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@SupplierID", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@Usertype", SqlDbType.Int,4),
					new SqlParameter("@UserPassword", SqlDbType.VarChar,18),
					new SqlParameter("@UserEmail", SqlDbType.VarChar,50),
					new SqlParameter("@UserAddress", SqlDbType.VarChar,200),
					new SqlParameter("@UserPhone", SqlDbType.VarChar,50),
					new SqlParameter("@UserMobel", SqlDbType.VarChar,20),
					new SqlParameter("@UserState", SqlDbType.Int,4),
					new SqlParameter("@UserDesc", SqlDbType.VarChar,500)};
            parameters[0].Value = SupplierID;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.Sex;
            parameters[3].Value = UserType;
            parameters[4].Value = model.UserPassword;
            parameters[5].Value = model.UserEmail;
            parameters[6].Value = model.UserAddress;
            parameters[7].Value = model.UserPhone;
            parameters[8].Value = model.UserMobel;
            parameters[9].Value = model.UserState;
            parameters[10].Value = model.UserDesc;

            DbHelperSQL.RunProcedure(DbHelperSQL.connectionString(), "UP_SupplierUser_ADD", parameters, out _return);

            return _return;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Username=@Username,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Usertype=@Usertype,");
            strSql.Append("UserPassword=@UserPassword,");
            strSql.Append("UserEmail=@UserEmail,");
            strSql.Append("UserAddress=@UserAddress,");
            strSql.Append("UserPhone=@UserPhone,");
            strSql.Append("UserMobel=@UserMobel,");
            strSql.Append("UserState=@UserState,");
            strSql.Append("UserDesc=@UserDesc,");
            strSql.Append("Userofarea=@Userofarea");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.VarChar,20),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@Usertype", SqlDbType.VarChar,10),
					new SqlParameter("@UserPassword", SqlDbType.VarChar,18),
					new SqlParameter("@UserEmail", SqlDbType.VarChar,50),
					new SqlParameter("@UserAddress", SqlDbType.VarChar,200),
					new SqlParameter("@UserPhone", SqlDbType.VarChar,50),
					new SqlParameter("@UserMobel", SqlDbType.VarChar,20),
					new SqlParameter("@UserState", SqlDbType.Int,4),
					new SqlParameter("@UserDesc", SqlDbType.VarChar,500),
                    new SqlParameter("@Userofarea",SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Username;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Usertype;
            parameters[5].Value = model.UserPassword;
            parameters[6].Value = model.UserEmail;
            parameters[7].Value = model.UserAddress;
            parameters[8].Value = model.UserPhone;
            parameters[9].Value = model.UserMobel;
            parameters[10].Value = model.UserState;
            parameters[11].Value = model.UserDesc;
            parameters[12].Value = model.Userofarea;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        public void NewUpdate(LN.Model.UserInfo model)
        {
            if (model != null && model.ID != null)
            {
                StringBuilder sql = new StringBuilder();
                List<SqlParameter> paraList = new List<SqlParameter>();
                sql.Append("update UserInfo set ");
                if (model.Sex != null)
                {
                    sql.Append(" Sex=@Sex,");
                    paraList.Add(new SqlParameter("@Sex", model.Sex));
                }
                if (model.UserAddress != null)
                {
                    sql.Append(" UserAddress=@UserAddress,");
                    paraList.Add(new SqlParameter("@UserAddress", model.UserAddress));
                }
                if (model.UserDesc != null)
                {
                    sql.Append(" UserDesc=@UserDesc,");
                    paraList.Add(new SqlParameter("@UserDesc", model.UserDesc));
                }
                if (model.UserEmail != null)
                {
                    sql.Append(" UserEmail=@UserEmail,");
                    paraList.Add(new SqlParameter("@UserEmail", model.UserEmail));
                }
                if (model.UserMobel != null)
                {
                    sql.Append(" UserMobel=@UserMobel,");
                    paraList.Add(new SqlParameter("@UserMobel", model.UserMobel));
                }
                if (model.Username != null)
                {
                    sql.Append(" Username=@Username,");
                    paraList.Add(new SqlParameter("@Username", model.Username));
                }
                if (model.Userofarea != null)
                {
                    sql.Append(" Userofarea=@Userofarea,");
                    paraList.Add(new SqlParameter("@Userofarea", model.Userofarea));
                }
                if (model.UserPassword != null)
                {
                    sql.Append(" UserPassword=@UserPassword,");
                    paraList.Add(new SqlParameter("@UserPassword", model.UserPassword));
                }
                if (model.UserPhone != null)
                {
                    sql.Append(" UserPhone=@UserPhone,");
                    paraList.Add(new SqlParameter("@UserPhone", model.UserPhone));
                }
                if (model.UserState != null)
                {
                    sql.Append(" UserState=@UserState,");
                    paraList.Add(new SqlParameter("@UserState", model.UserState));
                }
                if (model.Usertype != null)
                {
                    sql.Append(" Usertype=@Usertype,");
                    paraList.Add(new SqlParameter("@Usertype", model.Usertype));
                }
                string sql1 = sql.ToString().TrimEnd(',');
                sql1 += " where ID=@ID";
                paraList.Add(new SqlParameter("@ID", model.ID));
                DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), sql1, paraList.ToArray());
            }
        }


        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete UserInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        public void Delete(string where)
        {
            if (!string.IsNullOrWhiteSpace(where))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete UserInfo ");
                strSql.Append(" where " + where);
                
                DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString());
            }
            
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Pwd"></param>
        public void ChangeUserPwd(int UserID, string Pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo ");
            strSql.Append("set  UserPassword ='" + Pwd + "' ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ְһ��Ա��
        /// </summary>
        /// <param name="UserID"></param>
        public void RehabOneUser(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo ");
            strSql.Append("set  UserState =1 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }

        /// <summary>
        /// �����û�����ְ״̬
        /// </summary>
        /// <param name="ID">Ҫ��������ԱID</param>
        public void SetUserState(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" declare @station int  ");
            strSql.Append("  set @station=(select UserState from Userinfo where ID =@ID) ");
            strSql.Append("   if(@station =1)  ");
            strSql.Append("   update Userinfo set UserState =0 where ID =@ID  ");
            strSql.Append(" else   ");
            strSql.Append(" update Userinfo set UserState =1 where ID =@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.UserInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,Username,Sex,Usertype,UserPassword,UserEmail,UserAddress,UserPhone,UserMobel,UserState,UserDesc,userofarea from UserInfo ");
            strSql.Append(" where userID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            LN.Model.UserInfo model = new LN.Model.UserInfo();
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Usertype = ds.Tables[0].Rows[0]["Usertype"].ToString();
                model.UserPassword = ds.Tables[0].Rows[0]["UserPassword"].ToString();
                model.UserEmail = ds.Tables[0].Rows[0]["UserEmail"].ToString();
                model.UserAddress = ds.Tables[0].Rows[0]["UserAddress"].ToString();
                model.UserPhone = ds.Tables[0].Rows[0]["UserPhone"].ToString();
                model.UserMobel = ds.Tables[0].Rows[0]["UserMobel"].ToString();
                if (ds.Tables[0].Rows[0]["UserState"].ToString() != "")
                {
                    model.UserState = int.Parse(ds.Tables[0].Rows[0]["UserState"].ToString());
                }
                model.UserDesc = ds.Tables[0].Rows[0]["UserDesc"].ToString();
                if (ds.Tables[0].Rows[0]["userofarea"].ToString() != "")
                {
                    model.Userofarea = int.Parse(ds.Tables[0].Rows[0]["userofarea"].ToString());
                }
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
            strSql.Append("select ID,UserID,Username,Sex,Usertype,UserPassword,UserEmail,UserAddress,UserPhone,UserMobel,UserState,UserDesc,userofarea ");
            strSql.Append(" FROM UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), strSql.ToString());
        }

        /// <summary>
        /// ָ����Ӧ�̵���Ա�б�AJAX��ҳ�б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <param name="model">����Դ����</param>
        /// <returns>����ָ����Ӧ�̵���Ա�б�</returns>
        public DataTable GetSupplierUserByWhere(LN.Model.PageModel model, out int TotalNumber)
        {
            DataTable dt = GetTableListSqlExec.GetList(model, out TotalNumber);
            if (dt != null)
                return dt;
            else
                return null;

        }
        /// <summary>
        /// �����û����͵õ��û���
        /// </summary>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public DataTable GetNameByType(string usertype)
        {
            string sqlstr = "select userid,username,UserTypeData.Usertype from userinfo,UserTypeData where userinfo.Usertype=UserTypeData.UsertypeID and UserTypeData.Usertype='" + usertype + "'";
            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sqlstr);
            DataTable dt = ds.Tables[0];
            return dt;

        }
        /// <summary>
        /// ���ݵ�¼�˵��������жϵ�¼�˵Ľ�ɫ
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetTypeByName(string username)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select top 1 UserTypeData.Usertype from userinfo,UserTypeData where userinfo.Usertype=UserTypeData.UsertypeID ");
            if (username.Length > 0)
            {
                str.Append(" and username='");
                str.Append(username + "'");
            }
            object obj = DbHelperSQL.GetSingle(DbHelperSQL.connectionString(), str.ToString());
            return obj.ToString();
        }
        /// <summary>
        /// ���ݵ�¼�˵�ID�õ�����������ĸ�ʡ��
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetAreaByUserId(string userid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("select * from areadata where areaid = (select userofarea from userinfo where userid={0})", userid));

            DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

            return ds.Tables[0];
        }
        #endregion  ��Ա����
    }
}


using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// ҵ���߼���UserInfo ��ժҪ˵����
    /// </summary>
    public class UserInfo
    {
        private readonly LN.DAL.UserInfo dal = new LN.DAL.UserInfo();
        public UserInfo()
        { }
        #region  ��Ա����

        /// <summary>
        /// ��ʼ���û�����Ϊ000000
        /// </summary>
        /// <param name="username">����ID</param>
        /// <returns>�ɹ�/ʧ��</returns>
        public bool UpdateUserInfoPwd(string ShopID)
        {
            if (dal.UpdateUserInfoPwd(ShopID) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// �ж��û��Ƿ��¼�ɹ�
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public bool ExistsUser(string User, string Pwd)
        {
            return dal.ExistsUser(User, Pwd);
        }
        /// <summary>
        /// �ж��û��Ƿ����
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool ExistsWithUserName(string UserName,int? userId=null)
        {
            return dal.ExistsWithUserName(UserName, userId);
        }
        /// <summary>
        /// ��֤�û���¼
        /// </summary>
        /// <param name="UserName">��½������û���</param>
        /// <param name="UserPwd">��½���������</param>
        /// <returns>���ص�½״̬</returns>
        public string CheckUserLogin(string UserName, string UserPwd, ref int UserID)
        {
            string _return = String.Empty;
            int LoginState = dal.CheckUserLogin(UserName, UserPwd);

            switch (LoginState)
            {
                case 0:
                    _return = "��½ʧ��---�û����������";
                    UserID = 0;
                    break;
                case -1:
                    _return = "��½ʧ��---��û�е�½Ȩ��";
                    UserID = -1;
                    break;
                default:
                    _return = "��½�ɹ�";
                    UserID = LoginState;
                    break;
            }

            return _return;

        }
        /// <summary>
        /// �����û�����ѯ�û�����
        /// </summary>
        /// <param name="UserName">�û���/��¼��</param>
        /// <returns>�û�����</returns>
        public LN.Model.UserInfo CheckUserLogin(string UserName)
        {
            return new LN.DAL.UserInfo().CheckUserLogin(UserName);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(LN.Model.UserInfo model)
        {
            return dal.Add(model);
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
            return dal.AddSupplierUser(model, SupplierID, UserType);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(LN.Model.UserInfo model)
        {
            dal.Update(model);
        }

        public void NewUpdate(LN.Model.UserInfo model)
        {
            dal.NewUpdate(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }

        public void Delete(string where)
        {

            dal.Delete(where);
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Pwd"></param>
        public void ChangeUserPwd(int UserID, string Pwd)
        {
            dal.ChangeUserPwd(UserID, Pwd);
        }
        /// <summary>
        /// ��ְһ��Ա��
        /// </summary>
        /// <param name="UserID"></param>
        public void RehabOneUser(int UserID)
        {
            dal.RehabOneUser(UserID);
        }

        /// <summary>
        /// �����û�����ְ״̬
        /// </summary>
        /// <param name="ID">Ҫ��������ԱID</param>
        public void SetUserState(int ID)
        {
            dal.SetUserState(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public LN.Model.UserInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.UserInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.UserInfo> modelList = new List<LN.Model.UserInfo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.UserInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.UserInfo();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(ds.Tables[0].Rows[n]["UserID"].ToString());
                    }
                    model.Username = ds.Tables[0].Rows[n]["Username"].ToString();
                    model.Sex = ds.Tables[0].Rows[n]["Sex"].ToString();
                    model.Usertype = ds.Tables[0].Rows[n]["Usertype"].ToString();
                    model.UserPassword = ds.Tables[0].Rows[n]["UserPassword"].ToString();
                    model.UserEmail = ds.Tables[0].Rows[n]["UserEmail"].ToString();
                    model.UserAddress = ds.Tables[0].Rows[n]["UserAddress"].ToString();
                    model.UserPhone = ds.Tables[0].Rows[n]["UserPhone"].ToString();
                    model.UserMobel = ds.Tables[0].Rows[n]["UserMobel"].ToString();
                    if (ds.Tables[0].Rows[n]["UserState"].ToString() != "")
                    {
                        model.UserState = int.Parse(ds.Tables[0].Rows[n]["UserState"].ToString());
                    }
                    model.UserDesc = ds.Tables[0].Rows[n]["UserDesc"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ָ����Ӧ�̵���Ա�б�AJAX��ҳ�б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <param name="model">����Դ����</param>
        /// <returns>����ָ����Ӧ�̵���Ա�б�</returns>
        public DataTable GetSupplierUserByWhere(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetSupplierUserByWhere(model, out TotalNumber);
        }
        /// <summary>
        /// �����û����͵õ��û���
        /// </summary>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public DataTable GetNameByType(string usertype)
        {
            return dal.GetNameByType(usertype);
        }
        /// <summary>
        /// ���ݵ�¼�˵��������жϵ�¼�˵Ľ�ɫ
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetTypeByName(string username)
        {
            return dal.GetTypeByName(username);
        }
        /// <summary>
        /// ���ݵ�¼�˵�ID�õ�����������ĸ�ʡ��
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetAreaByUserId(string userid)
        {
            return dal.GetAreaByUserId(userid);
        }
        #endregion  ��Ա����
    }
}


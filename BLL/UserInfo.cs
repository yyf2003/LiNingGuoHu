using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类UserInfo 的摘要说明。
    /// </summary>
    public class UserInfo
    {
        private readonly LN.DAL.UserInfo dal = new LN.DAL.UserInfo();
        public UserInfo()
        { }
        #region  成员方法

        /// <summary>
        /// 初始化用户密码为000000
        /// </summary>
        /// <param name="username">店铺ID</param>
        /// <returns>成功/失败</returns>
        public bool UpdateUserInfoPwd(string ShopID)
        {
            if (dal.UpdateUserInfoPwd(ShopID) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 判断用户是否登录成功
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public bool ExistsUser(string User, string Pwd)
        {
            return dal.ExistsUser(User, Pwd);
        }
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool ExistsWithUserName(string UserName,int? userId=null)
        {
            return dal.ExistsWithUserName(UserName, userId);
        }
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="UserName">登陆输入的用户名</param>
        /// <param name="UserPwd">登陆输入的密码</param>
        /// <returns>返回登陆状态</returns>
        public string CheckUserLogin(string UserName, string UserPwd, ref int UserID)
        {
            string _return = String.Empty;
            int LoginState = dal.CheckUserLogin(UserName, UserPwd);

            switch (LoginState)
            {
                case 0:
                    _return = "登陆失败---用户名密码错误";
                    UserID = 0;
                    break;
                case -1:
                    _return = "登陆失败---您没有登陆权限";
                    UserID = -1;
                    break;
                default:
                    _return = "登陆成功";
                    UserID = LoginState;
                    break;
            }

            return _return;

        }
        /// <summary>
        /// 根据用户名查询用户对象
        /// </summary>
        /// <param name="UserName">用户名/登录名</param>
        /// <returns>用户对象</returns>
        public LN.Model.UserInfo CheckUserLogin(string UserName)
        {
            return new LN.DAL.UserInfo().CheckUserLogin(UserName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.UserInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 添加供应商人员
        /// </summary>
        /// <param name="model">人员实体</param>
        /// <param name="SupplierID">所属供应商</param>
        /// <param name="UserType">权限（可修改或只查询）</param>
        /// <returns></returns>
        public int AddSupplierUser(LN.Model.UserInfo model, int SupplierID, int UserType)
        {
            return dal.AddSupplierUser(model, SupplierID, UserType);
        }

        /// <summary>
        /// 更新一条数据
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
        /// 删除一条数据
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
        /// 修改密码
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Pwd"></param>
        public void ChangeUserPwd(int UserID, string Pwd)
        {
            dal.ChangeUserPwd(UserID, Pwd);
        }
        /// <summary>
        /// 复职一个员工
        /// </summary>
        /// <param name="UserID"></param>
        public void RehabOneUser(int UserID)
        {
            dal.RehabOneUser(UserID);
        }

        /// <summary>
        /// 设置用户的在职状态
        /// </summary>
        /// <param name="ID">要操作的人员ID</param>
        public void SetUserState(int ID)
        {
            dal.SetUserState(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.UserInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 指定供应商的人员列表AJAX分页列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <param name="model">数据源总数</param>
        /// <returns>返回指定供应商的人员列表</returns>
        public DataTable GetSupplierUserByWhere(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetSupplierUserByWhere(model, out TotalNumber);
        }
        /// <summary>
        /// 根据用户类型得到用户名
        /// </summary>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public DataTable GetNameByType(string usertype)
        {
            return dal.GetNameByType(usertype);
        }
        /// <summary>
        /// 根据登录人的姓名来判断登录人的角色
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetTypeByName(string username)
        {
            return dal.GetTypeByName(username);
        }
        /// <summary>
        /// 根据登录人的ID得到这个人属于哪个省区
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetAreaByUserId(string userid)
        {
            return dal.GetAreaByUserId(userid);
        }
        #endregion  成员方法
    }
}


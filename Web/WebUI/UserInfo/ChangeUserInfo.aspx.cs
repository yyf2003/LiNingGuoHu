using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Linq;

public partial class WebUI_UserInfo_ChangeUserInfo : System.Web.UI.Page
{
    //public string ReqID = string.Empty;
    public string UserID = string.Empty;
    //public string UserName = string.Empty;
    //public string Sex = string.Empty;
    //public string UserType = string.Empty;
    //public string UserPassword = string.Empty;
    //public string UserEmail = string.Empty;
    //public string UserAddress = string.Empty;
    //public string UserPhone = string.Empty;
    //public string UserMobel = string.Empty;
    //public string UserState = string.Empty;
    //public string UserDesc = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.QueryString["ID"] != null)
        {

            if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
            {
                Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
                return;
            }
            UserID = this.Request.QueryString["ID"].ToString(); 
            if (!IsPostBack)
            {
                //GetOneUserInfo();
                BindDDL();
                BindData();
            }
        }

    }

    void BindDDL()
    {
        IList<LN.Model.UserTypeData> list = new LN.BLL.UserTypeData().GetList("");
        ddl_UserType.DataSource = list;
        ddl_UserType.DataTextField = "Usertype";
        ddl_UserType.DataValueField = "ID";
        ddl_UserType.DataBind();
        ddl_UserType.SelectedValue = new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Usertype;
        List<LN.Model.DealerInfo> listdea = new LN.BLL.DealerInfo().GetModelList("");

        for (int j = 0; j < listdea.Count; j++)
        {
            ListItem ltdea = new ListItem(listdea[j].DealerName, listdea[j].DealerID.ToString());
            this.DDL_dealerList.Items.Add(ltdea);
        }
        //加载部门名称
        List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
        foreach (LN.Model.DepartMentInfo deptmodel in listdept)
        {
            ListItem item = new ListItem(deptmodel.department, deptmodel.ID.ToString());
            DDL_department.Items.Add(item);
            ListItem item1 = new ListItem(deptmodel.department, deptmodel.ID.ToString());
            cblDepartment.Items.Add(item1);
        }
    }

    //废弃
  

    LN.BLL.DepartMentInfo departmentBll = new LN.BLL.DepartMentInfo();
    LN.BLL.UserInAreaBLL userInAreaBll = new LN.BLL.UserInAreaBLL();

    void BindData()
    {
        LN.Model.UserInfo model = new LN.BLL.UserInfo().GetModel(int.Parse(UserID));
        if (model != null)
        {
            txt_UserName.Text = model.Username;
            ddl_Sex.SelectedValue = model.Sex;
            ddl_UserType.SelectedValue = model.Usertype;
            txt_UserMail.Text = model.UserEmail;
            txt_UserAddress.Text = model.UserAddress;
            txt_UserPhone.Text = model.UserPhone;
            txt_UserMobile.Text = model.UserMobel;
            
            if (model.UserState != null && model.UserState == 1)
            {
                rblState.SelectedValue = model.UserState.ToString();
            }
            txt_UserDesc.Text = model.UserDesc;
            //加载部门和区域
            if (model.Usertype == "2")
            {
                //区域VM经理
                DataSet ds = departmentBll.GetList(string.Format("Department_Master='{0}'", model.Username));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //string departmentId = ds.Tables[0].Rows[0]["ID"].ToString();
                    //DDL_department.SelectedValue = departmentId;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        foreach (ListItem item in cblDepartment.Items)
                        {
                            if (item.Value == dr["ID"].ToString())
                            {
                                item.Selected = true;
                                
                            }
                        }
                    }
                }
            }
            else
            { 
                //省区VM
                DataTable dt = userInAreaBll.GetAreaByUserId(UserID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    string departName = dt.Rows[0]["DepartMent"].ToString();
                    foreach (ListItem li in DDL_department.Items)
                    {
                        if (li.Text == departName)
                        {
                            li.Selected = true;
                            break;
                        }
                    }
                    StringBuilder areas = new StringBuilder();
                    foreach (DataRow dr in dt.Rows)
                    {
                        areas.Append(dr["AreaId"] + ",");
                    }
                    hfAreas.Value = areas.ToString().TrimEnd(',');
                    oldAreas.Value = areas.ToString().TrimEnd(',');
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Username = this.txt_UserName.Text;
        string UserPassword = this.txt_Pwd.Text;
        string Sex = this.ddl_Sex.SelectedValue;
        string UserType = this.ddl_UserType.SelectedValue;
        string UserEmail = this.txt_UserMail.Text;
        string UserAddress = this.txt_UserAddress.Text;
        string UserPhone = this.txt_UserPhone.Text;
        string UserMobile = this.txt_UserMobile.Text;
        string UserDes = this.txt_UserDesc.Text;
        string state = rblState.SelectedValue;
        LN.Model.UserInfo model = new LN.Model.UserInfo();
        model.Sex = Sex;
        model.UserAddress = UserAddress;
        model.UserDesc = UserDes;
        model.UserEmail = UserEmail;
        model.UserMobel = UserMobile;
        model.Username = Username;
        if (!string.IsNullOrWhiteSpace(UserPassword))
        model.UserPassword = UserPassword;
        model.UserPhone = UserPhone;
        model.UserState = state != "" ? int.Parse(state) : 1;
        model.Usertype = UserType;
        model.ID = int.Parse(UserID);
        new LN.BLL.UserInfo().NewUpdate(model);
        string DeaclerID = this.DDL_dealerList.SelectedValue;
        if (DeaclerID != "0")
        {
            LN.BLL.DealerUser dUserBll=new LN.BLL.DealerUser();
            LN.Model.DealerUser deausermodel;
            IList<LN.Model.DealerUser> list = dUserBll.GetList(string.Format(" UserID={0}", UserID));
            if (list.Any())
            {
                deausermodel = list[0];
                deausermodel.DealerID = DeaclerID;
                dUserBll.Update(deausermodel);
            }
            else
            {
                deausermodel = new LN.Model.DealerUser();
                deausermodel.DealerID = DeaclerID;
                deausermodel.UserID = int.Parse(UserID);
                dUserBll.Add(deausermodel);
            }
            
        }
        //初始化部门和区域数据（删除）
        LN.BLL.UserInAreaBLL userInAreaBll = new LN.BLL.UserInAreaBLL();
        userInAreaBll.DeleteByUserId(int.Parse(UserID));

        LN.Model.DepartMentInfo department;
        LN.BLL.DepartMentInfo departmentBll = new LN.BLL.DepartMentInfo();
        department = new LN.Model.DepartMentInfo();
        //int departmentId = int.Parse(DDL_department.SelectedValue);
        int departmentId = 0;
        departmentBll.ClearUserData(Username);
        if (UserType == "2")
        {
            //区域VM经理
            //department = new LN.Model.DepartMentInfo();
            //departmentId = int.Parse(DDL_department.SelectedValue);
            //department.Department_Master = Username;
            //department.department_MasterPhone = UserPhone;
            //department.ID = departmentId;
            //departmentBll.NewUpdate(department);
            foreach (ListItem item in cblDepartment.Items)
            {
                if (item.Selected)
                {
                    department = new LN.Model.DepartMentInfo();
                    //int departmentId = int.Parse(DDL_department.SelectedValue);
                    departmentId = int.Parse(item.Value);
                    department.Department_Master = Username;
                    department.department_MasterPhone = UserPhone;
                    department.ID = departmentId;
                    new LN.BLL.DepartMentInfo().NewUpdate(department);
                }
            }
        }
        else
        {
            //省区VM
            
            if (!string.IsNullOrWhiteSpace(hfAreas.Value))
            {
                string[] arr = hfAreas.Value.TrimEnd(',').Split(',');
                if (arr.Length > 0)
                {
                    LN.Model.UserInArea userInAreaModel;
                    foreach (string s in arr)
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            userInAreaModel = new LN.Model.UserInArea();
                            userInAreaModel.UserId = int.Parse(UserID);
                            userInAreaModel.AreaId = int.Parse(s);
                            userInAreaBll.Add(userInAreaModel);
                        }
                    }
                }
            }
        }

        string url = GetUrl();
        if (!string.IsNullOrWhiteSpace(url))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('修改成功！');window.location='UserList.aspx?" + url + "'</script>");
        }
        else
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('修改成功！');window.location='UserList.aspx'</script>");
    }

    string GetUrl()
    {
        string username = string.Empty;
        string sex = string.Empty;
        string usertype = string.Empty;
        string userstate = string.Empty;
        bool flag = false;
        if (Request.QueryString["username"] != null)
        {
            username = Request.QueryString["username"];
            flag = true;
        }
        if (Request.QueryString["sex"] != null)
        {
            sex = Request.QueryString["sex"];
            flag = true;
        }
        if (Request.QueryString["usertype"] != null)
        {
            usertype = Request.QueryString["usertype"];
            flag = true;
        }
        if (Request.QueryString["userstate"] != null)
        {
            userstate = Request.QueryString["userstate"];
            flag = true;
        }
        if (flag)
        {
            string searchkey = string.Format("username={0}&sex={1}&usertype={2}&userstate={3}", username, sex, usertype, userstate);
            return searchkey;
        }
        else
            return "";
    }
}

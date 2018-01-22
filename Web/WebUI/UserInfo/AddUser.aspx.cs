using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_UserInfo_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            GetUserTypeData();
        }
        //加载一级客户

    }
    public void GetUserTypeData()
    {
        //加载客户角色
        IList<LN.Model.UserTypeData> list = new LN.BLL.UserTypeData().GetList(" TypeState=1");
        for (int i = 0; i < list.Count; i++)
        {
            ListItem lt = new ListItem(list[i].Usertype, list[i].UserTypeID.ToString());
            this.ddl_UserType.Items.Add(lt);
        }

        //加载一级客户
        List<LN.Model.DealerInfo> listdea = new LN.BLL.DealerInfo().GetModelList("");

        for (int j = 0; j < listdea.Count; j++)
        {
            ListItem ltdea = new ListItem(listdea[j].DealerName, listdea[j].DealerID.ToString());
            this.DDL_dealerList.Items.Add(ltdea);
        }
        //加载部门名称
        List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
        foreach (LN.Model.DepartMentInfo model in listdept)
        {
            ListItem item = new ListItem(model.department, model.ID.ToString());
            cblDepartment.Items.Add(item);
            DDL_department.Items.Add(item);
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Username = this.txt_UserName.Text.Trim();
        string UserPassword = this.txt_Pwd.Text;
        string Sex = this.ddl_Sex.SelectedValue;
        string UserType = this.ddl_UserType.SelectedValue;
        string UserEmail = this.txt_UserMail.Text.Trim();
        string UserAddress = this.txt_UserAddress.Text.Trim();
        string UserPhone = this.txt_UserPhone.Text.Trim();
        string UserMobile = this.txt_UserMobile.Text.Trim();
        string UserStation = this.ddl_UserStation.SelectedValue;
        string UserDes = this.txt_UserDesc.Text.Trim();
        string DeaclerID = this.DDL_dealerList.SelectedValue;
        LN.Model.UserInfo model = new LN.Model.UserInfo(); 
        model.Sex = Sex;
        model.UserAddress = UserAddress;
        model.UserDesc = UserDes;
        model.UserEmail = UserEmail;
        model.UserMobel = UserMobile;
        model.Username = Username;
        model.UserPassword = UserPassword;
        model.UserPhone = UserPhone;
        model.UserState = int.Parse(UserStation);
        model.Usertype = UserType;
        //model.Userofarea =int.Parse(Request.Form["DDL_Area"].ToString());
        model.Userofarea = 0;
        try
        {
            int UserID = new LN.BLL.UserInfo().Add(model);
            if (DeaclerID!="0")
            {
                
                LN.Model.DealerUser deausermodel = new LN.Model.DealerUser();
                deausermodel.DealerID = DeaclerID;
                deausermodel.UserID = UserID;
                new LN.BLL.DealerUser().Add(deausermodel);
            }
            if (UserType == "2")
            {
                //区域VM经理
                foreach (ListItem item in cblDepartment.Items)
                {
                    if (item.Selected)
                    {
                        LN.Model.DepartMentInfo department = new LN.Model.DepartMentInfo();
                        //int departmentId = int.Parse(DDL_department.SelectedValue);
                        int departmentId = int.Parse(item.Value);
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
                LN.BLL.UserInAreaBLL userInAreaBll = new LN.BLL.UserInAreaBLL();
                userInAreaBll.DeleteByUserId(UserID);
                if (!string.IsNullOrWhiteSpace(hfArea.Value))
                {
                    string[] arr = hfArea.Value.TrimEnd(',').Split(',');
                    if (arr.Length > 0)
                    {
                        LN.Model.UserInArea userInAreaModel;
                        foreach (string s in arr)
                        {
                            if (!string.IsNullOrWhiteSpace(s))
                            {
                                userInAreaModel = new LN.Model.UserInArea();
                                userInAreaModel.UserId = UserID;
                                userInAreaModel.AreaId = int.Parse(s);
                                userInAreaBll.Add(userInAreaModel);
                            }
                        }
                    }
                }
            }
           
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>alert('添加成功!');window.location='UserList.aspx';</script>");

        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('添加失败,异常在:" + ex.Message.ToString() + "');window.location=window.location;</script>");
        }
    }
}

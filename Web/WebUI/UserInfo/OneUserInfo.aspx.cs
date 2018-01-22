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

public partial class WebUI_UserInfo_OneUserInfo : System.Web.UI.Page
{
    public string ReqID = string.Empty;
    public string UserID = string.Empty;
    public string UserName = string.Empty;
    public string Sex = string.Empty;
    public string UserType = string.Empty; 
    public string UserEmail = string.Empty;
    public string UserAddress = string.Empty;
    public string UserPhone = string.Empty;
    public string UserMobel = string.Empty;
    public string UserState = string.Empty;
    public string UserDesc = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        ReqID = Request.QueryString["ID"] == null ? "0" : Request.QueryString["ID"].ToString();
        if (!IsPostBack)
            GetOneUserInfo();
    }
    public void GetOneUserInfo()
    { 
        LN.Model.UserInfo model = new LN.BLL.UserInfo().GetModel(int.Parse(ReqID));
        if (model != null)
        {
            UserID = model.UserID.ToString();
            UserName = model.Username;
            Sex = model.Sex; 
            UserType = model.Usertype; 
            UserEmail = model.UserEmail;
            UserAddress = model.UserAddress;
            UserPhone = model.UserPhone;
            UserMobel = model.UserMobel;
            UserState = model.UserState.ToString(); 
            UserDesc = model.UserDesc;
        }
        this.DataBind();
    }
 
    public string GetUserType(string UserTypeID)
    {
        return new LN.BLL.UserTypeData().GetModel(int.Parse(UserTypeID)).Usertype;
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_UserInfo_ChangePwd : System.Web.UI.Page
{
    protected string userID = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        userID = this.Request.Cookies["UserID"].Value;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string OLDPWD = this.Request.Form["txtOlePwd"].ToString();
        string NewPwd = this.Request.Form["txtPwd2"].ToString();
        string UserOle = new LN.BLL.UserInfo().GetModel(int.Parse(userID)).UserPassword;
        if (UserOle == OLDPWD.ToLower())
        {
            new LN.BLL.UserInfo().ChangeUserPwd(int.Parse(userID), NewPwd.ToLower());
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>alert('密码修改成功，请牢记！');window.location=window.location;</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType (),"_erro","<script>alert('旧密码不正确,请重试！');</script>");
        }
    }
}

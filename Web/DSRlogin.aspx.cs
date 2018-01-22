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

public partial class DSRlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btn_login_Click(object sender, EventArgs e)
    {
        int UserID = 0;
        string UserName = this.username.Text.Trim();
        string UserPwd = this.pwd.Text.Trim();
        string Resutl = new LN.BLL.UserInfo().CheckUserLogin(UserName, UserPwd, ref UserID);
        if (UserID > 0)
        {
            Session["UserID"] = UserID.ToString();
            Session["UserName"] = UserName;
            Response.Redirect("PDADSR.aspx");
        }
        else
        {

            Response.Redirect("DSRlogin.aspx");

        }
    }
}

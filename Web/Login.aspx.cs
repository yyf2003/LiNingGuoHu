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

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtnUserLogin_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["ConnStrName"] == null)
        {
            Response.Redirect("Navigation.aspx");
        }

        string UserName = this.Request.Form["idname"].ToString();
        string UserPwd = this.Request.Form["password"].ToString();
        LN.Model.LoginLog model = new LN.Model.LoginLog();
        model.LoginIP = this.Request.UserHostAddress;
        model.LoginUserID = UserName;
        LN.Model.UserInfo u = new LN.BLL.UserInfo().CheckUserLogin(UserName);
        if (u != null)
        {
            if (u.UserState == 1)
            {
                if (u.UserPassword == UserPwd)
                {
                    Response.Cookies["UserID"].Value = u.UserID.ToString();
                    Response.Cookies["UserName"].Value = Server.UrlEncode(UserName);
                    if (u.Userofarea != 0)
                        Response.Cookies["UserArea"].Value = u.Userofarea.ToString();
                    else
                        Response.Cookies["UserArea"].Value = "";
                    Response.Redirect("Default.aspx");
                    model.Result = "登录成功";
                    new LN.BLL.LoginLog().Add(model);
                }
                else
                {
                    model.Result = "输入密码错误,请联系省区VM 谢谢!";
                    new LN.BLL.LoginLog().Add(model);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('" + model.Result + "');window.location=window.location;</script>");
                }
            }
            else
            {
                model.Result = "店铺系统内状态为关闭,请联系省区VM 谢谢!";
                new LN.BLL.LoginLog().Add(model);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('" + model.Result + "');window.location=window.location;</script>");
            }
        }
        else
        {
            model.Result = "店铺不存在,请联系省区VM 谢谢!";
            new LN.BLL.LoginLog().Add(model);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('" + model.Result + "');window.location=window.location;</script>");
        }

        //int UserID = 0;
        //string UserName = this.Request.Form["idname"].ToString();
        //string UserPwd = this.Request.Form["password"].ToString();
        //string Result = new LN.BLL.UserInfo().CheckUserLogin(UserName, UserPwd.ToLower(),ref UserID);

        //LN.Model.LoginLog model = new LN.Model.LoginLog();
        //model.LoginIP = this.Request.UserHostAddress;
        //model.LoginUserID = UserName;
        //model.Result = Result;
        //new LN.BLL.LoginLog().Add(model);

        //if (UserID > 0)
        //{
        //    Response.Cookies["UserID"].Value = UserID.ToString();
        //    Response.Cookies["UserName"].Value = Server.UrlEncode(UserName);
        //    Response.Redirect("Default.aspx");
        //}
        //else
        //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('" + Result + "');window.location=window.location;</script>");
    }
}

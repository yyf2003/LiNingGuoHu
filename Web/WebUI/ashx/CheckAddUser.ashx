<%@ WebHandler Language="C#" Class="CheckAddUser" %>

using System;
using System.Web;

public class CheckAddUser : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string UserName = string.Empty;
        int userId = 0;
        if (context.Request.QueryString["UserName"] != null)
        {
            UserName = context.Request.QueryString["UserName"];
        }
        if (context.Request.QueryString["UserId"] != null)
        {
            userId = int.Parse(context.Request.QueryString["UserId"]);
        }
        if (!string.IsNullOrWhiteSpace(UserName))
        {
            if (new LN.BLL.UserInfo().ExistsWithUserName(UserName, userId))
            {
                context.Response.Write("用户已经存在，请更换");
            }
            else
            {
                context.Response.Write("可以注册");
            }

        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
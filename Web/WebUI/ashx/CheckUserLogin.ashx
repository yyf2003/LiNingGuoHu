<%@ WebHandler Language="C#" Class="CheckUserLogin" %>

using System;
using System.Web;

public class CheckUserLogin : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string User = context.Request.Form["User"]; 
        string Pwd = context.Request.Form["Pwd"];
        if (User != "" && User != null && Pwd != null && Pwd != "")
        {
            bool re = new LN.BLL.UserInfo().ExistsUser(User, Pwd);
            if (re) 
                context.Response.Write("success"); 
            else 
                context.Response.Write("fail");  
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
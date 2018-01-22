<%@ WebHandler Language="C#" Class="RehabOneUser" %>

using System;
using System.Web;

public class RehabOneUser : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string UserID = context.Request.QueryString["UserID"];
        if (UserID!=null&&UserID!="")
        {
            int userid = int.Parse(UserID);
            new LN.BLL.UserInfo().RehabOneUser(userid);
        } 
        context.Response.Write("操作成功");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
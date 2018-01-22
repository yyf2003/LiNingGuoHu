<%@ WebHandler Language="C#" Class="DelOneAssginUser" %>

using System;
using System.Web;

public class DelOneAssginUser : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string useritem = context.Request.QueryString["UserItem"];
        if (useritem != null && useritem != "")
        {
            string[] users = useritem.Split(',');
            for (int i = 0; i < users.Length; i++)
            {
                string uu = users[i];
                new LN.BLL.AssignUser().Delete(int.Parse(uu));
            }
        }
        context.Response.Write("操作成功！");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
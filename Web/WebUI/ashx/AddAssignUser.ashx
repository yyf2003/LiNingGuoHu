<%@ WebHandler Language="C#" Class="AddAssignUser" %>

using System;
using System.Web;

public class AddAssignUser : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string UserItem = context.Request.QueryString["UserItem"];
        string UserID = context.Request.QueryString["UserID"];
        if (UserItem != null && UserItem != "" && UserID != null && UserID != "")
        {
            string[] user = UserItem.Split(',');
            for (int i = 0; i < user.Length; i++)
            {
                string uu = user[i];
                string userrole = new LN.BLL.UserInfo().GetModel(int.Parse(uu)).Usertype;
                LN.Model.AssignUser model = new LN.Model.AssignUser();
                model.UpmanagerID = int.Parse(UserID);
                model.ManagedID = int.Parse(uu);
                model.ManagedRole = int.Parse(userrole);
                new LN.BLL.AssignUser().Add(model);
            }
        }
        context.Response.Write("操作成功");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="doSet" %>

using System;
using System.Web;

public class doSet : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string UserID = context.Request.QueryString["UserID"];
        string ExamState = context.Request.QueryString["ExamState"];
        string AddID = context.Request.QueryString["AddID"];
        string Undes = context.Request.QueryString["Undes"];
        string role = context.Request.QueryString["UserRole"] == null ? "" : context.Request.QueryString["UserRole"].ToString();
        try
        {
            if (UserID != null && UserID != "" && ExamState != null && ExamState != "" && AddID != null && AddID != "")
            {
                if ("dept".Equals(role))
                {
                    new LN.BLL.POPAddition().UpdateAddition(int.Parse(UserID), Undes, int.Parse(ExamState), int.Parse(AddID));
                }
                else if ("VM".Equals(role))
                {
                    new LN.BLL.POPAddition().VMUpdateAddition(int.Parse(UserID), Undes, int.Parse(ExamState), int.Parse(AddID));
                }
            }
            context.Response.Write("操作成功");
        }
        catch (Exception)
        {

            context.Response.Write("操作失败；请重新操作！");
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
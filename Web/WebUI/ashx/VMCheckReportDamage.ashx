<%@ WebHandler Language="C#" Class="VMCheckReportDamage" %>

using System;
using System.Web;

public class VMCheckReportDamage : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string ID = context.Request.Form["ID"];
        string UserID = context.Request.Form["UserID"];
        string VMDesc = context.Request.Form["VMDesc"];
        string UpTime = DateTime.Now.ToString().Length > 19 ? DateTime.Now.ToString().Substring(0, 19) : DateTime.Now.ToString();
        if (ID != "" && ID != null && UserID != "" && UserID != null && VMDesc != "" && VMDesc != null && UpTime != "" && UpTime != null)
        {
            new LN.BLL.POPReprotDamage().VMCheckReprotDamage(int.Parse(UserID), VMDesc, UpTime, int.Parse(ID));
            context.Response.Write("操作成功！");
        }
        else
        {
            context.Response.Write("不能操作！");
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
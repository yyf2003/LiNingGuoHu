<%@ WebHandler Language="C#" Class="SetConnStr" %>

using System;
using System.Web;
using LN.DBUtility;
using System.Web.SessionState;

public class SetConnStr : IHttpHandler,IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string result = "0";
        string ConnStrName = context.Request["ConnStrName"] == null ? "" : context.Request["ConnStrName"].ToString();

        if (ConnStrName != "")
        {
            context.Response.Cookies["ConnStrName"].Value = ConnStrName;
            context.Response.Cookies["ConnStrName"].Expires = DateTime.Now.AddDays(1);
            result = "1";
        }
        
        context.Response.Write(result);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
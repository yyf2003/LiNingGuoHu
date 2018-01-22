<%@ WebHandler Language="C#" Class="DelOneDealerInfo" %>

using System;
using System.Web;

public class DelOneDealerInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string DealerID = context.Request.QueryString["ID"];
        if (DealerID != null && DealerID != "")
        {
            new LN.BLL.DealerInfo().Delete(int.Parse(DealerID));
        }
           context.Response.Write("删除成功");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="PostIDExists" %>

using System;
using System.Web;

public class PostIDExists : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
       string  posid = context.Request.QueryString["posid"].ToString();
        LN.BLL.ShopInfo shopBLL = new LN.BLL.ShopInfo();
        string flag = "";
        if (!shopBLL.Exists(posid))
        {
            flag = "true";
        }
        else
        {
            flag = "false";
        }
        context.Response.Write(flag);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
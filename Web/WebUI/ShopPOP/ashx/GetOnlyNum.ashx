<%@ WebHandler Language="C#" Class="GetOnlyNum" %>

using System;
using System.Web;

public class GetOnlyNum : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string shopid = context.Request.QueryString["shopid"].ToString();
        string snum = context.Request.QueryString["snum"].ToString();

       int i= new LN.BLL.POPInfo().GetOnlyNum(shopid,snum);

       context.Response.Write(i.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
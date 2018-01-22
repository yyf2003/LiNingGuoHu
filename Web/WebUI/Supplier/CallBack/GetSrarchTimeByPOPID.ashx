<%@ WebHandler Language="C#" Class="GetSrarchTimeByPOPID" %>

using System;
using System.Web;

public class GetSrarchTimeByPOPID : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string POPID = context.Request.QueryString["id"] == null ? "0": context.Request.QueryString["id"].ToString();
        string _return = String.Empty;

        _return = new LN.BLL.tb_OrderSearch_Time().GetOrderSearchByPOPID(POPID, Convert.ToInt32(context.Request.Cookies["UserID"].Value));
        
        if (string.IsNullOrEmpty(_return))
            _return = DateTime.Now.ToString();

        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="DelDisInfo" %>

using System;
using System.Web;

public class DelDisInfo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //返回值
        int _return = 0;
        //获取直属客户编号
        string id = context.Request["id"] == null ? "0" : context.Request["id"].ToString();
        if (id != "0")
        {
            _return = new LN.BLL.DistributorsInfo().Delete(id);
        }

        context.Response.Write(_return.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
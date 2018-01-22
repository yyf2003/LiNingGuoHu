<%@ WebHandler Language="C#" Class="AddTypeName" %>

using System;
using System.Web;

public class AddTypeName : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _return = "0";
        //获取故事包品类
        string tName = context.Request.QueryString["tname"] == null ? "0" : context.Request.QueryString["tname"].ToString();
        //获取添加结果
        int result = new LN.BLL.ProductLineType().Add(tName,1);
        if (result > 0)
            _return = result.ToString();

        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
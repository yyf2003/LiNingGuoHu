<%@ WebHandler Language="C#" Class="AddProductLine" %>

using System;
using System.Web;

public class AddProductLine : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _return = "0";
        //获取故事包品类
        string pName = context.Request.QueryString["pname"] == null ? "" : context.Request.QueryString["pname"].ToString();
        string pType = context.Request.QueryString["ptype"] == null ? "0" : context.Request.QueryString["ptype"].ToString();
        if (!string.IsNullOrEmpty(pName))
        {
            //获取添加结果
            LN.Model.ProductLineData model = new LN.Model.ProductLineData();
            model.ProductLine = pName;
            model.TypeID = Int32.Parse(pType);
            int result = new LN.BLL.ProductLineData().Add(model);
            if (result > 0)
                _return = result.ToString();
        }
        

        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
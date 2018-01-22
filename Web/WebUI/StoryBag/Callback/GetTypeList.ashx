<%@ WebHandler Language="C#" Class="GetTypeList" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
public class GetTypeList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string IsDelete = context.Request.QueryString["isdelete"] == null ? "" : context.Request.QueryString["isdelete"].ToString();
        //返回给客户端的字符串
        string _return = String.Empty;
        IList<LN.Model.ProductLineType> list = new LN.BLL.ProductLineType().GetList(" IsDelete = " + IsDelete);
        StringBuilder sb = new StringBuilder();
        _return = "[";
        if (list.Count > 0)
        {
            foreach (LN.Model.ProductLineType model in list)
            {
                sb.Append("{ProductTypeID:\"" + model.ProductTypeID.ToString().Trim() + "\"");
                sb.Append(",ProductTypeName:\"" + model.ProductTypeName.Trim() + "\"},");
            }
        }
        else
        {
            sb.Append("{ProductTypeID:\"0\",,ProductTypeName:\"\"}");
        }
        _return += sb.ToString().Trim(new char[] { ',' }) + "]";

        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
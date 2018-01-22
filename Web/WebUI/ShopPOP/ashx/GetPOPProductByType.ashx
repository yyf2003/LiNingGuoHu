<%@ WebHandler Language="C#" Class="GetPOPProductByType" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
public class GetPOPProductByType : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string typeid = string.Empty;
        typeid = context.Request.QueryString["typeid"].ToString();
        IList<LN.Model.ProductLineData> typelist = new LN.BLL.ProductLineData().GetList(" Typeid="+typeid);
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        if (typelist.Count > 0)
        {
            foreach (LN.Model.ProductLineData model in typelist)
            {
                sb.Append("{");
                sb.Append("pid");
                sb.Append(":\"");
                sb.Append(model.ProductLineID.ToString());
                sb.Append("\",");
                sb.Append("linename");
                sb.Append(":\"");
                sb.Append(model.ProductLine.ToString());

                sb.Append("\"},");
            }
        }
        else
        {
            sb.Append("{");
            sb.Append("pid");
            sb.Append(":\"");
            sb.Append("0");
            sb.Append("\",");
            sb.Append("linename");
            sb.Append(":\"");
            sb.Append("");

            sb.Append("\"},");
        }
        context.Response.Write(sb.ToString().Substring(0, sb.ToString().Length - 1) + "]");

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
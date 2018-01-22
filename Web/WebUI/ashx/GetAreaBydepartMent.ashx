<%@ WebHandler Language="C#" Class="GetAreaBydepartMent" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
public class GetAreaBydepartMent : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        StringBuilder sb = new StringBuilder();
        string dept = context.Request.QueryString["dept"].ToString();
        string strsql = "";
        if (dept != "0")
        {
            strsql += " departMent='" + dept + "'";
           
        }
        else
        {
            strsql = "";
        }
        IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strsql);
        sb.Append("[");
        foreach (LN.Model.AreaData model in arealist)
        {
            sb.Append("{");
            sb.Append("ID");
            sb.Append(":\"");
            sb.Append(model.AreaID.ToString());
            sb.Append("\",");
            sb.Append("IName");
            sb.Append(":\"");
            sb.Append(model.AreaName);
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
<%@ WebHandler Language="C#" Class="GetDealerByAreaID" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Data;

public class GetDealerByAreaID : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string areaid = context.Request.QueryString["areaID"].ToString();
        DataTable dt = new LN.BLL.DealerInfo().GetDealerName(" AreaID=" + areaid + " ");
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{");
                sb.Append("ID");
                sb.Append(":\"");
                sb.Append(dt.Rows[i][0].ToString());
                sb.Append("\",");
                sb.Append("dname");
                sb.Append(":\"");
                sb.Append(dt.Rows[i][1].ToString());

                sb.Append("\"},");
            }
        }
        else
        {

            sb.Append("{");
            sb.Append("ID");
            sb.Append(":\"");
            sb.Append("0");
            sb.Append("\",");
            sb.Append("dname");
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
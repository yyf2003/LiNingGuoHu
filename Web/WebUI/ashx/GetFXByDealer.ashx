<%@ WebHandler Language="C#" Class="GetFXByDealer" %>

using System;
using System.Web;
using System.Data;
using System.Text;
public class GetFXByDealer : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string dealerid = context.Request.QueryString["dealerid"].ToString();
        DataTable dt = new LN.BLL.DistributorsInfo().GetIDName(" dealerid='"+dealerid+"'");
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
                sb.Append("fxname");
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
            sb.Append("fxname");
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
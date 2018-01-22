<%@ WebHandler Language="C#" Class="GetProductlineBytypeID" %>

using System;
using System.Web;
using System.Data;
using System.Text;
public class GetProductlineBytypeID : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string typeid = context.Request.QueryString["typeid"].ToString();
        string popid = context.Request.QueryString["popid"].ToString();
        DataTable dt = new LN.BLL.ProductLineData().GetPOPproductLineByTypeID(popid,int.Parse(typeid));
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                sb.Append("{");
                sb.Append("pID");
                sb.Append(":\"");
                sb.Append(dt.Rows[i][0].ToString());
                sb.Append("\",");
                sb.Append("linename");
                sb.Append(":\"");
                sb.Append(dt.Rows[i][1].ToString());

                sb.Append("\"},");
            }
        }
        else
        {
            sb.Append("{");
            sb.Append("pID");
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
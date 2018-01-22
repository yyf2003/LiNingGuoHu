<%@ WebHandler Language="C#" Class="GetDealerName" %>

using System;
using System.Web;
using System.Data;
using System.Text;

public class GetDealerName : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string CityID = context.Request.QueryString["CityID"] == null ? "0" : context.Request.QueryString["CityID"].ToString();

        LN.DAL.DealerInfo dealerDal = new LN.DAL.DealerInfo();
        DataTable dealerdt = dealerDal.GetDealerInfoListBy(CityID);
        
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        if (dealerdt.Rows.Count > 0)
        {
            for (int i = 0; i < dealerdt.Rows.Count; i++)
            {
                sb.Append("{");
                sb.Append("ID");
                sb.Append(":\"");
                sb.Append(dealerdt.Rows[i][0].ToString());
                sb.Append("\",");
                sb.Append("IName");
                sb.Append(":\"");
                sb.Append(dealerdt.Rows[i][1].ToString());

                sb.Append("\"},");
            }
        }
        //else
        //{
        //    sb.Append("{");
        //    sb.Append("ID");
        //    sb.Append(":\"");
        //    sb.Append("0");
        //    sb.Append("\",");
        //    sb.Append("IName");
        //    sb.Append(":\"");
        //    sb.Append("请选择市");

        //    sb.Append("\"},");
        //}
        context.Response.Write(sb.ToString().Substring(0, sb.ToString().Length - 1) + "]");
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
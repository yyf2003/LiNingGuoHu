<%@ WebHandler Language="C#" Class="GetCityName" %>

using System;
using System.Web;
using System.Data;
using System.Text;
public class GetCityName : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string ProvinceId = context.Request.QueryString["ProvinceID"].ToString();
        LN.DAL.CityData cityDAL = new LN.DAL.CityData();
        DataTable citydt = cityDAL.GetCityList("provinceID=" + ProvinceId);
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        if (citydt.Rows.Count > 0)
        {
            for (int i = 0; i < citydt.Rows.Count; i++)
            {
                sb.Append("{");
                sb.Append("ID");
                sb.Append(":\"");
                sb.Append(citydt.Rows[i][0].ToString());
                sb.Append("\",");
                sb.Append("IName");
                sb.Append(":\"");
                sb.Append(citydt.Rows[i][1].ToString());

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
            sb.Append("IName");
            sb.Append(":\"");
            sb.Append("请选择市");

            sb.Append("\"},");
        }
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


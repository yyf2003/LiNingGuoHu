<%@ WebHandler Language="C#" Class="GetTown" %>

using System;
using System.Web;
using System.Text;
using System.Collections.Generic;
public class GetTown : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
       string cityid= context.Request.QueryString["cityid"].ToString();
       IList<LN.Model.TownData> modellist = new LN.BLL.TownData().GetList(" CityID =" + cityid);
       StringBuilder sb = new StringBuilder();
       sb.Append("[");
       foreach (LN.Model.TownData model in modellist)
       {

           sb.Append("{");
           sb.Append("townid");
           sb.Append(":\"");
           sb.Append(model.TownID.ToString());
           sb.Append("\",");
           sb.Append("IName");
           sb.Append(":\"");
           sb.Append(model.TownName);

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
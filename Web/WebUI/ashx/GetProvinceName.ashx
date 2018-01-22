<%@ WebHandler Language="C#" Class="GetProvinceName" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
public class GetProvinceName : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string areaid = context.Request.QueryString["areaid"].ToString();
        IList<LN.Model.ProvinceData> prolist = null;
        if (areaid == "-1")
            prolist = new LN.BLL.ProvinceData().GetList("");
        else
            prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + areaid);
        StringBuilder proStr = new StringBuilder();
        proStr.Append("[");
        foreach (LN.Model.ProvinceData model in prolist)
        {
            proStr.Append("{");
            proStr.Append("Proid");
            proStr.Append(":\"");
            proStr.Append(model.ProvinceID.ToString());
            proStr.Append("\",");
            proStr.Append("Proname");
            proStr.Append(":\"");
            proStr.Append(model.ProvinceName);
            proStr.Append("\"},");
            
        }
        context.Response.Write(proStr.ToString().Substring(0, proStr.ToString().Length - 1) + "]");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
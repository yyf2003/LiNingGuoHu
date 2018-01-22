<%@ WebHandler Language="C#" Class="GetVmMasterByProvinceID" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
public class GetVmMasterByProvinceID : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string ProvinceID = context.Request.QueryString["ID"].ToString();
        IList<LN.Model.ProvinceData> prolist = null;
        if (int.Parse(ProvinceID) > 0)
            prolist = new LN.BLL.ProvinceData().GetList(" provinceID=" + ProvinceID);
        StringBuilder proStr = new StringBuilder();
        if (prolist.Count > 0)
        {
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
                proStr.Append("\",");
                proStr.Append("aid");
                proStr.Append(":\"");
                proStr.Append(model.AreaID.ToString());
                proStr.Append("\",");
                proStr.Append("VMName");
                proStr.Append(":\"");
                proStr.Append(model.VMmaster);
                proStr.Append("\",");
                proStr.Append("VMTel");
                proStr.Append(":\"");
                proStr.Append(model.VMphone);
                proStr.Append("\"},");
            }
            context.Response.Write(proStr.ToString().Substring(0, proStr.ToString().Length - 1) + "]");
        }
        else
            context.Response.Write("[{ID:\"0\"}]");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
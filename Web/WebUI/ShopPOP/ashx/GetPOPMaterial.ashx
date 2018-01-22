<%@ WebHandler Language="C#" Class="GetPOPMaterial" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Data;

public class GetPOPMaterial : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //获取FOS店POP位置描述
        string ShopID = context.Request.QueryString["id"] == null ? "0" : context.Request.QueryString["id"].ToString();

        //返回给客户端的字符串
        string _return = String.Empty;

        DataTable materdt = new LN.BLL.POPMateriaData().GetMaterialByshopID(ShopID);
        _return = "[";
        StringBuilder sb = new StringBuilder();
        if (materdt.Rows.Count > 0)
        {
            foreach (DataRow dr in materdt.Rows)
            {
                sb.Append("{MateriaID:\"" + dr["MateriaID"].ToString().Trim() + "\"");
                sb.Append(",materiapro:\"" + dr["materiapro"].ToString().Trim() + "\"},");
            }
        }
        else
        {
            sb.Append("{MateriaID:\"0\",materiapro:\"\"}");
        }
        _return += sb.ToString().Trim(new char[] { ',' }) + "]";
        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
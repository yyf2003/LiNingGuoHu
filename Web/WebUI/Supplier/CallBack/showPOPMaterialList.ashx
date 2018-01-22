<%@ WebHandler Language="C#" Class="showPOPMaterialList" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

public class showPOPMaterialList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //获取供应商编号
        string sID = context.Request.QueryString["sID"] == null ? "0" : context.Request.QueryString["sID"].ToString();
        //获取用户名
        string userID = context.Request.QueryString["uID"] == null ? "0" : context.Request.QueryString["uID"].ToString();
        //返回给客户端的字符串
        string _return = String.Empty;
        //查询条件
        string strWhere = string.Format(" p.POPID='{0}' AND p.SupplierID = (SELECT TOP 1 [SupplierID] FROM [SupplierUserManage] WHERE [UserID]={1})", sID, userID);
        
        IList<LN.Model.POPPrice> list = new LN.BLL.POPPrice().GetList(strWhere);
        _return = "[";
        StringBuilder sb = new StringBuilder();
        if (list != null && list.Count > 0)
        {
            foreach (LN.Model.POPPrice model in list)
            {
                sb.Append("{PriceID:\"" + model.PriceID.ToString() + "\"");
                sb.Append(",POPMaterial:\"" + model.POPMaterial + "\"");
                sb.Append(",POPprice:\"" + model.POPprice.ToString() + "\"},"); 
            }
        }
        else
        {
            sb.Append("{PriceID:\"0\",POPMaterial:\"\",POPprice:\"\"}");
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
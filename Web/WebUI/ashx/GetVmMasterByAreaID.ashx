<%@ WebHandler Language="C#" Class="GetVmMasterByAreaID" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Data;

public class GetVmMasterByAreaID : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //返回给客户端的字符串
        string _return = String.Empty;
        //获取区域编号
        string AreaID = context.Request.QueryString["areaID"].ToString();
        
        DataSet userinfods =  new LN.BLL.UserInfo().GetList(" userType=3 and userofarea=" + AreaID);
        _return = "[";
        StringBuilder sb = new StringBuilder();
        if (userinfods != null)
        {
            foreach (DataRow dr in userinfods.Tables[0].Rows)
            {
                sb.Append("{VMName:\"" + dr["Username"].ToString() + "\"");
                sb.Append(",VMTel:\"" + dr["UserMobel"].ToString() + "\"},");
            }
        }
        else
        {
            sb.Append("{VMName:\"0\",VMTel:\"\"}");
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
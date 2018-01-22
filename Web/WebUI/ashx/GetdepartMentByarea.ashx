<%@ WebHandler Language="C#" Class="GetdepartMentByarea" %>

using System;
using System.Web;
using System.Text;
using System.Collections.Generic;
public class GetdepartMentByarea : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string areaID = context.Request.QueryString["ID"].ToString();
        LN.Model.AreaData model = new LN.BLL.AreaData().GetModel(int.Parse(areaID));
        context.Response.Write(model.DepartMent.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
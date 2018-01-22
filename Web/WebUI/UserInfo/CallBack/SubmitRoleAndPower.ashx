<%@ WebHandler Language="C#" Class="SubmitRoleAndPower" %>

using System;
using System.Web;

public class SubmitRoleAndPower : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int _return = 0;
        string roleID = context.Request["rid"] == null ? "0" : context.Request["rid"].Trim();
        string rolePage = context.Request["pid"] == null ? "0" : context.Request["pid"].Trim();
        if (roleID != "0")
        {
            LN.Model.roleAndPower model = new LN.Model.roleAndPower();
            model.roleId = Int32.Parse(roleID.Trim());
            model.functionId = rolePage.Trim(new char[] { ',' });
            _return = new LN.BLL.roleAndPower().Add(model);
            
        }
        context.Response.Write(_return.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
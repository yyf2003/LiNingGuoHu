<%@ WebHandler Language="C#" Class="AddAfficheType" %>

using System;
using System.Web;

public class AddAfficheType : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string typeName = context.Request.QueryString["TypeName"];
        if (typeName!=null &&typeName!="")
        {
            LN.Model.AfficheType model = new LN.Model.AfficheType();
            model.Type = typeName;
            new LN.BLL.AfficheType().Add(model);
            context.Response.Write("添加成功！");
            
        }  
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
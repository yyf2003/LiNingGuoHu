<%@ WebHandler Language="C#" Class="UpdateWuLiu"     %>

using System;
using System.Web;

public class UpdateWuLiu : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //返回值
        int _return = 0;
        //获取物流公司编号
        string id = context.Request["id"] == null ? "0" : context.Request["id"].ToString();
        //获取修改后的联系人
        string name = context.Request["name"] == null ? "0" : context.Request["name"].ToString();
        //获取修改后的联系人
        string photo = context.Request["photo"] == null ? "0" : context.Request["photo"].ToString();
        if (id != "0")
        {
            _return = new LN.BLL.PhysicalCompanyData().Update(Int32.Parse(id), name, photo);
        }
        
        context.Response.Write(_return.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
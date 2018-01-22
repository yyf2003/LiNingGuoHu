<%@ WebHandler Language="C#" Class="updateSupplierMaterial" %>

using System;
using System.Web;

public class updateSupplierMaterial : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _return = "0";
        //获取材料编号
        string mID = context.Request.QueryString["mID"] == null ? "0" : context.Request.QueryString["mID"].ToString();
        //获取材料名称
        string mName = context.Request.QueryString["name"] == null ? "0" : context.Request.QueryString["name"].ToString();

        LN.Model.POPMateriaData model = new LN.Model.POPMateriaData();
        model.MateriaID = Int32.Parse(mID);
        model.MateriaPro = mName;
        
        //获取添加结果
        int result = new LN.BLL.POPMateriaData().Update(model);
        if (result > 0)
            _return = result.ToString();
        
        context.Response.Write(_return);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
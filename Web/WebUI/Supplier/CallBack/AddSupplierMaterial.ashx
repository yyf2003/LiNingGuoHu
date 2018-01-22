<%@ WebHandler Language="C#" Class="AddSupplierMaterial" %>

using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using LN.DBUtility;
public class AddSupplierMaterial : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string _return = "0";
        //获取用户编号
        string userID = context.Request.QueryString["uID"] == null ? "0" : context.Request.QueryString["uID"].ToString();
        //获取材料名称
        string mName = context.Request.QueryString["name"] == null ? "0" : context.Request.QueryString["name"].ToString();
        string ctype = context.Request.QueryString["ctype"] == null ? "0" : context.Request.QueryString["ctype"].ToString();
        //获取添加结果
        int result = new LN.BLL.POPMateriaData().Add(mName, userID,ctype);
        IList<LN.Model.SupplierInfo> supplierlist = new LN.BLL.SupplierInfo().GetList(" supplierState=1");
        List<string> sqllist = new List<string>();
        foreach (LN.Model.SupplierInfo model in supplierlist)
        {
            sqllist.Add("insert into POPMaterialPrice select " + model.SupplierID + ",(select max(MateriaID) from POPMateriaData),0,"+userID+",getdate()");
        }
        DbHelperSQL.ExecuteSqlTran(DbHelperSQL.connectionString(), sqllist);
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
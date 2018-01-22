<%@ WebHandler Language="C#" Class="IsDeleteMaterial" %>

using System;
using System.Web;

public class IsDeleteMaterial : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string _return = "0";
        //获取用户编号
        string mID = context.Request.QueryString["mID"] == null ? "0" : context.Request.QueryString["mID"].ToString();
        //获取材料名称
        string isDelete = context.Request.QueryString["isDelete"] == null ? "0" : context.Request.QueryString["isDelete"].ToString();
        //获取添加结果
        int result = new LN.BLL.POPMateriaData().IsDelete(Int32.Parse(mID),Int32.Parse(isDelete));
        if (result > 0)
            _return = result.ToString();

        context.Response.Write(_return);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
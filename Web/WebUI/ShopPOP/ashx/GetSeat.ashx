<%@ WebHandler Language="C#" Class="GetSeat" %>

using System;
using System.Web;
using LN.DBUtility;
using System.Web.SessionState;
using System.Collections.Generic;

public class GetSeat : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string result = "<option value=\"0\">请选择</option>";
        string strSeat = context.Request["seat"] == null ? "" : context.Request["seat"].ToString();

        IList<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetList(" vsl.shopid=-1 and popseat='" + strSeat + "'");
        //IList<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetList(" vsl.shopid=-1");
        foreach (LN.Model.POPInfo model in list)
        {
            //result += "<option value=\"0\">" + model.POPMaterial + "|" + model.RealWith + "|" + model.RealHeight + "|" + model.POPWith + "|" + model.POPHeight + "</option>";
            result += "<option value=\"0\">" + model.POPMaterialRemark + "</option>";
        }

        //if (ConnStrName != "")
        //{
        //    context.Response.Cookies["ConnStrName"].Value = ConnStrName;
        //    context.Response.Cookies["ConnStrName"].Expires = DateTime.Now.AddDays(1);
        //    result = "1";
        //}

        context.Response.Write(result);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
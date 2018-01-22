<%@ WebHandler Language="C#" Class="JoinPopLanuch" %>

using System;
using System.Web;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

public class JoinPopLanuch : IHttpHandler {

    HttpContext _context;
    string result = "";
    public void ProcessRequest(HttpContext context)
    {
        _context = context;
        context.Response.ContentType = "text/plain";

        if (_context.Request["method"] == null) return;
        string strMethod = _context.Request["method"].Trim();
        MethodInfo mi = this.GetType().GetMethod(strMethod);
        if (mi != null) mi.Invoke(this, null);

        context.Response.Write(result);
        context.Response.End();
    }

    public void JoinIntoPopLanuch()
    {
        if (new LN.BLL.POPChangeSet().JoinPopLanuch(_context.Request["shopid"]) > 0)
        {
            result = "1";
        }
    }

    /// <summary>
    /// 获取省份或城市列表
    /// </summary>
    public void getCity()
    {
        //if (_context.Request["parentId"] == null) return;
        //string strParentId = _context.Request["parentId"].ToString();

        //int ParentId = int.Parse(strParentId);
        //CityBLL bll = new CityBLL();
        //List<City> cityLis = bll.GetCityList(ParentId);
        //foreach (City obj in cityLis)
        //{
        //    result += "<option value=\"" + obj.CityId.ToString() + "\">" + obj.CityName + "</option>";
        //}
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
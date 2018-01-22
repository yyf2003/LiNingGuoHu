<%@ WebHandler Language="C#" Class="GetAreaByDepID" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;

public class GetAreaByDepID : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //获取部门编号
        string depName = context.Request.QueryString["depName"] == null ? "0" : context.Request.QueryString["depName"].ToString();

        //返回给客户端的字符串
        string _return = String.Empty;
        //查询条件
        string strWhere = string.Format("department='{0}'", depName);

        IList<LN.Model.AreaData> list = new LN.BLL.AreaData().GetList(strWhere);
        _return = "[";
        StringBuilder sb = new StringBuilder();
        if (list != null && list.Count > 0)
        {
            foreach (LN.Model.AreaData model in list)
            {
                sb.Append("{AreaID:\"" + model.AreaID.ToString() + "\"");
                sb.Append(",AreaName:\"" + model.AreaName + "\"");
                sb.Append(",DepartMent:\"" + model.DepartMent.ToString() + "\"},"); 
            }
        }
        else
        {
            sb.Append("{AreaID:\"0\",AreaName:\"\",DepartMent:\"\"}");
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
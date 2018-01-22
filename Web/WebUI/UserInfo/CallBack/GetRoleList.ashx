<%@ WebHandler Language="C#" Class="GetRoleList" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;

public class GetRoleList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        IList<LN.Model.UserTypeData> list = new LN.BLL.UserTypeData().GetList("");

        StringBuilder sb = new StringBuilder();
        if (list.Count > 0)
        {
            bool IsFirst = true;
            foreach (LN.Model.UserTypeData item in list)
            {
                if (IsFirst == true)
                {
                    sb.AppendFormat("<input name=\"TypeRadio\" type=\"radio\" checked=\"checked\" value=\"{0}\" onclick='javascript:getList.GetRolePageList(this.value);' />{1}<br />", item.UserTypeID.ToString(), item.Usertype);
                    IsFirst = false;
                }
                else
                    sb.AppendFormat("<input name=\"TypeRadio\" type=\"radio\" value=\"{0}\"  onclick='javascript:getList.GetRolePageList(this.value);' />{1}<br />", item.UserTypeID.ToString(), item.Usertype);

            }
        }
        else
            sb.Append("");
        context.Response.Write(sb.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
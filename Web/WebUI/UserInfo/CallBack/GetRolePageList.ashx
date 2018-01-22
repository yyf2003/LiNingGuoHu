<%@ WebHandler Language="C#" Class="GetRolePageList" %>

using System;
using System.Web;
using System.Text;
using System.Collections.Generic;

public class GetRolePageList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string rid = context.Request["id"] == null ? "0" : context.Request["id"].Trim();
        string _return = String.Empty;
        StringBuilder sb = new StringBuilder();
        IList<LN.Model.sysFunction> list = new LN.BLL.sysFunction().GetList("");
        //获取指定权限编号所授权的功能编号
        IList<LN.Model.roleAndPower> pageList = new LN.BLL.roleAndPower().GetList(" roleId = " + rid);
        //功能编号集合
        List<string> pList = new List<string>();
        if (pageList.Count > 0)
        {
            string[] array = pageList[0].functionId.Split(new char[] { ',' });
            for (int i = 0; i < array.Length; i++)
            {
                pList.Add(array[i].Trim());
            }
        }
        _return = "[";
        if (list.Count > 0)
        {
            foreach (LN.Model.sysFunction item in list)
            {
                sb.Append("{id:\"" + item.id.ToString() + "\"");
                sb.Append(",funcName:\"" + item.funcName + "\"");
                sb.Append(",callFormClass:\"" + item.callFormClass + "\"");
                sb.Append(",upId:\"" + item.upId.ToString() + "\"");
                sb.Append(",FolderName:\"" + item.FolderName + "\"");
                if (pList.Contains(item.id.ToString()))
                    sb.Append(",IsCheck:\"1\"");
                else
                    sb.Append(",IsCheck:\"0\"");
                sb.Append(",LevelNum:\"" + item.LevelNum.ToString() + "\"},");
            }
        }
        else
        {
            sb.Append("{id:\"0\",funcName:\"\",callFormClass:\"\",upId:\"\",FolderName:\"\",IsCheck:\"\",LevelNum:\"\"}");
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
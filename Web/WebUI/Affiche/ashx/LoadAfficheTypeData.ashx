<%@ WebHandler Language="C#" Class="LoadAfficheTypeData" %>

using System;
using System.Web;
using System.Collections.Generic;

public class LoadAfficheTypeData : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        List<LN.Model.AfficheType> list = new LN.BLL.AfficheType().GetModelList("IsDel =0 ");
        string start_option = " <select name=\"categoryId\" id=\"categoryId\">";
        string end_option = "</select>";
        string option = "";
        if (list.Count > 0)
        {
            foreach (LN.Model.AfficheType item in list)
            {
                option += "  <option value=\"" + item.ID + "\">" + item.Type + "</option>";
            }
        }
        else
        {
            option = " <option value='0'> 默认 </option>";
        }
        context.Response.Write(start_option + option + end_option);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
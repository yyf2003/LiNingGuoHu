<%@ WebHandler Language="C#" Class="AddAfficheTypeForAdd" %>

using System;
using System.Web;
using System.Collections.Generic;
public class AddAfficheTypeForAdd : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string typeName = context.Request.QueryString["TypeName"];
        if (typeName != null && typeName != "")
        {
            LN.Model.AfficheType model = new LN.Model.AfficheType();
            model.Type = typeName;
            string start_option = " <select name=\"categoryId\" id=\"categoryId\">";
            string end_option = "</select>";
            string option = "";
            if (new LN.BLL.AfficheType().Add(model) > 0)
            {
                List<LN.Model.AfficheType> list = new LN.BLL.AfficheType().GetModelList("IsDel =0 ");
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
            }
            context.Response.Write(start_option + option + end_option);

        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
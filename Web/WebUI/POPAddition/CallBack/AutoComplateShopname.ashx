<%@ WebHandler Language="C#" Class="AutoComplateShopname" %>

using System;
using System.Web;
using System.Data;

public class AutoComplateShopname : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string shopname = context.Request.QueryString["ShopName"];
        string divitem = "";
        if (shopname != null && shopname != "")
        {
            DataTable dt = new LN.BLL.ShopInfo().GetAutoComplateShopname(shopname).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    divitem += "  <div onmouseover=\"this.style.backgroundColor='#3366cc'\" onmouseout=\"this.style.backgroundColor=''\" onclick=\"setval(this.innerText)\">" + dt.Rows[i]["Shopname"].ToString() + "</div>";
                }
            }
        }
        context.Response.Write(divitem);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
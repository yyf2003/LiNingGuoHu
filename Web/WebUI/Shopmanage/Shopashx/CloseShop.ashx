<%@ WebHandler Language="C#" Class="CloseShop" %>

using System;
using System.Web;

public class CloseShop : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        string shopip=context.Request.QueryString["shopid"].ToString();
        string closeID = context.Request.Cookies["UserID"].Value.ToString();
       // string closeID = context.Request.QueryString["closeID"].ToString();
        LN.BLL.ShopInfo BLL = new LN.BLL.ShopInfo();
        bool s=  BLL.CloseShopState(int.Parse(shopip),int.Parse(closeID));
        string sb = "";
        sb="[{OK:\""+s.ToString()+"\"}]";
        context.Response.Write(sb);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="receiveGoods" %>

using System;
using System.Web;

public class receiveGoods : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string userid = context.Request.QueryString["uid"].ToString();//操作人
        string rdate = context.Request.QueryString["rdate"].ToString();//收货时间
        string fs = context.Request.QueryString["fs"].ToString();//分数
        string pj = context.Request.QueryString["pj"].ToString();//评价
        string popid = context.Request.QueryString["popid"].ToString();//发起的popid
        string shopid = context.Request.QueryString["shopid"].ToString();
        shopid = shopid.Remove(shopid.Length - 1);
        new LN.BLL.ShippingSpeedData().RecevieGoods(popid, rdate, userid, fs, pj, shopid);
        context.Response.Write("ok");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
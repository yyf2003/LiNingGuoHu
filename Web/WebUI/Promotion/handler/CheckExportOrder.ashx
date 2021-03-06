﻿<%@ WebHandler Language="C#" Class="CheckExportOrder" %>

using System;
using System.Web;
using System.Web.SessionState;

public class CheckExportOrder : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
       
        HttpCookie cookie = context.Request.Cookies["export"];
        string result = cookie != null ? cookie.Value : "0";
        if (result == "1")
        {
            cookie.Value = "0";
            cookie.Expires = DateTime.Now.AddMinutes(30);
            context.Response.Cookies.Add(cookie);
            result = "ok";

        }
        context.Response.Write(result);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
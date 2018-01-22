﻿<%@ WebHandler Language="C#" Class="GetShopList" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Data;
public class GetShopList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string pid = context.Request.QueryString["Posid"] != null ? context.Request.QueryString["Posid"].ToString() : "";
        string sname = context.Request.QueryString["Sname"] != null ? context.Request.QueryString["Sname"].ToString() : "";
        string proid = context.Request.QueryString["province"] != null ? context.Request.QueryString["province"].ToString() : "0";
        string cityid = context.Request.QueryString["cityid"] != null ? context.Request.QueryString["cityid"].ToString() : "0";
        string dealerid = context.Request.QueryString["dealerid"] != null ? context.Request.QueryString["dealerid"].ToString() : "";
        string installID = context.Request.QueryString["install"] != null ? context.Request.QueryString["install"].ToString() : "-1";
        string typeid = context.Request.QueryString["typeid"] != null ? context.Request.QueryString["typeid"].ToString() : "0";
        string saleid = context.Request.QueryString["saleid"] != null ? context.Request.QueryString["saleid"].ToString() : "0";
        string StateID = context.Request.QueryString["sstate"] != null ? context.Request.QueryString["sstate"].ToString() : "-1";
        string Username = context.Request.Cookies["UserName"].Value;
        string pageIndex = context.Request.QueryString["page"] != null ? context.Request.QueryString["page"].ToString() : "1";
        string PageSize = context.Request.QueryString["psize"] != null ? context.Request.QueryString["psize"].ToString() : "20";
        LN.BLL.ShopInfo BLL = new LN.BLL.ShopInfo();

        Hashtable hdt = new Hashtable();
        hdt.Add("pid", pid);
        hdt.Add("sname", sname);
        hdt.Add("proid", proid);
        hdt.Add("cityid", cityid);
        hdt.Add("dealerid", dealerid);
        hdt.Add("installID", installID);
        hdt.Add("typeid", typeid);
        hdt.Add("saleid", saleid);
        hdt.Add("stateID",StateID);
        hdt.Add("Fxid", "0");
       // ----------------------------------------
        hdt.Add("pageindex", pageIndex);//的几页
        hdt.Add("PageSize", PageSize);//每页显示多少行
        //得到店铺信息列表
        int TotalNumber = 0;
        Username=context.Server.UrlDecode(Username);
        hdt.Add("dsrmaster", Username);
        DataTable dt=  BLL.GetInfolist(hdt,ref TotalNumber);
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append("{");
            sb.Append("sID");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["ShopID"].ToString());
            sb.Append("\",");
            sb.Append("pID");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["PosID"].ToString());
            sb.Append("\",");
            sb.Append("SName");
            sb.Append(":\"");
            sb.Append("<a href='../Shopmanage/OneShopInfo.aspx?shopid=" + dt.Rows[i]["ShopID"].ToString() + "'>" + dt.Rows[i]["ShopName"].ToString() + "</a>");
            sb.Append("\",");
            sb.Append("jxs");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["DealerName"].ToString());
            sb.Append("\",");
            sb.Append("sf");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["ProvinceName"].ToString());
            sb.Append("\",");
            sb.Append("cs");
            sb.Append(":\"");
            sb.Append(dt.Rows[i]["cityname"].ToString());
            sb.Append("\",");
            sb.Append("TotalNumber");
            sb.Append(":\"");
            sb.Append(TotalNumber.ToString());
            sb.Append("\",");
            sb.Append("xg");//检查
            sb.Append(":\"");

            sb.Append("<a href='DSRCheckShop.aspx?shopid=" + dt.Rows[i]["ShopID"].ToString() + "&sname=" + dt.Rows[i]["ShopName"].ToString() + "'>检 查</a>");
            sb.Append("\",");
            sb.Append("gd");//查看
            sb.Append(":\"");
            sb.Append("<a href='ShopRecordList.aspx?shopid=" + dt.Rows[i]["ShopID"].ToString() + "&sname=" + dt.Rows[i]["ShopName"].ToString() + "'>查 看</a>");

            sb.Append("\"},");
        }
        if (dt.Rows.Count <= 0)
        {
            sb.Append("{");
            sb.Append("sID");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("pID");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("SName");
            sb.Append(":\"");
            sb.Append("<font color='red'>没有你所要的店铺！</font>");
            sb.Append("\",");
            sb.Append("jxs");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("sf");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("cs");
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("TotalNumber");
            sb.Append(":\"");
            sb.Append("0");
            sb.Append("\",");
            sb.Append("xg");//检查
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\",");
            sb.Append("gd");//查看
            sb.Append(":\"");
            sb.Append("");
            sb.Append("\"},"); 
        }
        context.Response.Write(sb.ToString().Substring(0, sb.ToString().Length - 1) + "]");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
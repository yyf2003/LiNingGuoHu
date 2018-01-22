﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_Shopmanage_shopinfodaochu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pid = Request.QueryString["Posid"] != null ? Request.QueryString["Posid"].ToString() : "";
        string sname = Request.QueryString["Sname"] != null ? Request.QueryString["Sname"].ToString() : "";
        string proid = Request.QueryString["province"] != null ? Request.QueryString["province"].ToString() : "0";
        string cityid = Request.QueryString["cityid"] != null ? Request.QueryString["cityid"].ToString() : "0";
        string dealerid = Request.QueryString["dealerid"] != null ? Request.QueryString["dealerid"].ToString() : "";
        string installID = Request.QueryString["install"] != null ? Request.QueryString["install"].ToString() : "-1";
        string typeid = Request.QueryString["typeid"] != null ? Request.QueryString["typeid"].ToString() : "0";
        string saleid = Request.QueryString["saleid"] != null ? Request.QueryString["saleid"].ToString() : "0";
        string StateID = Request.QueryString["sstate"] != null ? Request.QueryString["sstate"].ToString() : "-1";
        string Fxid = Request.QueryString["Fxid"] != null ? Request.QueryString["Fxid"].ToString() : "0";



        string department = Request.QueryString["department"].ToString();//部门
        string areaid = Request.QueryString["areaid"].ToString();//区域
        string Citylevel = Request.QueryString["Citylevel"].ToString();//地市级城市级别

        string townlevel = Request.QueryString["townlevel"].ToString();//区县级城市级别

        string CusCard = Request.QueryString["CusCard"].ToString();//客户身份
        string CusID = Request.QueryString["CusID"].ToString();//上级客户编号
        string CusLevel = Request.QueryString["CusLevel"].ToString();//上级客户级别
        string CusShip = Request.QueryString["CusShip"].ToString();//客户产权关系
        string ShopLevel = Request.QueryString["ShopLevel"].ToString();//店铺级别
        string shopArea = Request.QueryString["shopArea"].ToString() == "" ? "0" : Request.QueryString["shopArea"].ToString();//营业面积
        string supplierID = Request.QueryString["supplierID"].ToString() == "" ? "0" : Request.QueryString["supplierID"].ToString();//所属供应商

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
        hdt.Add("stateID", StateID);
        hdt.Add("Fxid", Fxid);
        hdt.Add("department", department);
        hdt.Add("areaid", areaid);
        hdt.Add("Citylevel", Citylevel);
        hdt.Add("townlevel", townlevel);
        hdt.Add("CusCard", CusCard);
        hdt.Add("CusID", CusID);
        hdt.Add("CusLevel", CusLevel);
        hdt.Add("CusShip", CusShip);
        hdt.Add("ShopLevel", ShopLevel);
        hdt.Add("shopArea", shopArea);
        hdt.Add("supplierID", supplierID);

        DataTable dt = BLL.GetShop_infolist(hdt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "GB2312";  //设置了类型为中文防止乱码的出现  
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddhhmmss") + "OrderList.xls"); //定义输出文件和文件名
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");//设置输出流为简体中文

        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
        this.EnableViewState = false;
        System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        //this.GridView1.RenderControl(oHtmlTextWriter);
        // Session["otherdt"] = null;

        Response.Write(oStringWriter.ToString());
    }
}

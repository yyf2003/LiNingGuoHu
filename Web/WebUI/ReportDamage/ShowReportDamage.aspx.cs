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

public partial class WebUI_ReportDamage_ShowReportDamage : System.Web.UI.Page
{
    public string ShopID = string.Empty;
    public string ShopName = string.Empty;
    public string UserID = string.Empty;
    public string StartTime = string.Empty;
    public string EndTime = string.Empty;
    public string Stataion = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (this.Request.QueryString["ShopID"] == null)
        {
            Response.Redirect("../../Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                GetReportData();
            }
        }
    }
    public void GetReportData()
    {
        string Ary = "";
        if (this.Request.Cookies["UserID"] != null)
        {
            UserID = this.Request.Cookies["UserID"].Value;
        }
        if (this.Request.QueryString["StartTime"] != null)
        {
            StartTime = this.Request.QueryString["StartTime"].ToString();
            EndTime = this.Request.QueryString["EndTime"].ToString();
            Ary = " UpPOPDate between '" + StartTime + "' and '" + EndTime + "'";
        }
        if (this.Request.QueryString["Station"] != null)
        {
            Stataion = this.Request.QueryString["Station"].ToString();
            if (Ary == "")
                Ary = " VMState =" + Stataion + " ";
            else
                Ary += "and  VMState =" + Stataion + "";
        }  
        if (Ary == "")
        {
            ShopID = this.Request.QueryString["ShopID"].ToString();
            ShopName = new LN.BLL.ShopInfo().GetModel(int.Parse(ShopID)).Shopname;
            DataTable dt = new LN.BLL.POPReprotDamage().GetList("ShopID=" + ShopID + " order by VMState asc ").Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
            this.DataBind();
        }
        else
        {
            ShopID = this.Request.QueryString["ShopID"].ToString();
            ShopName = new LN.BLL.ShopInfo().GetModel(int.Parse(ShopID)).Shopname;
            DataTable dt = new LN.BLL.POPReprotDamage().GetList("ShopID=" + ShopID + "  and " + Ary).Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
            this.DataBind();
        }


    }

    /// <summary>
    /// 得到颠仆pscode
    /// </summary>
    /// <param name="ShopID"></param>
    /// <returns></returns>
    public string GetShopPosCodeWithShopID(string ShopID)
    {
        string PsCode = "";
        DataTable dt = new LN.BLL.ShopInfo().GetList("ShopID= " + ShopID + "").Tables[0];
        if (dt.Rows.Count > 0)
        {
            PsCode = dt.Rows[0]["PosID"].ToString();
        }
        return PsCode;
    }
    /// <summary>
    /// 得到店铺名称
    /// </summary>
    /// <param name="ShopID"></param>
    /// <returns></returns>
    public string GetShopName(string ShopID)
    {
        string Shopname = "";
        DataTable dt = new LN.BLL.ShopInfo().GetList("ShopID= " + ShopID + "").Tables[0];
        if (dt.Rows.Count > 0)
        {
            Shopname = dt.Rows[0]["Shopname"].ToString();
        }
        return Shopname;
    }
    /// <summary>
    /// 得到提交人姓名 
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    public string GetUserName(string UserID)
    {
        return new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Username;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        GetReportData();

    }
}

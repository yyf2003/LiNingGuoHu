using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_ReportDamage_SupplierReport : System.Web.UI.Page
{
    public string StartTime = string.Empty;
    public string EndTime = string.Empty;
    public string SupplierName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (this.Request.Cookies["UserID"] == null)
        {
            Response.Redirect("../../Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                string UserID = this.Request.Cookies["UserID"].Value;
                IList<int> list = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
                hidSupplierID.Value = list[0].ToString();
                SupplierName = new LN.BLL.SupplierInfo().GetModel(list[0]).SupplierName;
                LoadReprotDamageData();
                this.DataBind(); 
            }
        }
    }
    public void LoadReprotDamageData()
    {
        string ary = "";
        string suppid = "";
        if (this.Request.QueryString["StartTime"] != null)
        {
            StartTime = this.Request.QueryString["StartTime"].ToString();
            EndTime = this.Request.QueryString["EndTime"].ToString();
            ary = "UpPOPDate between '" + StartTime + "' and '" + EndTime + "'";
        }
        if (hidSupplierID.Value != "")
        { 
            suppid = hidSupplierID.Value; 
            if (ary == "")
            {
                if (suppid != "")
                {
                    if (ary == "") 
                        ary = "supplierid =" + hidSupplierID.Value + "";
                    else
                        ary += " and supplierid =" + hidSupplierID.Value + "";  
                }
            }
        }
        string sql = ary;
        DataTable dt = new LN.BLL.POPReprotDamage().GetPopReportDamageData(sql);
        if (dt.Rows.Count > 0)
        {
            this.GridView1.DataSource = dt;
            GridView1.DataBind();
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        LoadReprotDamageData();
    }
}

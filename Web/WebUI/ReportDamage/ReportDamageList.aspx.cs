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

public partial class WebUI_ReportDamage_ReportDamageList : System.Web.UI.Page
{
    public string StartTime = string.Empty;
    public string EndTime = string.Empty;
    public string SupplierID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadReprotDamageData();
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
        if (this.Request.QueryString["SupplierID"] != null)
        {

            SupplierID = this.Request.QueryString["SupplierID"].ToString();
            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierName ='" + SupplierID + "'");
            if (list.Count > 0)
            {
                foreach (LN.Model.SupplierInfo model in list)
                {
                    suppid = model.SupplierID.ToString();
                }
            }
            if (ary == "")
            {
                if (suppid != "")
                {
                    if (ary == "")

                        ary = "supplierid =" + SupplierID + "";
                    else
                        ary += " and supplierid =" + SupplierID + "";

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

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_Analysis_Default : System.Web.UI.Page
{
 protected string pro=string.Empty, cailiao = string.Empty, POPID = string.Empty, PosCode = string.Empty, Shopname = string.Empty;
 protected string SID = string.Empty, DID = string.Empty, areaID = string.Empty, ProvinceID = string.Empty, CityID = string.Empty, prolines = string.Empty,year=string.Empty,fxid=string.Empty;
 protected double area = 0.0000;
 protected double price = 0.000;
 protected int num = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        POPID = Request.QueryString["POPID"].ToString();
        PosCode = Request.QueryString["PosCode"].ToString();
        Shopname = Request.QueryString["Shopname"].ToString();
        SID = Request.QueryString["SID"].ToString();
        DID = Request.QueryString["DID"].ToString();
        areaID = Request.QueryString["areaID"].ToString();
        ProvinceID = Request.QueryString["ProvinceID"].ToString();
        CityID = Request.QueryString["CityID"].ToString();
        prolines = Request.QueryString["prolines"].ToString();
        fxid = Request.QueryString["fxid"].ToString();
        if (Request.QueryString["cailiao"] != null)
            cailiao = Request.QueryString["cailiao"].ToString();
        if (Request.QueryString["pro"] != null)
        {
            prolines = Request.QueryString["pro"].ToString();
           
        }
        year = Request.QueryString["year"].ToString();
        bind();

    }
    private void bind()
    {
        Hashtable ht = new Hashtable();
        ht.Add("POPID", POPID);
        ht.Add("PosCode", PosCode);
        ht.Add("Shopname", Shopname);
        ht.Add("SupplierID", SID);
        ht.Add("DealerID", DID);
        ht.Add("areaID", areaID);
        ht.Add("ProvinceID", ProvinceID);
        ht.Add("CityID", CityID);
        ht.Add("fxid",fxid);
        ht.Add("OrderField", "totalprice desc");
        ht.Add("pageSize", ListPages.PageSize.ToString());
        ht.Add("pageIndex", ListPages.CurrentPageIndex.ToString());
        ht.Add("prolines", prolines);
        
        ht.Add("cailiao", cailiao);
        ht.Add("year", year);
        int totalnum = 0;
        DataTable dt = new LN.BLL.POPLaunch().EveryShopPOP(ht,  out totalnum);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            area += double.Parse(dt.Rows[i]["totalarea"].ToString());
            price += double.Parse(dt.Rows[i]["totalprice"].ToString());
            num += int.Parse(dt.Rows[i]["totalnum"].ToString());
        }
        ListPages.RecordCount = totalnum;
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
    protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPages.CurrentPageIndex = e.NewPageIndex;
        bind();
    }
}

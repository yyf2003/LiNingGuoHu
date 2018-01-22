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

public partial class WebUI_POPLanuch_GetShopByCity : System.Web.UI.Page
{
    string citylist = string.Empty, townlist = string.Empty, levellist = string.Empty, typelist = string.Empty, VIlist = string.Empty, SaleType = string.Empty, ShopACL = string.Empty, ShopTCL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
       //string ProIDlist = Request.Form["province"] == null ? "" : Request.Form["province"].ToString();
        //citylist = Request.QueryString["citylist"].ToString();
        //townlist = Request.QueryString["townlist"].ToString();
        string ProIDlist = Request.QueryString["province"].ToString();
        levellist = Request.QueryString["levellist"].ToString();
        typelist = Request.QueryString["typelist"].ToString();
        VIlist = Request.QueryString["VIlist"].ToString();
        SaleType = Request.QueryString["SaleType"].ToString();
        ShopACL = Request.QueryString["AreaCityLevel"].ToString();
        ShopTCL = Request.QueryString["TownCityLevel"].ToString();

        //if (townlist.Length > 0)
        //{
        //    DataSet ds = new LN.BLL.ShopInfo().GetSublist(" ExamState=1 and ShopState=1 and  TownID in (" + townlist + ") and shoplevelID in (" + levellist + ") and shoptype in (" + typelist + ") and ShopVI in (" + VIlist + ") order by shopname");
        //    DataTable dt = ds.Tables[0];
        //    Repeater1.DataSource = dt;
        //    Repeater1.DataBind();
        //}
        //else
        //{
        //    if (citylist.Length > 0)
        //    {
        //        DataSet ds = new LN.BLL.ShopInfo().GetSublist(" ExamState=1 and ShopState=1 and  CityID in (" + citylist + ") and shoplevelID in (" + levellist + ") and shoptype in (" + typelist + ") and ShopVI in (" + VIlist + ") order by shopname");
        //        DataTable dt = ds.Tables[0];
        //        Repeater1.DataSource = dt;
        //        Repeater1.DataBind();
        //    }
        //    else
        //    {

        //        if (ProIDlist.Length > 0)
        //        {
        //            DataSet ds = new LN.BLL.ShopInfo().GetSublist(" ExamState=1 and ShopState=1 and  provinceID in (" + ProIDlist + ") and shoplevelID in (" + levellist + ") and shoptype in (" + typelist + ") and ShopVI in (" + VIlist + ") order by shopname");
        //            DataTable dt = ds.Tables[0];
        //            Repeater1.DataSource = dt;
        //            Repeater1.DataBind();

        //        }
        //    }
        //}

        if (ProIDlist.Length > 0)
        {
            DataSet ds = new LN.BLL.ShopInfo().GetSublist(" ExamState=1 and ShopState=1 and  provinceID in (" + ProIDlist + ") and shoplevelID in (" + levellist + ") and shoptype in (" + typelist + ") and ShopVI in (" + VIlist + ") and SaleTypeID in (" + SaleType + ") and TCL_ID in (" + ShopACL + ") and ACL_ID in (" + ShopTCL + ") order by shopname");
            DataTable dt = ds.Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }
    }
}

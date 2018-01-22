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

public partial class WebUI_POPLanuch_POPLaunchEvaryShopPOP : System.Web.UI.Page
{
    protected string suppliername = string.Empty, POPID = string.Empty,prolist=string.Empty,supplierid=string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        POPID = Request.QueryString["POPID"].ToString();
        suppliername = Request.QueryString["sname"].ToString();
        prolist = Request.QueryString["prolist"].ToString();
        supplierid = Request.QueryString["sid"].ToString();
        if (!Page.IsPostBack)
        {
            bind();
        }
    }

    protected void bind()
    {
        string tempprolist = prolist;
        //if (prolist.IndexOf('"') > 0)
        //{
        //    tempprolist = prolist.Replace('"','\'');
        //}
        int totalnum = 0;
        DataTable dt = new LN.BLL.POPLaunch().GetPOPlaunchshopPOPlist(POPID, supplierid, prolist, ListPages.CurrentPageIndex, ListPages.PageSize, out totalnum);
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

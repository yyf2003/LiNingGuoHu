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
using System.Data.SqlClient;

public partial class WebUI_Shopmanage_ShopOrderformDetail : System.Web.UI.Page
{
    public string POPID = "";
    public string ShopID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {

        POPID = Request.QueryString["POPID"] == null ? "" : Request.QueryString["POPID"].ToString();
        ShopID = Request.QueryString["ShopID"] == null ? "" : Request.QueryString["ShopID"].ToString();
        Hashtable hdt = new Hashtable();
        hdt.Add("POPID", POPID);
        hdt.Add("ShopID", ShopID);

        DataTable dt = new LN.BLL.POPInfo().GetShopPOPInfoList(hdt);
        RepPOPList.DataSource = dt;
        RepPOPList.DataBind();
    }
}

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

public partial class WebUI_Supplier_Supplier_OrderListImg : System.Web.UI.Page
{
    protected string suppliername = string.Empty, POPID = string.Empty,supplierid=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        suppliername = Request.QueryString["sname"].ToString();
        supplierid = Request.QueryString["sid"].ToString();
        POPID = Request.QueryString["POPID"].ToString();

        DataTable dt = new LN.BLL.imageToPOP().Supplier_popcountByimg(" and imagetoPOP.POPID='"+POPID+"' and supplierid="+supplierid);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
}

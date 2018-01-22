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

public partial class WebUI_DSRCheck_OneDsrCheckshop : System.Web.UI.Page
{
    protected  string POPID = string.Empty, checkuser = string.Empty, checkname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        POPID = Request.QueryString["POPID"].ToString();
        checkuser = Request.QueryString["checkuser"].ToString();
        checkname = Request.QueryString["checkname"].ToString();
        DataSet ds = new LN.BLL.DSRExamData().GetList(" POPID='" + POPID + "' and CheckUserID="+checkuser);
        DataTable dt = ds.Tables[0];

        Repeater1.DataSource = dt;
        Repeater1.DataBind();

    }
}

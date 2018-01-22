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

public partial class WebUI_POPLanuch_del : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string POPID = Request.QueryString["POPID"].ToString();

        try
        {
            new LN.BLL.POPLaunch().delpoplaunch(POPID);
            Response.Redirect("POPindex.aspx");
        }
        catch (Exception)
        {

            Response.Redirect("POPindex.aspx");
        }
    }
}

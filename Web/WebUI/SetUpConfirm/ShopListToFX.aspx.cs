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

public partial class WebUI_SetUpConfirm_ShopListToFX : System.Web.UI.Page
{
    protected string UserID = string.Empty;
    protected string FXID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        FXID = new LN.BLL.DistributorsInfo().GetFXIdByUserID(UserID);
        if (string.IsNullOrEmpty(FXID))
            Response.Redirect("../../Error.aspx?param=15");
    }
}

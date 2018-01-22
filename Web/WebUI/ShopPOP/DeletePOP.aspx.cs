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

public partial class WebUI_ShopPOP_DeletePOP : System.Web.UI.Page
{
    string POPID = String.Empty;
    string ShopID = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        POPID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].Trim();
        ShopID = Request.QueryString["shopid"] == null ? "0" : Request.QueryString["shopid"].Trim();

        new LN.BLL.POPInfo().Delete(Int32.Parse(POPID));

        string returnURL = string.Format("./ShopPOPEditList.aspx?shopid={0}", ShopID);

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Yes", "<script>alert('该POP信息删除成功！！');window.location.href='" + returnURL + "'</script>");
    }
}

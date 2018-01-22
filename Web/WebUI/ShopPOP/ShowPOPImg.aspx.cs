using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class WebUI_ShopPOP_ShowPOPImg : System.Web.UI.Page
{
    private string POPInfoID = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        POPInfoID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString().Trim();

        IList<LN.Model.tb_POPInfo_Img> list = new LN.BLL.tb_POPInfo_Img().GetList(" Img_POPInfoID = " + POPInfoID);

        if (list.Count > 0)
        {
            RepShowImg.DataSource = list;
            RepShowImg.DataBind();
        }

    }
}

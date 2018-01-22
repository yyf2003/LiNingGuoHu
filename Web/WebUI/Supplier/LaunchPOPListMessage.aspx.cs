using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUI_Supplier_LaunchPOPListMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            BindLaunchPOP();
        }
    }

    /// <summary>
    /// 绑定POP发起的活动集合
    /// </summary>
    private void BindLaunchPOP()
    {
        IList<LN.Model.POPLaunch> list = new LN.BLL.POPLaunch().GetList("steps=0");
        if (list != null && list.Count > 0)
        {
            RepLaunchPOP.DataSource = list;
            RepLaunchPOP.DataBind();
        }
    }
}

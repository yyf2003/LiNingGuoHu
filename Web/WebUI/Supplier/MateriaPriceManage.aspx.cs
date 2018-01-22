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
using System.Collections.Generic;
public partial class WebUI_Supplier_MateriaPriceManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }

        IList<LN.Model.SupplierInfo> supplierlist = new LN.BLL.SupplierInfo().GetList(" supplierState=1");
        Repeater1.DataSource = supplierlist;
        Repeater1.DataBind();
    }
}

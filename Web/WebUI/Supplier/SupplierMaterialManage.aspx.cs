using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_Supplier_SupplierMaterialManage : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //用户编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;

        LN.BLL.POPMateriaData bll = new LN.BLL.POPMateriaData();

       DataTable dt= bll.GetMaterialListData("0");
       Session["MaterPro"] = null;
       Session["MaterPro"] = dt;
    }
}

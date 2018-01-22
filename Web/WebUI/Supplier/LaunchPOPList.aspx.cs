using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUI_Supplier_LaunchPOPList : System.Web.UI.Page
{
    protected string UserID = String.Empty;         //用户编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        string supplierID = "0";//如果是VM进来 供应商ID 为 0 
        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
        {
            supplierID = supplierBody[0].ToString();

        }
        if (supplierID == "0")
        {
            DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
                supplierID = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + userdt.Rows[0][0].ToString() + "'");
        }
        string strWhere = " IsDelete=0 ";
        if (supplierID != "")
        {
            strWhere += " and supplierid=" + supplierID;
        }
        DataSet priceds = new LN.BLL.POPMaterialPrice().GetList(strWhere);
        GridView1.DataSource = priceds.Tables[0];
        GridView1.DataBind();
        
    }
}

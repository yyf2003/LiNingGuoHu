using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LN.BLL;

public partial class WebUI_Promotion_Supprier_List : System.Web.UI.Page
{
    SupplierInfo supplierBll = new SupplierInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        IList<LN.Model.SupplierInfo> list = supplierBll.GetList("");
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }



    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
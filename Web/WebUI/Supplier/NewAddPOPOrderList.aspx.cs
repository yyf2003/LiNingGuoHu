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
using System.Text;
public partial class WebUI_Supplier_NewAddPOPOrderList : System.Web.UI.Page
{
    public string TotalCount = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;//得到用户ID
        if (!Page.IsPostBack)
        {
           
            //加载供应商

            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");
            foreach (LN.Model.SupplierInfo model in list)
            {
                ListItem item = new ListItem(model.SupplierName, model.SupplierID.ToString());
                DDL_Supplier.Items.Add(item);
            }
            //加载所有的 POP发起ID
            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                DDL_POPID.Items.Add(item);
            }

            string supplierID = "0";//如果是VM进来 供应商ID 为 0 
            IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
            if (supplierBody != null)
            {
                supplierID = supplierBody[0].ToString();
                DDL_Supplier.Text = supplierID;

                DDL_Supplier.Enabled = false;
            }
            bind();
        }
    }
    private void bind()
    {
        StringBuilder  sql=new StringBuilder();

        sql.Append(" 1=1 ");

        if (DDL_POPID.Text != "")
            sql.Append( " and NewAddPOP.POPID='" + DDL_POPID.Text + "'");
        if (DDL_Supplier.Text != "0")
            sql.Append(" and view_shopinfo.supplierid =" + DDL_Supplier.Text);
        string strBeginDate = txtBeginDate.Text.Trim();
        string strEndDate = txtEndDate.Text.Trim();
        if (strBeginDate != "")
            sql.Append(" and popinfo.SysTime>='" + strBeginDate + "' ");
        if (strEndDate != "")
            sql.Append(" and popinfo.SysTime<='" + strEndDate + "' ");

        DataTable dt = new LN.BLL.NewAddPOP().GetNewList(sql.ToString());

        Session["NewOrderlist"] = null;
        Session["NewOrderlist"] = dt;
        TotalCount = dt.Rows.Count.ToString();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind();
    }

 
}

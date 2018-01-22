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
public partial class WebUI_Supplier_Supplier_MateriaPrice : System.Web.UI.Page
{
    protected string suppliername = string.Empty,supplierID=string.Empty;
    string UserID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["sname"] != null)
                suppliername = Request.QueryString["sname"].ToString();

            if (Request.QueryString["sid"] != null)
            {
                supplierID = Request.QueryString["sid"].ToString();
                DataSet priceds = new LN.BLL.POPMaterialPrice().GetList(" IsDelete=0 and supplierid=" + Request.QueryString["sid"].ToString());
                GridView1.DataSource = priceds.Tables[0];
                GridView1.DataBind();
            }
            if (Request.QueryString["flag"] != null)
            {
                DataTable dt = new LN.BLL.POPMateriaData().GetTable("  IsDelete=0 ");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow) || (e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Visible = false;
        }
       
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (suppliername != "")
        {
            List<Hashtable> htlist = new List<Hashtable>();
            Hashtable ht = null;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                ht = new Hashtable();
                TextBox txtprice = (TextBox)gr.Cells[1].Controls[0].FindControl("txt_price");
                ht.Add("sid", supplierID);
                ht.Add("price", txtprice.Text == "" ? "0" : txtprice.Text);
                ht.Add("MID",gr.Cells[2].Text);
                ht.Add("UserID", UserID);

                htlist.Add(ht);
            }

            new LN.BLL.POPMaterialPrice().UpdatePrice_supplier(htlist);
        }
        if (Request.QueryString["flag"] != null)
        {
            List<Hashtable> htlist = new List<Hashtable>();
            Hashtable ht = null;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                ht = new Hashtable();
                TextBox txtprice = (TextBox)gr.Cells[1].Controls[0].FindControl("txt_price");
                ht.Add("price", txtprice.Text == "" ? "0" : txtprice.Text);
                ht.Add("MID", gr.Cells[2].Text);
                ht.Add("UserID", UserID);

                htlist.Add(ht);
            }

            new LN.BLL.POPMaterialPrice().UpdatePrice_all(htlist);
        }
    }
}

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

public partial class WebUI_Supplier_SupplierListByVM : System.Web.UI.Page
{
    int Pagei = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    protected void Bind()
    {
        IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");

        this.GridView1.DataSource = list;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            Pagei++;
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ECECEC'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            e.Row.Cells[0].Text = Pagei.ToString();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "allotArea")
        {
            Response.Redirect("ShowAllotArea.aspx?id=" + e.CommandArgument.ToString()+"&show=1");
        }
        //if (e.CommandName == "ExamPrice")
        //{
        //    Response.Redirect("ExamPrice.aspx?gID=" + e.CommandArgument.ToString());
        //}
        if (e.CommandName == "GiveUp")
        {
            Response.Redirect("GiveUp.aspx?gID=" + e.CommandArgument.ToString());
        }
    }
}

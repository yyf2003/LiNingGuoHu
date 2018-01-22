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

public partial class WebUI_SetUpConfirm_Show : System.Web.UI.Page
{
    public string para = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.QueryString["para"] != null)
        {
            if (!IsPostBack)
            {
                GetOneData();
            }
        }
        else
        {
            Response.Redirect("../../Login.aspx");
        }
    }
    public void GetOneData()
    {
        para = this.Request.QueryString["para"].ToString();
        DataTable dt = new LN.BLL.SetUpConfirm().GetListFromView("ID in (" + para + ")");
        this.GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        GetOneData();
    }
}

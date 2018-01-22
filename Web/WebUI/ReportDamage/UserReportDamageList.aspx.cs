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

public partial class WebUI_ReportDamage_UserReportDamageList : System.Web.UI.Page
{
    public string UserID = string.Empty;
    public string StartTime = string.Empty;
    public string EndTime = string.Empty;
    public string Stataion = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (this.Request.Cookies["UserID"] == null)
        {
            Response.Redirect("../../Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                LoadUserData();
            }
        } 
    }
    public void LoadUserData()
    {
        UserID = this.Request.Cookies["UserID"].Value;
        string Ary = "";
        if (this.Request.Cookies["UserID"] != null)
        {
            UserID = this.Request.Cookies["UserID"].Value;
        }
        if (this.Request.QueryString["StartTime"] != null)
        {
            StartTime = this.Request.QueryString["StartTime"].ToString();
            EndTime = this.Request.QueryString["EndTime"].ToString();
            Ary = " UpPOPDate between '" + StartTime + "' and '" + EndTime + "'";
        }
        if (this.Request.QueryString["Station"] != null)
        {
            Stataion = this.Request.QueryString["Station"].ToString();
            if (Ary == "")
                Ary = " VMState =" + Stataion + " ";
            else
                Ary += "and  VMState =" + Stataion + "";
        }
        if (Ary == "")
        { 
            DataTable dt = new LN.BLL.POPReprotDamage().GetList("UpUserID=" + UserID + " order by VMState asc ").Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
            this.DataBind();
        }
        else
        { 
            DataTable dt = new LN.BLL.POPReprotDamage().GetList("UpUserID=" + UserID + "  and " + Ary).Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
            this.DataBind();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        LoadUserData();
    }

}

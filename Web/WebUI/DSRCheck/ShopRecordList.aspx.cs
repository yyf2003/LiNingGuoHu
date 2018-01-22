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

public partial class WebUI_DSRCheck_ShopRecordList : System.Web.UI.Page
{
    public static int i = 0;    //计数
    protected  string shopid = "", sname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        shopid = Request.QueryString["shopid"].ToString();
        sname=Request.QueryString["sname"].ToString();
        if (!Page.IsPostBack)
        {
            bind(Txt_btime.Text.Trim(),Txt_etime.Text.Trim());
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        i = GridView1.PageIndex;
        bind(Txt_btime.Text.Trim(), Txt_etime.Text.Trim());
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int indexID = 1;
            indexID = i * this.GridView1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = indexID.ToString();
        }
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ECECEC'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            
            e.Row.Cells[9].Visible = false;
            
        }
    }

    public void bind(string btime,string etime)
    {
        string strWhere = " shopid="+shopid;
        if (btime.Length > 0)
        {
            strWhere =strWhere+ " and CheckDate>='"+btime+"'";
        }
        if (etime.Length > 0)
        {
            strWhere = strWhere + " and CheckDate<='"+etime+"'";
        }

        DataSet ds= new LN.BLL.DSRExamData().GetList(strWhere);

        this.GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "look")
        {
            Response.Redirect("ResultInfo.aspx?shopid=" + shopid + "&Did=" +e.CommandArgument.ToString());
        }
    }
}

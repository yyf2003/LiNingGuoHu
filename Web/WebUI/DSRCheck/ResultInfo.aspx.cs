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

public partial class WebUI_DSRCheck_ResultInfo : System.Web.UI.Page
{
    protected int noRules = 0;//gridView 第一列所显示的序列号
    protected string shopid = "", DataID = "", UserID = "";//店铺ID，检查人ID，POP发起ID，店铺所属供应商ID
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        shopid = Request.QueryString["shopid"].ToString();
        DataID = Request.QueryString["Did"].ToString();

        if (!Page.IsPostBack)
        {
            LN.BLL.DSRResultsList resultBLL = new LN.BLL.DSRResultsList();
            DataSet ruleds = resultBLL.GetList(" DataID='"+DataID+"'");
            DataTable rulesdt = ruleds.Tables[0];
            this.GridView1.DataSource = rulesdt;
            this.GridView1.DataBind();

            LN.BLL.DSRExamData oneInfo = new LN.BLL.DSRExamData();
            DataSet ds = oneInfo.GetList(" ShopID=" + shopid+" and DataID='"+DataID+"'");

            DataTable dt = ds.Tables[0];

            DataTable supplierdt = new LN.BLL.SupplierAssignRecord().GetSpplierAssignRecordWithShopID(int.Parse(shopid));

            if (supplierdt.Rows.Count > 0)
            {
                this.Txt_gyx.Text = supplierdt.Rows[0]["SupplierName"].ToString();
            }
            this.PosID.Text = dt.Rows[0]["PosID"].ToString();
            this.Txt_Shopname.Text = dt.Rows[0]["ShopName"].ToString();
            this.Txt_City.Text = dt.Rows[0]["ProvinceName"].ToString() + "，" + dt.Rows[0]["CityName"].ToString();
            this.Txt_Dealer.Text = dt.Rows[0]["DealerName"].ToString();
            this.Txt_gyx.Text = dt.Rows[0]["SupplierName"].ToString();
            this.Txt_result.Text = "是" + dt.Rows[0]["YesCount"].ToString() + "个/否" + dt.Rows[0]["NoCount"].ToString() + "个 是占" + dt.Rows[0]["Y"].ToString()+"%";
            this.Txt_checkman.Text = dt.Rows[0]["Username"].ToString();
            this.Txt_CheckDate.Text = dt.Rows[0]["CheckDate"].ToString();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ECECEC'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

        }
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            noRules++;
            e.Row.Cells[0].Text = noRules.ToString();
            if (e.Row.Cells[3].Text.Trim().ToString() == "1")
            {
                e.Row.Cells[3].Text = "是";
            }
            else if (e.Row.Cells[3].Text.Trim().ToString() == "0")
            {
                e.Row.Cells[3].Text = "否";
            }

        }
    }
  

}

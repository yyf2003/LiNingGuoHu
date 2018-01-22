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

public partial class WebUI_SetUpConfirm_stuplist : System.Web.UI.Page
{
    protected string dealerid = string.Empty, areaid = string.Empty, proviceid = string.Empty, cityid = string.Empty, fxid = string.Empty, sid = string.Empty,popid=string.Empty,flag=string.Empty;
     //   dealerid=" + dealerid + "&areaid=" + areaid + "&proviceid=" + proviceid + "&cityid=" + cityid + "&fxid=" + fxid+"&popid="+popid
    protected void Page_Load(object sender, EventArgs e)
    {
        dealerid = Request.QueryString["dealerid"] != null ? Request.QueryString["dealerid"].ToString() : "0";
        areaid = Request.QueryString["areaid"] != null ? Request.QueryString["areaid"].ToString() : "0";
        proviceid = Request.QueryString["proviceid"] != null ? Request.QueryString["proviceid"].ToString() : "0";
        cityid = Request.QueryString["cityid"] != null ? Request.QueryString["cityid"].ToString() : "0";
        fxid = Request.QueryString["fxid"] != null ? Request.QueryString["fxid"].ToString() : "0";
        sid = Request.QueryString["sid"] != null ? Request.QueryString["sid"].ToString() : "0";
        popid = Request.QueryString["popid"] != null ? Request.QueryString["popid"].ToString() : "0";
        flag = Request.QueryString["flag"] != null ? Request.QueryString["flag"].ToString() : "-1";
        if (!Page.IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        string strWhere = " 1=1 ";
        if (dealerid != "0")
            strWhere += " and dealerid='" + dealerid + "' ";
        if (areaid != "0")
            strWhere += " and  provinceid in (select provinceID from ProvinceData where Areaid=" + areaid + ")";
        if (proviceid != "0")
            strWhere += " and provinceid=" + proviceid;
        if (cityid != "0")
            strWhere += " and cityid =" + cityid;
        if (fxid != "0")
            strWhere += " and fxid='" + fxid + "'";
        if (sid != "0")
            strWhere += " and supplierid=" + sid;

        if (txt_code.Text.Trim().Length > 0)
            strWhere += " and posid='" + txt_code.Text.Trim() + "'";
        if (txt_shopname.Text.Trim().Length > 0)
            strWhere += " and shopname='" + txt_shopname.Text + "'";

        DataTable dt = null;
        if ("1".Equals(flag))
        {
            if (popid != "")
                strWhere += " and popid='" + popid + "'";
            dt = new LN.BLL.SetUpConfirm().GetListFromView(strWhere);
        }
        if ("0".Equals(flag))
        {
            strWhere += " and posid not in (select posid from dbo.View_SetUpConfirmList) ";
            dt = new LN.BLL.SupplierAssignRecord().getdatafromView(strWhere);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Btn_search_Click(object sender, EventArgs e)
    {
        bind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }
}

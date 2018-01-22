using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class WebUI_Supplier_ShowSupplierLaunch : System.Web.UI.Page
{
    protected string UserID = String.Empty;         //用户编号
    protected string POPID = String.Empty;          //发起的POP编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        POPID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        if (!IsPostBack)
        {
            BindSupplierList();
        }
    }

    /// <summary>
    /// 绑定供应商列表
    /// </summary>
    private void BindSupplierList()
    {
        IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");
        if (list != null)
        {
            RepSupplierList.DataSource = list;
            RepSupplierList.DataBind();
        }
    }

    /// <summary>
    /// 获取指定供应商的材料报价
    /// </summary>
    /// <param name="POPID">供应商编号</param>
    /// <param name="UserID">该供应商人员编号</param>
    /// <returns>供应商的材料报价集合</returns>
    protected IList<LN.Model.POPPrice> BindPrice(string SupplierID)
    {
        string strWhere = string.Format("  p.POPID='{0}' AND p.SupplierID = {1}", POPID, SupplierID);

        IList<LN.Model.POPPrice> list = new LN.BLL.POPPrice().GetList(strWhere);

        return list;
    }
}

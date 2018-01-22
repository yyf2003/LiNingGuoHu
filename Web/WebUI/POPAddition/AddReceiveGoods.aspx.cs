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
public partial class WebUI_PhysicalDistribution_AddReceiveGoods : System.Web.UI.Page
{
    protected string NewPOPID = string.Empty;//最新发起的POP
    protected string UserID = string.Empty, Username = string.Empty;//得到登录人的ID
    string SupplierID = string.Empty;//得到登录人所管理的供应商
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        Username = Server.UrlDecode(Request.Cookies["UserName"].Value);

        if (GetSupplierID() == "0")
            Response.Redirect("../../Error.aspx?param=7");
        LN.BLL.POPLaunch launchbll = new LN.BLL.POPLaunch();
        NewPOPID = launchbll.GetLastPOPID();//得到最新发起的POPID

        if (!Page.IsPostBack)
        {
            BindDealer();

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ListPages.CurrentPageIndex = 1;
        GetList();
    }

    /// <summary>
    /// 绑定一级客户


    /// </summary>
    private void BindDealer()
    {
        DataTable dt = new LN.BLL.DealerInfo().GetDealerNameBySupplierID(SupplierID);
        ddl_dealer.Items.Add(new ListItem("请选择一级客户", "0"));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ddl_dealer.Items.Add(new ListItem(dr["DealerName"].ToString().Trim(), dr["DealerID"].ToString().Trim()));
            }
        }
    }

    /// <summary>
    /// 获取指定用户所属的供应商编号和权限
    /// </summary>
    /// <param name="userid">用户编号</param>
    private string GetSupplierID()
    {
        string TypeID = "0";
        IList<int> s = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (s != null && s.Count > 0)
        {
            SupplierID = s[0].ToString();
            TypeID = s[1].ToString();
        }
        return TypeID;
    }
    protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPages.CurrentPageIndex = e.NewPageIndex;
        GetList();
    }

    private void GetList()
    {
        string StrWhere = string.Empty;
        if (Txt_PosID.Text.Trim().Length > 0)
            StrWhere += string.Format(" AND PosID = '{0}'", Txt_PosID.Text.Trim());
        if (Txt_ShopName.Text.Trim() != "")
            StrWhere += string.Format(" AND Shopname LIKE '%{0}%'", Txt_ShopName.Text.Trim());
        if (ddl_dealer.SelectedValue.Trim() != "0")
            StrWhere += string.Format(" AND DealerID = '{0}' ", ddl_dealer.SelectedValue.Trim());
        if (this.txt_FHID.Text.Trim().Length > 0)
            StrWhere += string.Format(" AND GoodsOrderNo = '{0}'", txt_FHID.Text.Trim());
        if (SupplierID != "")
        {
            StrWhere += " and supplierid=" + SupplierID;
        } 
        StrWhere += " and b.ExamState<>0 and b.state=0 and b.POPID='" + NewPOPID + "'"; 
        LN.Model.PageModel model = new LN.Model.PageModel();
        model.SelectSql = new LN.BLL.POPAddition().GetNoReceiveGoodList(StrWhere);
        model.pageIndex = ListPages.CurrentPageIndex;
        model.pageSize = ListPages.PageSize;
        model.OrderField = "ShopID DESC";
        int totalNumber = 0;
        DataTable dt = new LN.BLL.ShopInfo().GetShopListBySupplierID(model, out totalNumber);
        ListPages.RecordCount = totalNumber;
        RepShopList.DataSource = dt;
        RepShopList.DataBind();


    }
}

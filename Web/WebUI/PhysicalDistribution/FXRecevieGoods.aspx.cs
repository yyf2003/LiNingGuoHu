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

public partial class WebUI_PhysicalDistribution_FXRecevieGoods : System.Web.UI.Page
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

        //LN.BLL.POPLaunch launchbll = new LN.BLL.POPLaunch();
        //NewPOPID = launchbll.GetLastPOPID();//得到最新发起的POPID
        this.txt_time.Text = DateTime.Now.ToShortDateString();
        if (!Page.IsPostBack)
        {
            //BindDealer();

            //DataTable dt = new LN.BLL.DealerInfo().GetDealerByUserName(" contactor='" + Username + "'");

            //ddl_dealer.Text = dt.Rows[0]["DealerID"].ToString();
            //ddl_dealer.Enabled = false;
            //DataTable FXdt = new LN.BLL.DistributorsInfo().GetIDName(" dealerid='" + ddl_dealer.Text + "'");
            //for (int i = 0; i < FXdt.Rows.Count; i++)
            //{
            //    ListItem item = new ListItem(FXdt.Rows[i][1].ToString(), FXdt.Rows[i][0].ToString());
            //    DDL_fx.Items.Add(item);
            //}
            if (Username.Length >= 9)
                Username = Username.Substring(0, 7);
            DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName(" FXID='" + Username + "'");
            if (fxdt.Rows.Count > 0)
            {
                ListItem fxitem = new ListItem(fxdt.Rows[0]["FXName"].ToString(), fxdt.Rows[0]["FXID"].ToString());
                DDL_fx.Items.Add(fxitem);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "jump", "<script language='javascript'>alert('没有你负责的直属客户，请联系管理员');location.href='../Affiche/Index.aspx'</script>");
            }
            btn_goods.Enabled = false;
            GetList();
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
        //DataTable dt = new LN.BLL.DealerInfo().GetDealerName("");
        //ddl_dealer.Items.Add(new ListItem("请选择一级客户", "0"));
        //if (dt.Rows.Count > 0)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        ddl_dealer.Items.Add(new ListItem(dr["DealerName"].ToString().Trim(), dr["DealerID"].ToString().Trim()));
        //    }
        //}
    }

    protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPages.CurrentPageIndex = e.NewPageIndex;
        GetList();
    }

    private void GetList()
    {
        string StrWhere = string.Empty;
        string childstr = string.Empty;
        //if (Txt_PosID.Text.Trim().Length > 0)
        //    StrWhere += string.Format(" AND PosID = '{0}'", Txt_PosID.Text.Trim());
        //if (Txt_ShopName.Text.Trim() != "")
        //    StrWhere += string.Format(" AND Shopname LIKE '%{0}%'", Txt_ShopName.Text.Trim());
        if (DDL_fx.SelectedValue.Trim() != "0")
            StrWhere += string.Format(" AND FXID = '{0}' ", DDL_fx.SelectedValue.Trim());
        if (this.txt_FHID.Text.Trim().Length > 0)
            StrWhere += string.Format(" AND GoodsOrderNO = '{0}'", txt_FHID.Text.Trim());
        //if (Request.Form["DDL_fx"].ToString() != "0")
        //    StrWhere += string.Format(" and FXID='{0}'", Request.Form["DDL_fx"].ToString());
        StrWhere += " and GetInState<>'已收货' and IsState='发货到直属客户' and popid in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate())";

        LN.Model.PageModel model = new LN.Model.PageModel();
        model.SelectSql = LN.DAL.GetTableListSqlExec.strReceiveGoodsShoplist(StrWhere);
        model.pageIndex = ListPages.CurrentPageIndex;
        model.pageSize = ListPages.PageSize;
        model.OrderField = "FHDate DESC";
        int totalNumber = 0;
        DataTable dt = new LN.BLL.ShopInfo().GetShopListBySupplierID(model, out totalNumber);
        if (dt != null && dt.Rows.Count > 0)
        {
            ListPages.RecordCount = totalNumber;
            RepShopList.DataSource = dt;
            RepShopList.DataBind();
            btn_goods.Enabled = true;
        }
        else
        {
            RepShopList.DataSource = null;
            RepShopList.DataBind();
            btn_goods.Enabled = false;
        }
    }
    protected void btn_goods_Click(object sender, EventArgs e)
    {
        string ordernolist = "";
        foreach (RepeaterItem row in RepShopList.Items)
        {
            CheckBox cb = (CheckBox)row.FindControl("cb");
            if (cb.Checked)
            {
                HiddenField hf = (HiddenField)row.FindControl("hf1");
                ordernolist += hf.Value + ",";
            }
        }
        if (ordernolist.Length > 0)
        {
            ordernolist = ordernolist.Remove(ordernolist.Length - 1);
            new LN.BLL.ShippingSpeedData().RecevieGoods(NewPOPID, txt_time.Text.Trim(), UserID, this.fs.Value, txt_fk.Text, ordernolist);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('确认完毕');window.location.href='ReceiveGoods.aspx'</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('请选择要收货的发货单');window.location.href='ReceiveGoods.aspx'</script>");
        }
    }
}

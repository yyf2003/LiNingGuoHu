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

public partial class WebUI_PhysicalDistribution_shopRecevieGoods : System.Web.UI.Page
{
    protected string NewPOPID = string.Empty;//最新发起的POP
    protected string UserID = string.Empty, Username = string.Empty;//得到登录人的ID

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
      
        LN.BLL.POPLaunch launchbll = new LN.BLL.POPLaunch();
        NewPOPID = launchbll.GetLastPOPID();//得到最新发起的POPID
        this.txt_time.Text = DateTime.Now.ToShortDateString();
        if (!Page.IsPostBack)
        {
            
            Bindshop();
           
            //DataTable dt = new LN.BLL.DealerInfo().GetDealerByUserName(" contactor='" + Username + "'");

            //ddl_dealer.Text = dt.Rows[0]["DealerID"].ToString();
            //ddl_dealer.Enabled = false;
            //DataTable FXdt = new LN.BLL.DistributorsInfo().GetIDName(" dealerid='" + ddl_dealer.Text + "'");
            //for (int i = 0; i < FXdt.Rows.Count; i++)
            //{
            //    ListItem item = new ListItem(FXdt.Rows[i][1].ToString(), FXdt.Rows[i][0].ToString());
            //    DDL_fx.Items.Add(item);
            //}

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
    private void Bindshop()
    {
        DataTable dt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(Username);
        if (dt.Rows.Count > 0)
        {
            Txt_PosID.Text = dt.Rows[0]["posid"].ToString();
            Txt_PosID.Enabled = false;
            Txt_ShopName.Text = dt.Rows[0]["shopname"].ToString();
            Txt_ShopName.Enabled = false;

            DataTable fhdt = new LN.BLL.ShippingSpeedData().GetFHID(" shopid=" + dt.Rows[0]["ShopID"].ToString() + " and POPID='" + NewPOPID + "' and IsState='发货到店' and GetInState='已发送' ");
            for (int i = 0; i < fhdt.Rows.Count; i++)
            {
                txt_FHID.Items.Add(new ListItem(fhdt.Rows[i][0].ToString(), fhdt.Rows[i][0].ToString()));
            }
            
        }
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
        if (Txt_PosID.Text.Trim().Length > 0)
            StrWhere += string.Format(" AND PosID = '{0}'", Txt_PosID.Text.Trim());
        if (Txt_ShopName.Text.Trim() != "")
            StrWhere += string.Format(" AND Shopname LIKE '%{0}%'", Txt_ShopName.Text.Trim());
        //if (ddl_dealer.SelectedValue.Trim() != "0")
        //    StrWhere += string.Format(" AND DealerID = '{0}' ", ddl_dealer.SelectedValue.Trim());
        if (this.txt_FHID.Text.Trim().Length > 0)
            childstr += string.Format(" AND GoodsOrderNO = '{0}'", txt_FHID.Text.Trim());
        //if (Request.Form["DDL_fx"].ToString() != "0")
        //    StrWhere += string.Format(" and FXID='{0}'", Request.Form["DDL_fx"].ToString());
        StrWhere += " and GetInState<>'已收货' and IsState='发货到店' and popid='" + NewPOPID + "'";

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
            btn_goods.Enabled = false;
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

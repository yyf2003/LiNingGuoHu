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
public partial class WebUI_Analysis_AddPOPAnalysis : System.Web.UI.Page
{
    protected string POPID = string.Empty;
    protected Double areasum = 0.00, pricesum = 0.00;
    protected int shopcount = 0, popcount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;//得到用户ID
        if (!Page.IsPostBack)
        {
            DDL_year.Text = DateTime.Now.Year.ToString();
            //加载供应商
            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");
            foreach (LN.Model.SupplierInfo model in list)
            {
                ListItem item = new ListItem(model.SupplierName, model.SupplierID.ToString());
                DDL_Supplier.Items.Add(item);
            }
            //加载所有的 POP发起ID
            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                DDL_POPID.Items.Add(item);
            }

            //加载一级客户
            DataTable dealerdt = new LN.BLL.DealerInfo().GetDealerName(" 1=1 ");
            for (int i = 0; i < dealerdt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                DDL_Dealer.Items.Add(item);
            }

            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList("");
            foreach (LN.Model.AreaData model in arealist)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                DDL_Area.Items.Add(item);
            }
            // 根据登录人ID得到所属省区 并加载相应市

            DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                DDL_Area.Text = userdt.Rows[0][0].ToString();
                DDL_Area.Enabled = false;
                IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
                foreach (LN.Model.ProvinceData pmodel in prolist)
                {
                    DDL_Province.Items.Add(new ListItem( pmodel.ProvinceName,pmodel.ProvinceID.ToString()));
                }
            }

        }

        string supplierID = "0";//如果是VM进来 供应商ID 为 0 
        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
        {
            supplierID = supplierBody[0].ToString();
            DDL_Supplier.Text = supplierID;

            DDL_Supplier.Enabled = false;
        }
    }
    protected void Btn_Analysis_Click(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {
        POPID = DDL_POPID.Text;
        Hashtable ht = new Hashtable();
        ht.Add("year", DDL_year.Text);
        ht.Add("POPID", DDL_POPID.Text);
        ht.Add("PosCode", txt_PosID.Text.Trim());
        ht.Add("Shopname", txt_shopname.Text.Trim());
        ht.Add("SupplierID", DDL_Supplier.Text);
        ht.Add("DealerID", DDL_Dealer.Text);
        ht.Add("areaID", DDL_Area.Text);
        ht.Add("ProvinceID", Request.Form["DDL_Province"].ToString());
        ht.Add("CityID", Request.Form["DDL_city"].ToString());
        //ht.Add("OrderField", "totalprice desc");
        //ht.Add("pageSize", ListPages.PageSize.ToString());
        //ht.Add("pageIndex", ListPages.CurrentPageIndex.ToString());
        ht.Add("Examstate",DDL_OK.Text);
        ht.Add("send",DDL_send.Text);
        //ht.Add("recevie",DDL_Recevie.Text);

        LN.Model.PageModel model = new LN.Model.PageModel();
        model.SelectSql = new LN.BLL.POPAddition().GetAnalysisstr(ht);
        model.pageIndex = ListPages.CurrentPageIndex;
        model.pageSize = ListPages.PageSize;
        model.OrderField = "totalprice DESC";
        int totalNumber = 0;
        DataTable dt = new LN.BLL.ShopInfo().GetShopListBySupplierID(model, out totalNumber);
     
            ListPages.RecordCount = totalNumber;
            RepShopList.DataSource = dt;
            RepShopList.DataBind();
        //统计数据
            shopcount = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                popcount += int.Parse(dt.Rows[i]["POPcount"].ToString());
                areasum += Double.Parse(dt.Rows[i]["Totalarea"].ToString());
                pricesum += Double.Parse(dt.Rows[i]["Totalprice"].ToString() == "" ? "0" : dt.Rows[i]["Totalprice"].ToString());
            }
    }
    protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPages.CurrentPageIndex = e.NewPageIndex;
        bind();
    }
}

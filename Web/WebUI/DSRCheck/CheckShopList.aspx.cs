using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_Shopmanage_ShopInfoList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            BindInfo();
        }
    }

    /// <summary>
    /// 绑定店铺信息
    /// </summary>
    private void BindInfo()
    {
        //绑定店铺级别
        LN.DAL.ShopLevel levelDLL = new LN.DAL.ShopLevel();
        DataSet ds = levelDLL.GetList("");
        DataTable dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem item = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
            this.DDL_Shoptype.Items.Add(item);
        }
        //绑定店铺类型
        LN.DAL.SaleTypeInfo saleDLL = new LN.DAL.SaleTypeInfo();
        DataSet saleds = saleDLL.GetList("");
        DataTable saledt = saleds.Tables[0];
        for (int i = 0; i < saledt.Rows.Count; i++)
        {
            ListItem item = new ListItem(saledt.Rows[i][1].ToString(), saledt.Rows[i][0].ToString());
            SaleTypeID.Items.Add(item);
        }
        //绑定店铺的一级客户

        LN.DAL.DealerInfo dealerDAL = new LN.DAL.DealerInfo();

        DataTable dealerdt = dealerDAL.GetDealerName("");
        for (int i = 0; i < dealerdt.Rows.Count; i++)
        {
            ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
            ddl_dealer.Items.Add(item);
        }
        //加载省份
        IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
        for (int i = 0; i < pList.Count; i++)
        {
            ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
            DDL_Province.Items.Add(item);
        }

        //加载店铺状态
        LN.BLL.ShopStateInfo statebll = new LN.BLL.ShopStateInfo();
        IList<LN.Model.ShopStateInfo> statelist = statebll.GetModelList("");
        foreach (LN.Model.ShopStateInfo model in statelist)
        {
            ListItem item = new ListItem(model.ShopState, model.ID.ToString());
            DDL_shopstate.Items.Add(item);
        }
    }
}

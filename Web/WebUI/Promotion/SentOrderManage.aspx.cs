using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using LN.BLL;

public partial class WebUI_Promotion_SentOrderManage : System.Web.UI.Page
{
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        userId = int.Parse(Request.Cookies["UserID"].Value);
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        StringBuilder where = new StringBuilder();
        where.Append(" and IsConfirmOrder=1 ");
        if (!string.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
        {
            where.AppendFormat(" and PromotionName like '%{0}%'", txtTitle.Text.Trim());
        }
        if (!string.IsNullOrWhiteSpace(txtBeginDate.Text))
        {
           
            where.Append(" and BeginDate >= '" + txtBeginDate.Text.Trim() + "'");
        }
        if (!string.IsNullOrWhiteSpace(txtEndDate.Text))
        {
            DateTime date = DateTime.Parse(txtEndDate.Text).AddDays(1);
            where.Append(" and EndDate  < '" + date + "'");
        }
        
        Promotion promotionBll = new Promotion();
        AspNetPager1.RecordCount = promotionBll.GetPageCount(where.ToString());
        DataSet ds = promotionBll.GetList(where.ToString(), AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();

    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    PromotionShops promotionShopBll = new PromotionShops();
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                int pid = int.Parse(item["Id"].ToString());
                IList<LN.Model.PromotionShops> list = promotionShopBll.GetDataList(string.Format(" PromotionId={0}",pid));
                ((Label)e.Item.FindControl("labTotalShops")).Text = list.Count.ToString();
                if (list.Any())
                {
                    list = list.Where(s=>s.SentOrderDate!=null).ToList();
                    ((Label)e.Item.FindControl("labSnedShops")).Text = list.Count.ToString();

                }
            }
        }
    }
}
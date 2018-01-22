using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using LN.BLL;
using System.Web.UI.HtmlControls;


public partial class WebUI_Promotion_Shops_RackList : System.Web.UI.Page
{
    int shopId;
    RackInShop rackInShopBll = new RackInShop();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["shopid"] != null)
        {
            shopId = int.Parse(Request.QueryString["shopid"]);
        }
        if (!IsPostBack)
            BindData();
    }

    void BindData()
    {
        DataSet ds = rackInShopBll.GetJoinRackList(string.Format(" and RackInShop.ShopId={0}", shopId));
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
        CombineCell();
    }

    /// <summary>
    /// 合并单元格
    /// </summary>
    void CombineCell()
    {

        for (int i = Repeater1.Items.Count - 1; i > 0; i--)
        {

            HtmlTableCell cell1 = Repeater1.Items[i - 1].FindControl("seat") as HtmlTableCell;
            HtmlTableCell cell2 = Repeater1.Items[i].FindControl("seat") as HtmlTableCell;
           
            cell1.RowSpan = (cell1.RowSpan == -1) ? 1 : cell1.RowSpan;
            cell2.RowSpan = (cell2.RowSpan == -1) ? 1 : cell2.RowSpan;
            if (cell2.InnerText == cell1.InnerText)
            {
                cell2.Visible = false;
                cell1.RowSpan += cell2.RowSpan;
            }


        }
    }
}
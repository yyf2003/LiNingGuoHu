using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using LN.BLL;


public partial class WebUI_Promotion_PromotionShops : System.Web.UI.Page
{
    int pid;
    int isSent;
    int isReceive;
    int isCheck;
    int userId;
    string userType = string.Empty;
    string posId = string.Empty;
    int shopId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        userId = int.Parse(Request.Cookies["UserID"].Value);
        posId = Request.Cookies["UserName"].Value;//店铺的是用posid作为用户名登陆的

        DataSet shopDs = new ShopInfo().GetSublist(" PosID='" + posId + "'");
        if (shopDs != null && shopDs.Tables[0].Rows.Count > 0)
        {
            shopId = int.Parse(shopDs.Tables[0].Rows[0]["ShopId"].ToString());
        }

        LN.Model.UserInfo user = new LN.BLL.UserInfo().GetModel(userId);
        if (user != null)
        {
            userType = user.Usertype;
        }
        if (Request.QueryString["id"] != null)
        {
            pid = int.Parse(Request.QueryString["id"].ToString());
        }
        if (Request.QueryString["issent"] != null)
        {
            isSent = int.Parse(Request.QueryString["issent"].ToString());
        }
        if (Request.QueryString["isreceive"] != null)
        {
            isReceive = int.Parse(Request.QueryString["isreceive"].ToString());
        }
        if (Request.QueryString["ischeck"] != null)
        {
            isCheck = int.Parse(Request.QueryString["ischeck"].ToString());
        }
        if (!IsPostBack)
        {
            Promotion promotionBll = new Promotion();
            LN.Model.Promotion promotionModel = promotionBll.GetModel(pid);
            if (promotionModel != null)
            {
                labPromotionId.Text = promotionModel.PromotionId;
                labTitle.Text = promotionModel.PromotionName;
            }
            BindData();
        }
    }

    void BindData()
    {
        PromotionShops pShopsBll = new PromotionShops();
        StringBuilder where = new StringBuilder();
        where.AppendFormat(" and PromotionId={0}", pid);
        if (!string.IsNullOrWhiteSpace(userType))
        {
            if (userType == "7")
            {
                where.AppendFormat(" and PromotionShops.ShopId={0}", shopId);
            }
        }
        if (!string.IsNullOrWhiteSpace(txtPOSCode.Text))
        {
            where.AppendFormat(" and PosID='{0}'", txtPOSCode.Text.Trim());
        }
        if (!string.IsNullOrWhiteSpace(txtShopName.Text))
        {
            where.AppendFormat(" and Shopname like '%{0}%'", txtShopName.Text.Trim());
        }
        AspNetPager1.RecordCount = pShopsBll.GetPageCount(where.ToString());
        DataSet ds = pShopsBll.GetPageList(where.ToString(), AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();

    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    PromotionPOPOrder orderBll = new PromotionPOPOrder();
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (isSent == 1)
            {
                HtmlTableCell receiveStateCell = ((HtmlTableCell)e.Item.FindControl("receiveState"));
                receiveStateCell.Visible = false;
            }
        }
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                int pid = int.Parse(item["PromotionId"].ToString());
                int shopid = int.Parse(item["ShopId"].ToString());
                int orderCount = orderBll.GetPageCount(string.Format(" and PromotionPOPOrder.ShopID={0} and PromotionPOPOrder.PromotionId={1}", shopid, pid));
                ((Label)e.Item.FindControl("labOrderCount")).Text = orderCount.ToString();
                if (orderCount == 0)
                {
                    ((LinkButton)e.Item.FindControl("lbSent")).Enabled = false;

                }
                if (isSent == 1)
                {
                    ((LinkButton)e.Item.FindControl("lbSent")).Text = "提交发货";
                    HtmlTableCell receiveStateCell = ((HtmlTableCell)e.Item.FindControl("receiveState"));
                    receiveStateCell.Visible = false;
                }
                if (isReceive == 1)
                {
                    ((LinkButton)e.Item.FindControl("lbSent")).Text = "提交收货";
                    if (string.IsNullOrWhiteSpace(item["SentOrderDate"].ToString()))
                    {
                        ((LinkButton)e.Item.FindControl("lbSent")).Enabled = false;
                    }
                }
                if (isCheck == 1)
                {
                    ((LinkButton)e.Item.FindControl("lbSent")).Text = "查看详细";
                }

            }
        }
        
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());//PromotionShops表的主键
        if (isSent == 1)
            Response.Redirect("OrderSentConfirm.aspx?id=" + id, false);
        else if (isReceive == 1)
            Response.Redirect("OrderReceiveConfirm.aspx?id=" + id, false);
        else if (isCheck == 1)
            Response.Redirect("CheckLogistics.aspx?id=" + id, false);

    }
    protected void lbBack_Click(object sender, EventArgs e)
    {
        if (isSent == 1)
        {
            Response.Redirect("SentOrderManage.aspx",false);
        }
        else if (isReceive == 1)
        {
            Response.Redirect("ReceiveOrderManage.aspx",false);
        }
        else if (isCheck == 1)
        {
            Response.Redirect("POPOrderList.aspx?id=" + pid, false);
        }
    }
}
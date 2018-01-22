using System;
using System.Data;
using System.Text;
using System.Web.UI;
using Common;
using LN.BLL;

public partial class WebUI_Promotion_CheckLogistics : System.Web.UI.Page
{
    int promotionShopId;
    int pid;
    int shopid;
    int userId;
    PromotionShops pshopBll = new PromotionShops();
    LN.Model.PromotionShops PromotionShopModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        userId = int.Parse(Request.Cookies["UserID"].Value);

        if (Request.QueryString["id"] != null)
        {
            promotionShopId = int.Parse(Request.QueryString["id"].ToString());
        }
        PromotionShopModel = pshopBll.GetModel(promotionShopId);
        if (PromotionShopModel != null)
        {
            pid = PromotionShopModel.PromotionId ?? 0;
            shopid = PromotionShopModel.ShopId ?? 0;
            Attachment attachBll = new Attachment();
            labWuLiuDan.Text = attachBll.GetAttachList(string.Format(" FileCode='{0}' and ItemTypeId={1} and ItemId={2} and IsDelete=0", ((int)FileCodeEnum.SentWuLiuDang).ToString(), pid, shopid));
            labQianShouDan.Text = attachBll.GetAttachList(string.Format(" FileCode='{0}' and ItemTypeId={1} and ItemId={2} and IsDelete=0", ((int)FileCodeEnum.ReceiveQianShouDang).ToString(), pid, shopid));
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
            ShopInfo shopBll = new ShopInfo();
            LN.Model.ShopInfo shopModel = shopBll.GetModel(shopid);
            if (shopModel != null)
            {
                labPosCode.Text = shopModel.PosID;
                labShopName.Text = shopModel.Shopname;
            }
            if (PromotionShopModel != null)
            {
                labSentDate.Text = PromotionShopModel.SentOrderDate != null ? DateTime.Parse(PromotionShopModel.SentOrderDate.ToString()).ToShortDateString() : "";
                labSentRemark.Text = PromotionShopModel.SentRemark;
                labReceiveDate.Text = PromotionShopModel.ReceiveOrderDate != null ? DateTime.Parse(PromotionShopModel.ReceiveOrderDate.ToString()).ToShortDateString() : "";
                labReceiveRemark.Text = PromotionShopModel.ReceiveRemark;
                

            }
            BindOrders();
        }
    }


    void BindOrders()
    {
        PromotionPOPOrder orderBll = new PromotionPOPOrder();
        StringBuilder where = new StringBuilder();
        where.AppendFormat(" and PromotionId={0} and ShopId={1}", pid, shopid);
        int count = orderBll.GetPageCount(where.ToString());
        AspNetPager1.RecordCount = count;
        DataSet ds = orderBll.GetPage(where.ToString(), AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindOrders();
    }
    protected void lbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionShops.aspx?id=" + pid + "&ischeck=1", false);
    }
}
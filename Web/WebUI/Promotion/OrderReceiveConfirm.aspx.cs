using System;
using System.Data;
using System.Text;
using System.Web.UI;
using Common;
using LN.BLL;

public partial class WebUI_Promotion_OrderReceiveConfirm : System.Web.UI.Page
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
        }
        if (!IsPostBack)
        {
            if (PromotionShopModel != null)
            {
                txtReceiveDate.Text = PromotionShopModel.ReceiveOrderDate != null ? DateTime.Parse(PromotionShopModel.ReceiveOrderDate.ToString()).ToShortDateString() : "";
                txtRemark.Text = PromotionShopModel.ReceiveRemark;
            }
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
            BindOrders();
        }

        InitUploadControl(UpLoadContraol1, FileTypeEnum.Files.ToString(), ((int)FileCodeEnum.ReceiveQianShouDang).ToString(), pid.ToString(), shopid.ToString(), userId.ToString());
    }

    void InitUploadControl(FileUploadUC_UpLoadContraol uc, string FileType, string BaseCode, string ItemTypeId, string ItemId, string UserId)
    {
        uc.FileType = FileType;
        uc.ItemTypeId = ItemTypeId;//PromotionId
        uc.ItemId = ItemId;//ShopId
        uc.UserId = UserId;
        uc.FileCode = BaseCode;

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

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        PromotionShopModel = new LN.Model.PromotionShops();
        PromotionShopModel.Id = promotionShopId;
        if (!string.IsNullOrEmpty(txtReceiveDate.Text))
            PromotionShopModel.ReceiveOrderDate = DateTime.Parse(txtReceiveDate.Text.Trim());
        PromotionShopModel.ReceiveRemark = txtRemark.Text.Trim();
        PromotionShopModel.ReceiveOrderUserId = userId;
        pshopBll.Update(PromotionShopModel);
        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('提交成功！');window.location.href='PromotionShops.aspx?id=" + pid + "&isreceive=1'", true);
    }
   
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindOrders();
    }

    protected void lbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionShops.aspx?id=" + pid + "&isreceive=1", false);
    }
}
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

public partial class WebUI_SetUpConfirm_ConfirmSetUp : System.Web.UI.Page
{
    protected string UserID = string.Empty;     //用户编号
    protected string ShopID = string.Empty;     //店铺编号
    protected string DealreID = string.Empty;   //一级客户编号
    protected string FXID = string.Empty;       //直属客户编号
    protected string SupplierID = string.Empty; //供应商编号
    protected string PopID = string.Empty;      //POP发起ID

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        ShopID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        PopID = Request.QueryString["popid"] == null ? "0" : Request.QueryString["popid"].ToString();
        DealreID = Request.QueryString["did"] == null ? "0" : Request.QueryString["did"].ToString();
        FXID = Request.QueryString["fxid"] == null ? "0" : Request.QueryString["fxid"].ToString(); 
        SupplierID = Request.QueryString["sid"] == null ? "0" : Request.QueryString["sid"].ToString();

        if (!IsPostBack)
            GetShopInfo();
    }

    /// <summary>
    /// 获取指定店铺的信息
    /// </summary>
    private void GetShopInfo()
    {
        if (ShopID == "0")
            btnSubmit.Enabled = false;
        else
        {
            DataTable dt = new LN.BLL.ShopInfo().GetInfoByID(Int32.Parse(ShopID), Int32.Parse(SupplierID), PopID, DealreID);
            if (dt != null)
            {
                lblPOPName.Text = dt.Rows[0]["POPName"].ToString();
                lblDealerName.Text = dt.Rows[0]["DealreName"].ToString();
                lblShopName.Text = dt.Rows[0]["ShopName"].ToString();
                lblTitle.Text = lblShopName.Text;
                lblSupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
            }
            else
                btnSubmit.Enabled = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string PicUrl = String.Empty;
        if (fuImg.HasFile)
        {
            string fpath = "../../UpLoad/setUpFiles";
            int _ul = Upload_File.FileSave(fpath, fuImg, ref PicUrl);
            if (_ul <= 0) return;
        }

        LN.Model.SetUpConfirm model = new LN.Model.SetUpConfirm();
        model.DealerID = DealreID;
        model.Shopid = Int32.Parse(ShopID);
        model.Boolinstall = 0;
        model.SupplierID = Int32.Parse(SupplierID);
        model.FXID = FXID;
        model.POPID = PopID;
        model.SetUpCount = Int32.Parse(txtSetupNum.Text.Trim());
        model.OperatorID = Int32.Parse(UserID);
        model.SetUpDesc = this.txtDesc.Text;
        model.PicUrl = PicUrl;

        int addResult = new LN.BLL.SetUpConfirm().Add(model);
        if (addResult > 0)
        {
            string hrefURL = Request.QueryString["href"] == null ? "1" : Request.QueryString["href"].ToString();
            if (hrefURL == "1")
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tishi", "<script>alert('提交成功');window.location.href='ShopListToDealer.aspx';</script>");
            else
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tishi", "<script>alert('提交成功');window.location.href='ShopListToFX.aspx';</script>");
        }
        else
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tishi", "<script>alert('服务器忙，请稍后提交！！');window.location=window.location;</script>");
    }
}

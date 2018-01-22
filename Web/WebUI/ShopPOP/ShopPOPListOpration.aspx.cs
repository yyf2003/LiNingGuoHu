using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class WebUI_ShopPOP_ShopPOPListOpration : System.Web.UI.Page
{
    protected string shopid = "",UserID=string.Empty;
    protected string POPID = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        if (Request.QueryString["shopid"] != null)
        {
            shopid = Request.QueryString["shopid"].ToString();
            POPID = new LN.BLL.POPChangeSet().GetPOPIDByShopID(shopid);
        }
        else
        {
            string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
            DataTable shopdt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(UserName);

            if (shopdt.Rows.Count > 0)
            {
                shopid = shopdt.Rows[0]["ShopID"].ToString();
                POPID = new LN.BLL.POPChangeSet().GetPOPIDByShopID(shopid);
            }
            else
            {
                Response.Write("<script language='javascript'>alert('没有您负责的店铺');</script>");
                Response.End();
            }
        }
        if (!Page.IsPostBack)
        {
            LN.BLL.ShopInfo oneInfo = new LN.BLL.ShopInfo();
            DataSet ds = oneInfo.GetList(" ShopID=" + shopid);

            DataTable dt = ds.Tables[0];
            this.PosID.Text = dt.Rows[0]["PosID"].ToString();
            this.Txt_Shopname.Text = dt.Rows[0]["ShopName"].ToString();
            this.txt_samplename.Text = dt.Rows[0]["shopsamplename"].ToString();
            this.Txt_City.Text = dt.Rows[0]["CityName"].ToString();
            this.Txt_CloseTime.Text = dt.Rows[0]["shopCloseDate"].ToString();
            this.Txt_CloseUser.Text = dt.Rows[0]["CloseUserID"].ToString();
            this.Txt_Dealer.Text = dt.Rows[0]["DealerName"].ToString();
            this.Txt_Email.Text = dt.Rows[0]["Email"].ToString();
            this.Txt_FixNumber.Text = dt.Rows[0]["FaxNumber"].ToString();
            this.Txt_install.Text = dt.Rows[0]["BoolInstall"].ToString() == "1" ? "支持" : "不支持";
            this.Txt_LineMan.Text = dt.Rows[0]["LinkMan"].ToString();
            this.Txt_LinkPhone.Text = dt.Rows[0]["LinkPhone"].ToString();
            this.Txt_ShopMaster.Text = dt.Rows[0]["ShopMaster"].ToString();
            this.Txt_ShopMasterPhone.Text = dt.Rows[0]["ShopMasterPhone"].ToString();
            this.Txt_PostAddress.Text = dt.Rows[0]["PostAddress"].ToString();
            this.Txt_PostCode.Text = dt.Rows[0]["PostCode"].ToString();
            this.Txt_Pro.Text = dt.Rows[0]["ProvinceName"].ToString();
            //this.Txt_Saletype.Text = dt.Rows[0]["Saletype"].ToString();
            this.txt_town.Text = dt.Rows[0]["TownName"].ToString();
            this.DDL_Shoptype.Text = dt.Rows[0]["ShopTypename"].ToString();
            this.txt_shopownership.Text = dt.Rows[0]["shopownership"].ToString();
            this.Txt_ShopState.Text = new LN.BLL.ShopStateInfo().GetModel(int.Parse(dt.Rows[0]["ShopState"].ToString())).ShopState;
            Txt_VMMaster.Text = dt.Rows[0]["VMMaster"].ToString();
            Txt_VMMasterPhone.Text = dt.Rows[0]["VMMasterPhone"].ToString();
            Txt_DSRMaster.Text = dt.Rows[0]["DSRMaster"].ToString();
            Txt_DSRMasterPhone.Text = dt.Rows[0]["DSRMasterPhone"].ToString();
            Txt_Shoparea.Text = dt.Rows[0]["ShopArea"].ToString();
            DDL_shopLevel.Text = dt.Rows[0]["ShopLevel"].ToString();
            DDL_shopVI.Text = dt.Rows[0]["ShopVIName"].ToString();
            txt_fx.Text = dt.Rows[0]["FXname"].ToString();
            txt_shopphone.Text = dt.Rows[0]["ShopPhone"].ToString();
            txt_customerCard.Text = dt.Rows[0]["CustomerCard"].ToString();
            txt_CustomerGroupID.Text = dt.Rows[0]["CustomerGroupID"].ToString();
            txt_CustomerGroupName.Text = dt.Rows[0]["CustomerGroupName"].ToString();
            Txt_Saletype.Text = "常规店";
            txt_customerCard.Text = dt.Rows[0]["customerCard"].ToString();
            txt_shopownership.Text = dt.Rows[0]["shopownership"].ToString();
            bind(shopid);
        }
    }

    private void bind(string _shopid)
    {
        //string strWhere = string.Format(" shopid = {0} ", _shopid);
        if (!String.IsNullOrEmpty(POPID))
        {
            int IsAllExam = new LN.BLL.POPInfo().IsAllExamByShopID(Int32.Parse(_shopid));
            if (IsAllExam == 1)
            {
                IList<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetListOrderByShop(_shopid);//审核通过的POP才能进行对应图片的操作

                this.GridView1.DataSource = list;
                GridView1.DataBind();

                if (list.Count <= 0)
                    btn_save.Enabled = false;
            }
            else
            {
                btn_save.Visible = false;
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "No", "<script language='javascript'>alert('新增或修改的POP在通过大区VM经理审批前，暂无法进行季度订单操作，请联系省区VM专员，谢谢');</script>");
                //return false;
            }
            
        }
        else
        {
            btn_save.Visible = false;
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "No", "<script language='javascript'>alert('您的店铺不在此次季度更换的范围，谢谢您的使用');</script>");
            //return false;
        }
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string IsSubmit = e.Row.Cells[16].Text.Trim();
        if (IsSubmit != "是否提交订单")
        {

            if (IsSubmit == "0")
            {
                e.Row.Cells[16].Text = "未提交";
                e.Row.Cells[16].BackColor = Color.Red;
                e.Row.Cells[16].ForeColor = Color.White;
                e.Row.Cells[16].Style.Add("font-weight", "bold");
            }
            else
            {
                e.Row.Cells[16].Text = "已提交";
            }
           

        }
        HiddenField h_popInfoId = (HiddenField)e.Row.FindControl("h_popInfoId");
        if (h_popInfoId != null)
        {            
            List<LN.Model.POPImageData> list = new List<LN.Model.POPImageData>();
            list = new LN.BLL.POPImageData().GetList(" [ImageID] in(select top 1 [ImageID] from [imageToPOPTemp] where popinfoid='" + h_popInfoId.Value + "' and popid in(SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()))");
            if (list.Count > 0)
            {
                e.Row.Cells[17].Text = "<a href='" + list[0].ImageUrl + "' target='_bank'><img src='" + list[0].SmallImageUrl + "' width='60' alt='' /> </a>";
            }
        }

        //add by mhj 20130905
        HiddenField h_IsHide = (HiddenField)e.Row.FindControl("h_IsHide");        
        if (h_IsHide != null)
        {
            HiddenField h_id = (HiddenField)e.Row.FindControl("h_id");            
            if (h_IsHide.Value == "1")
            {
                e.Row.Cells[15].Text = "不需下单";
                e.Row.Cells[16].Text = "";
                e.Row.Cells[16].BackColor = Color.White;
            }
            else
            {
                e.Row.Cells[15].Text = "<a href=\"#\" onclick='openWin(\"" + h_id.Value + "\",\"" + shopid + "\",\"" + POPID + "\")'>确认画面订单</a>";
            }
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        int result = new LN.BLL.imageToPOPTemp().POPUniformSubmit(shopid);
        if (result > 0)
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", "<script>alert('店铺POP订单提交成功！！');window.location.href=window.location.href</script>");
        else
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", "<script>alert('还有未提交订单的POP，提交失败！！');window.location.href=window.location.href</script>");
    }
}

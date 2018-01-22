﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_POPLanuch_SupplierEveryshoppoplist : System.Web.UI.Page
{
    string shopid = "", POPID = "", prolist = "",cailiao=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        shopid = Request.QueryString["shopid"].ToString();
        POPID = Request.QueryString["POPID"].ToString();
        prolist = Request.QueryString["prolist"].ToString();
       
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
        }

        bind(shopid);
    }

    private void bind(string _shopid)
    {
       
        DataTable list = new LN.BLL.POPChangeSet().Getview_List(" shopid=" + _shopid + "  and POPID='" + POPID + "' and CatenaProID in (" + prolist + ")");//根据发起POP的ID和相关的故事包得到相应的POP

        this.GridView1.DataSource = list;
        GridView1.DataBind();
    }
    
}

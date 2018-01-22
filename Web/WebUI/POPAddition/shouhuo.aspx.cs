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
using System.Collections;
public partial class WebUI_ShopPOP_ShopPOPList : System.Web.UI.Page
{
   protected  string shopid = string.Empty, POPID = string.Empty, Username=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;
        Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
        if (Request.QueryString["shopid"] != null)
        {
            shopid = Request.QueryString["shopid"].ToString();
            POPID = Request.QueryString["POPID"].ToString();
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
            
            bind();
        }

       
    }

    private void bind()
    {
        DataSet ds = new LN.BLL.POPAddition().GetNoReceivePOPlist(shopid,POPID);

        this.GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }
    protected void btn_goods_Click(object sender, EventArgs e)
    {
        ArrayList updateid = new ArrayList();
        foreach (GridViewRow  grow in GridView1.Rows)
        {
            CheckBox cb = (CheckBox)grow.Cells[18].Controls[0].FindControl("CB_choose");
            if (cb.Checked)
            {
                HiddenField hf = (HiddenField)grow.Cells[18].Controls[0].FindControl("HF1");
                updateid.Add(hf.Value);

            }
        }

        new LN.BLL.POPAddition().POPReceive(updateid, Username, txt_time.Text.Trim(), fs.Value, txt_fk.Text.Trim());

        Response.Write("<script>alert('已收货完成');location.href='AddReceiveGoods.aspx';</script>");
    }
}

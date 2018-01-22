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

public partial class WebUI_Shopmanage_OneShopInfo : System.Web.UI.Page
{
    LN.BLL.ShopInfo oneInfo = new LN.BLL.ShopInfo();
    string shopid = "", userID = "", userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
         {
             Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
             return;
         } 
         userID = Request.Cookies["UserID"].Value;//登录人ID
         userName = Server.UrlDecode(Request.Cookies["UserName"].Value);
         this.Btn_Sure.Visible = false;
         if (Request.QueryString["shopid"] != null)
         {
             shopid = Request.QueryString["shopid"].ToString();
         }
         else
         {
             DataTable dt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(userName);
             if (dt.Rows.Count > 0)
             {
                 shopid = dt.Rows[0]["ShopID"].ToString();
             }
             else
             {
                 Response.Write("<script>alert('没有此人负责的店铺');</script>");
                 return;
             }
         }
         
        if (!Page.IsPostBack)
        {
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
            this.Txt_Saletype.Text = dt.Rows[0]["Saletype"].ToString();
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
            
            txt_customerCard.Text = dt.Rows[0]["customerCard"].ToString();
            txt_shopownership.Text = dt.Rows[0]["shopownership"].ToString();
            if (userName.Equals(this.Txt_ShopMaster.Text))
            {
                if (dt.Rows[0]["ExamState"].ToString() == "1")
                {
                    this.Btn_Sure.Visible = false;
                }
                else
                {
                    this.Btn_Sure.Visible = true;
                }
            }

            GetExamState();
        }
    }

    private void GetExamState()
    {
        DataTable dt = new LN.BLL.EditShopInfo().GetExamState(shopid);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
           
                string strExamState = dt.Rows[0][0].ToString().Trim() == "" ? "1" : dt.Rows[0][0].ToString().Trim();
                string strVMExamState = dt.Rows[0][1].ToString().Trim() == "" ? "1" : dt.Rows[0][1].ToString().Trim();

                switch(strExamState)
                {
                    case "0":
                        lblExamState.Text = "未审批";
                        break;
                    case "1":
                        lblExamState.Text = "审批通过";
                        break;
                    case "-1":
                        lblExamState.Text = "未通过，被驳回";
                        break;
                }

                switch (strVMExamState)
                {
                    case "0":
                        lblVMExamState.Text = "未审批";
                        break;
                    case "1":
                        lblVMExamState.Text = "审批通过";
                        break;
                    case "-1":
                        lblVMExamState.Text = "未通过，被驳回";
                        break;
                }
            }
            else
            {
                lblExamState.Text = "审批通过";
                lblVMExamState.Text = "审批通过";
            }
        }
    }

    protected void Btn_Sure_Click(object sender, EventArgs e)
    {

        if (oneInfo.ConfirmShopInfo(int.Parse(shopid)))
        {
            Response.Write("<script>alert('店铺负责人确认成功');'</script>");
        }
        else
        {
            Response.Write("<script>alert('店铺负责人确认失败')</script>");
        }
    }
}

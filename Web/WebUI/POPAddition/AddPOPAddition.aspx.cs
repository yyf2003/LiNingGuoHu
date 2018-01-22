using System;
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

public partial class WebUI_POPAddition_AddPOPAddition : System.Web.UI.Page
{
    protected string shopid = string.Empty;
    protected string POPID = string.Empty;
    protected string supplierid = string.Empty;
    protected string Shopname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        shopid = this.Request.QueryString["shopid"].ToString();
        POPID = this.Request.QueryString["POPID"].ToString();
        if (!IsPostBack)
        {
            LN.BLL.ShopInfo oneInfo = new LN.BLL.ShopInfo();
            DataSet ds = oneInfo.GetList(" ShopID=" + int.Parse(shopid));
            DataTable dt = ds.Tables[0];
            this.PosID.Text = dt.Rows[0]["PosID"].ToString();
            Shopname = this.Txt_Shopname.Text = dt.Rows[0]["ShopName"].ToString();
            this.Txt_Address.Text = dt.Rows[0]["ShopAddress"].ToString();
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
            this.txt_town.Text = dt.Rows[0]["TownName"].ToString();
            //this.Txt_Saletype.Text = dt.Rows[0]["Saletype"].ToString();
            this.Txt_shoplevel.Text = dt.Rows[0]["ShopLevel"].ToString();
            this.Txt_ShopOpenDate.Text = dt.Rows[0]["ShopOpenDate"].ToString();
            this.Txt_ShopState.Text = new LN.BLL.ShopStateInfo().GetModel(int.Parse(dt.Rows[0]["ShopState"].ToString())).ShopState;
        }
        LoadAddAtionPOP(); 
    }
    /// <summary>
    /// 加载要增补的POP信息
    /// </summary>
    public void LoadAddAtionPOP()
    {
        DataTable dt = new LN.BLL.POPInfo().GetListDataSet("ID in (" + POPID + ")").Tables[0];
        dt.Columns.Add("isdone");
        foreach (DataRow dr in dt.Rows)
        {
            dr["isdone"] = CheckPOP(dr["ID"].ToString ());
        }
        RepPOPList.DataSource = dt;
        RepPOPList.DataBind(); 
    }


    public string CheckPOP(string POPinfoID)
    {
        POPID = new LN.BLL.POPLaunch().GetLastPOPID();
        return new LN.BLL.POPAddition().CheckPOP(POPinfoID,POPID);
       
    }
}

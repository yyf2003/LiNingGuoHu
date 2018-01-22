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

public partial class WebUI_POPAddition_SendToPOPAddition : System.Web.UI.Page
{

    protected string UserID = string.Empty; //登录用户编号
    protected string ShopID = string.Empty; //店铺名称
    protected string AddID = string.Empty;
    protected string ShopName = string.Empty; //店铺名称
    protected string SupplierID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        ShopID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        SupplierID = Request.QueryString["sid"] == null ? "0" : Request.QueryString["sid"].ToString();
        AddID = Request.QueryString["AddID"] == null ? "0" : Request.QueryString["AddID"].ToString();
        ShopName = new LN.BLL.ShopInfo().GetModel(Int32.Parse(ShopID)).Shopname;
        if (!IsPostBack)
        {
            GetPOPLaunchID();
            BindPhysical();
            BindPOPAddition();
        }
    }
    /// <summary>
    /// 获取最最新发起的POP
    /// </summary>
    private void GetPOPLaunchID()
    {
        LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetNewestModel();
        if (model != null)
            txtPOPID.Text = model.POPID.Trim();
        else
            btnAdd.Enabled = false;
    }

    private void BindPOPAddition()
    {
        string popid = txtPOPID.Text.Trim();
        int addid =int.Parse (AddID);
        DataTable dt = new LN.BLL.POPAddition().GetPOPInfoToSend(popid, addid).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            RepPOPList.DataSource = dt;
            RepPOPList.DataBind();
        }
        else
            btnAdd.Enabled = false;

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int UserID = int.Parse(this.Request.Cookies["UserID"].Value);
        int Addid = int.Parse(AddID);
        string SendTime = System.DateTime.Now.ToString().Length > 20 ? DateTime.Now.ToString().Substring(0, 20) : DateTime.Now.ToString();
        int State = 1;
        string Goodsorderno = this.txtGoodsOrderNO.Text.Trim();
        int Companyid = int.Parse(ddlCompanyName.SelectedItem.Value);
        string SendDes = txtRemarks.Text.Trim().Replace("\r\n", "<br>");
        new LN.BLL.POPAddition().SendPOPAddition(UserID, Addid, SendTime, State, Goodsorderno, Companyid, SendDes);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "_sendok", "<script>alert('发货成功！');window.location='SendToPOPAdditionList.aspx';</script>");
    }
    /// <summary>
    /// 绑定物流公司
    /// </summary>
    private void BindPhysical()
    {
        string sid = SupplierID.Trim();
        IList<LN.Model.PhysicalCompanyData> list = new LN.BLL.PhysicalCompanyData().GetList(" SupplierID = " + sid);
        ddlCompanyName.Items.Add(new ListItem("请选择物流公司", "0"));
        if (list.Count > 0)
        {
            foreach (LN.Model.PhysicalCompanyData item in list)
            {
                ddlCompanyName.Items.Add(new ListItem(item.CompanyName, item.CompanyID.ToString()));
            }
        }
    }
}

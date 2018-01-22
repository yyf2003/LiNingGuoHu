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

public partial class WebUI_PhysicalDistribution_SendToDealerInfo : System.Web.UI.Page
{
    protected string UserID = String.Empty; //登录用户编号
    protected string ShopID = String.Empty; //店铺名称
    protected string SupplierID = String.Empty; //所属供应商编号
    protected string DealerID = String.Empty; //所属一级客户编号
    protected string ShopName = String.Empty; //店铺名称
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
        DealerID = Request.QueryString["did"] == null ? "0" : Request.QueryString["did"].ToString();
        ShopName = new LN.BLL.ShopInfo().GetModel(Int32.Parse(ShopID)).Shopname;
        if (!IsPostBack)
        {
            GetPOPLaunchID();
            GetPOPList(); 
        }
    }


    /// <summary>
    /// 获取最最新发起的POP
    /// </summary>
    private void GetPOPLaunchID()
    {
        string POPID = new LN.BLL.POPChangeSet().GetPOPIDByShopID(ShopID);
        //LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetNewestModel();
        if (!string.IsNullOrEmpty(POPID))
            txtPOPID.Value  = POPID.Trim(); 
    }

    /// <summary>
    /// 获取指定店铺的POP列表
    /// </summary>
    private void GetPOPList()
    {
        try
        {
            string ProductLineID = new LN.BLL.POPLaunch().GetProline(txtPOPID.Value.Trim());
            List<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetList(" ExamState=1 and  imp.ShopID = " + ShopID + " AND ProductLineID IN (" + ProductLineID + ")");
            if (list != null && list.Count > 0)
            {
                RepPOPList.DataSource = list;
                RepPOPList.DataBind();
            }
        }
        catch(Exception e) {
            Response.Write(e.ToString());
        }
    }

    
}

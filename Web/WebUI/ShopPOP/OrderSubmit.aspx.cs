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

public partial class WebUI_ShopPOP_OrderSubmit : System.Web.UI.Page
{
    protected string NewPOPID = string.Empty;//最新发起的POP
    protected string UserID = string.Empty, Username = string.Empty;//得到登录人的ID
    string SupplierID = string.Empty;//得到登录人所管理的供应商
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        Username = Server.UrlDecode(Request.Cookies["UserName"].Value);
        
        LN.BLL.POPLaunch launchbll = new LN.BLL.POPLaunch();
        NewPOPID = launchbll.GetLastPOPID();//得到最新发起的POPID

        string upID = "";
        string strsql = " where shopid not in (select distinct shopid from imagetoPOP where POPID in (SELECT POPID FROM POPLaunch WHERE BeginDate<=getdate() and EndDate>=getdate()))";
        DataTable dt = new LN.BLL.DealerUser().GetDealerIdByUserID(int.Parse(UserID));
        if (dt.Rows.Count > 0)
        {
            upID = dt.Rows[0]["DealerID"].ToString();
            strsql += "  AND DealerID='" + upID + "'";
        }
        else
        {
            DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName(" FXID='" + Username.Substring(0, 7).Trim() + "'");
            if (fxdt.Rows.Count > 0)
            {
                upID = fxdt.Rows[0]["FXID"].ToString();
                strsql += " AND FXID='" + upID + "' ";
            }
        }
        

       
        if (strsql.Length > 0)
        {
            DataTable dts = new LN.BLL.imageToPOP().Supplier_NoSubmitOrderShop(strsql);

            GridView1.DataSource = dts;
            GridView1.DataBind();
        }
        else
        {
            Response.Write("没有所负责的店铺，无法进行此操作");
        }
    }

}

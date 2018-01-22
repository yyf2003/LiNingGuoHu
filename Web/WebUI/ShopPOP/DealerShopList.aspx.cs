using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class WebUI_ShopPOP_DealerShopList : System.Web.UI.Page
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
        NewPOPID = new LN.BLL.POPLaunch().GetLastPOPID();//得到最新发起的POPID

        string upID = "";
        string strsql = " WHERE 1=1 ";
        if (Username.Length >= 9)
        {
            Username = Username.Substring(0, 7);

            DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName(" FXID='" + Username + "'");
            if (fxdt.Rows.Count > 0)
            {
                upID = fxdt.Rows[0]["FXID"].ToString();
                strsql += " AND FXID='" + upID + "' ";
            }
        }
        else
        {
            DataTable dt = new LN.BLL.DealerUser().GetDealerIdByUserID(int.Parse(UserID));
            if (dt.Rows.Count > 0)
            {
                upID = dt.Rows[0]["DealerID"].ToString();
                strsql += "  AND DealerID='" + upID + "'";
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

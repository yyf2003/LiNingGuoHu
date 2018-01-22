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
using System.Text;
public partial class WebUI_GetBaseInfo_Base_shopInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string posID = Request.QueryString["ID"].ToString();
        StringBuilder str = new StringBuilder();
        DataTable dt = new LN.BLL.ShopInfo().GetShopNameByPosID(posID);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str.Append("<a>");
            str.Append(dt.Rows[i][1].ToString());
            str.Append("|");
            str.Append(dt.Rows[i][0].ToString());
            str.Append("</a>");
        }
        Response.Write(str.ToString());
    }
}

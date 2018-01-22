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
public partial class WebUI_GetBaseInfo_Base_DealerInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载一级客户

        string dealerID = Request.QueryString["ID"].ToString();
        StringBuilder str = new StringBuilder();
        DataTable dealerdt = new LN.BLL.DealerInfo().GetDealerName("dealerID like  '%" + dealerID + "%'");
        for (int i = 0; i < dealerdt.Rows.Count; i++)
        {
            str.Append("<a>");
            str.Append(dealerdt.Rows[i][1].ToString());
            str.Append("|");
            str.Append(dealerdt.Rows[i][0].ToString());
            str.Append("</a>");

        }
        Response.Write(str.ToString());
    }
}

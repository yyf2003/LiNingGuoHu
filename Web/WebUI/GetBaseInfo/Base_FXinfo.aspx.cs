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
public partial class WebUI_GetBaseInfo_Base_FXinfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder str = new StringBuilder();
        string FXID = Request.QueryString["ID"].ToString();
        DataTable dt = new LN.BLL.DistributorsInfo().GetIDName(" FXID like '%"+FXID+"%'");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str.Append("<a>");
            str.Append(dt.Rows[i]["FXName"].ToString());
            str.Append("|");
            str.Append(dt.Rows[i]["FXID"].ToString());
            str.Append("</a>");
        }

        Response.Write(str.ToString());
    }
}

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
using System.Collections.Generic;
public partial class WebUI_GetBaseInfo_Base_CustomerInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string CustomerID = Request.QueryString["ID"].ToString();
        List<LN.Model.CustomerInfo> modellist = new LN.BLL.CustomerInfo().GetModelList(" CustomerId like '%"+CustomerID+"%'");
        StringBuilder str = new StringBuilder();
        foreach (LN.Model.CustomerInfo model in modellist)
        {
            str.Append("<a>");
            str.Append(model.CustomerName);
            str.Append("|");
            str.Append(model.CustomerID.ToString());
            str.Append("</a>");
        }

        Response.Write(str.ToString());
    }
}

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

public partial class WebUI_POPLanuch_POPList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        
        int i = 0;
       IList<LN.Model.POPLaunch> modellist = new LN.BLL.POPLaunch().GetList(" steps=0");
      foreach (LN.Model.POPLaunch model in modellist)
      {
          string proname = "";
          
        IList<LN.Model.ProductLineData> promodellist = new LN.BLL.ProductLineData().GetList("ProductLineID in (" + model.ProductLineDatas + ")");
        foreach (LN.Model.ProductLineData promodel in promodellist)
        {
            proname += promodel.ProductLine + ",";
           // pronamelist += promodel.ProductLine + "\",\"";
        }
        model.ProductUrl = Server.UrlEncode(model.ProductLineDatas);
        model.ProductLineDatas =proname.Remove(proname.Length-1);
        i++;
        model.ID = i;
      }
      this.Repeater1.DataSource = modellist;
      Repeater1.DataBind();
    }
}

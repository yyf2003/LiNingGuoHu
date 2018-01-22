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
using System.Collections.Generic;
public partial class WebUI_POPLanuch_POPlaunchEdit : System.Web.UI.Page
{
    protected string  POPID = "", POPTitle = "", BeginDate = "", EndDate = "", ProductLineDatas = "", ProductUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        //{
        //    Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
        //    return;
        //}

        LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetNewestModel();

        string proname = "", pronamelist = "";
        if (model==null)
        {
            Response.Write("<script>alert('没有发起的季度POP活动，无法执行此功能');</script>");
           
            Response.End();
        }
        IList<LN.Model.ProductLineData> promodellist = new LN.BLL.ProductLineData().GetList("ProductLineID in (" + model.ProductLineDatas + ")");
        foreach (LN.Model.ProductLineData promodel in promodellist)
        {
            proname += promodel.ProductLine + ",";
            pronamelist += promodel.ProductLine + "\",\"";
        }
        ProductUrl = Server.UrlEncode(model.ProductLineDatas);
        ProductLineDatas = proname.Remove(proname.Length - 1);
        POPID = model.POPID;
        POPTitle = model.POPTitle;
        BeginDate = model.BeginDate.ToShortDateString();
        EndDate = model.EndDate.ToShortDateString();
    }
}

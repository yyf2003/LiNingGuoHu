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

public partial class WebUI_Supplier_POP_NoSubmitOrder : System.Web.UI.Page
{
    protected string imageID = string.Empty, POPID = string.Empty, supplierid = string.Empty, areaid = string.Empty, strProvince = string.Empty, strDealerInfo = string.Empty, strFXID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //imageID = Request.QueryString["imgid"] == null ? "" : Request.QueryString["imgid"].ToString();
        supplierid = Request.QueryString["sid"] == null ? "" : Request.QueryString["sid"].ToString();
        POPID = Request.QueryString["POPID"].ToString();
        areaid = Request.QueryString["areaid"] == null ? "" : Request.QueryString["areaid"].ToString();
        string dept = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();

        strProvince = Request.QueryString["province"] == null ? "0" : Request.QueryString["province"].ToString();
        strDealerInfo = Request.QueryString["dealer"] == null ? "0" : Request.QueryString["dealer"].ToString();
        strFXID = Request.QueryString["fxid"] == null ? "0" : Request.QueryString["fxid"].ToString();

        //string sql = " where shopid not in (select shopid from imagetoPOP where POPID='" + POPID + "' group by shopid) ";
        string sql = " where ShopInfo.[ShopState]>0 and (SELECT COUNT(ID) FROM POPInfo WHERE  ShopID=ShopInfo.shopid and IsHide=0)>0 ";
        //if (imageID != "")
        //{
        //    sql += "and imagetopop.imageID=" + imageID;
        //}

        if (supplierid != "")
            sql += " and supplierid=" + supplierid;
        if (areaid != "" && areaid != "0")
            sql += " and ShopInfo.areaid=" + areaid;
        if (dept.Trim().Length > 0)
            sql += " and DepartMent='" + dept + "' ";

        if (strProvince != "0")
            sql += " and ProvinceID='" + strProvince + "' ";
        if (strDealerInfo != "0")
            sql += " and DealerID='" + strDealerInfo + "' ";
        if (strFXID != "0")
            sql += " and FXID='" + strFXID + "' ";

        DataTable dt = new LN.BLL.imageToPOP().Supplier_NoSubmitOrderShopNew(sql, POPID);
        GridView1.DataSource = dt;
        GridView1.DataBind();
      //  GroupRows(GridView1, 0);
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "GB2312";  //设置了类型为中文防止乱码的出现  
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddhhmmss") + "OrderList.xls"); //定义输出文件和文件名
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");//设置输出流为简体中文

        Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
        this.EnableViewState = false;
        System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter(myCItrad);
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        //this.GridView1.RenderControl(oHtmlTextWriter);
        // Session["otherdt"] = null;

        Response.Write(oStringWriter.ToString());
    }
}

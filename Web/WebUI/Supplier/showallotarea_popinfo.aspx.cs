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

public partial class WebUI_Supplier_showallotarea_popinfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string supplierID = Request.QueryString["ID"].ToString();
        int sID = 0;
        int.TryParse(supplierID, out sID);
        GridView1.DataSource = new LN.BLL.SupplierAssignRecord().Getsupplier_popinfo(sID);
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "GB2312";  //设置了类型为中文防止乱码的出现  
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls"); //定义输出文件和文件名
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

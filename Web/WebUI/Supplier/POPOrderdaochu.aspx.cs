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

public partial class WebUI_Supplier_POPOrderdaochu : System.Web.UI.Page
{
    protected string imageID = string.Empty, POPID = string.Empty, supplierid = string.Empty, areaid = string.Empty, strProvince = string.Empty, strDealerInfo = string.Empty, strFXID = string.Empty, strBeginDate = string.Empty, strEndDate = string.Empty;

    //add by mhj 2012.08.17
    string SpecialType = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        imageID = Request.QueryString["imgid"] == null ? "" : Request.QueryString["imgid"].ToString();
        supplierid = Request.QueryString["sid"] == null ? "" : Request.QueryString["sid"].ToString();
        POPID = Request.QueryString["POPID"].ToString();
        areaid = Request.QueryString["areaid"] == null ? "0" : Request.QueryString["areaid"].ToString();
        strProvince = Request.QueryString["province"] == null ? "0" : Request.QueryString["province"].ToString();
        strDealerInfo = Request.QueryString["dealer"] == null ? "0" : Request.QueryString["dealer"].ToString();
        strFXID = Request.QueryString["fxid"] == null ? "0" : Request.QueryString["fxid"].ToString();
        strBeginDate = Request.QueryString["begdate"] == null ? "" : Request.QueryString["begdate"].ToString();
        //strEndDate = Request.QueryString["enddate"] == null ? "" : Request.QueryString["enddate"].ToString();
        strEndDate = DateTime.Now.ToString();

        //add by mhj 2012.08.17
        SpecialType = Request.QueryString["SpecialType"] == null ? "" : Request.QueryString["SpecialType"].ToString();

        string dept = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();
        string sql = " 1=1 ";

        //add by mhj 2012.08.17
        if (SpecialType == "0" || SpecialType == "1")
        {
            sql += " and SpecialType=" + SpecialType;
        }

        if (imageID != "")
        {
            sql += " and c.imageID=" + imageID;
        }
        if (supplierid != "")
            sql += " and supplierid=" + supplierid;
        if (areaid != "0")
            sql += " and areaid=" + areaid;
        if (dept.Trim().Length > 0)
            sql += " and DepartMent='" + dept + "' ";

        if (strProvince != "0")
            sql += " and ProvinceID='" + strProvince + "' ";
        if (strDealerInfo != "0")
            sql += " and DealerID='" + strDealerInfo + "' ";
        if (strFXID != "0")
            sql += " and FXID='" + strFXID + "' ";
        if (strBeginDate != "")
        {
            sql += " and c.sysTime BETWEEN CONVERT(DATETIME,'" + strBeginDate + "',120) AND CONVERT(DATETIME,'" + strEndDate + "',120) ";
            LN.Model.tb_OrderSearch_Time m = new LN.Model.tb_OrderSearch_Time();
            m.TIME_POPID = POPID;
            m.TIME_SearchTime = DateTime.Parse(strEndDate);
            m.TIME_USERID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            int AddSearchTime = new LN.BLL.tb_OrderSearch_Time().Add(m);

        }
       
        DataTable dt = new LN.BLL.imageToPOP().supplier_orderdaochu(sql, POPID);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //GroupRows(GridView1, 0);
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
    ///   <summary>  
    ///   根据条件列合并GridView列中相同的行  
    ///   </summary>  
    ///   <param   name=”GridView1″>GridView对象</param>  
    ///   <param   name=”cellNum”>需要合并的列</param>
    ///   ///   <param   name=”cellNum2″>条件列(根据某条件列还合并)</param>
    public static void GroupRows(GridView GV, int cellNum)
    {
        int i = 0, rowSpanNum = 1;
        while (i < GV.Rows.Count - 1)
        {
            GridViewRow gvr = GV.Rows[i];
            for (++i; i < GV.Rows.Count; i++)
            {
                GridViewRow gvrNext = GV.Rows[i];
                if (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text)
                {

                    for (int y = 0; y < 42; y++)
                    {
                        gvrNext.Cells[y].Visible = false;
                    }
                    rowSpanNum++;
                }
                else
                {

                    for (int y = 0; y < 42; y++)
                    {
                        gvr.Cells[y].RowSpan = rowSpanNum;
                    }
                    rowSpanNum = 1;
                    break;
                }

                if (i == GV.Rows.Count - 1)
                {
                    gvr.Cells[cellNum].RowSpan = rowSpanNum;
                }
            }
        }
    }
}


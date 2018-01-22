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
using LN.DBUtility;
public partial class WebUI_Supplier_HavaPOPShops : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder str = new StringBuilder();
        str.Append("select  posid,shopname,shopaddress,(select provincename from  provincedata where provinceid=shopinfo.provinceid),");
        str.Append(" (select cityname from citydata where cityid=shopinfo.cityid),");
        str.Append(" (select dealername from dealerinfo where dealerid=shopinfo.dealerid),");
        str.Append("  linkman,linkphone,shopmaster,shopmasterPhone,Email,VMmaster,VMmasterPhone,DSRMaster,DSRMasterPhone,shoparea,");
        str.Append(" (select areaname from areadata where areaid=shopinfo.areaid),");
        str.Append(" (select shoplevel from shoplevel where levelID=shopinfo.shoplevelid),");
        str.Append(" (select shopviname from shopvi where shopviid=shopvi),");
        str.Append(" (select shoptypename from shoptype where id=shopinfo.shoptype),popinfo.*,(select producttypename from View_ProductLine where productlineid=popinfo.productlineid),");
        str.Append(" (select productline from View_ProductLine where productlineid=popinfo.productlineid)");
        str.Append(" from popinfo,shopinfo where shopinfo.shopid=popinfo.shopid  order by DealerID,shopinfo.shopid");

        DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), str.ToString());
      GridView1.DataSource = ds;
      GridView1.DataBind();
      GroupRows(GridView1, 0, 1, 2, 3, 4, 5);
      Response.Clear();
      Response.Buffer = true;
      Response.Charset = "GB2312";  //设置了类型为中文防止乱码的出现  
      Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddhhmmss") + "OrderList.xls"); //定义输出文件和文件名
      Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文

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
    public static void GroupRows(GridView GV, int cellNum, int cellNum1, int cellNum2, int cellNum3, int cellNum4, int cellNum5)
    {
        int i = 0, rowSpanNum = 1;
        while (i < GV.Rows.Count - 1)
        {
            GridViewRow gvr = GV.Rows[i];
            for (++i; i < GV.Rows.Count; i++)
            {
                GridViewRow gvrNext = GV.Rows[i];
                string strgvr = "";
                string strgvrnext = "";
                for (int y = 0; y <=15; y++)
                {
                    strgvr += gvr.Cells[y].Text;
                    strgvrnext += gvrNext.Cells[y].Text;
                }
               // if (gvr.Cells[cellNum].Text + gvr.Cells[cellNum1].Text + gvr.Cells[cellNum2].Text + gvr.Cells[cellNum3].Text + gvr.Cells[cellNum4].Text + gvr.Cells[cellNum5].Text == gvrNext.Cells[cellNum].Text + gvrNext.Cells[cellNum1].Text + gvrNext.Cells[cellNum2].Text + gvrNext.Cells[cellNum3].Text + gvrNext.Cells[cellNum4].Text + gvrNext.Cells[cellNum5].Text)
                if(strgvr==strgvrnext)
                {
                    //gvrNext.Cells[cellNum].Visible = false;
                    //gvrNext.Cells[cellNum1].Visible = false;
                    //gvrNext.Cells[cellNum2].Visible = false;
                    //gvrNext.Cells[cellNum3].Visible = false;
                    //gvrNext.Cells[cellNum4].Visible = false;
                    //gvrNext.Cells[cellNum5].Visible = false;
                    for (int y = 0; y <= 15; y++)
                    {
                        gvrNext.Cells[y].Visible = false;
                    }
                    rowSpanNum++;
                }
                else
                {
                    //gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    //gvr.Cells[cellNum1].RowSpan = rowSpanNum;
                    //gvr.Cells[cellNum2].RowSpan = rowSpanNum;
                    //gvr.Cells[cellNum3].RowSpan = rowSpanNum;
                    //gvr.Cells[cellNum4].RowSpan = rowSpanNum;
                    //gvr.Cells[cellNum5].RowSpan = rowSpanNum;
                    for (int y = 0; y <= 15; y++)
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

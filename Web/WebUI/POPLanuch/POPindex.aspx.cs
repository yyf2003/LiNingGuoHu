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
using System.Text;
public partial class WebUI_POPLanuch_POPindex : System.Web.UI.Page
{
    protected StringBuilder sb = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        sb.Append("<table class='table'>");
        sb.Append("<tr>");
        sb.Append("<th>POPID</th>");
        sb.Append("<th>POP标题</th>");
        sb.Append("<th>开始时间</th>");
        sb.Append("<th>结束时间</th>");
        sb.Append("<th>发起者</th>");
        sb.Append("<th>产品系列</th>");
        sb.Append("<th>文件</th>");
        sb.Append("<th></th>");
        sb.Append("<th></th>");
        sb.Append("</tr>");
        IList<LN.Model.POPLaunch> modellist = new LN.BLL.POPLaunch().GetList(" steps<>0");
        if (modellist.Count > 0)
        {
            foreach (LN.Model.POPLaunch model in modellist)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + model.POPID + "</td>");
                sb.Append("<td>" + model.POPTitle + "</td>");
                sb.Append("<td>" + model.BeginDate.ToString() + "</td>");
                sb.Append("<td>" + model.EndDate.ToString() + "</td>");
                sb.Append("<td>" + model.OrganigerName + "</td>");
                string proname = "";

                IList<LN.Model.ProductLineData> promodellist = new LN.BLL.ProductLineData().GetList("ProductLineID in (" + model.ProductLineDatas + ")");
                foreach (LN.Model.ProductLineData promodel in promodellist)
                {
                    proname += promodel.ProductLine + ",";

                }
                sb.Append("<td>" + proname + "</td>");
                string urlstr = "";
                if (model.steps == 2)
                    urlstr = "POPLaunchTwo.aspx";
                if (model.steps == 3)
                    urlstr = "POPImgSet.aspx";
                if (model.steps == 4)
                    urlstr = "POPLaunchSetCiyt.aspx";

                string hrefstr = "<a href='" + urlstr + "?POPID=" + model.POPID + "'>继续完整信息</a>";
                sb.Append("<td><a target='_bank' href='" + model.UploadFileUrl + "'>上传的文件</a></td>");
                sb.Append("<td>" + hrefstr + "</td>");
                sb.Append("<td><a href='del.aspx?POPID=" + model.POPID + "' onclick=\"return confirm('是否要删除此发起的POP')\">删除</a></td>");
                sb.Append("</tr>");
            }
        }
        else
        {
            Response.Redirect("POPLaunchOne.aspx");
        }
        sb.Append("</table>");
    }
}

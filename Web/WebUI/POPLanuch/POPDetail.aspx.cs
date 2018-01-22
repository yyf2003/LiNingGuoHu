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
public partial class WebUI_POPLanuch_POPDetail : System.Web.UI.Page
{
    public string strDisplay = "display:none;";
    protected string POPID = string.Empty;
    protected string fileurl = string.Empty ,DownLoadFilename=string.Empty,productlist=string.Empty;
    protected int totalnum = 0;//pop总数量
    protected double totalarea = 0.0000;//pop总面积
    protected StringBuilder totalstr = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;
      
       string supplierID = "0";//如果是VM进来 供应商ID 为 0 
       IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
       if (supplierBody!= null)
       {
           supplierID = supplierBody[0].ToString();
       }

       POPID = Request.QueryString["POPID"].ToString();
       productlist = Request.QueryString["POPpro"].ToString();//得到要参加POP的故事包
      // Response.Write(productlist);
        //POPID = "20090511042830";
       if (!Page.IsPostBack)
       {
           LN.Model.POPLaunch launchmodel = new LN.BLL.POPLaunch().GetModel(POPID);

           Label1.Text = launchmodel.POPTitle;
           Label2.Text = launchmodel.BeginDate.ToShortDateString();
           Label3.Text = launchmodel.EndDate.ToShortDateString();
           Label4.Text = launchmodel.LaunchDesc;
           fileurl = launchmodel.UploadFileUrl;
           DownLoadFilename = "没有文件可供下载";
           if (fileurl != null && fileurl.Length > 0)
           {
               DownLoadFilename = fileurl.Substring(fileurl.LastIndexOf("/") + 1);
           }

           bind("POPID='" + POPID + "' order by productlevel,ImageLevel ASC");
   


           //string tempprolist = productlist;//将url中prolist参数的"替换为'
           //if (productlist.IndexOf('"') > 0)
           //{
           //    tempprolist=productlist.Replace('"','\'');
           //}

          

           //加载上传图片的产品大类
           DataTable typedt = new LN.BLL.POPImageData().GetSetProtype(POPID);
           for (int i = 0; i < typedt.Rows.Count; i++)
           {
               ListItem item = new ListItem(typedt.Rows[i][0].ToString(),typedt.Rows[i][0].ToString());
               DDL_Prolist.Items.Add(item);
           }
       }
       DataTable totalpop = new LN.BLL.POPLaunch().GetTotalPOPList(POPID, supplierID, productlist);

       // StringBuilder totalstr = new StringBuilder();
       totalstr.Append("<table class='table'>");
       totalstr.Append("<tr>");
       totalstr.Append("<th>供应商名称</td><th>POP数量</td><th>POP总面积</td>");
       totalstr.Append("</tr>");

       for (int i = 0; i < totalpop.Rows.Count; i++)
       {
           totalstr.Append("<tr>");
           totalstr.Append("<td style='width:300px'>" + totalpop.Rows[i][2].ToString() + "</td><td><a href='POPLaunchEvaryShopPOP.aspx?POPID=" + POPID + "&sid=" + totalpop.Rows[i][3].ToString() + "&prolist=" + Server.UrlEncode(productlist) + "&sname=" + Server.UrlEncode(totalpop.Rows[i][2].ToString()) + "'>" + totalpop.Rows[i][0].ToString() + "</a></td><td>" + totalpop.Rows[i][1].ToString() + "</td>");
           totalstr.Append("</tr>");
           totalnum += int.Parse(totalpop.Rows[i][0].ToString());
           totalarea += double.Parse(totalpop.Rows[i][1].ToString());
       }
       totalstr.Append("</table>");

       LN.Model.UserInfo model_user = new LN.BLL.UserInfo().GetModel(int.Parse(UserID));
       if (model_user.Usertype == "1")
       {
           strDisplay = "";
       }
    }
    protected void DDL_Prolist_SelectedIndexChanged(object sender, EventArgs e)
    {

        DDL_ProLine.Items.Clear();
        DDL_ProLine.Items.Add(new ListItem("请选择产品系列","0"));

        DataTable linedt = new LN.BLL.POPImageData().GetLineByType(POPID,DDL_Prolist.Text);
        for (int i = 0; i < linedt.Rows.Count; i++)
        {
            ListItem item = new ListItem(linedt.Rows[i][0].ToString(), linedt.Rows[i][0].ToString());
            DDL_ProLine.Items.Add(item);
        }

        string str = "POPID='" + POPID + "'";
        if (DDL_Prolist.Text != "0")
        {
            str += string.Format(" and ProductTypeName='{0}'", DDL_Prolist.Text);
        }
       
        str += " order by productlevel,ImageLevel ASC";
        bind(str);
    }
    protected void DDL_ProLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "POPID='" + POPID + "'";
        if (DDL_Prolist.Text != "0")
        {
            str += string.Format(" and ProductTypeName='{0}'",DDL_Prolist.Text);
        }
        if (DDL_ProLine.Text != "0")
        {
            str += string.Format(" and productlinename='{0}'", DDL_ProLine.Text);
        }
        str += " order by productlevel,ImageLevel ASC";
        bind(str);
    }

    private void bind(string bindstr)
    {
        IList<LN.Model.POPImageData> modellist = new LN.BLL.POPImageData().GetList(bindstr);

        Repeater1.DataSource = modellist;
        Repeater1.DataBind();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            new LN.BLL.POPImageData().Delete(int.Parse(e.CommandArgument.ToString()));
            bind("POPID='" + POPID + "' order by productlevel,ImageLevel ASC");
        }
    }
   
}

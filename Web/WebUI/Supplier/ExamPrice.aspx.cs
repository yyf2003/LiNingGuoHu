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

public partial class WebUI_Supplier_ExamPrice : System.Web.UI.Page
{
    protected int Pagei = 0;
    protected string gID = "";//供应商ID
    protected string sName = String.Empty;    //供应商名称
    protected string Pid = "";//pop发起ID
    protected string UserID = "0";//所登录的ID  Cookie中得到

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;//得到登录用户的ID
        Pid = new LN.BLL.POPLaunch().GetLastPOPID();
        gID = Request.QueryString["gID"] == null ? "0" : Request.QueryString["gID"].ToString();//得到供应商ID
        sName = new LN.BLL.SupplierInfo().GetModel(Int32.Parse(gID)).SupplierName;
        if (!Page.IsPostBack)
        {
            GridView1.DataSource =bind(Pid, gID, "0");
            GridView1.DataBind(); 
          
        }
        Repeater1.DataSource = bind(Pid, gID, "1");
        Repeater1.DataBind();
        
    }

    protected IList<LN.Model.POPPrice> bind(string POPID, string supplierID,string Examstate)
    {
        string sqlstr = "POPID='"+POPID+"' and p.SupplierID = '" + supplierID + "'";
        if (Examstate.Length > 0)
        {
            sqlstr += " and ExamState="+Examstate;
        }
        IList<LN.Model.POPPrice> list = new LN.BLL.POPPrice().GetList(sqlstr);
        return list;
    }
    protected void btn_Exam_Click(object sender, EventArgs e)
    {
        List<string> strlist = new List<string>();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox cb_in = (CheckBox)gr.Cells[4].FindControl("Check_in");
           
            Label l1 = (Label)gr.Cells[3].FindControl("Label1");

            if (cb_in.Checked)
            {  
               string inPopstage = "update POPPrice set ExamState=1,ExamUserID="+UserID+" where PriceID="+gr.Cells[5].Text;
               strlist.Add(inPopstage);
            }
           
        }

        try
        {
            new LN.BLL.POPPrice().ExamPrice(strlist);
            GridView1.DataSource = bind(Pid, gID, "0");
            GridView1.DataBind(); 
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            Pagei++;
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ECECEC'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            e.Row.Cells[0].Text = Pagei.ToString();
            e.Row.Cells[5].Visible =false;
        }
    }
}

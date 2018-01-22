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

public partial class WebUI_ShopPOP_ExamShopPopList : System.Web.UI.Page
{
    string UserID = string.Empty, deptname = string.Empty, UserName=string.Empty;
    protected string shopid = string.Empty, Shopname = string.Empty, SupplierID = string.Empty, SupplierName = string.Empty;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        shopid = Request.QueryString["shopid"].ToString();
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        if (deptdt.Rows.Count > 0)
        {
            deptname = deptdt.Rows[0]["department"].ToString();
        }
        if (!Page.IsPostBack)
        {
            bind(shopid);

          DataTable dt=  new LN.BLL.SupplierAssignRecord().GetSpplierAssignRecordWithShopID(int.Parse(shopid));

          Shopname = dt.Rows[0]["ShopName"].ToString();
          SupplierID = dt.Rows[0]["SupplierID"].ToString();
          SupplierName = dt.Rows[0]["SupplierName"].ToString();
        }
    }

    private void bind(string _shopid)
    {
        string strsql = "";
        if (!string.IsNullOrEmpty(deptname))
        {
            strsql = " and  VMExamState=1 and  ExamState=0 ";
        }
        else
        {
            strsql = " and  VMExamState=0  and  ExamState=0  ";
        }

        IList<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetList(" vsl.shopid=" + _shopid + strsql);
        this.GridView1.DataSource = list;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;

            HyperLink HyLink = e.Row.Cells[22].FindControl("HyLinkShow") as HyperLink;

            HyLink.NavigateUrl = "./ShowPOPImg.aspx?id=" + e.Row.Cells[20].Text.Trim();

        }
    }
    /// <summary>
    /// 审核通过操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Exam_Click(object sender, EventArgs e)
    {
        string strID="0,";
        List<string> examlist = new List<string>();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox cb=(CheckBox)gr.Cells[19].Controls[0].FindControl("DB_exam");
            if (cb.Checked)
            {
                examlist.Add(gr.Cells[20].Text);
                strID+=gr.Cells[20].Text+",";
            }
        }

        if (examlist.Count > 0)
        {
            bool flag = false;
            strID = strID.Remove(strID.Length-1);
            if (!string.IsNullOrEmpty(deptname))
            {
                flag = new LN.BLL.POPInfo().ExamShopPOP(examlist, UserID);
            }
            else
            {
                flag = new LN.BLL.POPInfo().VMExamPOPState("1", strID, UserID);
            }
            if (flag)
                Response.Write("<script>alert('更新成功');window.location.href='ConfirmPOP.aspx' </script>");
            else
                Response.Write("<script>alert('更新失败');</script>");

            bind(shopid);
        }
    }
    /// <summary>
    /// 审核未通过操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_ExamNo_Click(object sender, EventArgs e)
    {
        string StrID = "0,";
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox cb = (CheckBox)gr.Cells[19].Controls[0].FindControl("DB_exam");
            if (cb.Checked)
            {
                StrID += gr.Cells[20].Text+",";
            }
        }

        StrID = StrID.Remove(StrID.Length-1);
        try
        {
            if (!string.IsNullOrEmpty(deptname))//如果是 大区域vm审核未通过则 放弃此数据
            {
                new LN.BLL.POPInfo().giveupPOP(StrID, UserID);
            }
            else
            {
                new LN.BLL.POPInfo().VMExamPOPState("-1", StrID, UserID);
            }
            Response.Write("<script>alert('更新成功');window.location.href='ConfirmPOP.aspx' </script>");
        }
        catch (Exception)
        {

            Response.Write("<script>alert('更新失败');</script>");
        }

        bind(shopid);
    }
}

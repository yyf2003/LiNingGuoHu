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

public partial class WebUI_Supplier_GiveUp : System.Web.UI.Page
{
    string sID = "", Username = "";//供应商ID,操作人姓名

    LN.BLL.SupplierInfo bll = new LN.BLL.SupplierInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        Username =Server.UrlDecode( Request.Cookies["UserName"].Value);//得到登录用户的ID

        sID=Request.QueryString["gID"].ToString();
        if (!Page.IsPostBack)
        {
            LN.Model.SupplierInfo mobel = bll.GetModel(int.Parse(sID));
            this.Txt_lxr.Text = mobel.Contacter;
            this.Txt_phone.Text = mobel.ContactPhone;
            this.Txt_Role.Text = mobel.ContacterRole;
            this.Txt_supplier.Text = mobel.SupplierName;
        }
    }
    protected void btn_fangqi_Click(object sender, EventArgs e)
    {
        try
        {
            bll.GiveUpSup(int.Parse(sID), Txt_remarks.Text + "  操作人：" + Username);
            Response.Write("<script>alert('操作成功');location.href='SupplierListByVM.aspx'</script>");
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}

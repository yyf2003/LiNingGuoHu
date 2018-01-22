using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUI_Supplier_AddWuLiu : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //登录用户编号
    protected string SupplierID = String.Empty; //所属供应商编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        this.UserID = Request.Cookies["UserID"].Value;
        this.SupplierID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        if (SupplierID == "0")
            btnAdd.Enabled = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LN.Model.PhysicalCompanyData model = new LN.Model.PhysicalCompanyData();
        model.CompanyName = txtSupplierName.Text.Trim();
        model.Contactor = txtContacter.Text.Trim();
        model.ContactorPhone = txtContactPhone.Text.Trim();
        string Remarks = "";
        if (txtRemarks.Text.Trim() != "")
        {
            Remarks = txtRemarks.Text.Replace(" ", "&nbsp;").Replace("\r\n", "<br />");
        }
        model.CompanyNameDesc = Remarks;
        model.SupplierID = Int32.Parse(SupplierID);

        int result = new LN.BLL.PhysicalCompanyData().Add(model);
        if (result > 0)
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tishi", "<script language='javascript'>alert('添加物流公司成功！！');window.location=window.location;</script>");
        else
            Response.Redirect("../../Error.aspx?param=6");
    }
}

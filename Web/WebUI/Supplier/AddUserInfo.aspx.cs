using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_Supplier_AddUserInfo : System.Web.UI.Page
{
    protected string UserID = String.Empty; //登录用户编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        if (!IsPostBack)
        {
            int supplierID = GetSupplierID(UserID);
            if (supplierID == 0)
                Response.Redirect("../../Error.aspx?param=4");
            else
                hidSupplierID.Value = supplierID.ToString();
        }
    }

    /// <summary>
    /// 根据用户编号获取供应商编号
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <returns>返回供应商编号</returns>
    private int GetSupplierID(string userid)
    {
        int _return = 0;
        IList<int> list = new LN.BLL.SupplierInfo().GetSupplierID(userid);
        if (list != null)
        {
            if (list[1] == 2)    //有添加人员的权限
                _return = list[0];  //获取供应商编号
        }

        return _return;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LN.Model.UserInfo model = new LN.Model.UserInfo();
        model.Username = txtUserName.Text.Trim();
        model.UserPassword = txtPassWord.Text;
        model.Sex = ddlSex.SelectedValue.Trim();
        int UserType = Int32.Parse(ddlUserType.SelectedValue.Trim());
        model.UserEmail = txtEmail.Text.Trim();
        model.UserMobel = txtMob.Text.Trim();
        model.UserPhone = txtPhone.Text.Trim();
        model.UserAddress = txttAddress.Text.Trim();
        model.UserDesc = txtRemarks.Text.Trim();
        model.UserState = 1;

        int result = new LN.BLL.UserInfo().AddSupplierUser(model, Int32.Parse(hidSupplierID.Value), UserType);
        if (result > 0)
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tishi", "<script language='javascript'>alert('添加员工成功！！');window.location=window.location;</script>");
        else
            Response.Redirect("../../Error.aspx?param=5");
    }
}

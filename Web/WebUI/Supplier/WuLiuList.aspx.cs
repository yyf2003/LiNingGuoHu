using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUI_Supplier_WuLiuList : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //登录用户编号
    protected string SupplierID = "0"; //所属供应商编号
    protected string TypeID = String.Empty;     //该用户在供应商中的权限
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        this.UserID = Request.Cookies["UserID"].Value;
        this.GetSupplierID();
        this.BindWuLiuBySupplierID();
        if (TypeID == "1" || TypeID == "2")
        {
            hyLink.Visible = true;
            hyLink.NavigateUrl = "AddWuLiu.aspx?id=" + SupplierID;
        }
    }

    /// <summary>
    /// 获取指定用户所属的供应商编号和权限
    /// </summary>
    /// <param name="userid">用户编号</param>
    private void GetSupplierID()
    {
        IList<int> s = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (s != null && s.Count > 0)
        {
            SupplierID = s[0].ToString();
            TypeID = s[1].ToString();
        }
        else
        {
            Response.Redirect("../../Error.aspx?param=10");
            return;
        }
    }

    private void BindWuLiuBySupplierID()
    {
        IList<LN.Model.PhysicalCompanyData> list = new LN.BLL.PhysicalCompanyData().GetList(" SupplierID = " + SupplierID);
        if (list.Count > 0)
        {
            RepWuLiu.DataSource = list;
            RepWuLiu.DataBind();
        }
    }
}

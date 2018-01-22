using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUI_Supplier_UserManage : System.Web.UI.Page
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
            {
                hidSupplierID.Value = supplierID.ToString();
                GetList();
            }
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
            {
                hyLink.NavigateUrl = "./AddUserInfo.aspx";
                hyLink.Visible = true;
            }
            _return = list[0];  //获取供应商编号
        }

        return _return;
    }


    private void GetList()
    {
        string strWhere = String.Empty; //搜索条件
        int totalNumber = 0;        //返回搜索后的员工数量
        if (txtUserName.Text.Trim() != "")
            strWhere += string.Format(" AND u.Username LIKE '%{0}%'", txtUserName.Text.Trim());
        if (ddlUserType.SelectedValue.Trim() != "-1")
            strWhere += string.Format(" AND SupplierUserManage.TypeID = {0} ", ddlUserType.SelectedValue.Trim());

        LN.Model.PageModel model = new LN.Model.PageModel();
        model.SelectSql = LN.DAL.GetTableListSqlExec.strGetSupplierUserSql(hidSupplierID.Value, strWhere);
        model.pageIndex = ListPages.CurrentPageIndex;
        model.pageSize = ListPages.PageSize;
        model.OrderField = "UserID DESC";
        DataTable dt = new LN.BLL.SupplierAssignRecord().GetAssignRecordByID(model, out totalNumber);
        if (dt != null)
        {
            ListPages.RecordCount = totalNumber;
            RepSupplierUser.DataSource = dt;
            RepSupplierUser.DataBind();
        }
    }

    protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPages.CurrentPageIndex = e.NewPageIndex;
        GetList();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetList();
    }
}

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

public partial class WebUI_SetUpConfirm_SearchShop : System.Web.UI.Page
{
    public string UserID = string.Empty;
    public string TypeID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            UserID = this.Request.Cookies["UserID"].Value;
            GetSupplierID();
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
            hidSupplierID.Value = s[0].ToString();
            TypeID = s[1].ToString();
        }
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        BindData();
    }
    public void BindData()
    {
        string posid = this.txt_posid.Text.Trim();
        string shopname = this.txt_shopname.Text.Trim();
        string parm = "";
        if (posid != "")
            parm += " and PosID ='" + posid + "' ";
        if (shopname != "")
            parm += " and Shopname like '%" + shopname + "%'  ";

        parm += " and  SupplierID =" + hidSupplierID.Value;

        DataTable dt = new LN.BLL.ShopInfo().GetShopInfoWithSupplierID(parm).Tables[0];
        int rid = 1;
        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add("Rid");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Rid"] = rid.ToString();
                rid++;
            }
        }
        GV_UserList.DataSource = dt;
        GV_UserList.DataBind();

    }
    protected void GV_UserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GV_UserList.PageIndex = e.NewPageIndex;
        BindData();


    }
}

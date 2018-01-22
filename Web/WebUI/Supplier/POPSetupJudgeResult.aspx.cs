using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class WebUI_Supplier_POPSetupJudgeResult : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //登录用户编号
    protected string TypeID = String.Empty;     //该用户在供应商中的权限

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
            this.GetSupplierID();
            if (TypeID != "1" && TypeID != "2")
            {
                Response.Redirect("../../Error.aspx?param=12");
                return;
            }
            BindProvinceData();
            BindPOPLaunch();
            BindDealerInfo();
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
            HidSupplierID.Value = s[0].ToString();
            TypeID = s[1].ToString();
        }
        else
        {
            Response.Redirect("../../Error.aspx?param=10");
            return;
        }
    }

    /// <summary>
    /// 绑定店铺一级客户
    /// </summary>
    private void BindDealerInfo()
    {
        LN.DAL.DealerInfo dealerDAL = new LN.DAL.DealerInfo();
        DataTable dealerdt = dealerDAL.GetDealerName("");
        for (int i = 0; i < dealerdt.Rows.Count; i++)
        {
            ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
            ddl_dealer.Items.Add(item);
        }
    }

    /// <summary>
    /// 绑定省份
    /// </summary>
    private void BindProvinceData()
    {
        IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
        for (int i = 0; i < pList.Count; i++)
        {
            ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
            DDL_Province.Items.Add(item);
        }
    }

    /// <summary>
    /// 绑定发起的POP
    /// </summary>
    private void BindPOPLaunch()
    {
        IList<LN.Model.POPLaunch> pList = new LN.BLL.POPLaunch().GetList("");
        for (int i = 0; i < pList.Count; i++)
        {
            ListItem item = new ListItem(pList[i].POPTitle, pList[i].POPID.ToString());
            DDL_POP.Items.Add(item);
        }
    }
}

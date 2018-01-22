using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class WebUI_Supplier_POPSetupJudgeList : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //登录用户编号
    private string UserArea = String.Empty;     //用户所属区域编号
    private string strWhere = String.Empty;     //查询条件
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        if (userdt.Rows.Count > 0)
        {
            UserArea = userdt.Rows[0][0].ToString();
            strWhere = " AreaID = " + UserArea;
        }

        if (!IsPostBack)
        {
            BindPOPLaunch();
            BindSupplier();
            BindDealerInfo();
            BindProvinceData();
        }
    }

    /// <summary>
    /// 绑定店铺一级客户
    /// </summary>
    private void BindDealerInfo()
    {
        LN.DAL.DealerInfo dealerDAL = new LN.DAL.DealerInfo();
        DataTable dealerdt = dealerDAL.GetDealerName(strWhere);
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
        IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList(strWhere);
        for (int i = 0; i < pList.Count; i++)
        {
            ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
            DDL_Province.Items.Add(item);
        }
    }

    /// <summary>
    /// 绑定供应商
    /// </summary>
    private void BindSupplier()
    {
        IList<LN.Model.SupplierInfo> pList = new LN.BLL.SupplierInfo().GetList("");
        for (int i = 0; i < pList.Count; i++)
        {
            ListItem item = new ListItem(pList[i].SupplierName, pList[i].SupplierID.ToString());
            DDL_Supplier.Items.Add(item);
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

using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class WebUI_Supplier_SupplierList : System.Web.UI.Page
{
    protected string UserID = String.Empty;  //登录用户编号
    protected string TypeID = String.Empty;     //该用户在供应商中的权限

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;//得到用户ID
        if (!IsPostBack)
        {
            BindSupplierList();
        }
    }



    /// <summary>
    /// 绑定供应商列表
    /// </summary>
    private void BindSupplierList()
    {
        string SupplierID = "0";//如果是VM进来 供应商ID 为 0 
        string strWhere = string.Empty;
        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
        {
            SupplierID = supplierBody[0].ToString();
            strWhere += string.Format(" and SupplierID={0}", SupplierID);
        }
        else
        {
           // DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {

                StringBuilder areas = new StringBuilder();
                foreach (DataRow dr in userdt.Rows)
                {
                    areas.Append(dr["AreaId"] + ",");
                }
                if (areas.Length > 0)
                {
                    string IDList = String.Empty;
                    DataTable SDT = new LN.BLL.SupplierAssignRecord().GetSuplierIDListbyArea(areas.ToString().TrimEnd(','));
                    if (SDT.Rows.Count > 0)
                    {
                        for (int i = 0; i < SDT.Rows.Count; i++)
                        {
                            IDList += SDT.Rows[i][0].ToString() + ",";
                        }
                        strWhere += string.Format(" and SupplierID in ({0})", IDList.Substring(0, IDList.Length - 1));
                    }
                }

                //if (userdt.Rows[0][0].ToString() != "0")
                //{
                //    string IDList = String.Empty;
                //    DataTable SDT = new LN.BLL.SupplierAssignRecord().GetSuplierIDListbyArea(userdt.Rows[0][0].ToString());
                //    if (SDT.Rows.Count > 0)
                //    {
                //        for (int i = 0; i < SDT.Rows.Count; i++)
                //        {
                //            IDList += SDT.Rows[i][0].ToString() + ",";
                //        }
                //        strWhere += string.Format(" and SupplierID in ({0})", IDList.Substring(0, IDList.Length-1));
                //    }
                //}

            }
        }
        

        IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1"+strWhere);
        if (list != null)
        {
            RepSupplierList.DataSource = list;
            RepSupplierList.DataBind();
        }
    }
}

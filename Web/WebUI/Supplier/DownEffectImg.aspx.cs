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

public partial class WebUI_Supplier_DownEffectImg : System.Web.UI.Page
{
    protected string UserID = String.Empty;         //登录用户编号

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
            BindPOPID();
            BindSupplierID();
        }
    }

    /// <summary>
    /// 绑定发起的POP编号
    /// </summary>
    private void BindPOPID()
    {
        IList<string> POPIDList = new LN.BLL.POPLaunch().GetPOPID();
        if (POPIDList != null)
        {
            foreach (string strID in POPIDList)
            {
                ddlPOPID.Items.Add(new ListItem(strID,strID));
            }
        }
    }

    /// <summary>
    /// 绑定供应商编号
    /// </summary>
    private void BindSupplierID()
    {
        IList<LN.Model.SupplierInfo> SupplierList = new LN.BLL.SupplierInfo().GetList("");
        if (SupplierList != null)
        {
            foreach (LN.Model.SupplierInfo model in SupplierList)
            {
                ddlSupplierID.Items.Add(new ListItem(model.SupplierName,model.SupplierID.ToString()));
            }
        }
    }

    protected void btnUpLoad_Click(object sender, EventArgs e)
    {
        string SelectPOPID = ddlPOPID.Text;
        string SelectSID = ddlSupplierID.Text;
        string strWhere = " 1=1 ";
        if (SelectPOPID.Length > 0)
        {
            strWhere += string.Format(" and POPID = '{0}'", SelectPOPID);
        }
        if (SelectSID.Length > 0)
        {
            strWhere += string.Format(" AND SupplierID = {0} ", SelectSID);
        }
        DataTable dt = new LN.BLL.UpLoadEffectImg().GetListName(strWhere);

        RepImgList.DataSource = dt;
        RepImgList.DataBind();
    }
}

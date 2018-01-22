using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class WebUI_Supplier_VmSetMPrice : System.Web.UI.Page
{
    protected string UserID = String.Empty;         //用户编号
    protected string SupplierID = String.Empty;     //供应商编号
    protected string POPID = String.Empty;          //POP发起ID
    protected string POPTitle = String.Empty;       //POP主题
    protected string BeginDate = String.Empty;      //发起时间
    protected string EndDate = String.Empty;        //结束时间
    protected string OrganigerName = String.Empty;  //发起人
    protected string InputDate = String.Empty;      //录入时间

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        if (!IsPostBack)
            P_IsExistLaunch(UserID);
    }

    /// <summary>
    /// 判断指定用户是否有材料报价的权限
    /// </summary>
    /// <param name="userid">用户编号</param>
    private void P_IsExistLaunch(string userid)
    {
        string POPID = new LN.BLL.POPPrice().IsSetMPrice(Int32.Parse(userid));
        if (!string.IsNullOrEmpty(POPID))
        {
            hidPOPID.Value = POPID;
            if (hidPOPID.Value == "0")
            {
                Response.Redirect("../../Error.aspx?param=3");
                return;
            }
            else if (hidPOPID.Value == "-1")
            {
                Response.Redirect("../../Error.aspx?param=16");
                return;
            }
            else
            {
                GetLaunchInfo(hidPOPID.Value);
                BindMateriaPrice();
            }
        }
        else
            btnSubmit.Enabled = false;
    }

    /// <summary>
    /// 获取指定编号的POP发起信息
    /// </summary>
    /// <param name="popid">POP发起ID</param>
    private void GetLaunchInfo(string popid)
    {
        LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetModel(popid);
        if (model != null)
        {
            POPID = model.POPID;          //POP发起ID
            POPTitle = model.POPTitle;       //POP主题
            BeginDate = model.BeginDate.ToString();      //发起时间
            EndDate = model.EndDate.ToString();        //结束时间
            OrganigerName = model.OrganigerName;  //发起人
            InputDate = model.InputDate.ToString();      //录入时间

        }
    }

    /// <summary>
    /// 得到指定用户所在供应商上期材料报价清单
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <returns>返回材料报价清单列表</returns>
    private void BindMateriaPrice()
    {
        List<LN.Model.POPMateriaData> list = new LN.BLL.POPMateriaData().GetList("");
        if (list != null)
        {
            if (list.Count > 0)
            {
                RepMateriaPrice.DataSource = list;
                RepMateriaPrice.DataBind();
            }
            else
                btnSubmit.Enabled = false;
        }
        else
            btnSubmit.Enabled = false;
    }

    /// <summary>
    /// 提交报价
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<string> strSqlList = new List<string>();
        IList<LN.Model.SupplierInfo> SList = new LN.BLL.SupplierInfo().GetList("");
        if (SList.Count <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('没有相应的供应商，不能提交报价！！');window.location = window.location;</script>");
            return;
        }
        foreach (LN.Model.SupplierInfo model in SList)
        {

            foreach (RepeaterItem item in RepMateriaPrice.Items)
            {
                StringBuilder sb = new StringBuilder();
                Label lblID = item.FindControl("lblID") as Label;
                TextBox txtPrice = item.FindControl("txtPrice") as TextBox;
                if (txtPrice.Text.Trim() != "0" && txtPrice.Text.Trim() != "0.00" && txtPrice.Text.Trim() != "0.0")
                {
                    sb.Append("INSERT INTO [POPPrice] ");
                    sb.Append("([POPID]");
                    sb.Append(",[SupplierID]");
                    sb.Append(",[POPMaterial]");
                    sb.Append(",[POPprice]");
                    sb.Append(",[ExamState]");
                    sb.Append(",[Remark]");
                    sb.Append(",[UserID]");
                    sb.Append(",[SysTime]");
                    sb.Append(",[ExamUserID])");
                    sb.Append(" VALUES ");
                    sb.AppendFormat("('{0}'", hidPOPID.Value.Trim());
                    sb.AppendFormat(",{0}", model.SupplierID.ToString().Trim());
                    sb.AppendFormat(",{0}", lblID.Text.Trim());
                    sb.AppendFormat(",{0}", txtPrice.Text.Trim());
                    sb.AppendFormat(",{0}", "1");
                    sb.AppendFormat(",'{0}'", "");
                    sb.AppendFormat(",{0}", UserID);
                    sb.AppendFormat(",'{0}'", DateTime.Now.ToString());
                    sb.AppendFormat(",{0});", UserID);
                    strSqlList.Add(sb.ToString());
                }
            }
        }
        if (strSqlList.Count > 0)
        {
            int result = new LN.BLL.POPPrice().Operate(strSqlList);
            if (result > 0)
            {
                string url = string.Format("ShowSupplierLaunch.aspx?id={0}", hidPOPID.Value.Trim());
                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("../../Error.aspx?param=1");
            }
        }
    }
}

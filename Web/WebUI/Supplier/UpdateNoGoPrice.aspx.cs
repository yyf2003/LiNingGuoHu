using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class WebUI_Supplier_UpdateNoGoPrice : System.Web.UI.Page
{
    protected string UserID = String.Empty;         //用户编号
    protected string SupplierID = String.Empty;     //供应商编号
    protected string POPID = String.Empty;          //POP发起ID
    protected string POPTitle = String.Empty;       //POP主题
    protected string BeginDate = String.Empty;      //发起时间
    protected string EndDate = String.Empty;        //结束时间
    protected string OrganigerName = String.Empty;  //发起人
    protected string InputDate = String.Empty;      //录入时间
    protected string TypeID = String.Empty;     //该用户在供应商中的权限

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        POPID = Request.QueryString["pid"] == null ? "0" : Request.QueryString["pid"].ToString().Trim();        //发起的POP编号
        if (!IsPostBack)
        {
            P_GetPOPIDAndSIDByUserID(UserID);
        }
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
    /// 判断指定用户所在的供应商是否对最新发起的POP进行材料报价
    /// </summary>
    /// <param name="userid">用户编号</param>
    private void P_GetPOPIDAndSIDByUserID(string userid)
    {
        IList<string> list = new LN.BLL.SupplierInfo().GetPOPIDAndSIDByUserID(Int32.Parse(userid));
        if (list.Count > 0)
        {
            hidPOPID.Value = list[0].Trim();
            hidSupplierID.Value = list[1].Trim();
            if (hidSupplierID.Value == "0")
            {
                Response.Redirect("../../Error.aspx?param=14");
                return;
            }
            else
            {
                GetLaunchInfo(hidPOPID.Value);
                BindMateriaPrice(hidPOPID.Value,hidSupplierID.Value);
            }
        }
        else
            btnSubmit.Enabled = false;
    }


    /// <summary>
    /// 得到指定用户所在供应商上期材料报价清单
    /// </summary>
    /// <param name="userid">用户编号</param>
    /// <returns>返回材料报价清单列表</returns>
    private void BindMateriaPrice(string popid, string sid)
    {
        string strWhere = string.Format(" p.POPID = '{0}' AND p.SupplierID = {1} AND ExamState = {2}", popid, sid, "0");
        IList<LN.Model.POPPrice> list = new LN.BLL.POPPrice().GetList(strWhere);
        if (list != null && list.Count > 0)
        {
            RepMateriaPrice.DataSource = list;
            RepMateriaPrice.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<string> strSqlList = new List<string>();
        foreach (RepeaterItem item in RepMateriaPrice.Items)
        {
            StringBuilder sb = new StringBuilder();
            Label lblID = item.FindControl("lblID") as Label;
            TextBox txtPrice = item.FindControl("txtPrice") as TextBox;
            sb.Append("UPDATE [POPPrice] ");
            sb.Append("SET [POPprice] = " + txtPrice.Text.Trim());
            sb.AppendFormat(" WHERE [POPID]='{0}' AND [SupplierID]={1} AND [POPMaterial]={2}", hidPOPID.Value, hidSupplierID.Value, lblID.Text.Trim());
            strSqlList.Add(sb.ToString());
        }
        if (strSqlList.Count > 0)
        {
            int result = new LN.BLL.POPPrice().Operate(strSqlList);
            if (result > 0)
            {
                GetLaunchInfo(hidPOPID.Value);
                BindMateriaPrice(hidPOPID.Value, hidSupplierID.Value);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_error", "<script language='javascript'>alert('修改成功！！'); window.location=window.location;</script>");
            }
            else
            {
                Response.Redirect("../../Error.aspx?param=15");
            }
        }
    }
}

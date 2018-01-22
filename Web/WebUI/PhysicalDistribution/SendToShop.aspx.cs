using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class WebUI_PhysicalDistribution_SendToShop : System.Web.UI.Page
{
    protected string UserID = String.Empty; //登录用户编号
    protected string ShopID = String.Empty; //店铺名称
    protected string SupplierID = String.Empty; //所属供应商编号
    protected string DealerID = String.Empty; //所属一级客户编号
    protected string ShopName = String.Empty; //店铺名称
    string fxid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        ShopID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        SupplierID = Request.QueryString["sid"] == null ? "0" : Request.QueryString["sid"].ToString();
        DealerID = Request.QueryString["did"] == null ? "0" : Request.QueryString["did"].ToString();
        ShopName = new LN.BLL.ShopInfo().GetModel(Int32.Parse(ShopID)).Shopname;
        fxid = Request.QueryString["fxid"] == null ? "0" : Request.QueryString["fxid"].ToString();
        if (!IsPostBack)
        {
            GetPOPLaunchID();
            GetPOPList();
            BindPhysical();
        }
    }
    /// <summary>
    /// 获取最最新发起的POP
    /// </summary>
    private void GetPOPLaunchID()
    {
        DataTable dt = new LN.BLL.POPLaunch().GetNewPOPID();
        //LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetNewestModel();
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddlPOPID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                }
            }
            else
                btnAdd.Enabled = false;
        }
        else
            btnAdd.Enabled = false;
    }
    ///// <summary>
    ///// 获取最最新发起的POP
    ///// </summary>
    //private void GetPOPLaunchID()
    //{
    //    LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetNewestModel();
    //    if (model != null)
    //        txtPOPID.Text = model.POPID.Trim();
    //    else
    //        btnAdd.Enabled = false;
    //}

    /// <summary>
    /// 获取指定店铺的POP列表
    /// </summary>
    private void GetPOPList()
    {
        if (ddlPOPID.SelectedValue.Trim() != "")
        {
            string ProductLineID = new LN.BLL.POPLaunch().GetProline(ddlPOPID.SelectedValue.Trim());
            List<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetList(" ExamState=1 and vsl.ShopID = " + ShopID + " AND ProductLineID IN (" + ProductLineID + ")");
            if (list != null && list.Count > 0)
            {
                RepPOPList.DataSource = list;
                RepPOPList.DataBind();
            }
            else
                btnAdd.Enabled = false;
        }
        else
            btnAdd.Enabled = false;
    }

    /// <summary>
    /// 绑定物流公司
    /// </summary>
    private void BindPhysical()
    {
        IList<LN.Model.PhysicalCompanyData> list = new LN.BLL.PhysicalCompanyData().GetList(" SupplierID = " + SupplierID.Trim());
        ddlCompanyName.Items.Add(new ListItem("请选择物流公司", "0"));
        if (list.Count > 0)
        {
            foreach (LN.Model.PhysicalCompanyData item in list)
            {
                ddlCompanyName.Items.Add(new ListItem(item.CompanyName, item.CompanyID.ToString()));
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<string> strList = new List<string>();
        int POPNum = 0;
        foreach (RepeaterItem item in RepPOPList.Items)
        {
            CheckBox chk = item.FindControl("chkSelect") as CheckBox;
            Label lblID = item.FindControl("lblID") as Label;
            if (chk.Checked)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO [ShippingPOPData](");
                strSql.Append("[POPinfoID] ,");
                strSql.Append("[FHID]) VALUES (");
                strSql.AppendFormat("{0} ,", lblID.Text.Trim());
                strSql.AppendFormat("'{0}')", txtGoodsOrderNO.Text.Trim());

                strList.Add(strSql.ToString());
                POPNum++;
            }
        }
        //判断是否选择POP列表
        if (strList.Count <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请选择POP信息列表！！');</script>");
            return;
        }
        //判断发货单号是否为空
        if (txtGoodsOrderNO.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入发货单号！！');</script>");
            return;
        }
        //判断是否选择货物公司
        if (ddlCompanyName.SelectedValue == "0")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请选择物流公司！！');</script>");
            return;
        }
        //是否设置预计收货时间
        if (txt_YJSHDate.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入预计收货时间！！');</script>");
            return;
        }
        //收货人地址
        if (txt_SendAddress.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入发货地址！！');</script>");
            return;
        }
        //收货人
        if (txt_Consignee.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入收货人！！');</script>");
            return;
        }
        //收货人移动电话
        if (txt_ConsigneeMobile.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入收货人移动电话！！');</script>");
            return;
        }
        //收货人固定电话
        if (txt_ConsigneePhone.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入收货人固定电话！！');</script>");
            return;
        }

        StringBuilder sb = new StringBuilder();

        sb.Append("INSERT INTO [ShippingSpeedData] ( ");
        sb.Append("[POPID] ,");
        sb.Append("[GoodsOrderNO] ,");
        sb.Append("[POPCount] ,");
        sb.Append("[CompanyID] ,");
        sb.Append("[FHDate] ,");
        sb.Append("[OperatorID] ,");
        sb.Append("[DealerID] ,");
        sb.Append("[SupplierID] ,");
        sb.Append("[ShopID] ,");
        sb.Append("[IsState] ,");
        sb.Append("[Remars] ,");
        sb.Append("[GetInUserID] ,");
        sb.Append("[GetInState] ,");
        sb.Append("[SendAddress] ,");
        sb.Append("[Consignee] ,");
        sb.Append("[ConsigneeMobile] ,");
        sb.Append("[ConsigneePhone] ,");
        sb.Append("[GetInFeedBack],FXID) VALUES (");

        sb.AppendFormat("'{0}' ,", ddlPOPID.SelectedValue.Trim());
        sb.AppendFormat("'{0}' ,", txtGoodsOrderNO.Text.Trim());
        sb.AppendFormat("{0} ,", POPNum.ToString().Trim());
        sb.AppendFormat("{0} ,", ddlCompanyName.SelectedValue.Trim());
        sb.AppendFormat("'{0}' ,", DateTime.Now.ToString().Trim());
        sb.AppendFormat("{0} ,", UserID.Trim());
        sb.AppendFormat("'{0}' ,", DealerID.Trim());
        sb.AppendFormat("{0} ,", SupplierID.Trim());
        sb.AppendFormat(" {0},", ShopID.Trim());
        sb.Append("'发货到店' ,");
        sb.AppendFormat("'{0}' ,", txtRemarks.Text.Trim() + "[预计收货时间:" + txt_YJSHDate.Text.Trim() + "]");//将预计收货时间写入到备注当中，发货时间系统自动记录 为填写单据时间
        sb.AppendFormat("{0} ,", 0);
        //if (POPNum == RepPOPList.Items.Count)
        //    sb.Append("'全部发送' ,");
        //else
        //    sb.Append("'部分发送' ,");
        sb.Append("'已发送' ,");
        sb.AppendFormat("'{0}' ,", txt_SendAddress.Text.Trim());
        sb.AppendFormat("'{0}' ,", txt_Consignee.Text.Trim());
        sb.AppendFormat("'{0}' ,", txt_ConsigneeMobile.Text.Trim());
        sb.AppendFormat("'{0}' ,", txt_ConsigneePhone.Text.Trim());
        sb.Append("'','" + fxid + "')");
        strList.Add(sb.ToString());

        if (strList.Count > 1)
        {
            int result = new LN.BLL.ShippingSpeedData().Add(strList);
            if (result > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('提交发货单成功！！');window.location.href='./SendToShopList.aspx';</script>");
                return;
            }
            else
            {
                Response.Redirect("../../Error.aspx?param=11");
                return;
            }
        }
    }
}

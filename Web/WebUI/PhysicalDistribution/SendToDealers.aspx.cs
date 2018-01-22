using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;

public partial class WebUI_PhysicalDistribution_SendToDealers : System.Web.UI.Page
{
    protected string UserID = String.Empty; //登录用户编号
    protected string UserofArea = string.Empty;
    protected string TypeID = "0";     //该用户在供应商中的权限
    protected string DealerID = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        UserofArea = Request.Cookies["UserArea"].Value;
        DealerID = Request.QueryString["DealerID"] == null ? "" : Request.QueryString["DealerID"].ToString();
        if (!IsPostBack)
        {
            GetSupplierID();
            if (TypeID == "0")
                Response.Redirect("../../Error.aspx?param=7");
            else
            {
                //GetProvince();
                //BindDealer();
                GetPOPLaunchID();
                BindPhysical();
                //加载一级客户
                string strWhere = " 1=1 ";
                if (!String.IsNullOrEmpty(UserofArea))
                    strWhere += "and AreaID =" + UserofArea;

                DataTable dealerdt = new LN.BLL.DealerInfo().GetDealerName(strWhere);
                for (int i = 0; i < dealerdt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                    //ddl_dealer.Items.Add(item);
                }
            }
            GetList();
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

    /// <summary>
    /// 绑定省份
    /// </summary>
    //private void GetProvince()
    //{
    //    //加载省份
    //    // IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
    //    DataTable dt = new LN.BLL.SupplierAssignRecord().GetSupplierPro(int.Parse(hidSupplierID.Value));
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        ListItem item = new ListItem(dt.Rows[i]["ProvinceName"].ToString(), dt.Rows[i]["ProvinceID"].ToString());
    //        //DDL_Province.Items.Add(item);
    //    }
    //}



    /// <summary>
    /// 绑定物流公司
    /// </summary>
    private void BindPhysical()
    {
        IList<LN.Model.PhysicalCompanyData> list = new LN.BLL.PhysicalCompanyData().GetList(" SupplierID = " + int.Parse(hidSupplierID.Value));
        ddlCompanyName.Items.Add(new ListItem("请选择物流公司", "0"));
        if (list.Count > 0)
        {
            foreach (LN.Model.PhysicalCompanyData item in list)
            {
                ddlCompanyName.Items.Add(new ListItem(item.CompanyName, item.CompanyID.ToString()));
            }
        }
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        string strWhere = String.Empty; //搜索条件
        //if (DDL_Province.SelectedValue.Trim() != "0")
        //    strWhere += string.Format(" AND ProvinceID = {0} ", DDL_Province.SelectedValue.Trim());
        //if (DDL_city.SelectedValue.Trim() != "0")
        //    strWhere += string.Format(" AND CityID = {0} ", DDL_city.SelectedValue.Trim());
        //if (txtDealerID.Text.Trim() != "")
        //    strWhere += string.Format(" AND DealerID = '{0}' ", txtDealerID.Text.Trim());
        //if (ddl_dealer.Text.Trim() != "0")
        //    strWhere += string.Format(" AND DealerID = '{0}' ", ddl_dealer.Text.Trim());

        if (DealerID != "")
            strWhere += string.Format(" AND DealerID = '{0}' ", DealerID);

        if (txtShopID.Text.Trim() != "")
            strWhere += string.Format(" AND PosID like '%{0}%' ", txtShopID.Text.Trim());
        if (txtShopName.Text.Trim() != "")
            strWhere += string.Format(" AND Shopname like '%{0}%' ", txtShopName.Text.Trim());
        //string ProductLineID = new LN.BLL.POPLaunch().GetProline(txtPOPID.Text.Trim());
        //if (ProductLineID.Length > 0)
        //    strWhere += string.Format("AND ProductLineID IN ({0})", ProductLineID);
        DataTable dt = new LN.BLL.ShopInfo().GetAllShopListBySuppliersID(hidSupplierID.Value, strWhere);
        if (dt != null)
        {
            RepShopList.DataSource = dt;
            RepShopList.DataBind();
        }
    }

    public void RepShopList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //BLL.Products products = new BLL.Products();

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField lblID = e.Item.FindControl("lblID") as HiddenField;
            CheckBox chk = e.Item.FindControl("chkSelect") as CheckBox;
            IDictionary<string, ArrayList> di = Session["ToDealers"] == null ? new Dictionary<string, ArrayList>() : Session["ToDealers"] as Dictionary<string, ArrayList>;

            if (di.ContainsKey(lblID.Value.ToString()))
                chk.Checked = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetList();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
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
        string ProductLineID = new LN.BLL.POPLaunch().GetProline(ddlPOPID.SelectedValue.Trim());
        List<string> strList = new List<string>();
        IDictionary<string, ArrayList> di = Session["ToDealers"] == null ? new Dictionary<string, ArrayList>() : Session["ToDealers"] as Dictionary<string, ArrayList>;
        foreach (string key in RepShopList.Items)
        {
            ArrayList arry = di[key] as ArrayList;
            //    CheckBox chk = item.FindControl("chkSelect") as CheckBox;
            //    Label lblID = item.FindControl("lblID") as Label;
            //    Label lblDealerID = item.FindControl("lblDealerID") as Label;
            //    HiddenField lblpopnum = item.FindControl("lbl_popnum") as HiddenField;
            //    Label lbfx = item.FindControl("lbfx") as Label;
            //if (chk.Checked)
            //{
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [ShippingSpeedData] ( ");
            sb.Append("[SendAddress] ,");
            sb.Append("[Consignee] ,");
            sb.Append("[ConsigneeMobile] ,");
            sb.Append("[ConsigneePhone] ,");
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
            sb.Append("[GetInFeedBack],FXID) VALUES (");

            sb.AppendFormat("'{0}' ,", txt_SendAddress.Text.Trim());
            sb.AppendFormat("'{0}' ,", txt_Consignee.Text.Trim());
            sb.AppendFormat("'{0}' ,", txt_ConsigneeMobile.Text.Trim());
            sb.AppendFormat("'{0}' ,", txt_ConsigneePhone.Text.Trim());
            sb.AppendFormat("'{0}' ,", ddlPOPID.SelectedValue.Trim());
            sb.AppendFormat("'{0}' ,", txtGoodsOrderNO.Text.Trim());
            sb.AppendFormat("{0} ,", int.Parse(arry[2].ToString()));
            sb.AppendFormat("{0} ,", ddlCompanyName.SelectedValue.Trim());
            sb.AppendFormat("'{0}' ,", DateTime.Now.ToString().Trim());
            sb.AppendFormat("{0} ,", UserID.Trim());
            sb.AppendFormat("'{0}' ,", arry[1].ToString());
            sb.AppendFormat("{0} ,", hidSupplierID.Value.Trim());
            sb.AppendFormat(" {0},", arry[0].ToString());
            sb.Append("'发货到一级客户' ,");
            sb.AppendFormat("'{0}' ,", txtRemarks.Text.Trim() + "[预计收货时间:" + txt_YJSHDate.Text.Trim() + "]");//将预计收货时间写入到备注当中，发货时间系统自动记录 为填写单据时间
            sb.AppendFormat("{0} ,", 0);
            //if (POPNum == RepPOPList.Items.Count)
            //    sb.Append("'全部发送' ,");
            //else
            //    sb.Append("'部分发送' ,");
            sb.Append("'已发送' ,");
            sb.Append("'','" + arry[3].ToString() + "')");
            strList.Add(sb.ToString());

            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [ShippingPOPData]");
            strSql.Append(" select ID,");
            strSql.AppendFormat("'{0}'", txtGoodsOrderNO.Text.Trim());
            strSql.Append(" from popinfo  where ProductlineID in(");
            strSql.AppendFormat("{0})", ProductLineID);
            strSql.AppendFormat(" and shopid={0}", arry[0].ToString());
            strList.Add(strSql.ToString());
            //}
        }

        if (strList.Count > 0)
        {
            int result = new LN.BLL.ShippingSpeedData().Add(strList);
            if (result > 0)
            {
                ///新添加代码
                Session["ToDealers"] = null;
                GetList();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('提交发货单成功！！');window.location='DistributorsInfoLists.aspx';</script>");

                return;
            }
            else
            {
                Response.Redirect("../../Error.aspx?param=11");
                return;
            }
        }

    }

    protected void btnReSelect_Click(object sender, EventArgs e)
    {
        Response.Redirect("DealerInfoList.aspx");
    }
}

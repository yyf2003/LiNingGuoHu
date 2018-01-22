using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUI_PhysicalDistribution_SendToShopList : System.Web.UI.Page
{
    protected string UserID = String.Empty; //登录用户编号
    protected string TypeID = "0";     //该用户在供应商中的权限

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
            GetSupplierID();
            if (TypeID == "0")
                Response.Redirect("../../Error.aspx?param=7");
            else
            {
                GetProvince();
                //BindDealer();
                //GetList();
            }
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
    /// 绑定省份
    /// </summary>
    private void GetProvince()
    {
        //加载省份
        DataTable dt = new LN.BLL.SupplierAssignRecord().GetSupplierPro(int.Parse(hidSupplierID.Value));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem item = new ListItem(dt.Rows[i]["ProvinceName"].ToString(), dt.Rows[i]["ProvinceID"].ToString());
            DDL_Province.Items.Add(item);
        }
    }

    /// <summary>
    /// 绑定城市
    /// </summary>
    /// <param name="ProvinceID"></param>
    private void GetCity(string ProvinceID)
    {
        DDL_city.Items.Clear();
        DataTable dt = new LN.BLL.CityData().GetCityList("provinceID=" + ProvinceID);
        DDL_city.Items.Add(new ListItem("请选择地级城市", "0"));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem item = new ListItem(dt.Rows[i]["CityName"].ToString(), dt.Rows[i]["CItyID"].ToString());
            DDL_city.Items.Add(item);
        }
    }

    /// <summary>
    /// 绑定一级客户
    /// </summary>
    private void BindDealer(string CityID)
    {
        ddl_dealer.Items.Clear();
        DataTable dt = new LN.BLL.DealerInfo().GetDealerInfoListBy(CityID);
        ddl_dealer.Items.Add(new ListItem("请选择一级客户", "0"));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ddl_dealer.Items.Add(new ListItem(dr["DealerName"].ToString().Trim(), dr["DealerID"].ToString().Trim()));
            }
        }
    }

    /// <summary>
    /// 绑定直属客户
    /// </summary>
    private void BindFx(string DealerID)
    {
        DDL_fx.Items.Clear();
        DataTable dt = new LN.BLL.DistributorsInfo().GetFXinfolistsBy(DealerID);
        DDL_fx.Items.Add(new ListItem("请选择店铺的直属客户", "0"));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                DDL_fx.Items.Add(new ListItem(dr["FXName"].ToString().Trim(), dr["FXID"].ToString().Trim()));
            }
        }
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        string strWhere = String.Empty; //搜索条件
        int totalNumber = 0;        //返回搜索后的员工数量
        if (Txt_PosID.Text.Trim() != "")
            strWhere += string.Format(" AND PosID = '{0}'", Txt_PosID.Text.Trim());
        if (Txt_ShopName.Text.Trim() != "")
            strWhere += string.Format(" AND Shopname LIKE '%{0}%'", Txt_ShopName.Text.Trim());
        if (DDL_Province.SelectedValue.Trim() != "0")
            strWhere += string.Format(" AND ProvinceID = {0} ", DDL_Province.SelectedValue.Trim());
        if (DDL_city.SelectedValue.Trim() != "0")
            strWhere += string.Format(" AND CityID = {0} ", DDL_city.SelectedValue.Trim());
        if (ddl_dealer.SelectedValue.Trim() != "0")
            strWhere += string.Format(" AND DealerID = '{0}' ", ddl_dealer.SelectedValue.Trim());
        string FXid = this.Request.Form["DDL_fx"].ToString();
        if (FXid != "0")
            strWhere += string.Format(" AND FXID = '{0}' ", FXid);
        LN.BLL.POPLaunch popDal = new LN.BLL.POPLaunch();
        //strWhere += string.Format(" and productlineid in ({0})", popDal.GetProline(popDal.GetLastPOPID()));
        LN.Model.PageModel model = new LN.Model.PageModel();
        model.SelectSql = LN.DAL.GetTableListSqlExec.strShopListBySupplierID(hidSupplierID.Value, strWhere);
        model.pageIndex = ListPages.CurrentPageIndex;
        model.pageSize = ListPages.PageSize;
        model.OrderField = "[PosID],[ShopID],[DealerName]";
        DataTable dt = new LN.BLL.ShopInfo().GetShopListBySupplierID(model, out totalNumber);
        if (dt != null)
        {
            ListPages.RecordCount = totalNumber;
            RepShopList.DataSource = dt;
            RepShopList.DataBind();
        }
    }
    protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPages.CurrentPageIndex = e.NewPageIndex;
        GetList();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ListPages.CurrentPageIndex = 1;
        //GetList();
    }
    protected void DDL_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCity(DDL_Province.SelectedValue.Trim());
        BindDealer(DDL_city.SelectedValue.Trim());
        BindFx(ddl_dealer.SelectedValue.Trim());
    }

    protected void DDL_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDealer(DDL_city.SelectedValue.Trim());
        BindFx(ddl_dealer.SelectedValue.Trim());
    }
    protected void ddl_dealer_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFx(ddl_dealer.SelectedValue.Trim());
    }
}

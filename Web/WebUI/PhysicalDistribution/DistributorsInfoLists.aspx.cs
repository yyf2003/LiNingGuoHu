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

public partial class WebUI_PhysicalDistribution_DistributorsInfoLists : System.Web.UI.Page
{
    //protected string DealerID = "";
    protected string UserID = "";
    protected string TypeID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //DealerID = Request.QueryString["DealerID"] == null ? "" : Request.QueryString["DealerID"].ToString();
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
                //GetPOPLaunchID();
                //BindPhysical();
                //GetDistributorsInfo();
            }
        }
    }

    ///// <summary>
    ///// 获取直属客户
    ///// </summary>
    //private void GetDistributorsInfo()
    //{
    //    DataTable dt = new LN.BLL.DistributorsInfo().GetIDName("areaID=16");
    //    if (dt != null)
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            foreach (DataRow dr in dt.Rows)
    //            {
    //                DDL_fx.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
    //            }
    //        }
    //    }
    //}


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
    /// 绑定直属客户
    /// </summary>
    private void BindFx(string CityID)
    {
        DDL_fx.Items.Clear();
        DataTable dt = new LN.BLL.DistributorsInfo().GetFXinfolistBy(CityID);
        DDL_fx.Items.Add(new ListItem("请选择直属客户", "0"));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                DDL_fx.Items.Add(new ListItem(dr["FXName"].ToString().Trim(), dr["FXID"].ToString().Trim()));
            }
        }
    }

    /// <summary>
    /// 绑定直属客户
    /// </summary>
    private void BindFxID(string CityID)
    {
        DDL_fxID.Items.Clear();
        DataTable dt = new LN.BLL.DistributorsInfo().GetFXinfolistBy(CityID);
        DDL_fxID.Items.Add(new ListItem("请选择直属客户编号", "0"));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                DDL_fxID.Items.Add(new ListItem(dr["FXID"].ToString().Trim(), dr["FXID"].ToString().Trim()));
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
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        string strWhere = String.Empty; //搜索条件
        strWhere += " 1=1 ";

        //if (Request.Cookies["UserArea"].Value != "")
        //    strWhere += " AND AreaID = " + Request.Cookies["UserArea"].Value + " ";

        if (DDL_Province.SelectedValue != "0")
            strWhere += string.Format(" AND FxID in (select distinct FXID from ShopInfo where ProvinceID='{0}' )", DDL_Province.SelectedValue);

        if (DDL_city.SelectedValue != "0")
            strWhere += string.Format(" AND FxID in (select distinct FXID from ShopInfo where CityID='{0}' )", DDL_city.SelectedValue);

        if (DDL_fxID.SelectedValue.Trim() != "0")
            strWhere += string.Format(" AND fxid = '{0}' ", DDL_fxID.SelectedValue.Trim());

        if (DDL_fx.SelectedValue.Trim() != "0")
            strWhere += string.Format(" AND fxid = '{0}' ", DDL_fx.Text.Trim());



        DataSet ds = new LN.BLL.DistributorsInfo().GetList(strWhere);

        if (ds != null)
        {
            RepShopList.DataSource = ds.Tables[0];
            RepShopList.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetList();
    }

    protected void DDL_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCity(DDL_Province.SelectedValue.Trim());
        BindFx(DDL_city.SelectedValue.Trim());
        BindFxID(DDL_city.SelectedValue.Trim());
    }

    protected void DDL_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFx(DDL_city.SelectedValue.Trim());
        BindFxID(DDL_city.SelectedValue.Trim());
    }
}
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

public partial class WebUI_PhysicalDistribution_DealerInfoList : System.Web.UI.Page
{
    protected string UserID = String.Empty; //登录用户编号
    protected string UserofArea = string.Empty;
    protected string TypeID = "0";     //该用户在供应商中的权限
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        UserofArea = Request.Cookies["UserArea"].Value;
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

                ////加载一级客户
                //string strWhere = " 1=1 ";
                //if (!String.IsNullOrEmpty(UserofArea))
                //    strWhere += "and AreaID =" + UserofArea;

                //DataTable dealerdt = new LN.BLL.DealerInfo().GetDealerName(strWhere);
                //for (int i = 0; i < dealerdt.Rows.Count; i++)
                //{
                //    ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                //    ddl_dealer.Items.Add(item);
                //}
            }
            //GetList();
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
        // IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
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
    /// 绑定一级客户编号
    /// </summary>
    private void BindDealerID(string CityID)
    {
        ddl_dealers.Items.Clear();
        DataTable dt = new LN.BLL.DealerInfo().GetDealerInfoListBy(CityID);
        ddl_dealers.Items.Add(new ListItem("请选择一级客户编号", "0"));
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ddl_dealers.Items.Add(new ListItem(dr["DealerID"].ToString().Trim(), dr["DealerID"].ToString().Trim()));
            }
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
            strWhere += string.Format(" AND DealerID in (select distinct DealerID from ShopInfo where ProvinceID='{0}' )", DDL_Province.SelectedValue);

        if (DDL_city.SelectedValue != "0")
            strWhere += string.Format(" AND DealerID in (select distinct DealerID from ShopInfo where CityID='{0}' )", DDL_city.SelectedValue);

        if (ddl_dealers.SelectedValue.Trim() != "0")
            strWhere += string.Format(" AND DealerID = '{0}' ", ddl_dealers.SelectedItem.Text.Trim());

        if (ddl_dealer.SelectedValue.Trim() != "0")
            strWhere += string.Format(" AND DealerID = '{0}' ", ddl_dealer.SelectedValue.Trim());



        DataTable dt = new LN.BLL.DealerInfo().GetDealerInfoList(strWhere);
        if (dt != null)
        {
            RepShopList.DataSource = dt;
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
        BindDealer(DDL_city.SelectedValue.Trim());
        BindDealerID(DDL_city.SelectedValue.Trim());
    }

    protected void DDL_city_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDealer(DDL_city.SelectedValue.Trim());
        BindDealerID(DDL_city.SelectedValue.Trim());
    }
}

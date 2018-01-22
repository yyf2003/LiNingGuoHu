using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_POPAddition_SendToPOPAdditionList : System.Web.UI.Page
{
    protected string UserType = string.Empty;
    protected string UserID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {

            //判断人员类别
            UserID = this.Request.Cookies["UserID"].Value;
            UserType = new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Usertype;
            if (UserType == "6")//供应商
            {
                string LinkUser = Server.UrlDecode(this.Request.Cookies["UserName"].Value);
                IList<LN.Model.SupplierInfo> Slist = new LN.BLL.SupplierInfo().GetList("Contacter ='" + LinkUser + "'");
                if (Slist.Count > 0)
                {
                    for (int i = 0; i < Slist.Count; i++)
                    {
                        ListItem item = new ListItem(Slist[i].SupplierName, Slist[i].SupplierID.ToString());
                        ddl_supplier.Items.Add(item);
                    }
                }
            }
            else
            {
                //绑定店铺的供应商
                IList<LN.Model.SupplierInfo> SList = new LN.BLL.SupplierInfo().GetList("");
                for (int i = 0; i < SList.Count; i++)
                {
                    ListItem item = new ListItem(SList[i].SupplierName, SList[i].SupplierID.ToString());
                    ddl_supplier.Items.Add(item);
                }
            }

            //绑定店铺级别
            LN.DAL.ShopLevel levelDLL = new LN.DAL.ShopLevel();
            DataSet ds = levelDLL.GetList("");
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                this.DDL_Shoptype.Items.Add(item);
            }

            //绑定店铺类型
            LN.DAL.SaleTypeInfo saleDLL = new LN.DAL.SaleTypeInfo();
            DataSet saleds = saleDLL.GetList("");
            DataTable saledt = saleds.Tables[0];
            for (int i = 0; i < saledt.Rows.Count; i++)
            {
                ListItem item = new ListItem(saledt.Rows[i][1].ToString(), saledt.Rows[i][0].ToString());
                SaleTypeID.Items.Add(item);
            }

            //绑定店铺的一级客户
            LN.DAL.DealerInfo dealerDAL = new LN.DAL.DealerInfo();

            DataTable dealerdt = dealerDAL.GetDealerName("");
            for (int i = 0; i < dealerdt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                ddl_dealer.Items.Add(item);
            }


            //加载省份
            IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
            for (int i = 0; i < pList.Count; i++)
            {
                ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
                DDL_Province.Items.Add(item);
            }
        }
    }
    protected void Btn_search_ServerClick(object sender, EventArgs e)
    {
        string posid = Txt_PosID.Text.Trim();
        string shopname = Txt_ShopName.Text.Trim();
        string proviceid = DDL_Province.SelectedItem.Value;
        string cityid = DDL_city.SelectedItem.Value;
        string deaclerid = ddl_dealer.SelectedItem.Value;
        string boolinstall = DDL_install.SelectedItem.Value;
        string shoptype = DDL_Shoptype.SelectedItem.Value;
        string saletypeid = SaleTypeID.SelectedItem.Value;
        string examstate = DDL_examstate.SelectedItem.Value;
        string supplierid = ddl_supplier.SelectedItem.Value;
        string fxid = this.Request.Form["DDL_fx"].ToString();
        string strWhere = "";
        if (posid != "")
            strWhere += "AND PosID='" + posid + "'";
        if (fxid != "0")
        {
            strWhere += "AND FXID='" + fxid + "'"; 
        }
        if (shopname != "")
            strWhere += "AND Shopname='" + shopname + "'";
        if (proviceid != "0")
            strWhere += "AND ProvinceID='" + proviceid + "'";
        if (cityid != "0")
            strWhere += "AND CityID='" + cityid + "'";
        if (deaclerid != "0")
            strWhere += "AND DealerID='" + deaclerid + "'";
        if (boolinstall != "-1")
            strWhere += "AND Boolinstall='" + boolinstall + "'";
        if (shoptype != "0")
            strWhere += "AND ShopType='" + shoptype + "'";
        if (saletypeid != "0")
            strWhere += "AND SaleTypeID='" + saletypeid + "'";
        if (examstate != "-1")
            strWhere += "AND POPAddition.ExamState='" + examstate + "'";
        if (supplierid != "0")
            strWhere += "AND SupplierID='" + supplierid + "'";
        DataTable dt = new LN.BLL.POPAddition().GetSendPOPAddition(strWhere).Tables[0];
        int N = 1; dt.Columns.Add("No");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["No"] = i.ToString();
                N++;
            }
        }
        gv_popaddition.DataSource = dt;
        gv_popaddition.DataBind();
    }

    /// <summary>
    /// 得到一级客户名称
    /// </summary>
    /// <param name="Dealerid"></param>
    /// <returns></returns>
    protected string GetDealerName(string Dealerid)
    {
        if (Dealerid != "")
        {
            return new LN.BLL.DealerInfo().GetDealerName("Dealerid='" + Dealerid + "'").Rows[0]["Dealername"].ToString();
        }
        return "";
    }
    /// <summary>
    /// 得到省份名称
    /// </summary>
    /// <returns></returns>
    protected string GetProviceName(string ProID)
    {
        if (!string.IsNullOrEmpty(ProID))
        {
            return new LN.BLL.ProvinceData().GetModel(int.Parse(ProID)).ProvinceName;
        }
        return "";
    }
    /// <summary>
    /// 得到市的名称
    /// </summary>
    /// <param name="CityID"></param>
    /// <returns></returns>
    protected string GetCityName(string CityID)
    {
        if (!string.IsNullOrEmpty(CityID))
        {
            return new LN.BLL.CityData().GetModel(int.Parse(CityID)).CityName;
        }
        return "";

    }

}

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
public partial class WebUI_POPAddition_SupplierSearchadd : System.Web.UI.Page
{
    protected string UserType = string.Empty;
    protected string UserID = string.Empty;
    protected string ReUrl = string.Empty;
    protected int POPAddtionCount = 0;
    protected decimal POPAddtitionArea = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }

        else
        {
            UserID = this.Request.Cookies["UserID"].Value;

            if (!IsPostBack)
            {
                //绑定店铺的供应商
                IList<LN.Model.SupplierInfo> SList = new LN.BLL.SupplierInfo().GetList("");
                for (int i = 0; i < SList.Count; i++)
                {
                    ListItem item = new ListItem(SList[i].SupplierName, SList[i].SupplierID.ToString());
                    ddl_supplier.Items.Add(item);
                }


                //判断人员类别
                UserID = this.Request.Cookies["UserID"].Value;
                //UserType = new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Usertype;

                string supplierID = "0";//如果是VM进来 供应商ID 为 0 
                IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
                if (supplierBody != null)
                {
                    supplierID = supplierBody[0].ToString();
                    ddl_supplier.Text = supplierID;
                    ddl_supplier.Enabled = false;
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
                //加载发起的POP的ID
                string newPOPID = new LN.BLL.POPLaunch().GetLastPOPID();
                ddl_poplaunch.Items.Add(new ListItem(newPOPID, newPOPID));

            }
        }


    }
    protected void Btn_search_ServerClick(object sender, EventArgs e)
    {
        string posid = Txt_PosID.Text.Trim();
        string shopname = Txt_ShopName.Text.Trim();
        string proviceid = Request.Form["DDL_Province"].ToString();// DDL_Province.SelectedItem.Value;
        string cityid = Request.Form["DDL_city"].ToString();// DDL_city.SelectedItem.Value;
        string deaclerid = ddl_dealer.SelectedItem.Value;
        
        string supplierid = ddl_supplier.SelectedItem.Value;
        string strWhere = " 1=1 ";
        string poplaunch = ddl_poplaunch.SelectedItem.Value;
        if (posid != "")
            strWhere += " AND PosID='" + posid + "'";
        if (shopname != "")
            strWhere += " AND Shopname='" + shopname + "'";
        if (proviceid != "0")
            strWhere += " AND provincename='" + proviceid + "'";
        if (cityid != "0")
            strWhere += " AND cityname='" + DDL_city.SelectedItem.Text + "'";
        if (deaclerid != "0")
            strWhere += " AND dealername='" + cityid + "'";
       
        strWhere += " and Examstate ='1'";
        if (supplierid != "0")
            strWhere += " AND Suppliername='" + ddl_supplier.SelectedItem.Text + "'";
        if (poplaunch != "0")
            strWhere += " and POPID='" + poplaunch + "'";
        DataTable dt = new LN.BLL.POPAddition().GetPOPExamlist(strWhere).Tables[0];
        if (dt.Rows.Count > 0)
        {
            gv_popaddition.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                POPAddtitionArea += decimal.Parse(dt.Rows[i]["POPArea"].ToString());
            }
            POPAddtionCount = dt.Rows.Count;
            gv_popaddition.DataBind();
        }
        else
        {
            POPAddtionCount = 0;
            POPAddtitionArea = 0;
            gv_popaddition.DataSource = null;
            gv_popaddition.DataBind();

        }
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
    
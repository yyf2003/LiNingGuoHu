﻿using System;
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
public partial class WebUI_Analysis_NewAddPOPAnalysis : System.Web.UI.Page
{
    protected int shopcount = 0, popcount = 0;
    protected Double areasum = 0.00, totalMoney = 0.00;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;//得到用户ID
        if (!Page.IsPostBack)
        {
            DDL_year.Text = DateTime.Now.Year.ToString();
            //加载供应商

            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");
            foreach (LN.Model.SupplierInfo model in list)
            {
                ListItem item = new ListItem(model.SupplierName, model.SupplierID.ToString());
                DDL_Supplier.Items.Add(item);
            }

            //加载一级客户

            DataTable dealerdt = new LN.BLL.DealerInfo().GetDealerName(" 1=1 ");
            for (int i = 0; i < dealerdt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                DDL_Dealer.Items.Add(item);
            }

            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList("");
            foreach (LN.Model.AreaData model in arealist)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                DDL_Area.Items.Add(item);
            }
            ////加载产品大类
            IList<LN.Model.ProductLineType> typelist = new LN.BLL.ProductLineType().GetList(" isDelete=1");
            foreach (LN.Model.ProductLineType model in typelist)
            {
                ListItem item = new ListItem(model.ProductTypeName, model.ProductTypeID.ToString());
                DDL_ProductType.Items.Add(item);
            }
            //加载产品系列
            DataTable linedt = new LN.BLL.ProductLineData().GetDistinctLine("");
            for (int i = 0; i < linedt.Rows.Count; i++)
            {
                DDL_proLine.Items.Add(new ListItem(linedt.Rows[i][0].ToString(), linedt.Rows[i][0].ToString()));
            }
            //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                DDL_Area.Items.Clear();
                DDL_Area.Items.Add(new ListItem("请选择省区", "0"));
                //DDL_Area.Text = userdt.Rows[0][0].ToString();
                //DDL_Area.Enabled = false;
                //IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
                //foreach (LN.Model.ProvinceData pmodel in prolist)
                //{
                //    DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                //}
                //string GetSuplierID = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + DDL_Area.Text + "'");
                //if (GetSuplierID != "")
                //{
                //    DDL_Supplier.Text = GetSuplierID;
                //    DDL_Supplier.Enabled = false;
                //}
                StringBuilder areas = new StringBuilder();
                foreach (DataRow dr in userdt.Rows)
                {
                    areas.Append(dr["AreaId"] + ",");
                    DDL_Area.Items.Add(new ListItem(dr["AreaName"].ToString(), dr["AreaId"].ToString()));
                }
                hfAreas.Value = areas.ToString().TrimEnd(',');

            }
        }

        string supplierID = "0";//如果是VM进来 供应商ID 为 0 
        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
        {
            supplierID = supplierBody[0].ToString();
            DDL_Supplier.Text = supplierID;

            DDL_Supplier.Enabled = false;
        }
    }
    protected void Btn_Analysis_Click(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {


        Hashtable ht = new Hashtable();
        ht.Add("year", DDL_year.Text);
        //ht.Add("POPID", DDL_POPID.Text);
        ht.Add("PosCode", txt_PosID.Text.Trim());
        ht.Add("Shopname", txt_shopname.Text.Trim());
        ht.Add("SupplierID", DDL_Supplier.Text);
        ht.Add("DealerID", DDL_Dealer.Text);
        if (DDL_Area.SelectedValue == "0")
            ht.Add("areaID", DDL_Area.SelectedValue);
        else
            ht.Add("areaID", hfAreas.Value);
        ht.Add("ProvinceID", Request.Form["DDL_Province"].ToString());
        ht.Add("CityID", Request.Form["DDL_city"].ToString());
        ht.Add("protype", DDL_ProductType.Text);
        ht.Add("proline", DDL_proLine.Text);
        // LN.Model.PageModel model = new LN.Model.PageModel();
        //model.SelectSql = new LN.BLL.POPAddition().GetAnalysisstr(ht);
        //model.pageIndex = ListPages.CurrentPageIndex;
        //model.pageSize = ListPages.PageSize;
        //model.OrderField = "totalprice DESC";
        //int totalNumber = 0;
        //DataTable dt = new LN.BLL.ShopInfo().GetShopListBySupplierID(model, out totalNumber);

        //ListPages.RecordCount = totalNumber;

        DataSet ds = new LN.BLL.POPInfo().GetNewaddPOPCount(ht);

        //统计数据
        shopcount = ds.Tables[0].Rows.Count;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            popcount += int.Parse(ds.Tables[0].Rows[i]["数量"].ToString());
            areasum += Double.Parse(ds.Tables[0].Rows[i]["总面积"].ToString());
            totalMoney += Double.Parse(ds.Tables[0].Rows[i]["总金额"].ToString());
            //pricesum += Double.Parse(dt.Rows[i]["Totalprice"].ToString() == "" ? "0" : dt.Rows[i]["Totalprice"].ToString());
        }
        Session["NewAddlist"] = null;
        Session["NewAddlist"] = ds.Tables[3];
    }

}
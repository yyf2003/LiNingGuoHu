﻿using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
public partial class WebUI_Analysis_POPAnalysisByProduct : System.Web.UI.Page
{
    protected double area = 0.0000;
    protected double price = 0.000,setupprice = 0.000;
    protected int num = 0;
    protected string cxstr = string.Empty, deptname=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;//得到用户ID
        string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        //if (deptdt.Rows.Count > 0)
        //{
        //    deptname = deptdt.Rows[0]["department"].ToString();
        //}
        if (!Page.IsPostBack)
        {

            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_department.Items.Add(item);
            }
            string strarea = "";
            if (deptdt.Rows.Count > 0)
            {
                DDL_department.DataSource = deptdt;
                DDL_department.DataTextField = "department";
                DDL_department.DataValueField = "department";
                DDL_department.DataBind();
                strarea += string.Format(" department='{0}' ", DDL_department.SelectedValue);
                //DDL_department.Text = deptname;
                //DDL_department.Enabled = false;
            }
            DDL_year.Text = DateTime.Now.Year.ToString();
            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");
            foreach (LN.Model.SupplierInfo model in list)
            {
                ListItem item = new ListItem(model.SupplierName, model.SupplierID.ToString());
                DDL_Supplier.Items.Add(item);
            }

            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                DDL_POPID.Items.Add(item);
            }

            //加载一级客户
            DataTable dealerdt = new LN.BLL.DealerInfo().GetDealerName(" 1=1 ");
            for (int i = 0; i < dealerdt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                ddl_dealer.Items.Add(item);
            }

            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strarea);
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
                DDL_proLine.Items.Add(new ListItem(linedt.Rows[i][0].ToString(),linedt.Rows[i][0].ToString()));
            }
            // 根据登录人ID得到所属省区 并加载相应市

            DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                DDL_Area.Text = userdt.Rows[0][0].ToString();
                DDL_department.Text = userdt.Rows[0][2].ToString();
                DDL_department.Enabled = false;
                DDL_Area.Enabled = false;
                IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
                foreach (LN.Model.ProvinceData pmodel in prolist)
                {
                    DDL_Province.Items.Add(new ListItem( pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                }
                string GetSuplierID = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + DDL_Area.Text + "'");
                if (GetSuplierID != "")
                {
                    DDL_Supplier.Text = GetSuplierID;
                    DDL_Supplier.Enabled = false;
                }
            }

        }
        DataTable ddt = new LN.BLL.DealerUser().GetDealerIdByUserID(int.Parse(UserID));
        if (ddt.Rows.Count > 0)
        {
            ddl_dealer.Text = ddt.Rows[0]["DealerID"].ToString();
            ddl_dealer.Enabled = false;
        }
        string supplierID = "0";//如果是VM进来 供应商ID 为 0 
        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
        {
            supplierID = supplierBody[0].ToString();
            DDL_Supplier.Text = supplierID;

            DDL_Supplier.Enabled = false;
        }

        //如果是一级客户登录  所定相应的一级客户

        DataTable duserdt = new LN.BLL.DealerUser().GetDealerIdByUserID(int.Parse(UserID));
        if (duserdt.Rows.Count > 0)
        {
            ddl_dealer.Text = duserdt.Rows[0][0].ToString();
            ddl_dealer.Enabled = false;
            DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName(" dealerID='" + ddl_dealer.Text + "'");//加载相应的直属客户
            for (int m = 0; m < fxdt.Rows.Count; m++)
            {
                DDL_fx.Items.Add(new ListItem(fxdt.Rows[m][1].ToString(), fxdt.Rows[m][0].ToString()));
            }
        }
    }
    protected void Btn_Analysis_Click(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {
        string prolines = new LN.BLL.POPLaunch().GetProline(DDL_POPID.Text);
        Hashtable ht = new Hashtable();
        ht.Add("POPID", DDL_POPID.Text);
        ht.Add("PosCode", txt_PosID.Text.Trim());
        ht.Add("Shopname", txt_shopname.Text.Trim());
        ht.Add("SupplierID", DDL_Supplier.Text);
        ht.Add("DealerID", ddl_dealer.Text);
        ht.Add("areaID", DDL_Area.Text);
        ht.Add("ProvinceID", Request.Form["DDL_Province"].ToString());
        ht.Add("CityID", Request.Form["DDL_city"].ToString());
        ht.Add("FXID", Request.Form["DDL_fx"].ToString());
        ht.Add("OrderField", "totalprice desc");
        ht.Add("pageSize", "0");
        ht.Add("pageIndex", "0");
        ht.Add("year", DDL_year.Text);
        ht.Add("protype",DDL_ProductType.Text);
        ht.Add("proline",DDL_proLine.Text);
        ht.Add("department", DDL_department.Text);
        //ht.Add("typename", DDL_ProductType.SelectedItem.Text);
       // ht.Add("ptype",DDL_ProductType.Text);
       // ht.Add("prolines", prolines);
        //int totalnum = 0;
        DataSet  ds = new LN.BLL.POPLaunch().POPAnalysisByPro(ht);
        cxstr += "POPID=" + DDL_POPID.Text + "&PosCode=" + txt_PosID.Text.Trim() + "&Shopname=" + Server.UrlEncode(txt_shopname.Text.Trim()) + "&SID=" + DDL_Supplier.Text + "&DID=" + ddl_dealer.Text;
        cxstr += "&areaID=" + DDL_Area.Text + "&ProvinceID=" + Request.Form["DDL_Province"].ToString() + "&CityID=" + Request.Form["DDL_city"].ToString() + "&prolines=" + prolines + "&year=" + DDL_year.Text;
        cxstr += "&fxid=" + Request.Form["DDL_fx"].ToString();//+"&protype="+DDL_ProductType.Text+"&proline="+Server.UrlEncode(DDL_proLine.Text)
        cxstr += "&department=" + Server.UrlEncode(DDL_department.Text);
        DataTable dt = ds.Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            area += double.Parse(dt.Rows[i]["totalarea"].ToString());
            price += double.Parse(dt.Rows[i]["totalprice"].ToString());
            num += int.Parse(dt.Rows[i]["totalnum"].ToString());
            setupprice += double.Parse(dt.Rows[i]["setupMoney"].ToString());
        }
        //ListPages.RecordCount = totalnum;
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

        GridView1.DataSource = ds.Tables[1];
        GridView1.DataBind();

        GridView2.DataSource = ds.Tables[2];
        GridView2.DataBind();
    }
    //protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    //{
    //    ListPages.CurrentPageIndex = e.NewPageIndex;
    //    bind();
    //}
}

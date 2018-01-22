using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
public partial class WebUI_Analysis_imagetopopAnalysis : System.Web.UI.Page
{
    string POPID = string.Empty;

    public  string showpage="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;//得到用户ID

         //string UserID = "5469";
        if (!Page.IsPostBack)
        {
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
                ddl_dealer.Items.Add(item);
            }
            //加载POP编号
            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                DDL_POPID.Items.Add(item);
            }
            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList("");
            foreach (LN.Model.AreaData model in arealist)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                DDL_Area.Items.Add(item);
            }
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
                    DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                }
            }
        }

        

        //POPID = new LN.BLL.POPLaunch().GetLastPOPID();
    }
    protected void Btn_Analysis_Click(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {


        Hashtable ht = new Hashtable();
        ht.Add("POPID", DDL_POPID.SelectedValue.Trim());
        ht.Add("PosCode", txt_PosID.Text.Trim());
        ht.Add("Shopname", txt_shopname.Text.Trim());
        ht.Add("DealerID", ddl_dealer.Text);
        ht.Add("areaID", DDL_Area.Text);
        ht.Add("ProvinceID", Request.Form["DDL_Province"].ToString());
        ht.Add("CityID", Request.Form["DDL_city"].ToString());

        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();

        sb.Append("shopid in (select distinct shopid from imagetopop where 1=1");
        sb2.Append("shopid not in (select distinct shopid from imagetopop where 1=1");

        if (ht["POPID"].ToString() != "0")
        {
            sb.Append(" and POPID='" + ht["POPID"].ToString() + "'");
            sb2.Append(" and POPID='" + ht["POPID"].ToString() + "'");
        }
        if (Txt_begindate.Text.Length > 0)
        {
            sb.Append(" and sysTime>='"+DateTime.Parse(Txt_begindate.Text.Trim())+"'");
            sb2.Append(" and sysTime>='" + DateTime.Parse(Txt_begindate.Text.Trim()) + "'");
        }
        if (Txt_enddate.Text.Trim().Length > 0)
        {
            sb.Append(" and sysTime<='"+DateTime.Parse(Txt_enddate.Text.Trim())+"'");
            sb2.Append(" and sysTime<='" + DateTime.Parse(Txt_enddate.Text.Trim()) + "'");
        }

        sb.Append(")");
        sb2.Append(")");
        if (ht["PosCode"].ToString().Length > 0)
        {
            sb.Append(" and Posid='" + ht["PosCode"].ToString() + "'");
            sb2.Append(" and Posid='" + ht["PosCode"].ToString() + "'");
        }
        if (ht["Shopname"].ToString().Length > 0)
        {
            sb.Append(" and shopname like '%" + ht["Shopname"].ToString() + "%'");
            sb2.Append(" and shopname like '%" + ht["Shopname"].ToString() + "%'");
        }
        if (ht["DealerID"].ToString() != "0")
        {
            sb.Append(" and DealerID = '" + ht["DealerID"].ToString() + "'");
            sb2.Append(" and DealerID = '" + ht["DealerID"].ToString() + "'");
        }
        if (ht["areaID"].ToString() != "-1" && ht["areaID"].ToString() !="0")
        {
            sb.Append(" and areaID = " + ht["areaID"].ToString());
            sb2.Append(" and areaID = " + ht["areaID"].ToString());

        }
        if (ht["ProvinceID"].ToString() != "0")
        {
            sb.Append(" and ProvinceID = " + ht["ProvinceID"].ToString());
            sb2.Append(" and ProvinceID = " + ht["ProvinceID"].ToString());
        }
        if (ht["CityID"].ToString() != "0")
        {
            sb.Append(" and CityID = " + ht["CityID"].ToString());
            sb2.Append(" and CityID = " + ht["CityID"].ToString());
        }
        if (DDL_Supplier.Text != "0")
        {
            sb.Append(" and supplierID="+DDL_Supplier.Text);
            sb2.Append(" and supplierID=" + DDL_Supplier.Text);
        }
        //DataSet ds=  new LN.BLL.imageToPOP().getShoplist(ht);
        DataTable dt1 = new LN.DAL.imageToPOP().getShoplist(sb.ToString());
        Session ["submitok"]=dt1;
        DataTable dt2 = new LN.DAL.imageToPOP().GetshoplistNO(sb2.ToString());
        Session["submitno"]=dt2;
        showpage = "提交的店铺数量为<a href='daochu.aspx?dtname=submitok'>" + dt1.Rows.Count + "</a>家                 未提交的店铺为<a href='daochu.aspx?dtname=submitno'>" + dt2.Rows.Count + "</a>家";
    
    }
}

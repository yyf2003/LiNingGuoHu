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
public partial class WebUI_POPAddition_SearchAddPOP : System.Web.UI.Page
{
   protected string dealerdispaly = "";
   protected int POPAddtionCount = 0;
   protected decimal POPAddtitionArea = 0;
    string UserID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        //////////////////////////////////////////确定增补人的权限 增补只能是 一级客户 直属客户 和店铺负责人来进行增补。
        string username = string.Empty;
        username = Server.UrlDecode(Request.Cookies["UserName"].Value);//根据cookie得到登录人姓名
        UserID = Request.Cookies["UserID"].Value;
        string usertype = new LN.BLL.UserInfo().GetTypeByName(username);//得到登录人的角色
        if ("店铺主管".Equals(usertype))
            dealerdispaly = "style=\"display:none\"";

        /////////////////////////////////////////

        if (!Page.IsPostBack)
        {

            ///////////////////////////////////////////////
            if ("店铺主管".Equals(usertype))
            {
                DataTable shopdt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(username);
                if (shopdt.Rows.Count > 0)
                {
                    this.Txt_PosID.Text = shopdt.Rows[0]["PosID"].ToString();

                    Txt_PosID.Enabled = false;

                }
            }
            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList("");
            foreach (LN.Model.AreaData model in arealist)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                DDL_Area.Items.Add(item);
            }
            //
            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");
            foreach (LN.Model.SupplierInfo model in list)
            {
                ListItem item = new ListItem(model.SupplierName, model.SupplierID.ToString());
                ddl_supplier.Items.Add(item);
            }
            //加载所有的 POP发起ID
            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                ddl_poplaunch.Items.Add(item);
            }

            //加载一级客户
            DataTable dealerdt = new LN.BLL.DealerInfo().GetDealerName(" 1=1 ");
            for (int i = 0; i < dealerdt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                ddl_dealer.Items.Add(item);
            }


            // 根据登录人ID得到所属省区 并加载相应市

            //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                //DDL_Area.Text = userdt.Rows[0][0].ToString();
                //IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + userdt.Rows[0][0].ToString());
                //foreach (LN.Model.ProvinceData pmodel in prolist)
                //{
                //    DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                //}
                //ddl_supplier.Text = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + userdt.Rows[0][0].ToString() + "'");
                //ddl_supplier.Enabled = false;
                DDL_Area.Items.Clear();
                DDL_Area.Items.Add(new ListItem("请选择区域", "0"));
                StringBuilder areas = new StringBuilder();
                foreach (DataRow dr in userdt.Rows)
                {
                    areas.Append(dr["AreaId"] + ",");
                    DDL_Area.Items.Add(new ListItem(dr["AreaName"].ToString(), dr["AreaId"].ToString()));

                }
                hfAreas.Value = areas.ToString().TrimEnd(',');
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
                ddl_supplier.Text = supplierID;
                DDL_examstate.Text = "1";
                DDL_examstate.Enabled = false;
                ddl_supplier.Enabled = false;

                if (supplierID != "0")
                {
                    DataTable sdt = new LN.BLL.SupplierAssignRecord().GetSupplierArea(int.Parse(supplierID));
                    DDL_Area.Items.Clear();
                    DDL_Area.Items.Add(new ListItem("请选择省区", "0"));
                    for (int i = 0; i < sdt.Rows.Count; i++)
                    {
                        DDL_Area.Items.Add(new ListItem(sdt.Rows[i][0].ToString(), sdt.Rows[i][1].ToString()));
                    }

                }
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
      

       
    }



    protected void Btn_search_ServerClick(object sender, EventArgs e)
    {
        
        string posid = Txt_PosID.Text.Trim();
        string AreaID = DDL_Area.SelectedValue;
        if (AreaID == "0")
            AreaID = hfAreas.Value;
        string proviceid = Request.Form["DDL_Province"].ToString();// DDL_Province.SelectedItem.Value;
        string cityid = Request.Form["DDL_city"].ToString();// DDL_city.SelectedItem.Value;
        string deaclerid = ddl_dealer.SelectedItem.Value;
        string examstate = DDL_examstate.SelectedItem.Value;
        string fxid = DDL_fx.SelectedItem.Value;
        string suppilerid = ddl_supplier.Text;
        string strWhere = " 1=1 ";
        string strBeginDate = txtBeginDate.Text.Trim();
        string strEndDate = txtEndDate.Text.Trim();
        string poplaunch = ddl_poplaunch.SelectedItem.Value;
        if (posid != "")
            strWhere += " AND PosID like  '%" + posid + "%'";
        if (AreaID != "0")
        {
            //strWhere += " AND areaid=" + AreaID;
            strWhere += " AND areaid in (" + AreaID+")";
        }
        if (proviceid != "0")
            strWhere += " AND provincename='" + proviceid + "'";
        if (cityid != "0")
            strWhere += " AND cityname='" + cityid + "'";
        if (deaclerid != "0")
            strWhere += " AND dealername='" + deaclerid + "'";
        if (examstate != "-1")
            strWhere += " and Examstate ='" + examstate + "'";
        if (fxid != "0")
            strWhere += " AND FXID='" + fxid + "'";
        if (poplaunch != "0")
            strWhere += " and POPID='" + poplaunch + "'";
        if (suppilerid != "0")
            strWhere += " and supplierID="+suppilerid;
        if (strBeginDate != "")
            strWhere += " and AddDate>='" + strBeginDate + "' ";
        if (strEndDate != "")
            strWhere += " and AddDate<='" + strEndDate + "' ";

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
        dt.Columns.Remove("Addid");
        dt.Columns.Remove("dealerid");
        dt.Columns.Remove("shopid");
        dt.Columns.Remove("UnDes");
        dt.Columns.Remove("Des");
        dt.Columns.Remove("PhotoUrl");
        dt.Columns.Remove("examstate");
        dt.Columns["posid"].ColumnName = "店铺编号";
        dt.Columns["shopname"].ColumnName = "店铺名称";
        dt.Columns["dealername"].ColumnName = "一级客户";
        dt.Columns["POPseat"].ColumnName = "位置";
        dt.Columns["seatnum"].ColumnName = "POP编号";
        dt.Columns["RealHeight"].ColumnName = "实际高度";
        dt.Columns["RealWith"].ColumnName = "实际宽度";
        dt.Columns["POPHeight"].ColumnName = "画面高度";
        dt.Columns["POPWith"].ColumnName = "画面宽度";
        dt.Columns["POPMaterial"].ColumnName = "POP材质";
        dt.Columns["POPArea"].ColumnName = "POP面积";

        Session["addPOPps"] = null;
        Session["addPOPps"] = dt;
        
    }
}

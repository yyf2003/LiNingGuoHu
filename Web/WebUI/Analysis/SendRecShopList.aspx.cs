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
public partial class WebUI_Analysis_SendRecShopList : System.Web.UI.Page
{
    public int NorecCount = 0;
    string deptname = string.Empty;
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
        if (deptdt.Rows.Count > 0)
        {
            deptname = deptdt.Rows[0]["department"].ToString();
        }
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
            if (!string.IsNullOrEmpty(deptname))
                strarea += string.Format(" department='{0}' ", deptname);

            //加载供应商

            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");
            foreach (LN.Model.SupplierInfo model in list)
            {
                ListItem item = new ListItem(model.SupplierName, model.SupplierID.ToString());
                ddl_supplier.Items.Add(item);
            }
            //加载所有的 POP发起ID
            //IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            //for (int i = 0; i < plist.Count; i++)
            //{
            //    ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
            //    DDL_POPID.Items.Add(item);
            //}

            //只加载最新发起的POPID
            string lastPOP = new LN.BLL.POPLaunch().GetLastPOPID();
            ListItem popitem = new ListItem(lastPOP, lastPOP);
            ddl_popid.Items.Add(popitem);
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
                    DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                }

                ddl_supplier.Text = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + DDL_Area.Text + "'");
                ddl_supplier.Enabled = false;
            }

            
        }

        string supplierID = "0";//如果是VM进来 供应商ID 为 0 
        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
        {
            supplierID = supplierBody[0].ToString();
            ddl_supplier.Text = supplierID;

            ddl_supplier.Enabled = false;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bind();
        
    }
    private void bind()
    {
        StringBuilder sb = new StringBuilder();
        if (DDL_Area.Text != "0")
            sb.Append(string.Format(" and View_shippingSpeed.areaid={0}", DDL_Area.Text));
        if (Request.Form["DDL_Province"].ToString() != "0")
            sb.Append(string.Format(" and View_shippingSpeed.provinceID={0}", Request.Form["DDL_Province"].ToString()));
        if (Request.Form["DDL_city"].ToString() != "0")
            sb.Append(string.Format(" and View_shippingSpeed.cityid={0}", Request.Form["DDL_city"].ToString()));
        if (ddl_dealer.Text != "0")
            sb.Append(string.Format(" and View_shippingSpeed.dealerID='{0}'", ddl_dealer.Text));
        if (ddl_supplier.Text != "0")
            sb.Append(string.Format(" and View_shippingSpeed.supplierid={0}", ddl_supplier.Text));
        if (ddl_shippingtype.Text != "0")
            sb.Append(string.Format(" and IsState='{0}'", ddl_shippingtype.Text));
        if (DDL_department.Text != "")//部门
            sb.Append(string.Format(" and department='{0}'",DDL_department.Text));
        if (Request.Form["DDL_fx"].ToString() != "0")
            sb.Append(string.Format(" and FXID='{0}'", Request.Form["DDL_fx"].ToString()));
        if (Txt_begindate.Text.Length > 0)
            sb.Append(string.Format(" and FHDate>='{0}'",Txt_begindate.Text.Trim()));
        if (Txt_enddate.Text.Length > 0)
            sb.Append(string.Format(" and FHDate<='{0}'",Txt_enddate.Text.Trim()));
        
        sb.Append(string.Format(" and POPID='{0}'", ddl_popid.Text));
        sb.Append(string.Format(" and GetInState='{0}'", "已发送"));
        DataTable dt = new LN.BLL.ShippingSpeedData().GetSubList(sb.ToString());
        NorecCount = dt.Rows.Count;
        Session["sendRec"] = null;
        Session["sendRec"] = dt;
    }
}

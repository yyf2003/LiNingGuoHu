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


public partial class WebUI_Analysis_ShopSHAnalysis : System.Web.UI.Page
{

    protected string UserID = String.Empty; //登录用户编号
    protected string TypeID = "0";     //该用户在供应商中的权限
    protected int AllNum = 0;
    protected int fhOKCount = 0;
    protected int fhNoCount = 0;
    protected string deptname = string.Empty;

    public decimal bili = 0;
    protected void Page_Load(object sender, EventArgs e)
    {



        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名

        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        if (deptdt.Rows.Count > 0)
        {
            deptname = deptdt.Rows[0]["department"].ToString();
        }

        if (!IsPostBack)
        {
            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_department.Items.Add(item);
            }

            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList("");
            foreach (LN.Model.AreaData model in arealist)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                DDL_Area.Items.Add(item);
            }

            GetProvince();
            LoadPOP();
            BindSupplier();
            GetSupplierID();
            BindDealer();
            if (hidSupplierID.Value.Trim() != "0")
            {
                ddl_supplier.Text = hidSupplierID.Value;
                ddl_supplier.Enabled = false;
            }

            // 根据登录人ID得到所属省区 
            DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                DDL_Area.Text = userdt.Rows[0][0].ToString();
                DDL_department.Text = userdt.Rows[0][2].ToString();
                DDL_department.Enabled = false;
                DDL_Area.Enabled = false;
            }
        }

    }

    /// <summary>
    /// 绑定POP信息，最新的POP排在最上面
    /// </summary>
    private void LoadPOP()
    {
        IList<string> Plist = new LN.BLL.POPLaunch().GetPOPID();
        for (int i = 0; i < Plist.Count; i++)
        {
            ListItem item = new ListItem(Plist[i].ToString(), Plist[i].ToString());
            ddl_popid.Items.Add(item);
        }

    }

    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {



        string strWhere = String.Empty; //搜索条件


        if (Txt_PosID.Text.Trim() != "")
        {
            strWhere += string.Format(" AND PosID like '%{0}%' ", Txt_PosID.Text.Trim());
        }
        if (this.DDL_Area.Text.Trim() != "0")
        {
            strWhere += string.Format(" AND areaID = {0}", DDL_Area.Text.Trim());
        }
        if (Request.Form["DDL_Province"].ToString() != "0")
        {
            strWhere += string.Format(" AND ProvinceID = {0} ", Request.Form["DDL_Province"].ToString());
        }
        if (Request.Form["DDL_city"].ToString() != "0")
        {
            strWhere += string.Format(" AND CityID = {0} ", DDL_city.SelectedValue.Trim());
        }
        if (Request.Form["DDL_fx"].ToString() != "0")
            strWhere += string.Format(" AND [View_ShopInfo].FXID = {0} ", Request.Form["DDL_fx"].ToString());
        if (ddl_dealer.SelectedValue.Trim() != "0")
        {
            strWhere += string.Format(" AND DealerID = '{0}' ", ddl_dealer.SelectedValue.Trim());
        }
        if (ddl_supplier.SelectedValue.Trim() != "0")
        {
            strWhere += string.Format(" AND SupplierID = '{0}' ", ddl_supplier.SelectedValue.Trim());
        }
        string shipping = "0";
        if (ddl_shippingtype.SelectedValue.Trim() != "0")
        {
            shipping = ddl_shippingtype.SelectedValue.Trim();
            strWhere += string.Format(" and IsState='{0}'",shipping);
        }
        string popid = ddl_popid.SelectedValue.Trim();
        if (popid.Length > 0)
            strWhere += string.Format(" and POPID='{0}'",popid);
        if (DDL_department.Text != "0")
            strWhere += string.Format(" and departMent='{0}'",DDL_department.Text.Trim());
        if(Txt_begindate.Text.Trim().Length>0)
            strWhere += string.Format(" and FHDate>='{0}'", Txt_begindate.Text.Trim());
        if (Txt_enddate.Text.Trim().Length > 0)
            strWhere += string.Format(" and FHDate<='{0}'", Txt_enddate.Text.Trim());
        DataSet ds = new LN.BLL.ShippingSpeedData().GetSHAnaysis(strWhere);

        AllNum = ds.Tables[0].Rows.Count;

        DataView dv = new DataView(ds.Tables[0]);
        dv.RowFilter = " 收货状态='已收货'";
        DataTable shOK = dv.ToTable();
        Session["SHOK"] = shOK;
        fhOKCount = shOK.Rows.Count;
        DataView dv1 = new DataView(ds.Tables[0]);
        dv1.RowFilter = " 收货状态='已发送'";
        DataTable shNO = dv1.ToTable();
       fhNoCount=shNO.Rows.Count;
       Session["SHNO"] = shNO;
       
        if (AllNum > 0)
            bili = decimal.Parse(fhOKCount.ToString()) / decimal.Parse(AllNum.ToString());
        else
            bili = 0;
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

        // 根据登录人ID得到所属省区 并加载相应市

        DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        if (userdt.Rows.Count > 0)
        {
            DDL_Area.Text = userdt.Rows[0][0].ToString();
            IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + userdt.Rows[0][0].ToString());
            foreach (LN.Model.ProvinceData pmodel in prolist)
            {
                DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
            }
            DDL_Area.Enabled = false;
        }
        else
        {
            //加载省份
            IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
            for (int i = 0; i < pList.Count; i++)
            {
                ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
                DDL_Province.Items.Add(item);
            }
        }
    }

    /// <summary>
    /// 绑定一级客户
    /// </summary>
    private void BindDealer()
    {
        DataTable dt = new LN.BLL.DealerInfo().GetDealerName(" 1=1 ");
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
    /// 绑定供应商
    /// </summary>
    private void BindSupplier()
    {
        // DataTable dt = new LN.BLL.SupplierInfo ();
        IList<LN.Model.SupplierInfo> sList = new LN.BLL.SupplierInfo().GetList("");
        ddl_supplier.Items.Add(new ListItem("请选择供应商", "0"));
        if (sList.Count > 0)
        {
            for (int i = 0; i < sList.Count; i++)
            {
                ListItem item = new ListItem(sList[i].SupplierName, sList[i].SupplierID.ToString());
                ddl_supplier.Items.Add(item);
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // ListPages.CurrentPageIndex = 1;
        GetList();
    }

    /// <summary>
    /// 加载一级客户名字
    /// </summary>
    /// <param name="dealerid"></param>
    /// <returns></returns>
    protected string GetDealerName(string dealerid)
    {
        if (dealerid != "")
        {
            DataTable dt = new LN.BLL.DealerInfo().GetDealerName("DealerID ='" + dealerid + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["DealerName"].ToString();
            }
        }
        return "";
    }
    /// <summary>
    /// 得到供应商名字
    /// </summary>
    /// <param name="supplierid"></param>
    /// <returns></returns>
    protected string GetSupplierName(string supplierid)
    {
        if (supplierid != "")
        {
            return new LN.BLL.SupplierInfo().GetModel(int.Parse(supplierid)).SupplierName;
        }
        return "";
    }
}

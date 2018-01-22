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

public partial class WebUI_SetUpConfirm_List : System.Web.UI.Page
{
    protected int totalcount = 0, setupcount = 0, unsetupcount = 0;
    protected decimal  bfb = 0;
    protected string pageUrl = string.Empty;
    string UserID = string.Empty, UserName = string.Empty, deptname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;//得到用户ID
        UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
        
        if (!IsPostBack)
        {
            LoadProviceData();
        }
    }
    public void LoadProviceData()
    {
        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        //if (deptdt.Rows.Count > 0)
        //{
        //    deptname = deptdt.Rows[0]["department"].ToString();
        //}

        //加载部门名称
        List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
        foreach (LN.Model.DepartMentInfo deptmodel in listdept)
        {
            ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
            DDL_department.Items.Add(item);
        }
        //string strarea = "";
        //if (!string.IsNullOrEmpty(deptname))
        //    strarea += string.Format(" department='{0}' ", deptname);

        //加载区域
        //IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strarea);
        //foreach (LN.Model.AreaData model in arealist)
        //{
        //    ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
        //    DDL_Area.Items.Add(item);
        //}

        //一级客户
        DataTable dtDearler = new LN.BLL.DealerInfo().GetList("").Tables[0];
        for (int j = 0; j < dtDearler.Rows.Count; j++)
        {
            ListItem item = new ListItem(dtDearler.Rows[j]["DealerName"].ToString(), dtDearler.Rows[j]["DealerID"].ToString());
            ddl_dealer.Items.Add(item);
        }
        IList<LN.Model.SupplierInfo> SupplierList = new LN.BLL.SupplierInfo().GetList("");
        foreach (LN.Model.SupplierInfo modelsup in SupplierList)
        {
            ListItem item = new ListItem(modelsup.SupplierName, modelsup.SupplierID.ToString());
            DDL_Supplier.Items.Add(item);
        }

        IList<string> poplaunchlist = new LN.BLL.POPLaunch().GetPOPID();
        if (poplaunchlist.Count > 0)
        {
            for (int i = 0; i < poplaunchlist.Count; i++)
            {
                  ListItem list = new ListItem(poplaunchlist[i].ToString(), poplaunchlist[i].ToString());
                  DDL_POPID.Items.Add(list);
            }
          
        }

        // 根据登录人ID得到所属省区 并加载相应市

        DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        if (userdt.Rows.Count > 0)
        {
            DDL_Area.Text = userdt.Rows[0][0].ToString();
            DDL_department.Text = userdt.Rows[0][2].ToString(); ;
            DDL_department.Enabled = false;
            DDL_Area.Enabled = false;
            IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
            foreach (LN.Model.ProvinceData pmodel in prolist)
            {
                DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
            }
            string GetSuplierID = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + DDL_Area.Text + "'");
            if (GetSuplierID != "")
            {
                DDL_Supplier.Text = GetSuplierID;
                DDL_Supplier.Enabled = false;
            }
        }
        else
        {
            if (deptdt.Rows.Count > 0)
            {
                //DDL_department.Text = deptname;
                //DDL_department.Enabled = false;
                DDL_department.DataSource = deptdt;
                DDL_department.DataTextField = "department";
                DDL_department.DataValueField = "department";
                DDL_department.DataBind();

                //加载区域
                IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(string.Format(" department='{0}'", DDL_department.SelectedValue));
                foreach (LN.Model.AreaData model in arealist)
                {
                    ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                    DDL_Area.Items.Add(item);
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string dealerid = this.ddl_dealer.SelectedValue;
        string supplierid = this.DDL_Supplier.SelectedValue;
        string areaid = this.DDL_Area.SelectedValue;
        string proviceid = this.DDL_Province.SelectedValue;
        string cityid = "0";
         if (Request.Form["DDL_city"] != null)
             cityid = this.Request.Form["DDL_city"].ToString();
         string fxid = "0";
         if (Request.Form["DDL_fx"] != null)
             fxid = Request.Form["DDL_fx"].ToString();
        string popid =DDL_POPID.Text;
        string begindate = Txt_begindate.Text.Trim();
        string enddate = Txt_enddate.Text.Trim();
        string department = DDL_department.Text;
        int boolinstall = int.Parse(DDL_install.Text);
        pageUrl = "&dealerid=" + dealerid + "&areaid=" + areaid + "&proviceid=" + proviceid + "&cityid=" + cityid + "&fxid=" + fxid+"&popid="+popid;
        //供应商要安装的总数量
        DataTable dt = new LN.BLL.SetUpConfirm().GetSetUpConfirmSearch(int.Parse(supplierid), dealerid,fxid, int.Parse(areaid), int.Parse(proviceid), int.Parse(cityid),popid,begindate,enddate,department,boolinstall);
        dt.Columns.Add("bfb");
        for (int i = 0; i < dt.Rows.Count; i++)
        { 
            if (decimal.Parse(dt.Rows[i]["setupcount"].ToString()) > 0)
                dt.Rows[i]["bfb"] = (decimal.Parse(dt.Rows[i]["setupcount"].ToString()) / decimal.Parse(dt.Rows[i]["totalsetup"].ToString())*100).ToString("#0.00");
            else
                dt.Rows[i]["bfb"] = "0";
            totalcount +=int.Parse( dt.Rows[i]["totalsetup"].ToString());
            setupcount += int.Parse(dt.Rows[i]["setupcount"].ToString());
            unsetupcount += int.Parse(dt.Rows[i]["nosetupcount"].ToString());
          
        }
        if (setupcount > 0)
            bfb = decimal.Parse(setupcount.ToString()) / decimal.Parse(totalcount.ToString())*100;
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

    }
}

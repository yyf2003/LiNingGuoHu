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
public partial class WebUI_Distribution_Add : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //获取用户编号
    protected string UserName = String.Empty;   //获取用户名称
    protected string DealerID = String.Empty;   //所属一级客户编号
    protected string deptname = string.Empty;   //所属部门名称
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        else
        {
            UserID = Request.Cookies["UserID"].Value;
            DealerID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
            UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
            DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
            DataTable deptdt = deptds.Tables[0];
            if (deptdt.Rows.Count > 0)
            {
                deptname = deptdt.Rows[0]["department"].ToString();
            }
        }
        if (!IsPostBack)
        {
            LoadAreaProvinceCityData();
            IsVM();

            //获取所属一级客户名称
            lblDealerName.Text = new LN.BLL.DealerInfo().GetDealerName(string.Format(" DealerID = '{0}'", DealerID)).Rows[0][1].ToString();
        }
    }

    /// <summary>
    /// 判断指定用户有没有添加直属客户的权限
    /// </summary>
    private void IsVM()
    {
        LN.Model.UserInfo u = new LN.BLL.UserInfo().GetModel(Int32.Parse(UserID));
        if (u != null)
        {
            if (Int32.Parse(u.Usertype) > 3)
                Response.Redirect("../../Error.aspx?param=17");
        }
        else
            btnAdd.Enabled = false;
    }

    public void LoadAreaProvinceCityData()
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


        // 根据登录人ID得到所属省区 并加载相应市

        DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        if (userdt.Rows.Count > 0)
        {
            DDL_department.Text = userdt.Rows[0][2].ToString();
            DDL_department.Enabled = false;
            DDL_Area.Items.Add(new ListItem(userdt.Rows[0][1].ToString(), userdt.Rows[0][0].ToString()));
            DDL_Area.Text = userdt.Rows[0][0].ToString();
            DDL_Area.Enabled = false;
            IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
            foreach (LN.Model.ProvinceData pmodel in prolist)
            {
                DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
            }
        }
        else
        {
            if (deptname != "")
            {
                IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList(strarea);
                foreach (LN.Model.AreaData model in AreaList)
                {
                    ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                    DDL_Area.Items.Add(item);
                }
                DDL_department.Text = deptname;
                DDL_department.Enabled = false;
            }
        }
    }

    /// <summary>
    /// 添加直属客户
    /// </summary>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string FXID = txtFXID.Text.Trim();
        string FXName = txtFXName.Text.Trim();
        string FXContactor = txtFXContactor.Text.Trim();
        string FXPhone = txtFXPhone.Text.Trim();
        string FXtel = txtFXtel.Text.Trim();
        string FXAddress = txtFXAddress.Text.Trim();
        LN.Model.DistributorsInfo model = new LN.Model.DistributorsInfo();
        model.FXID = FXID;
        model.FXName = FXName;
        model.FXContactor = FXContactor;
        model.FXPhone = FXPhone;
        model.FXtel = FXtel;
        model.DealerID = DealerID;
        model.NewDealerID = DealerID;
        model.FXAddress = FXAddress;

        if (Request.Form["DDL_Area"] == null)
            model.AreaID = Int32.Parse(DDL_Area.Text);
        else
            model.AreaID = Int32.Parse(Request.Form["DDL_Area"].ToString());

        if (Request.Form["DDL_Province"] == null)
            model.ProvinceID = Int32.Parse(DDL_Province.Text);
        else
            model.ProvinceID = Int32.Parse(Request.Form["DDL_Province"].ToString());

        if (Request.Form["DDL_city"] == null)
            model.CityID = Int32.Parse(DDL_city.Text);
        else
            model.CityID = Int32.Parse(Request.Form["DDL_city"].ToString());

        int result = new LN.BLL.DistributorsInfo().Add(model);

        if (result > 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('添加成功！！');window.location=window.location;</script>");
            return;
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('添加失败，该直属客户已经存在！！');window.location=window.location;</script>");
            return;
        }
    }
}

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
using System.Text;

public partial class WebUI_ShopPOP_ExamPOP : System.Web.UI.Page
{
    protected string NOrecord = string.Empty, deptname = string.Empty, UserName=string.Empty;
    int TotalNumber = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        string UserID = Request.Cookies["UserID"].Value;
        UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        //if (deptdt.Rows.Count > 0)
        //{
        //    deptname = deptdt.Rows[0]["department"].ToString();
        //}
        if (!Page.IsPostBack)
        {
            //加载供应商
            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("SupplierState = 1");

            foreach (LN.Model.SupplierInfo model in list)
            {
                ListItem supitem = new ListItem(model.SupplierName, model.SupplierID.ToString());
                DDL_supplier.Items.Add(supitem);
            }

            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_department.Items.Add(item);
            }
            string strarea = "";
            if (!string.IsNullOrEmpty(deptname))
            {
                strarea += string.Format(" department='{0}' ", deptname);
            }

            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
           
            if (userdt.Rows.Count > 0)
            {
                
                

                
                
                //DDL_supplier.Text = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + userdt.Rows[0][0].ToString() + "'");
                //DDL_supplier.Enabled = false;


                //if (userdt.Rows.Count == 1)
                //{
                //    DDL_department.Text = userdt.Rows[0][2].ToString();
                //    DDL_department.Enabled = false;
                //    DDL_Area.Items.Add(new ListItem(userdt.Rows[0][1].ToString(), userdt.Rows[0][0].ToString()));
                //    DDL_Area.Text = userdt.Rows[0][0].ToString();
                //    DDL_Area.Enabled = false;
                //    //加载省份
                //    IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + userdt.Rows[0][0].ToString());

                //    foreach (LN.Model.ProvinceData pmodel in prolist)
                //    {
                //        DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                //    }
                //}
                //else
                //{
                    
                    
                //}
                List<string> DepartmentList = new List<string>();
                StringBuilder areas = new StringBuilder();
                foreach (DataRow dr in userdt.Rows)
                {

                    if (!DepartmentList.Contains(dr["DepartMent"].ToString()))
                    {
                        DepartmentList.Add(dr["DepartMent"].ToString());
                    }
                    areas.Append(dr["AreaId"] + ",");
                }
                hfAreas.Value = areas.ToString().TrimEnd(',');
                if (DepartmentList.Count > 0)
                {

                    bool canDelete = true;
                    List<ListItem> ItemList = new List<ListItem>();
                    foreach (ListItem li in DDL_department.Items)
                    {
                        if (li.Value != "0")
                        {
                            canDelete = true;
                            foreach (string d in DepartmentList)
                            {
                                if (li.Text == d)
                                {
                                    canDelete = false;
                                    break;
                                }
                            }
                            if (canDelete)
                            {
                                ItemList.Add(li);
                            }
                        }

                    }
                    if (ItemList.Count > 0)
                    {
                        foreach (ListItem li in ItemList)
                        {
                            if (DDL_department.Items.Contains(li))
                            {
                                DDL_department.Items.Remove(li);
                            }
                        }
                    }
                }


            }
            else
            {
                if (deptdt.Rows.Count > 0)
                {
                    DDL_department.DataSource = deptdt;
                    DDL_department.DataTextField = "department";
                    DDL_department.DataValueField = "department";
                    DDL_department.DataBind();
                    //加载区域
                    IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(string.Format(" department='{0}'", DDL_department.SelectedValue));
                    //DDL_Area.Items.Add(new ListItem("请选择省区","0"));
                    foreach (LN.Model.AreaData model in arealist)
                    {
                        ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                        DDL_Area.Items.Add(item);
                    }
                    //DDL_department.Text = deptname;
                    //DDL_department.Enabled = false;
                }
               
            }
            bind(1);
        }
    }
   /// <summary>
   /// 按照相应 的条件查找相应的记录
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void btn_search_Click(object sender, EventArgs e)
    {

        bind(1);
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind(GridView1.PageIndex);
    }

    public void bind(int pageindex)
    {
        string strsql = "";
        if (!string.IsNullOrEmpty(deptname))//如果是大区域vm经理审核 只审核省区vm经理审核过的数据
        {
            strsql = " and  VMExamState=1 and  ExamState=0 ";
        }
        else //如果是省区vm审核 要审核所有未审核的数据
        {
            strsql = " and  VMExamState=0 ";
        }
        Hashtable htable = new Hashtable();
        htable.Add("PosID", this.txt_POSID.Text.Trim());
        htable.Add("ShopName", this.txt_shopname.Text.Trim());
        htable.Add("dept",DDL_department.SelectedValue!="0"?DDL_department.SelectedItem.Text:"0");
        if (DDL_Area.SelectedValue!="0")
        {
            htable.Add("areaid", DDL_Area.SelectedValue);
        }
        else
        {
            htable.Add("areaid", hfAreas.Value!=""?hfAreas.Value:"0");
        }
        //htable.Add("areaid", "0");
        htable.Add("strwhere",strsql);
        htable.Add("Pro", DDL_Province.SelectedValue);
        htable.Add("City", DDL_city.SelectedValue);
        htable.Add("Supplier", DDL_supplier.Text);
        htable.Add("btime",Txt_btime.Text.Trim());
        htable.Add("etime",Txt_etime.Text.Trim());
        htable.Add("Order", "ShopName desc");
        htable.Add("pageSize", 1000);
        htable.Add("pageIndex", pageindex);
        htable.Add("TotalRecord", 0);
        DataTable dt = new LN.BLL.POPInfo().GetExamPOP(htable,ref TotalNumber);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (dt.Rows.Count > 0)
        {
            
        }
        else
        {
            NOrecord = "无要审批的POP信息！";
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "exam")
        {
            Response.Redirect("ConfirmShopPopList.aspx?shopid=" + e.CommandArgument.ToString());
        }
    }

    /// <summary>
    /// 选择部门
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDL_department_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depName = (sender as DropDownList).SelectedItem.Text;
        DDL_Area.Items.Clear();
        DDL_Area.Items.Add(new ListItem("请选择区域", "0"));
        DDL_Province.Items.Clear();
        DDL_Province.Items.Add(new ListItem("请选择省份", "0"));
        DDL_city.Items.Clear();
        DDL_city.Items.Add(new ListItem("请选择地级城市", "0"));
        string strWhere = string.Format("department='{0}'", depName);
        IList<LN.Model.AreaData> list = new LN.BLL.AreaData().GetList(strWhere);
        if (list != null && list.Count > 0)
        {
            List<int> myAreas = new List<int>();
            if (hfAreas.Value != "")
            {
                string[] arr = hfAreas.Value.Split(',');
                foreach (string s in arr)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        myAreas.Add(int.Parse(s));
                    }
                }
            }
            foreach (LN.Model.AreaData model in list)
            {
                
                if (myAreas.Count > 0)
                {
                    if(myAreas.Contains(model.AreaID))
                        DDL_Area.Items.Add(new ListItem(model.AreaName, model.AreaID.ToString()));
                }
                else
                    DDL_Area.Items.Add(new ListItem(model.AreaName, model.AreaID.ToString()));
            }
            
           
        }
    }
    /// <summary>
    /// 选择区域
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDL_Area_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        DDL_city.Items.Clear();
        DDL_city.Items.Add(new ListItem("请选择地级城市", "0"));
        string areaId = (sender as DropDownList).SelectedValue;
        IList<LN.Model.ProvinceData> prolist = null;
        if (areaId == "-1")
            prolist = new LN.BLL.ProvinceData().GetList("");
        else
            prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + areaId);
        DDL_Province.DataSource = prolist;
        DDL_Province.DataTextField = "ProvinceName";
        DDL_Province.DataValueField = "ProvinceID";
        DDL_Province.DataBind();
        DDL_Province.Items.Insert(0, new ListItem("请选择省份", "0"));
    }

    /// <summary>
    /// 选择省份
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDL_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pid = (sender as DropDownList).SelectedValue;
        LN.DAL.CityData cityDAL = new LN.DAL.CityData();
        DataTable citydt = cityDAL.GetCityList("provinceID=" + pid);
        DDL_city.DataSource = citydt;
        DDL_city.DataTextField = "CityName";
        DDL_city.DataValueField = "CItyID";
        DDL_city.DataBind();
        DDL_city.Items.Insert(0, new ListItem("请选择地级城市", "0"));
    }
}

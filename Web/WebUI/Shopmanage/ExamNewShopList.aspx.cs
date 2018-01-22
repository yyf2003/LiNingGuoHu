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
using System.Text;
using System.Collections.Generic;
public partial class WebUI_Shopmanage_ExamNewShopList : System.Web.UI.Page
{
    string UserID = string.Empty, deptname = string.Empty, UserName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;//得到登录人ID
        UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名

        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        //if (deptdt.Rows.Count > 0)
        //{
        //    deptname = deptdt.Rows[0]["department"].ToString();
        //}
        // 根据登录人ID得到所属省区 并加载相应市
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
                
                //DDL_department.Text = deptname;
                //DDL_department.Enabled = false;
                DDL_department.DataSource = deptdt;
                DDL_department.DataTextField = "department";
                DDL_department.DataValueField = "department";
                DDL_department.DataBind();
                strarea += string.Format(" department='{0}' ", DDL_department.SelectedValue);
            }
            // 根据登录人ID得到所属省区 并加载相应市
            //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                //ListItem item = new ListItem(userdt.Rows[0][1].ToString(), userdt.Rows[0][0].ToString());
                //DDL_Area.Items.Add(item);
                //DDL_Area.Text = userdt.Rows[0][0].ToString();
                //DDL_department.Text = userdt.Rows[0][2].ToString();
                //DDL_department.Enabled = false;
                //DDL_Area.Enabled = false;
                //IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
                //foreach (LN.Model.ProvinceData pmodel in prolist)
                //{
                //    DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
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
                //加载区域
                IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strarea);
                //DDL_Area.Items.Add(new ListItem("请选择省区","0"));
                foreach (LN.Model.AreaData model in arealist)
                {
                    ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                    DDL_Area.Items.Add(item);
                }
            }


            bind();
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {
        string strdept = string.Empty;
        if (deptname.Length > 0)
        {
            strdept = " and VMExamState=1 and  ExamState=0  ";
        }
        else
        {
            //modify by mhj 2012.12.13
            //strdept = " and VMExamState is null  ";
            strdept = " and (VMExamState is null or  VMExamState=0) ";
        }

        //if (DDL_Area.Text != "")
        //{
            
        //}
        string dept = DDL_department.SelectedValue != "0" ? DDL_department.SelectedItem.Text : "0";
        string areaid = "0";
        if (DDL_Area.SelectedValue != "0")
        {
            areaid = DDL_Area.SelectedValue;
        }
        else
        {
            areaid = hfAreas.Value != "" ? hfAreas.Value : "0";
        }
        StringBuilder sb = new StringBuilder();
        sb.Append(" 1=1 ");
        if (dept != "0")
            sb.AppendFormat(" and department='{0}' ", dept);
        if (areaid != "0")
        {
            sb.Append(string.Format(" and areaid in ({0})", areaid));
        }
        //string ProID = Request.Form["DDL_Province"] == null ? "0" : Request.Form["DDL_Province"].ToString();
        string ProID = DDL_Province.SelectedValue;
        if (DDL_Province.Text != "0")
            sb.Append(string.Format(" and provinceID={0}", ProID));
        sb.Append(string.Format(strdept + " and shopstate>0"));
        DataSet shopdt = new LN.BLL.ShopInfo().GetList(sb.ToString());

        this.Repeater1.DataSource = shopdt.Tables[0];
        Repeater1.DataBind();
        if (shopdt.Tables[0].Rows.Count <= 0)
        {
            btn_ok.Enabled = false;
            Btn_no.Enabled = false;
        }
        else
        {
            btn_ok.Enabled = true;
            Btn_no.Enabled = true;
        }
    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        if (Request.Form["check_shopid"] != null)
        {
            if (Request.Form["check_shopid"].ToString().Length > 0)
            {
                string strwhere = "  shopid in (" + Request.Form["check_shopid"].ToString() + ")";
                try
                {
                    if (!string.IsNullOrEmpty(deptname))
                    {
                        new LN.BLL.ShopInfo().UpdateExamState(1, UserID, strwhere);
                    }
                    else
                    {
                        new LN.BLL.ShopInfo().VMUpdateExamState(1, UserID, strwhere);
                    }
                   Response.Write("<script>alert('审核成功');</script>");
                   bind();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('审核失败，请重新审核或联系管理员');</script>");

                    throw;
                }
                
            }
        }
    }
    protected void Btn_no_Click(object sender, EventArgs e)
    {
        if (Request.Form["check_shopid"] != null)
        {
            if (Request.Form["check_shopid"].ToString().Length > 0)
            {
                string strwhere = " shopid in (" + Request.Form["check_shopid"].ToString() + ")";

                try
                {
                    if (!string.IsNullOrEmpty(deptname))
                    {
                        new LN.BLL.ShopInfo().UpdateExamState(-1, UserID, strwhere);
                    }
                    else
                    {
                        new LN.BLL.ShopInfo().VMUpdateExamState(-1, UserID, strwhere);
                    }
                    Response.Write("<script>alert('审核成功');</script>");
                    bind();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('审核失败，请重新审核或联系管理员');</script>");

                    throw;
                }
            }
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
                    if (myAreas.Contains(model.AreaID))
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
}


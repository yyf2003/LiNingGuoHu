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

public partial class WebUI_DealerInfo_DealerList : System.Web.UI.Page
{
    public string DealerID = string.Empty;
    public string DealerName = string.Empty;
    public string Area = string.Empty;
    public string Provice = string.Empty;
    public string City = string.Empty, UserID = string.Empty, deptname=string.Empty, AreaID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
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
            LoadAreaProvinceCityData();
            GetDealerData();
        }
    }
    public void LoadAreaProvinceCityData()
    {
        //IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
        //for (int i = 0; i < pList.Count; i++)
        //{
        //    ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
        //    DDL_Province.Items.Add(item);
        //}
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

        //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
        if (userdt.Rows.Count > 0)
        {
            //DDL_department.Text = userdt.Rows[0][2].ToString();
            //DDL_department.Enabled = false;
            //DDL_Area.Items.Add(new ListItem(userdt.Rows[0][1].ToString(), userdt.Rows[0][0].ToString()));
            //DDL_Area.Text = userdt.Rows[0][0].ToString();
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
            if(deptname != "")
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

    public void GetDealerData()
    {
        string Par = "";

        DealerID = txt_DealerID.Text.Trim();
        DealerName = txt_DealerName.Text.Trim();
        deptname = DDL_department.SelectedValue.Trim();
        AreaID = DDL_Area.SelectedValue.Trim();
        if (AreaID == "0")
        {
            AreaID = hfAreas.Value;
        }
        Provice = DDL_Province.SelectedValue.Trim();
        City = DDL_city.SelectedValue.Trim();
        if (DealerID != "")
            Par += " and DealerID ='" + DealerID + "' ";
        if (DealerName != "")
            Par += " and DealerName  like '%" + DealerName + "%' ";
        if (deptname != "" && deptname != "0")
            Par += " and department='" + deptname + "'";
        if (AreaID != "" && AreaID != "0")
        {
            //Par += " and dealerinfo.AreaID =" + AreaID + " ";
            Par += " and dealerinfo.AreaID in (" + AreaID + ")";
        }
        if (Provice != "" && Provice != "0")
            Par += " and ProvinceID =" + Provice + " ";
        if (City != "" && City != "0")
            Par += " and CityID =" + City + " ";

        DataTable dt = new LN.BLL.DealerInfo().GetList(Par).Tables[0];
        int num = 1;
        dt.Columns.Add("Nid");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Nid"] = num;
                num++;
            }
        }
        this.GridView1.DataSource = dt;
        GridView1.DataBind();
    }  

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#dedede'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        GetDealerData();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetDealerData();
    }
}

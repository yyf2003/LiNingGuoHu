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
public partial class WebUI_Distribution_DisList : System.Web.UI.Page
{
    string UserID = string.Empty, deptname=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
                string  UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        if (deptdt.Rows.Count > 0)
        {
            deptname = deptdt.Rows[0]["department"].ToString();
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

        //加载区域
        IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strarea);
        foreach (LN.Model.AreaData model in arealist)
        {
            ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
            DDL_Area.Items.Add(item);
        }

        // 根据登录人ID得到所属省区 并加载相应市

        //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
        if (userdt.Rows.Count > 0)
        {
            //DDL_department.Text = userdt.Rows[0][2].ToString();
            //DDL_department.Enabled = false;
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
        else if (deptname != "")
        {
            DDL_department.Text = deptname;
            DDL_department.Enabled = false;
        }
    }
}

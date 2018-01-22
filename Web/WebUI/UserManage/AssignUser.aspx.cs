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

public partial class WebUI_UserManage_AssignUser : System.Web.UI.Page
{
    public string UserName = string.Empty;
    public string UID = string.Empty;
    public string RoleData = string.Empty;
    public string NoData = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.QueryString["UserID"] != null)
        {
            UID = this.Request.QueryString["UserID"].ToString();
            UserName = new LN.BLL.UserInfo().GetModel(int.Parse(UID)).Username;
            this.DataBind();
            GetUserRole();
            GetUserData();
        }
        else
        {
            Response.Redirect("../../Login.aspx");
        } 
    }
    public void GetUserRole()
    {
        IList<LN.Model.UserTypeData> typelist = new LN.BLL.UserTypeData().GetList("");
        if (typelist.Count > 0)
        {
            foreach (LN.Model.UserTypeData model in typelist)
            {
                RoleData += "<input id=\"Checkbox1\" type=\"checkbox\" value=\"" + model.UserTypeID + "\"  />" + model.Usertype + "";
            }
        }
        this.DataBind();
    }
    public void GetUserData()
    {
        UID = this.Request.QueryString["UserID"].ToString();

        DataTable dt = new LN.BLL.AssignUser().GetList("UpmanagerID = " + UID + "").Tables[0];
        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add("CodeID");
            int num = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["CodeID"] = num;
                num++;
            }
            this.GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            NoData = "<div style='float:left; text-align:center; width:900px;'  align='center'>暂时还没有下属人员</div>";
            this.DataBind();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        GetUserData();
    }
    /// <summary>
    /// 得到用户名字
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    public string GetUserName(string UserID)
    {
        return new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Username;
    }
    /// <summary>
    /// 加载用户角色
    /// </summary>
    /// <param name="RoleID"></param>
    /// <returns></returns>
    public string GetUserRole(string RoleID)
    {
        return new LN.BLL.UserTypeData().GetModel(int.Parse(RoleID)).Usertype;
    }
}

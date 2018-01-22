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
public partial class WebUI_UserManage_AddAssignUser : System.Web.UI.Page
{
    public string UserName = string.Empty;
    public string RoleData = string.Empty;
    public string UID = string.Empty;
    public string Role = string.Empty;
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
        IList<LN.Model.UserTypeData> list = new LN.BLL.UserTypeData().GetList("");
        if (list.Count > 0)
        {
            foreach (LN.Model.UserTypeData model in list)
            {
                RoleData += "<input id=\"Checkbox1\" type=\"checkbox\" value=\"" + model.UserTypeID + "\"  />" + model.Usertype + "";
            }
        }
        this.DataBind();
    }
    public void GetUserData()
    {
        UID = this.Request.QueryString["UserID"].ToString();
        string Ary = "";
        if (this.Request.QueryString["Role"] != null)
        {
            Role = this.Request.QueryString["Role"].ToString();
            Ary = "usertype in (" + Role + ")";
        }
        if (this.Request.QueryString["UserName"] != null)
        {
            UserName = this.Request.QueryString["UserName"].ToString();
            if (Ary == "")
                Ary = "Username ='" + UserName + "' ";
            else
                Ary += " and Username ='" + UserName + "' ";
        }
        if (Ary != "")
        {
            DataTable dt = new LN.BLL.UserInfo().GetList(Ary).Tables[0];
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
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        GetUserData();
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

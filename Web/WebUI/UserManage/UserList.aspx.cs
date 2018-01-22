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

public partial class WebUI_UserManage_UserList : System.Web.UI.Page
{
    public string StrRole = string.Empty;
    public string StrUserName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUserType();
            GetUserData();
        }
    }
    public void LoadUserType()
    {
        IList<LN.Model.UserTypeData> typelist = new LN.BLL.UserTypeData().GetList("");
        if (typelist.Count > 0)
        {
            foreach (LN.Model.UserTypeData model in typelist)
            {
                ListItem lt = new ListItem(model.Usertype.ToString(), model.UserTypeID.ToString());
                this.ddl_UserType.Items.Add(lt);
            }
        }
    }
    public void GetUserData()
    {
        string Ary = "";
        if (this.Request.QueryString["Role"] != null)
        {
            StrRole = this.Request.QueryString["Role"].ToString();
            Ary = "Usertype=" + StrRole + "";
        }
        if (this.Request.QueryString["UserName"] != null)
        {
            StrUserName = this.Request.QueryString["UserName"].ToString();
            if (Ary == "")

                Ary = "Username ='" + StrUserName + "'";
            else
                Ary += " and Username ='" + StrUserName + "'";
        }

        if (Ary == "") 
            Ary = "UserState =1 ";
        else
            Ary += " and  UserState =1 ";


        DataTable dt = new LN.BLL.UserInfo().GetList(Ary).Tables[0];
        if (dt.Rows.Count > 0)
        {
            this.GridView1.DataSource = dt;
            GridView1.DataBind();
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

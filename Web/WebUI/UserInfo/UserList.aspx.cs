using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Linq;

public partial class WebUI_UserInfo_UserList : System.Web.UI.Page
{
    public string NoData = string.Empty;
    public string UserName = string.Empty;
    public string Sex = string.Empty;
    public string UserType = string.Empty;
    public string Station = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        
        bool flag = false;
        if (Request.QueryString["username"] != null)
        {
            UserName = Request.QueryString["username"];
            flag = true;
        }
        if (Request.QueryString["sex"] != null)
        {
            Sex = Request.QueryString["sex"];
            flag = true;
        }
        if (Request.QueryString["usertype"] != null)
        {
            UserType = Request.QueryString["usertype"];
            flag = true;
        }
        if (Request.QueryString["userstate"] != null)
        {
            Station = Request.QueryString["userstate"];
            flag = true;
        }
        if (!IsPostBack)
        {
            
            LoadUserType();
            txt_UserName.Text = UserName;
            ddl_Sex.SelectedValue = Sex;
            ddl_UserType.SelectedValue = UserType;
            ddl_UserStation.SelectedValue = Station;
            if (flag)
            {
                SearchData();
            }
        }
    }
    public void LoadUserType()
    {
        IList<LN.Model.UserTypeData> typelist = new LN.BLL.UserTypeData().GetList("TypeState=1");
        foreach (LN.Model.UserTypeData model in typelist)
        {
            ListItem lt = new ListItem(model.Usertype, model.UserTypeID.ToString());
            this.ddl_UserType.Items.Add(lt);
        }
    }

    protected void GV_UserList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandArgument.ToString();
        //if (e.CommandName == "del")
        //{
            
        //    int DoID = int.Parse(key);
        //    new LN.BLL.UserInfo().Delete(DoID);
        //    SearchData();
        //}
        if (e.CommandName == "SetStation")
        {
            
            int DoID = int.Parse(key);
            new LN.BLL.UserInfo().SetUserState(DoID);
            SearchData();
        }
        if (e.CommandName == "mdf")
        {
            //string username = this.Request.Form["txt_UserName"];
            //string sex = this.Request.Form["ddl_Sex"];
            //string usertype = this.Request.Form["ddl_UserType"];
            //string userstate = this.Request.Form["ddl_UserStation"];
            string username = txt_UserName.Text;
            string sex = ddl_Sex.SelectedValue;
            string usertype = ddl_UserType.SelectedValue;
            string userstate = ddl_UserStation.SelectedValue;
            string searchkey = string.Format("&username={0}&sex={1}&usertype={2}&userstate={3}", username, sex, usertype, userstate);
            Response.Redirect(string.Format("ChangeUserInfo.aspx?ID={0}{1}", key, searchkey), false);
        }
    }


    LN.BLL.UserInAreaBLL userInAreaBll = new LN.BLL.UserInAreaBLL();
    LN.BLL.DepartMentInfo departmentBll = new LN.BLL.DepartMentInfo();
    LN.BLL.UserTypeData userTypeBll = new LN.BLL.UserTypeData();
    protected void GV_UserList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#dedede'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");

            DataRowView item = (DataRowView)e.Row.DataItem;
            if (item != null)
            {
                StringBuilder sb = new StringBuilder();
                Label departLab = (Label)e.Row.FindControl("labDepart");
                string userId = item["ID"].ToString();
                string role = item["Usertype"].ToString();
                LN.Model.UserTypeData typeModel = userTypeBll.GetModel(int.Parse(role));
                if (typeModel != null)
                {
                    ((Label)e.Row.FindControl("labRole")).Text = typeModel.Usertype;
                }
                if (role == "2")
                {
                    //区域VM经理
                    DataSet ds = departmentBll.GetList(string.Format("Department_Master='{0}'", item["Username"].ToString()));
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {

                        //sb.Append(ds.Tables[0].Rows[0]["department"].ToString());
                        StringBuilder departments = new StringBuilder();
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            departments.Append(dr["department"]+"/");

                        }
                        sb.Append(departments.ToString().TrimEnd('/'));
                    }
                }
                else
                { 
                    //省区VM
                    DataTable dt = userInAreaBll.GetAreaByUserId(userId);
                    if (dt.Rows.Count > 0)
                    {
                        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (!dic.Keys.Contains(dr["DepartMent"].ToString()))
                            {
                                List<string> list = new List<string>();
                                list.Add(dr["AreaName"].ToString());
                                dic.Add(dr["DepartMent"].ToString(), list);
                            }
                            else
                            {
                                List<string> list = dic[dr["DepartMent"].ToString()];
                                list.Add(dr["AreaName"].ToString());
                                dic[dr["DepartMent"].ToString()] = list;
                            }
                        }
                        if (dic.Any())
                        {
                            
                            sb.Append("<table style='width:200px;'>");
                            dic.ToList().ForEach(s =>
                            {
                                sb.AppendFormat("<tr><td style='width: 50px;text-align: left;padding-left:10px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;'>{0}</td>", s.Key.ToString());
                                sb.Append("<td style='text-align: left;vertical-align:top;padding:5px;border:0px; border-bottom:1px solid #ccc;'>");
                                List<string> lines = s.Value;
                                if (lines.Any())
                                {
                                    string check = string.Empty;
                                    lines.ForEach(p =>
                                    {
                                        sb.AppendFormat("{0},", p);
                                    });
                                }
                                sb.Append("</td></tr>");
                            });
                            sb.Append("</table>");
                        }
                    }
                }
                departLab.Text = sb.ToString();
            }

        }
    }
    /// <summary>
    /// 得到用户角色类型
    /// </summary>
    /// <param name="TypeID"></param>
    /// <returns></returns>
    //public string GetUserType(string TypeID)
    //{
    //    return new LN.BLL.UserTypeData().GetModel(int.Parse(TypeID)).Usertype;
    //}

    protected void GV_UserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GV_UserList.PageIndex = e.NewPageIndex;
        SearchData();

    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        SearchData();
    }



    public void SearchData()
    {
        string username = txt_UserName.Text;
        string sex = ddl_Sex.SelectedValue;
        string usertype = ddl_UserType.SelectedValue;
        string userstate = ddl_UserStation.SelectedValue;
        string Par = " 1=1 ";
        if (username != "")
        {
            UserName = username.ToString();
            Par = " Username like '%" + UserName + "%'";
        }
        if (sex != "0")
        {
            Sex = sex.ToString();
            Par += " and  Sex ='" + Sex + "'";
        }
        if (usertype != "0")
        {
            UserType = usertype.ToString();
            Par += " and  UserType ='" + UserType + "'";
        }
        if (userstate != "")
        {
            Station = userstate.ToString();
            Par += " and  UserState =" + Station + "";
        }
        DataTable dtOpenWin = new LN.BLL.UserInfo().GetList(Par).Tables[0];
        dtOpenWin.Columns.Add("Rid");
        int id = 1;
        if (dtOpenWin.Rows.Count > 0)
        {
            for (int i = 0; i < dtOpenWin.Rows.Count; i++)
            {
                dtOpenWin.Rows[i]["Rid"] = id.ToString();
                id++;
            }
        }
        this.GV_UserList.DataSource = dtOpenWin;
        GV_UserList.DataBind();
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder userIds = new System.Text.StringBuilder();
        foreach (GridViewRow item in GV_UserList.Rows)
        {
            if (item.RowType == DataControlRowType.DataRow)
            {
                CheckBox cb = (CheckBox)item.FindControl("cbOne");
                if (cb.Checked)
                {
                    userIds.Append(((HiddenField)item.FindControl("hfUserId")).Value+",");
                }
            }
        }
        if (userIds.Length > 0)
        {
            new LN.BLL.UserInfo().Delete(string.Format(" UserID in ({0})", userIds.ToString().TrimEnd(',')));
            SearchData();
        }
    }
}

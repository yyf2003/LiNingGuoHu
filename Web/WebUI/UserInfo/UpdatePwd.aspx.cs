using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class WebUI_UserInfo_UpdatePwd : System.Web.UI.Page
{
    protected string UserID = String.Empty;
    protected string LoginUserID = String.Empty;
    protected string LoginUserAreaID = String.Empty;
    protected string UserAreaID = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        LoginUserID = Request.Cookies["UserID"].Value;
        LoginUserAreaID = new LN.BLL.UserInfo().GetModel(Int32.Parse(LoginUserID)).Userofarea.ToString();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string UserName = txt_UserName.Text.Trim();
        DataTable dt  = new LN.BLL.UserInfo().GetList(string.Format(" UserName = '{0}' ", UserName)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            UserID = dt.Rows[0][1].ToString();
            UserAreaID = dt.Rows[0][12].ToString();
        }


        DataSet ds = null;
        if (LoginUserAreaID == "0" && LoginUserID == "1")
        {
            ds = new LN.BLL.UserInfo().GetList(string.Format(" UserName LIKE '%{0}%' ", UserName));
        }
        else if (LoginUserAreaID == "0" && LoginUserID != "1")
            ds = new LN.BLL.UserInfo().GetList(string.Format(" UserID<>1 AND UserName LIKE '%{0}%' ", UserName));
        else if( LoginUserAreaID.Trim() == UserAreaID.Trim())
            ds = new LN.BLL.UserInfo().GetList(string.Format(" UserID<>1 AND UserName LIKE '%{0}%' ", UserName));

        

        if (ds != null)
        {
            RepUserList.DataSource = ds.Tables[0];
            RepUserList.DataBind();
        }
        else
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert('您所在的区域与被修改者区域不一致，不可恢复密码！');window.location='./UpdatePwd.aspx';</script>"); 

    }
}

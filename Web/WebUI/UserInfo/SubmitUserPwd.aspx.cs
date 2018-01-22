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

public partial class WebUI_UserInfo_SubmitUserPwd : System.Web.UI.Page
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
        UserID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].Trim();
        LoginUserAreaID = new LN.BLL.UserInfo().GetModel(Int32.Parse(LoginUserID)).Userofarea.ToString();
        UserAreaID = new LN.BLL.UserInfo().GetModel(Int32.Parse(UserID)).Userofarea.ToString();
        if (LoginUserAreaID=="0")
        {
            UpdatePassWord();
        }
        else if (LoginUserAreaID.Trim() == UserAreaID.Trim())
        {
            UpdatePassWord();
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert('您所在的区域与被修改者区域不一致，不可恢复密码！');window.location='./UpdatePwd.aspx';</script>"); 
        }
        
    }

    private void UpdatePassWord()
    {
        try
        {
            new LN.BLL.UserInfo().ChangeUserPwd(Int32.Parse(UserID), "000000");
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert('恢复成功！');window.location='./UpdatePwd.aspx';</script>"); 
        }
        catch
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert('恢复失败！');window.location='./UpdatePwd.aspx';</script>"); 
        }
    }
}

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

public partial class WebUI_POPAddition_AddOnePOPAddition : System.Web.UI.Page
{
    protected string UserID = string.Empty, Username = string.Empty;//得到登录人的ID
    protected string POPID = string.Empty,prolineID=string.Empty;
    protected string POPSeat = string.Empty;
    protected string Shopname = string.Empty;
    protected string Shopid = string.Empty;
    protected string POPinfoID = string.Empty;
    string usertype = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.Cookies["UserID"] != null)
        {
            UserID = this.Request.Cookies["UserID"].Value;
            Username = Server.UrlDecode(this.Request.Cookies["UserName"].Value);
            if (this.Request.QueryString["Shopid"] != null && this.Request.QueryString["POPID"] != null)
            {
                POPinfoID = this.Request.QueryString["POPinfoID"].ToString();
                POPID = this.Request.QueryString["POPID"].ToString();
                Shopid = this.Request.QueryString["Shopid"].ToString();
                Shopname = new LN.BLL.ShopInfo().GetModel(int.Parse(Shopid)).Shopname;
                prolineID = Request.QueryString["prolineid"].ToString() == "" ? "0" : Request.QueryString["prolineid"].ToString();
            }



            usertype = new LN.BLL.UserInfo().GetTypeByName(Username);//得到登录人的角色
        }
        else
        {
            Response.Redirect("../../login.aspx");
        }
    }
    protected void btn_popaddition_Click(object sender, EventArgs e)
    {
        LN.Model.POPAddition model = new LN.Model.POPAddition();
        model.POPID = new LN.BLL.POPLaunch().GetNewestModel().POPID;
        model.Shopid = int.Parse(Shopid);
        model.POPinfoID = int.Parse(POPinfoID);
        model.AddUserID = int.Parse(UserID);
        model.ProLineID = int.Parse(prolineID);
        string picurl = "";
        if (this.FileUpload1.HasFile)
        {
            string filename = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
            string ex = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
            if (CheckFiles(ex))
            {
                this.FileUpload1.PostedFile.SaveAs(Server.MapPath("../../UpLoad/PopAddition/") + filename + ex);
                picurl = "UpLoad/PopAddition/" + filename + ex;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>alert('文件格式不正确，请选择正确的格式文件：gif, jpg,jpeg, png,bmp！');window.location=window.location;</script>");
                return;
            }
        }
        model.PhotoUrl = picurl;
        model.Addtype = DDL_addType.Text;
        model.AddObject = usertype;
        model.Des = this.txt_des.Text.Replace("\r\n", "<br>");
        new LN.BLL.POPAddition().Add(model);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>alert('提交增补成功！');parent.window.location='AddPOPAddition.aspx?Shopid=" + Shopid + "&POPID=" + POPID + "'</script>");
    }
    /// <summary>
    /// 判断文件类型
    /// </summary>
    /// <returns></returns>
    private bool CheckFiles(string ex)
    {
        string[] files ={ ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
        for (int i = 0; i < files.Length; i++)
        {
            if (ex == files[i].ToString())
            {
                return true;
            }
        }
        return false;
    }
}

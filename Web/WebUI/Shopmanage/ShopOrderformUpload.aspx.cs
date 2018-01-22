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
using System.Threading;

public partial class WebUI_Shopmanage_ShopOrderformUpload : System.Web.UI.Page
{
    string POPID = "";
    string ShopID = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Click(object sender, EventArgs e)
    {
        LN.Model.imageToPOP model = new LN.Model.imageToPOP();
        model.ID = int.Parse(Request.QueryString["id"].Trim());
        string strBig = "", strSmall = "";
        
        if (Request.Files[0].FileName == "" || UploadFile.IsImage(Request.Files[0].FileName) == false)
        {
            Response.Write("<script>alert('请选择图片')</script>");
            return;
        }
        UploadFile.FileSave("../../UpLoad/POPImages_New/", Request.Files[0], 80, 90, ref strBig, ref strSmall);
        model.NewImageUrl_Small = strSmall;
        model.NewImageUrl_Big = strBig;
        if (new LN.BLL.imageToPOP().UpdateImage(model, 1) > 0)
        {
            Response.Write("<script>alert('上传成功');location.href='ShopOrderformDetail.aspx?POPID=" + Request.QueryString["POPID"] + "&ShopID=" + Request.QueryString["ShopID"] + "'</script>");
            //Response.Write("<script>alert('上传成功');</script>");
        }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        LN.Model.imageToPOP model = new LN.Model.imageToPOP();
        model.ID = int.Parse(Request.QueryString["id"].Trim());
        string strBig = "", strSmall = "";

        if (Request.Files[1].FileName == "" || UploadFile.IsImage(Request.Files[1].FileName) == false)
        {
            Response.Write("<script>alert('请选择图片')</script>");
            return;
        }
        UploadFile.FileSave("../../UpLoad/POPImages_New/", Request.Files[1], 80, 90, ref strBig, ref strSmall);
        model.OldImageUrl_Small = strSmall;
        model.OldImageUrl_Big = strBig;
        if (new LN.BLL.imageToPOP().UpdateImage(model, 0) > 0)
        {
            //Response.Write("<script>alert('上传成功');</script>");
            Response.Write("<script>alert('上传成功');location.href='ShopOrderformDetail.aspx?POPID=" + Request.QueryString["POPID"] + "&ShopID=" + Request.QueryString["ShopID"] + "'</script>");

        }
    }
}

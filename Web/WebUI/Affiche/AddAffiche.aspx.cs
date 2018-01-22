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

public partial class WebUI_Affiche_AddAffiche : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (this.Request.Cookies["UserID"] == null)
        {
            Response.Redirect("../../Login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string affichetitle = this.Request.Form["txtTypeName"].ToString();
        if (affichetitle.Length > 25)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('标题不能超过２５个字！');</script>");
            return;
        }

        string typeid = this.Request.Form["categoryId"].ToString();
        string affichemain = this.FCKeditor1.Value;
        string UserID = this.Request.Cookies["UserID"].Value;
        string FullFilePath = String.Empty;
        int result = UpLoad(ref FullFilePath);
        try
        {
            LN.Model.AfficheData model = new LN.Model.AfficheData();
            model.UserID = UserID;
            model.Title = affichetitle;
            model.Main = affichemain;
            model.TypeID = typeid;
            model.FileUrl = FullFilePath;
            LN.BLL.AfficheData nba = new LN.BLL.AfficheData();
            if (nba.Add(model) > 0)
            {
                this.FCKeditor1.Value = "";
                this.txtTypeName.Text = "";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>alert('发表成功！');window.location='ManageAffiche.aspx'</script>");
            }

        }
        catch (Exception exx)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>alert('发表失败，异常在:" + exx.Message + "！');window.location='ManageAffiche.aspx'</script>");
        }

    }


    /// <summary>
    /// 多文件上传
    /// </summary>
    /// <param name="f">上传文件控件</param>
    /// <param name="saveAsName">获得文件上传的路径</param>
    /// <param name="num">文件名的最后数字</param>
    /// <returns>返回操作是否成功</returns>
    private int UpLoad(ref string saveAsName)
    {
        int _return = 0;
        HttpFileCollection Files = HttpContext.Current.Request.Files;
        for (int i = 0; i < Files.Count; i++)
        {
            HttpPostedFile postedFile = Files[i];
            string fileAllName = postedFile.FileName;
            if (postedFile.ContentLength > 0)
            {
                string Extension = System.IO.Path.GetExtension(fileAllName).ToLower();
                if (Extension == ".gif" || Extension == ".jpg" || Extension == ".jpeg" || Extension == ".bmp" || Extension == ".png" || Extension == ".ppt" || Extension == ".doc" || Extension == ".rar" || Extension == ".zip" || Extension == ".pdf" || Extension == ".word" || Extension == ".xls" || Extension == ".txt")
                {
                    string FileName = System.IO.Path.GetFileNameWithoutExtension(postedFile.FileName) + DateTime.Now.ToString("yyyyMMdd");
                    string saveName = System.IO.Path.Combine(Server.MapPath("UserFiles/"), FileName + Extension);
                    try
                    {
                        postedFile.SaveAs(saveName);
                        saveAsName += "UserFiles/" + FileName + Extension + ";";
                        _return = 1;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message, ex);
                    }
                }
            }
        }
        saveAsName = saveAsName.TrimEnd(new char[] { ';' });
        return _return;
    }

}

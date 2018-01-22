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

public partial class WebUI_Affiche_ModifyAffiche : System.Web.UI.Page
{
    public string AfficheID = string.Empty;
    public string AfficheTitle = string.Empty;
    public string AfficheMain = string.Empty;
    public string AfficheTypeID = string.Empty;
    public string FileUrl = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (this.Request.QueryString["ID"] != null)
        {
            if (this.Request.Cookies["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    GetData();
                    ddltype.SelectedValue = AfficheTypeID;
                }
            }
            else
            {
                Response.Redirect("../../Login.aspx");
            }
        }
        else
        { Response.Redirect("../../Login.aspx"); }

    }



    public void GetData()
    {


        LN.BLL.AfficheData nba = new LN.BLL.AfficheData();
        LN.Model.AfficheData nma = new LN.Model.AfficheData();
        nma = nba.GetModel(Convert.ToInt32(this.Request.QueryString["ID"].ToString()));
        AfficheTitle = nma.Title;
        AfficheMain = nma.Main;
        AfficheTypeID = nma.TypeID;
        FileUrl = nma.FileUrl;
        this.txtTypeName.Text = AfficheTitle;
        this.FCKeditor1.Value = AfficheMain;
        LN.BLL.AfficheType nbtype = new LN.BLL.AfficheType();
        LN.Model.AfficheType model = new LN.Model.AfficheType();
        model = nbtype.GetModel(Convert.ToInt32(this.Request.QueryString["ID"].ToString()));
        this.ddltype.DataSource = nbtype.GetList("IsDel = 0");
        ddltype.DataTextField = "type";
        ddltype.DataValueField = "id";
        this.ddltype.DataBind();
        this.DataBind();
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
                    //string FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + i.ToString();
                    string FileName = System.IO.Path.GetFileNameWithoutExtension(postedFile.FileName); ;
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


    protected void Button1_Click(object sender, EventArgs e)
    {
        string affichetitle = this.Request.Form["txtTypeName"].ToString();
        if (affichetitle.Length > 25)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('标题不能超过２５个字！');</script>");
            return;
        }
        string typeid = this.Request.Form["categoryId"];
        if (typeid != null && typeid != "")
        {
            typeid = typeid.ToString();
        }
        else
        {
            typeid = this.ddltype.SelectedValue;
        }
        string affichemain = this.FCKeditor1.Value;
        string UserID = this.Request.Cookies["UserID"].Value;
        string FullFilePath = String.Empty;
        int result = UpLoad(ref FullFilePath);
        LN.Model.AfficheData nma = new LN.Model.AfficheData();
        LN.BLL.AfficheData nba = new LN.BLL.AfficheData(); 
        nma.Title = affichetitle;
        nma.Main = affichemain;
        nma.TypeID = typeid;
        nma.ID = Convert.ToInt32(this.Request.QueryString["ID"].ToString());
        if (result > 0)
        {
            nma.FileUrl = FullFilePath;
        }
        else
        {
            nma.FileUrl = new LN.BLL.AfficheData().GetModel(int.Parse(this.Request.QueryString["ID"].ToString())).FileUrl;
        }
        nba.Update(nma);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>window.location='ManageAffiche.aspx';</script>");
    }
}

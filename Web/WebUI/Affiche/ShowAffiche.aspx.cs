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

public partial class WebUI_Affiche_ShowAffiche : System.Web.UI.Page
{
    public string afficheid = string.Empty;
    public string AfficheTitle = string.Empty;
    public string AfficheMain = string.Empty;
    public string AfficheUser = string.Empty;
    public string AfficheTime = string.Empty;
    public string AfficheFile = string.Empty;
    public string AfficheFileEx = string.Empty;
    public string Maintxt = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Request.QueryString["ID"] != null)
            {
                new LN.BLL.AfficheData().UpdateClick(int.Parse(Request.QueryString["ID"]));
                GetData();
            }
            else
            {
                Response.Redirect("../../Login.aspx");
            }
        }
    }


    public void GetData()
    {
        LN.BLL.AfficheData nba = new LN.BLL.AfficheData();
        LN.Model.AfficheData nma = new LN.Model.AfficheData();
        nma = nba.GetModel(Convert.ToInt32(this.Request.QueryString["ID"].ToString()));
        AfficheTitle = nma.Title;
        AfficheMain = nma.Main.ToString();
        this.Literal1.Text = AfficheMain;
        AfficheTime = nma.Time.ToString().Length > 10 ? nma.Time.ToString().Substring(0, 10) : nma.Time.ToString();
        AfficheUser = nma.UserID;
        AfficheFile = nma.FileUrl;

        if (AfficheFile != "")
        {
            string[] aa = AfficheFile.Split(';');
            if (aa.Length > 0)
            {
                foreach (string dd in aa)
                {
                    Maintxt += "<img src ='" + GetAfficheImg(System.IO.Path.GetExtension(dd).ToLower()) + "'  align='absmiddle'/>&nbsp;<a href ='" + dd + "' target='_blank' style='color:blue;' >" + System.IO.Path.GetFileNameWithoutExtension(dd).ToString() + "</a>";
                }
            }
            else
            {
                Maintxt = "无附件";
            }
        }
        else
        {
            Maintxt = "无附件";
        }
        this.DataBind();
      
    }

    public string GetAfficheImg(string ex)
    {
        string url = "";
        if (ex != "")
        {

            if (ex == ".doc")
            {
                return url = "../../images/affiche/word.gif";
            }
            if (ex == ".pdf")
            {
                return url = "../../images/affiche/pdf.gif";
            }
            if (ex == ".ppt")
            {
                return url = "../../images/affiche/ppt.gif";
            }
            if (ex == ".xls")
            {
                return url = "../../images/affiche/xls.gif";
            }
            if (ex == ".rar")
            {
                return url = "../../images/affiche/rar.gif";
            }
            if (ex == ".zip")
            {
                return url = "../../images/affiche/rar.gif";
            }
            if (ex == ".txt")
            {
                return url = "../../images/affiche/txt.gif";
            }
            if (ex == ".jpg" | ex == ".bmp" | ex == ".gif" | ex == ".jpeg" | ex == ".png")
            {
                return url = "../../images/affiche/jpg.gif";
            }
            return url = "../../images/affiche/dll.gif";
        }
        else
        {
            return url;
        }
    }
}

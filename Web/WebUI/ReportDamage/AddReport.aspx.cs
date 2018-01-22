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

public partial class WebUI_ReportDamage_AddReport : System.Web.UI.Page
{

    public string ShopID = string.Empty;
    public string ShopName = string.Empty;
    public string SupplierID = string.Empty;
    public string SupplierName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (this.Request.Cookies["UserName"] == null)
        {
            Response.Redirect("../../login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
    }
    public void GetData()
    {
        string LoginUser = Server.UrlDecode(this.Request.Cookies["UserName"].Value);
        DataTable dtShopInfo = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(LoginUser);
        if (dtShopInfo.Rows.Count > 0)
        {
            ShopID = dtShopInfo.Rows[0]["ShopID"].ToString();
            ShopName = dtShopInfo.Rows[0]["Shopname"].ToString();
            this.Label1.Text = ShopName;
        }
        DataTable dtSupplierAssignRecord = new LN.BLL.SupplierAssignRecord().GetList("AssignShopID =" + int.Parse(ShopID) + "").Tables[0];
        if (dtSupplierAssignRecord.Rows.Count > 0)
        {
            SupplierID = dtSupplierAssignRecord.Rows[0]["SupplierID"].ToString();
            SupplierName = new LN.BLL.SupplierInfo().GetModel(int.Parse(SupplierID)).SupplierName;
            this.Label2.Text = SupplierName;
        }
        this.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string LoginUser = Server.UrlDecode(this.Request.Cookies["UserName"].Value);
        LN.Model.POPReprotDamage model = new LN.Model.POPReprotDamage();
        DataTable dtShopInfo = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(LoginUser);
        if (dtShopInfo.Rows.Count > 0)
        {
            ShopID = dtShopInfo.Rows[0]["ShopID"].ToString();
        }
        DataTable dtSupplierAssignRecord = new LN.BLL.SupplierAssignRecord().GetList("AssignShopID =" + int.Parse(ShopID) + "").Tables[0];
        if (dtSupplierAssignRecord.Rows.Count > 0)
        {
            SupplierID = dtSupplierAssignRecord.Rows[0]["SupplierID"].ToString();
        }
        string UserID = this.Request.Cookies["UserID"].Value;
        string PhotoPath = "";
        string filename = System.DateTime.Now.ToString().Replace("-", "").Replace(":", "").Replace(" ", "");
        string ex = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
        if (CheckFileType(ex))
        {
            this.FileUpload1.PostedFile.SaveAs(Server.MapPath("../../UpLoad/PopPhoto/") + filename + ex);
            PhotoPath = "UpLoad/PopPhoto/" + filename + ex;
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_err", "<script>alert('上传文件格式不正确！');</script>");
            return;
        }
        string ShopDesc = this.txt_ShopDesc.Text;
        model.ShopID = int.Parse(ShopID);
        model.SupplierID = int.Parse(SupplierID);
        model.UpUserID = int.Parse(UserID);
        model.PhotoPath = PhotoPath;
        model.ShopDesc = ShopDesc;
        try
        {
            new LN.BLL.POPReprotDamage().Add(model);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_err", "<script>alert('提交成功！');window.location='UserReportDamageList.aspx';</script>");
        }
        catch (Exception exc)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_err", "<script>alert('异常在：" + exc.Message.ToString() + "');window.location=window.location;</script>");
        } 
    }

    /// <summary>
    /// 判断上传文件类型
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public bool CheckFileType(string ex)
    {
        string[] files ={ ".gif", ".jpeg", ".jpg", ".png", ".bmp" };
        for (int i = 0; i < files.Length; i++)
        {
            if (ex == files[i])
            {
                return true;
            }
        }
        return false;

    }
}

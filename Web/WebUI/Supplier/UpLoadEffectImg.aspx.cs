using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
public partial class WebUI_Supplier_UpLoadEffectImg : System.Web.UI.Page
{
    protected string UserID = String.Empty;         //登录用户编号
    protected string SupplierID = String.Empty;     //供应商ID
    protected string POPID = String.Empty;          //当前POP发起ID
    protected string TypeID = String.Empty;         //该用户在供应商中的权限
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;//得到用户ID
        if (!IsPostBack)
        {
            this.GetSupplierID();
            if (TypeID != "1" && TypeID != "2")
            {
                Response.Redirect("../../Error.aspx?param=12");
                return;
            }
        }

    }

    /// <summary>
    /// 获取指定用户所属的供应商编号和权限
    /// </summary>
    private void GetSupplierID()
    {
        IList<int> s = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (s != null && s.Count > 0)
        {
            HidSupplierID.Value = s[0].ToString();
            TypeID = s[1].ToString();
            lblSupplierName.Text = new LN.BLL.SupplierInfo().GetModel(s[0]).SupplierName;
            HidPOPID.Value = new LN.BLL.POPLaunch().GetLastPOPID();
        }
        else
        {
            Response.Redirect("../../Error.aspx?param=10");
            return;
        }
    }

    /// <summary>
    /// 文件上传
    /// </summary>
    protected void UpLoadImg()
    {
        IList<string> imgURLList = new List<string>();
        List<string> strSqlList = new List<string>();
        HttpFileCollection Files = HttpContext.Current.Request.Files;
        string fpath = Server.MapPath("../../UpLoad/UpLoadEffectImg/" + HidSupplierID.Value);//判断上传的文件夹是否存在 不存在则创建
        if (!Directory.Exists(fpath))
            Directory.CreateDirectory(fpath);
        for (int i = 0; i < Files.Count; i++)
        {
            HttpPostedFile postedFile = Files[i];

            if (postedFile.ContentLength > 0)
            {
                string filename = System.DateTime.Now.Ticks.ToString();
                string fileExname = System.IO.Path.GetExtension(postedFile.FileName);
                string filepath = fpath + "/" + filename + fileExname;
                postedFile.SaveAs(filepath);
                imgURLList.Add(fpath + "/" + filename + fileExname);
            }
        }
        if (imgURLList.Count > 0)
        {
            for (int i = 0; i < imgURLList.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO [UpLoadEffectImg] ");
                sb.Append("([SupplierID]");
                sb.Append(",[POPID]");
                sb.Append(",[ImgURL]");
                sb.Append(",[UserID]");
                sb.Append(",[CreateDate])");
                sb.Append(" VALUES ");
                sb.Append("(" + HidSupplierID.Value);
                sb.Append(",'" + HidPOPID.Value + "'");
                sb.Append(",'" + imgURLList[i] + "'");
                sb.Append("," + UserID);
                sb.Append(",'" + DateTime.Now.ToString() + "')");
                strSqlList.Add(sb.ToString());
            }

            if (strSqlList.Count > 0)
            {
                int result = new LN.BLL.UpLoadEffectImg().Operate(strSqlList);
                if (result > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('上传效果图片成功！！');window.location = window.location;</script>");
                    return;
                }
                else
                {
                    Response.Redirect("../../Error.aspx?param=13");
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请选择安装效果图，以供上传！！');window.location = window.location;</script>");
        }
    }

    protected void btnUpLoad_Click(object sender, EventArgs e)
    {
        UpLoadImg();
    }
}

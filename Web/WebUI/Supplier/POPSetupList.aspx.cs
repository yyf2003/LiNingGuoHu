using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
public partial class WebUI_Supplier_POPSetupList : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //登录用户编号
    protected string TypeID = String.Empty;     //该用户在供应商中的权限
    protected string ShopID = String.Empty;     //店铺编号

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        ShopID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        if (!IsPostBack)
        {
            this.GetSupplierID();
            if (TypeID != "1" && TypeID != "2")
            {
                Response.Redirect("../../Error.aspx?param=12");
                return;
            }
            lblShopName.Text = new LN.BLL.ShopInfo().GetModel(Int32.Parse(ShopID)).Shopname;
            BindPOPByShopID();
        }
    }

    /// <summary>
    /// 获取指定用户所属的供应商编号和权限
    /// </summary>
    /// <param name="userid">用户编号</param>
    private void GetSupplierID()
    {
        IList<int> s = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (s != null && s.Count > 0)
        {
            HidSupplierID.Value = s[0].ToString();
            TypeID = s[1].ToString();
        }
        else
        {
            Response.Redirect("../../Error.aspx?param=10");
            return;
        }
    }

    /// <summary>
    /// 绑定指定供应商的最新活动发起的POP安装列表
    /// </summary>
    private void BindPOPByShopID()
    {
        DataTable dt = new LN.BLL.POPInfo().GetPOPListByShopID(HidSupplierID.Value.Trim(), ShopID);

        if (dt != null && dt.Rows.Count > 0)
        {
            btnUpLoad.Visible = true;
            dt.Columns.Add("href");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["imgURL"].ToString().Trim() == "")
                    dr["href"] = "#";
                else
                    dr["href"] = "javascript:ShowImg(\"30%\",\"30%\",\"700px\",\"50px\",\"500px\",\"[店铺详情]\",\"" + dr["imgURL"].ToString().Trim() + "\")";
            }
            RepPOPList.DataSource = dt;
            RepPOPList.DataBind();
        }
    }

    /// <summary>
    /// 文件上传
    /// </summary>
    public void Uploadfile()
    {
        IList<string> imgURLList = new List<string>();
        List<string> strSqlList = new List<string>();
        HttpFileCollection Files = HttpContext.Current.Request.Files;
        string fpath = Server.MapPath("../../UpLoad/POPSetupImage/" + HidSupplierID.Value);//判断上传的文件夹是否存在 不存在则创建
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
                imgURLList.Add("../../UpLoad/POPSetupImage/" + HidSupplierID.Value + "/" + filename + fileExname);
            }
            else
                imgURLList.Add("");
        }

        if (imgURLList.Count > 0)
        {
            for (int i = 0; i < RepPOPList.Items.Count; i++)
            {
                if (imgURLList[i].Trim() != "")
                {
                    StringBuilder sb = new StringBuilder();
                    Label lblPOPID = RepPOPList.Items[i].FindControl("lblPOPID") as Label;
                    Label lblShopID = RepPOPList.Items[i].FindControl("lblShopID") as Label;
                    Label lblIsUpLoad = RepPOPList.Items[i].FindControl("lblIsUpLoad") as Label;
                    string imageURL = imgURLList[i].ToString().Trim();
                    if (lblIsUpLoad.Text.Trim() == "0")
                    {
                        sb.Append("INSERT INTO [POPSetupImage] ");
                        sb.Append("([i_ShopId]");
                        sb.Append(",[i_SupplierID]");
                        sb.Append(",[i_POPinfoID]");
                        sb.Append(",[i_PhotoUrl]");
                        sb.Append(",[i_OperatorID]");
                        sb.Append(",[i_ExamUserID]");
                        sb.Append(",[i_Score]");
                        sb.Append(",[i_ExamRemarks]");
                        sb.Append(",[i_CreateTime]");
                        sb.Append(",[i_POPID]");
                        sb.Append(",[i_Additional])");
                        sb.Append(" SELECT ");
                        sb.AppendFormat(" {0}", lblShopID.Text.Trim());
                        sb.AppendFormat(",{0}", HidSupplierID.Value.Trim());
                        sb.AppendFormat(",{0}", lblPOPID.Text.Trim());
                        sb.AppendFormat(",'{0}'", imageURL);
                        sb.AppendFormat(",{0}", UserID);
                        sb.AppendFormat(",{0}", "0");
                        sb.AppendFormat(",{0}", "0");
                        sb.AppendFormat(",'{0}'", "");
                        sb.AppendFormat(",'{0}'", DateTime.Now.ToString());
                        sb.AppendFormat(",{0}", "(SELECT TOP 1 [POPID] FROM [POPLaunch] ORDER BY ID DESC)");
                        sb.AppendFormat(",'{0}';", "常规");
                    }
                    else if (lblIsUpLoad.Text.Trim() == "1")
                    {
                        sb.Append("UPDATE [POPSetupImage] SET ");
                        sb.AppendFormat("[i_PhotoUrl] = '{0}'",imageURL);
                        sb.Append(" WHERE [i_POPID]=(SELECT TOP 1 [POPID] FROM [POPLaunch] ORDER BY ID DESC) ");
                        sb.AppendFormat(" AND [i_ShopId] = {0} ", lblShopID.Text.Trim());
                        sb.AppendFormat(" AND [i_SupplierID] = {0} ", HidSupplierID.Value.Trim());
                        sb.AppendFormat(" AND [i_POPinfoID] = {0} ", lblPOPID.Text.Trim());
                    }
                    strSqlList.Add(sb.ToString());

                }

            }
        }
        if (strSqlList.Count > 0)
        {
            int result = new LN.BLL.POPSetupImage().Operate(strSqlList);
            if (result > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('上传POP安装图片成功！！');window.location = window.location;</script>");
                return;
            }
            else
            {
                Response.Redirect("../../Error.aspx?param=13");
            }
        }
    }

    protected void btnUpLoad_Click(object sender, EventArgs e)
    {
        Uploadfile();
    }
}

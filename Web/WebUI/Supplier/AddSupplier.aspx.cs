using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_Supplier_AddSupplier : System.Web.UI.Page
{
    protected string UserID = String.Empty;     //获取用户编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        else
            UserID = Request.Cookies["UserID"].Value;
        if (!IsPostBack)
        {
            BindContacter();
        }
    }

    /// <summary>
    /// 上传营业执照
    /// </summary>
    /// <returns>返回是否成功</returns>
    private string UpLoadLicense()
    {
        string saveAsName = String.Empty;
        string fpath = "../../Upload/License";
        if (this.fudLicensePath.HasFile)
        {
            int _ul = Upload_File.FileSave(fpath, fudLicensePath, ref saveAsName);
            if (_ul <= 0)             
                saveAsName = "-1";    
        }
        return saveAsName;
    }

    /// <summary>
    /// 绑定供应商
    /// </summary>
    private void BindContacter()
    {
        DataTable dt = new LN.BLL.UserInfo().GetList(" Usertype = 6 AND UserState=1 and UserID NOT IN (SELECT UserID FROM SupplierUserManage) ").Tables[0];
        ddlContacter.Items.Add(new ListItem("请选择供应商负责人", "0"));
        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ddlContacter.Items.Add(new ListItem(dr["Username"].ToString(), dr["UserID"].ToString()));
            }
        }
    }

    /// <summary>
    /// 添加供应商信息
    /// </summary>
    /// <returns>返回添加结果</returns>
    private int InsertSupplier(string licensePath)
    {
        string SupplierName = txtSupplierName.Text.Trim();
        string Contacter = ddlContacter.SelectedItem.Text;
        string ContactPhone = txtContactPhone.Text.Trim();
        string ContacterRole = txtContacterRole.Text.Trim();
        string PostCode = txtPostCode.Text.Trim();
        string PostAddress = txtPostAddress.Text.Trim();
        string StaffNum = txtStaffNum.Text.Trim();
        string Remarks = "";
        if (txtRemarks.Text.Trim() != "")
        {
            Remarks = txtRemarks.Text.Replace(" ", "&nbsp;").Replace("\r\n", "<br />");
        }
        LN.Model.SupplierInfo model = new LN.Model.SupplierInfo();
        model.SupplierName = SupplierName;
        model.Contacter = Contacter;
        model.ContactPhone = ContactPhone;
        model.ContacterRole = ContacterRole;
        model.PostCode = PostCode;
        model.PostAddress = PostAddress;
        model.SupplierState = 1;
        model.StaffNum = Int32.Parse(StaffNum);
        model.LicensePath = licensePath;
        model.Remarks = Remarks;
        model.CreateDate = DateTime.Now;

        int result = new LN.BLL.SupplierInfo().Add(model);

        return result;
    }

    /// <summary>
    /// 添加供应商信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string licensePath = UpLoadLicense();
        if (licensePath != "-1")
        {
            int AddResult = InsertSupplier(licensePath);
            if (AddResult > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('添加成功！！');window.location.href = './SupplierList.aspx';</script>");
                return;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('添加失败，该供应商已经存在！！');window.location=window.location;</script>");
                return;
            }
            
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script language='javascript'>alert('上传图片发生异常！！');</script>");
            return;
        }
    }
}

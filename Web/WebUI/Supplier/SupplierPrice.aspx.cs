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

public partial class WebUI_Supplier_SupplierPrice : System.Web.UI.Page
{
    protected string UserID = String.Empty;         //登录用户编号
    protected string SupplierID = String.Empty;     //供应商ID
    protected string SupplierName = String.Empty;   //供应商名称

    protected string Contacter = String.Empty;      //联系人

    protected string ContactPhone = String.Empty;   //联系电话
    protected string ContacterRole = String.Empty;  //联系人职位

    protected int SupplierState = 0;                //供应商状态

    protected string PostCode = String.Empty;       //邮政编码
    protected string PostAddress = String.Empty;    //邮政地址
    protected string Remarks = String.Empty;        //备注
    protected DateTime CreateDate = DateTime.Now;   //添加时间

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;//得到用户ID
        SupplierID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        //SupplierID = "1";
        //UserID = "1";
        if (!IsPostBack)
        {
            ShowSupplierInfo(Int32.Parse(SupplierID));
        }
    }

    /// <summary>
    /// 显示指定供应商详情

    /// </summary>
    /// <param name="sid">供应商ID</param>
    private void ShowSupplierInfo(int sid)
    {
        LN.Model.SupplierInfo model = new LN.BLL.SupplierInfo().GetModel(sid);
        if (model != null)
        {
            SupplierName = model.SupplierName;   //供应商名称

            Contacter = model.Contacter;         //联系人

            ContactPhone = model.ContactPhone;   //联系电话
            ContacterRole = model.ContacterRole; //联系人职位

            SupplierState = model.SupplierState; //供应商状态

            PostCode = model.PostCode;           //邮政编码
            PostAddress = model.PostAddress;     //邮政地址
            Remarks = model.Remarks;             //备注
            CreateDate = model.CreateDate;       //添加时间
        }
    }
}

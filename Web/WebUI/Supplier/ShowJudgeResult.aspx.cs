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

public partial class WebUI_Supplier_ShowJudgeResult : System.Web.UI.Page
{
    protected string POPID = String.Empty;     //发起的POP编号
    protected string SupplierID = String.Empty;     //供应商编号
    protected string UserID = String.Empty;     //登录用户编号
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
        SupplierID = Request.QueryString["sid"] == null ? "0" : Request.QueryString["sid"].ToString();
        POPID = Request.QueryString["popid"] == null ? "0" : Request.QueryString["popid"].ToString();
        if (!IsPostBack)
        {
            lblShopName.Text = new LN.BLL.ShopInfo().GetModel(Int32.Parse(ShopID)).Shopname;
            BindPOPByShopID();
            GetStateModel();
        }
    }

    /// <summary>
    /// 绑定指定供应商的最新活动发起的POP安装列表
    /// </summary>
    private void BindPOPByShopID()
    {
        DataTable dt = new LN.BLL.POPInfo().GetPOPJudgeListByShopID(POPID, SupplierID, ShopID);

        if (dt != null && dt.Rows.Count > 0)
        {
            dt.Columns.Add("href");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PhotoUrl"].ToString().Trim() == "")
                    dr["href"] = "#";
                else
                    dr["href"] = "javascript:ShowImg(\"30%\",\"30%\",\"700px\",\"50px\",\"500px\",\"[图片详情]\",\"" + dr["PhotoUrl"].ToString().Trim() + "\")";
            }
            RepPOPList.DataSource = dt;
            RepPOPList.DataBind();
        }
    }

    /// <summary>
    /// 获取审核明细
    /// </summary>
    private void GetStateModel()
    {
        LN.Model.POPSetupImage model = new LN.BLL.POPSetupImage().GetModel(Int32.Parse(ShopID), Int32.Parse(SupplierID), POPID);
        if (model != null)
        {
            lblScore.Text = model.i_Score == 0 ? "无" : model.i_Score.ToString();
            txt_fk.Text = model.i_ExamRemarks;
            lblUserName.Text = model.i_ExamUserID == 0 ? "无" : new LN.BLL.UserInfo().GetModel(model.i_ExamUserID).Username;
        }
    }
}

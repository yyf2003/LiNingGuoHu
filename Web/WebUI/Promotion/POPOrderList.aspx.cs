using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Common;
using LN.BLL;

public partial class WebUI_Promotion_POPOrderList : System.Web.UI.Page
{
    int pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            pid = int.Parse(Request.QueryString["id"].ToString());
        }
        if (!IsPostBack)
        {
            BindPromotionData();
            BindData();
        }
    }

    void BindPromotionData()
    {
        Promotion promotionBll = new Promotion();
        LN.Model.Promotion model = promotionBll.GetModel(pid);
        if (model != null)
        {
           
            labPromotionId.Text = model.PromotionId;
            labTitle.Text = model.PromotionName;
            labStartDate.Text = model.BeginDate != null ? DateTime.Parse(model.BeginDate.ToString()).ToShortDateString() : "";
            labEndDate.Text = model.EndDate != null ? DateTime.Parse(model.EndDate.ToString()).ToShortDateString() : "";
            labRemark.Text = model.PromotionDesc;
            string attach =new Attachment().GetAttachList(string.Format(" ItemTypeId={0} and FileCode='{1}'", pid, ((int)FileCodeEnum.POPPromotionAttach)), "1");
            labAttachment.Text = attach;
        }
    }


    void BindData()
    {
        PromotionPOPOrder orderBll = new PromotionPOPOrder();
        StringBuilder where = new StringBuilder();
        where.Append(" and PromotionId=" + pid);
        if (!string.IsNullOrWhiteSpace(txtPOSCode.Text.Trim()))
        {
            where.AppendFormat(" and PosID like '%{0}%'", txtPOSCode.Text.Trim());
        }
        if (!string.IsNullOrWhiteSpace(txtShopName.Text.Trim()))
        {
            where.AppendFormat(" and Shopname like '%{0}%'", txtShopName.Text.Trim());
        }
        int count=orderBll.GetPageCount(where.ToString());
        AspNetPager1.RecordCount = count;
        btnLoadOut.Enabled = count > 0;
        DataSet ds = orderBll.GetPage(where.ToString(), AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindData();
    }
    

    //ProductLineType productTypeBll = new ProductLineType();
    //ProductLineData productLineBll = new ProductLineData();
    //POPSeat seatBll = new POPSeat();
    ////POPSeat seatBll = new POPSeat();
    //LN.Model.ProductLineType typeModel;
    //LN.Model.ProductLineData lineModel;
    //LN.Model.POPSeat seatModel;
    
    /// <summary>
    /// 导出
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLoadOut_Click(object sender, EventArgs e)
    {
        PromotionPOPOrder orderBll = new PromotionPOPOrder();
        StringBuilder where = new StringBuilder();
        where.Append(" and PromotionId=" + pid);
        if (!string.IsNullOrWhiteSpace(txtPOSCode.Text.Trim()))
        {
            where.AppendFormat(" and PosID like '%{0}%'", txtPOSCode.Text.Trim());
        }
        if (!string.IsNullOrWhiteSpace(txtShopName.Text.Trim()))
        {
            where.AppendFormat(" and Shopname like '%{0}%'", txtShopName.Text.Trim());
        }

        DataSet ds = orderBll.LoadOut(where.ToString());
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        { 
            


           CommonMethod.DownLoadToExcel(ds.Tables[0],"POP推广订单信息");
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void lbCheck_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionShops.aspx?id=" + pid+"&ischeck=1", false);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.UI.WebControls;
using Common;
using LN.BLL;

public partial class WebUI_Promotion_ConfirmOrder : System.Web.UI.Page
{
    int pid;
    int userId;
    PromotionPOPOrder orderBll = new PromotionPOPOrder();
    LN.Model.PromotionPOPOrder orderModel;
    Promotion promotionBll = new Promotion();
    LN.Model.Promotion promotionModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        userId = int.Parse(Request.Cookies["UserID"].Value);
        if (Request.QueryString["id"] != null)
        {
            pid = int.Parse(Request.QueryString["id"].ToString());
        }
        if (!IsPostBack)
        {
            
            promotionModel = promotionBll.GetModel(pid);
            if (promotionModel != null)
            {
                labPromotionId.Text = promotionModel.PromotionId;
                labTitle.Text = promotionModel.PromotionName;

            }
            BindData();
        }
    }

    void BindData()
    {
        StringBuilder where = new StringBuilder();
        where.Append(" and PromotionId=" + pid);
        if (!string.IsNullOrWhiteSpace(txtPOSCode.Text.Trim()))
        {
            where.AppendFormat(" and PosID='{0}'", txtPOSCode.Text.Trim());
        }
        if (!string.IsNullOrWhiteSpace(txtShopName.Text.Trim()))
        {
            where.AppendFormat(" and ShopName like '%{0}%'", txtShopName.Text.Trim());
        }
        switch (rblConfirmState.SelectedValue)
        { 
            case "0"://未确认
                where.Append(" and (IsConfirm is null or IsConfirm=0)");
                BtnConfirm.Enabled = true;
                break;
            case "1"://已确认
                where.Append(" and IsConfirm=1");
                BtnConfirm.Enabled = false;
                break;
        }
        AspNetPager1.RecordCount = orderBll.GetPageCount(where.ToString());
        DataSet ds = orderBll.GetPage(where.ToString(),AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize);
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
    
    /// <summary>
    /// 提交确认
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType== ListItemType.AlternatingItem)
                {
                    
                    HiddenField hfId = (HiddenField)item.FindControl("hfId");
                    int id = int.Parse(hfId.Value != "" ? hfId.Value : "0");
                    orderModel = new LN.Model.PromotionPOPOrder();
                    orderModel.IsConfirm = 1;
                    orderModel.ID = id;
                    orderBll.Update(orderModel);
                }
            }
            promotionModel = new LN.Model.Promotion();
            promotionModel.IsConfirmOrder = 1;
            promotionModel.Id = pid;
            promotionBll.Update(promotionModel);

            ClientScript.RegisterClientScriptBlock(GetType(), "AlertMsg", "AlertMsg('确认成功！');window.location.href='PromotionList.aspx?confirm=1'", true);
            //BindData();
        }
        catch {
            ClientScript.RegisterClientScriptBlock(GetType(), "AlertMsg", "AlertMsg('提交失败，请重新提交！')",true);
        }

    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                string confirm = item["IsConfirm"].ToString();
                //CheckBox cb = (CheckBox)e.Item.FindControl("cbOne");
                //cb.Enabled = !(confirm == "1");
                ((Label)e.Item.FindControl("labState")).Text = confirm == "1" ? "已确认" : "未确认";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionList.aspx?confirm=1",false);
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}
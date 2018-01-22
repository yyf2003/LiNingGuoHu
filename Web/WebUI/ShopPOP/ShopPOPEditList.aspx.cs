using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class WebUI_ShopPOP_ShopPOPEditList : System.Web.UI.Page
{
    protected string shopid = String.Empty; //店铺编号
    protected string UserID = String.Empty; //用户编号
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        if (Request.QueryString["shopid"] != null)
        {
            shopid = Request.QueryString["shopid"].ToString();
        }
        else
        {
            string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
            DataTable shopdt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(UserName);

            if (shopdt.Rows.Count > 0)
            {
                shopid = shopdt.Rows[0]["ShopID"].ToString();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('没有您负责的店铺');</script>");
                Response.End();
            }
        }
        bind();
    }

    private void bind()
    {
        //string strWhere = string.Format(" shopid = {0} ", shopid);
        IList<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetListOrderByShopIDNew(shopid);//审核通过的POP才能进行对应图片的操作

        RepPOPList.DataSource = list;
        RepPOPList.DataBind();

        foreach (RepeaterItem item in RepPOPList.Items)
        {
            HyperLink HLinkUrl = item.FindControl("HLinkUrl") as HyperLink;
            HyperLink HLinkDelete = item.FindControl("HLinkDelete") as HyperLink;
            Label lblIsSubmit = item.FindControl("lblIsSubmit") as Label;
            Label lblID = item.FindControl("lblID") as Label;
            if (lblIsSubmit.Text == "0")
            {
                HLinkUrl.Text = "修改";
                HLinkDelete.Text = "删除";
                HLinkUrl.NavigateUrl = string.Format("./ShopPOPEdit.aspx?id={0}&shopid={1}", lblID.Text.Trim(), shopid);
                HLinkDelete.Attributes.Add("onclick", "return window.confirm('确认删除吗？？')");
                HLinkDelete.NavigateUrl = string.Format("./DeletePOP.aspx?id={0}&shopid={1}", lblID.Text.Trim(), shopid);
            }
            else
            {
                HLinkUrl.Text = "已提交订单不可修改";
                HLinkDelete.Text = "已提交订单不可删除";
            }

        }
    }
}

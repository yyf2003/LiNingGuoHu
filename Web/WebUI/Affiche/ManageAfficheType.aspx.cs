using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_Affiche_ManageAfficheType : System.Web.UI.Page
{
    public string nodata = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (this.Request.Cookies["UserID"] != null)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        else
        {
            Response.Redirect("../../login.aspx");
        }
    }
    public void GetData()
    {
        List<LN.Model.AfficheType> list = new LN.BLL.AfficheType().GetModelList("IsDel = 0");
        if (list.Count > 0)
        {
            this.DataList1.DataSource = list;
            this.DataList1.DataBind();
        }
        else
        {
            nodata = "<div style='font-size:12px;color:#666666;'>对不起没有分类</div>";
            this.DataBind();
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string key = e.CommandArgument.ToString();
            try
            {
                new LN.BLL.AfficheType().Delete(Convert.ToInt32(key));
                GetData();
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('删除失败，异常退出！');</script>");
            }
        }
    }
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        this.DataList1.EditItemIndex = -1;
        GetData();
    }
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        this.DataList1.EditItemIndex = e.Item.ItemIndex;
        GetData();
    }
    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        string typename = ((TextBox)e.Item.FindControl("TextBox1")).Text;
        if (typename == "")
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('类别不能为空！');</script>");
            return;
        }
        string key = e.CommandArgument.ToString();

        int typeid = Convert.ToInt32(key);
        try
        {
            new LN.BLL.AfficheType().Update(typename, typeid);
            this.DataList1.EditItemIndex = -1;
            GetData();
        }
        catch
        {

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('更新失败，异常退出！');</script>");
        }

    }
}

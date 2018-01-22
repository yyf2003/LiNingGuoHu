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

public partial class WebUI_Affiche_ManageAffiche : System.Web.UI.Page
{
    public string nodata = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAfficheTypeData();
            LoadPage(1);
        }
    }
    public void GetAfficheTypeData()
    {

        LN.BLL.AfficheType nbtype = new LN.BLL.AfficheType();
        this.ddltype.DataSource = nbtype.GetList("IsDel = 0");
        ddltype.DataTextField = "type";
        ddltype.DataValueField = "id";
        this.ddltype.DataBind();
    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPage(1);
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string key = e.CommandArgument.ToString();
            try
            {
                new LN.BLL.AfficheData().Delete(Convert.ToInt32(key)); 
                LoadPage(1);
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "erro", "<script>alert('删除失败，异常退出！');</script>");
                
            }
        }
        if (e.CommandName == "setscroll")
        {
            string key = e.CommandArgument.ToString();
            new LN.BLL.AfficheData().SetScroll(Convert.ToInt32(key));
            LoadPage(1);
        }
        if (e.CommandName == "delscroll")
        {
            string key = e.CommandArgument.ToString();

            new LN.BLL.AfficheData().DelScroll(Convert.ToInt32(key));
            LoadPage(1);
        }
    }
    #region 翻页
    private void SetPageNum()
    {
        DropDownList2.Items.Clear();
        int pageNum = new LN.BLL.AfficheData().GetPageNumWithTypeID(this.ddltype.SelectedValue);
        this.Label2.Text = pageNum.ToString();
        for (int i = 1; i <= pageNum; i++)
        {
            DropDownList2.Items.Add(i.ToString());
        }
    }
    private void LoadPage(int i)
    {
        SetPageNum();
        DataTable dt = new LN.BLL.AfficheData().GetPageWithNumWithTypeID(i, this.ddltype.SelectedValue);
        if (dt == null)
        {
            LinkButton1.Enabled = false;
            LinkButton2.Enabled = false;
            LinkButton3.Enabled = false;
            LinkButton4.Enabled = false;
            Label1.Text = "0";
            this.Repeater1.DataSource = null;
            Repeater1.DataBind();
            return;
        }
        Repeater1.DataSource = null;
        Repeater1.DataBind();
        this.Repeater1.DataSource = dt;
        //this.Repeater1.DataKeyField = "ID";
        this.Repeater1.DataBind();
        Label1.Text = i.ToString();
        if (i == 1)
        {
            LinkButton1.Enabled = false;
            LinkButton2.Enabled = false;
        }
        else
        {
            LinkButton1.Enabled = true;
            LinkButton2.Enabled = true;
        }
        if (Label1.Text == Label2.Text)
        {
            LinkButton3.Enabled = false;
            LinkButton4.Enabled = false;
        }
        else
        {
            LinkButton3.Enabled = true;
            LinkButton4.Enabled = true;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int i = 1;
        LoadPage(i);
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        int i = int.Parse(Label1.Text) - 1;
        LoadPage(i);
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int i = int.Parse(Label1.Text) + 1;
        LoadPage(i);
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        int i = int.Parse(Label2.Text);
        LoadPage(i);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPage(int.Parse(DropDownList2.SelectedValue));
    }
    #endregion
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPage(int.Parse(DropDownList2.SelectedValue));
    }
}

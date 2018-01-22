using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LN.BLL;
using System.Data;

public partial class WebUI_Promotion_RackInfo_Edit : System.Web.UI.Page
{
    int id;
    RackInfo rackBll = new RackInfo();
    LN.Model.RackInfo rackModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            id = int.Parse(Request.QueryString["id"].ToString());
        }
        if (!IsPostBack)
        {
            BindDDL();
            BindData();
        }
    }

    void BindDDL()
    {
        DataSet ds = new PromotionStoryBag().GetList("");
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            ddlStoryBag.DataSource = ds;
            ddlStoryBag.DataTextField = "StoryBagName";
            ddlStoryBag.DataValueField = "Id";
            ddlStoryBag.DataBind();
        }
        ddlStoryBag.Items.Insert(0, new ListItem("请选择", "0"));

        IList<LN.Model.POPSeat> list = new POPSeat().GetList(" IsPomosion=1");
        if (list.Any())
        {
            ddlSeat.DataSource = list;
            ddlSeat.DataTextField = "seat";
            ddlSeat.DataValueField = "SeatID";
            ddlSeat.DataBind();
        }
        ddlSeat.Items.Insert(0, new ListItem("请选择", "0"));
    }

    void BindData()
    {
        rackModel = rackBll.GetModel(id);
        if (rackModel != null)
        {
            ddlStoryBag.SelectedValue =rackModel.StoryBagId!=null ? rackModel.StoryBagId.ToString():"";
            ddlSeat.SelectedValue = rackModel.PositionId != null ? rackModel.PositionId.ToString() : "";
            txtRackType.Text = rackModel.RackType;
            txtRackName.Text = rackModel.RackName;
            txtSize.Text = rackModel.Size;
            txtTexture.Text = rackModel.Texture;
            txtSpecification.Text = rackModel.Specification;
            txtUnits.Text = rackModel.Units;
            txtCategory.Text = rackModel.Category;
            txtPrice.Text = rackModel.Price != null ? rackModel.Price.ToString() : "";
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        rackModel = new LN.Model.RackInfo();
        if (id > 0)
        {
            rackModel = rackBll.GetModel(id);
        }
        rackModel.Category = txtCategory.Text.Trim();
        rackModel.PositionId = int.Parse(ddlSeat.SelectedValue);
        rackModel.RackName = txtRackName.Text.Trim();
        rackModel.RackType = txtRackType.Text.Trim();
        rackModel.Size = txtSize.Text;
        rackModel.Specification = txtSpecification.Text;
        rackModel.StoryBagId = int.Parse(ddlStoryBag.SelectedValue);
        rackModel.Texture = txtTexture.Text.Trim();
        rackModel.Units = txtUnits.Text.Trim();
        string price = txtPrice.Text.Trim();
        rackModel.Price = !string.IsNullOrWhiteSpace(price) ? decimal.Parse(price) : 0;
        if (id > 0)
        {
            rackBll.Update(rackModel);
        }
        else
        {
            rackModel.IsDelete = 0;
            id= rackBll.Add(rackModel);
            rackModel.RackCode=CreateCode(id);
            rackModel.Id = id;
            rackBll.Update(rackModel);
        }
        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('提交成功！');window.location.href='List.aspx'", true);
    }

    string CreateCode(int id)
    {
        return "M" + id.ToString().PadLeft(4, '0');
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        rackModel = new LN.Model.RackInfo();
        
        rackModel.Category = txtCategory.Text.Trim();
        rackModel.PositionId = int.Parse(ddlSeat.SelectedValue);
        rackModel.RackName = txtRackName.Text.Trim();
        rackModel.RackType = txtRackType.Text.Trim();
        rackModel.Size = txtSize.Text;
        rackModel.Specification = txtSpecification.Text;
        rackModel.StoryBagId = int.Parse(ddlStoryBag.SelectedValue);
        rackModel.Texture = txtTexture.Text.Trim();
        rackModel.Units = txtUnits.Text.Trim();
        string price = txtPrice.Text.Trim();
        rackModel.Price = !string.IsNullOrWhiteSpace(price) ? decimal.Parse(price) : 0;
        rackModel.IsDelete = 0;
        id = rackBll.Add(rackModel);
        rackModel.RackCode = CreateCode(id);
        rackModel.Id = id;
        rackBll.Update(rackModel);
        
        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('提交成功！');window.location.href='List.aspx'", true);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LN.BLL;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;


public partial class WebUI_Promotion_RackInfo_List : System.Web.UI.Page
{
    string where = string.Empty;
    RackInfo rackBll = new RackInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
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

        DataSet propTypeDs = rackBll.GetPropType();
        if (propTypeDs != null && propTypeDs.Tables[0].Rows.Count > 0)
        {
            ddlPropType.DataSource = propTypeDs;
            ddlPropType.DataTextField = "RackType";
            ddlPropType.DataValueField = "RackType";
            ddlPropType.DataBind();
        }
        ddlPropType.Items.Insert(0, new ListItem("请选择", "0"));

    }

    void GetWhere()
    {
        if (ddlStoryBag.SelectedValue != "0")
        {
            where += " and RackInfo.StoryBagId=" + ddlStoryBag.SelectedValue;
        }
        if (ddlSeat.SelectedValue != "0")
        {
            where += " and RackInfo.PositionId=" + ddlSeat.SelectedValue;
        }
        if (!string.IsNullOrWhiteSpace(txtName.Text))
        {
            where += " and RackInfo.RackName like '%" + txtName.Text.Trim() + "%'";
        }
        if (rblState.SelectedValue != "")
        {
            where += " and RackInfo.IsDelete=" + rblState.SelectedValue;
        }
        if (ddlPropType.SelectedValue != "0")
        {
            where += " and RackInfo.RackType='" + ddlPropType.SelectedValue + "'";
        }
    }

    void BindData()
    {

        where = string.Empty;
        GetWhere();
        AspNetPager1.RecordCount = rackBll.GetPageCount(where);
        DataSet ds = rackBll.GetJoinListPage(where, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "edit")
        {
            Response.Redirect("Edit.aspx?id=" + id);
        }
        if (e.CommandName == "dele")
        {
            LN.Model.RackInfo model = rackBll.GetModel(id);
            if (model != null)
            {
                model.IsDelete = 1;
                rackBll.Update(model);
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('删除成功')", true);
                BindData();
            }
            else
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('删除失败')", true);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx",false);
    }
    protected void lbExport_Click(object sender, EventArgs e)
    {
        where = " (RackInfo.IsDelete=0 or RackInfo.IsDelete is null)";
        GetWhere();
        
        DataSet ds = rackBll.GetJoinList(where);
        NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
        NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
        NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
        row1.CreateCell(0).SetCellValue("故事包");
        row1.CreateCell(1).SetCellValue("位置");
        row1.CreateCell(2).SetCellValue("道具类型");
        row1.CreateCell(3).SetCellValue("道具名称");
        row1.CreateCell(4).SetCellValue("道具编码");
        row1.CreateCell(5).SetCellValue("尺寸");
        row1.CreateCell(6).SetCellValue("材质");
        row1.CreateCell(7).SetCellValue("规格");
        row1.CreateCell(8).SetCellValue("类型");
        row1.CreateCell(9).SetCellValue("价格");
        int rowIndex = 1;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            NPOI.SS.UserModel.IRow rowTemp = sheet1.CreateRow(rowIndex);
            rowTemp.CreateCell(0).SetCellValue(dr["StoryBagName"].ToString());
            rowTemp.CreateCell(1).SetCellValue(dr["seat"].ToString());
            rowTemp.CreateCell(2).SetCellValue(dr["RackType"].ToString());
            rowTemp.CreateCell(3).SetCellValue(dr["RackName"].ToString());
            rowTemp.CreateCell(4).SetCellValue(dr["RackCode"].ToString());
            rowTemp.CreateCell(5).SetCellValue(dr["Size"].ToString());
            rowTemp.CreateCell(6).SetCellValue(dr["Texture"].ToString());
            rowTemp.CreateCell(7).SetCellValue(dr["Specification"].ToString());
            rowTemp.CreateCell(8).SetCellValue(dr["Category"].ToString());
            rowTemp.CreateCell(9).SetCellValue(dr["Price"].ToString());
            rowIndex++;
        }

        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        book.Write(ms);
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", System.Web.HttpUtility.UrlEncode("道具信息", System.Text.Encoding.UTF8)));
        Response.BinaryWrite(ms.ToArray());

        book = null;
        ms.Close();
        ms.Dispose();
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        Response.Redirect("import.aspx",false);
    }
}
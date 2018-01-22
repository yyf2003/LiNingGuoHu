using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LN.BLL;
using Common;
using System.Text;

public partial class WebUI_Promotion_PromotionThree : System.Web.UI.Page
{
    int pid;
    int userId;
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
            BindData();
        }

    }


    void BindData()
    {
        Promotion promotionBll = new Promotion();
        LN.Model.Promotion promotionModel = promotionBll.GetModel(pid);
        if (promotionModel != null)
        {
            labPromotionId.Text = promotionModel.PromotionId;
            labTitle.Text = promotionModel.PromotionName;
            PromotionProductLines pplBll = new PromotionProductLines();
            DataSet ds = pplBll.GetList(string.Format(" PromotionId='{0}'", promotionModel.PromotionId));
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }
    ProductLineData productLineBll = new ProductLineData();
    POPSeat popseatBll = new POPSeat();
    PromotionPosition positionBll = new PromotionPosition();
    DataSet positionDS = null;
    Attachment attachBll = new Attachment();
    DataSet attachDS = null;
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                int pkId = int.Parse(item["Id"].ToString());
                int lineId = int.Parse(item["ProductLineId"].ToString());
                List<LN.Model.ProductLineData> list = productLineBll.GetList(string.Format(" ProductLineID={0}", lineId));
                if (list.Any())
                {
                    ((Label)e.Item.FindControl("labLineName")).Text = list[0].ProductTypeName + "—" + list[0].ProductLine;
                }
                positionDS = null;
                positionDS = positionBll.GetList(string.Format(" PromotionId={0} and ProductLineId={1}", pid, lineId));
                string positions = string.Empty;
                if (positionDS != null && positionDS.Tables[0].Rows.Count > 0)
                {
                    positions = positionDS.Tables[0].Rows[0]["Position"].ToString();
                    ((DropDownList)e.Item.FindControl("ddlLevel")).SelectedValue = positionDS.Tables[0].Rows[0]["Level"].ToString();
                }
                string[] arr = positions.Split(',');
                List<LN.Model.POPSeat> seatList = popseatBll.GetAllList();
                if (seatList.Any())
                {
                    StringBuilder sb = new StringBuilder();
                    //sb.Append("<div>");
                    sb.Append("<div style='border-bottom:1px solid #ccc;color:blue;'><input type='checkbox' name='cbAll'/>全选</div>");
                    seatList.ForEach(s =>
                    {
                        string check = string.Empty;
                        if (arr.Contains(s.SeatID.ToString()))
                        {
                            check = "checked='checked'";
                        }
                        sb.AppendFormat("<div style='width:140px;float:left;'><input type='checkbox' {0} name='cbOne' value='{1}' />{2}</div>", check, s.SeatID, s.seat);
                    });
                    //sb.Append("</div>");
                    ((Label)e.Item.FindControl("labPosition")).Text = sb.ToString();
                    
                }

                attachDS = null;
                attachDS = attachBll.GetList(string.Format(" ItemTypeId={0} and FileCode='{1}' and ItemId={2} and IsDelete=0", pid, ((int)FileCodeEnum.POPPromotionPicture).ToString(), lineId));
                if (attachDS != null && attachDS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = attachDS.Tables[0].Rows[0];
                    ((Label)e.Item.FindControl("labImgNumber")).Text = attachDS.Tables[0].Rows[0]["FileNumber"].ToString();
                    StringBuilder imgs = new StringBuilder();
                    string src = dr["SmallImgUrl"].ToString().Replace("~/", "../../");
                    string path = dr["FilePath"].ToString().Replace("~/", "../../");
                    imgs.Append("<div style='width:120px;float:left;margin-right:8px;'><a href='" + path + "' class='showimg' data-fancybox-group='imgs' style='border:0px;'><img style='border:0px;' src='" + src + "' width='120px' height='95px' /></a><br/>");
                    imgs.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td style='text-align:left;width:50px; height:30px;font-size:12px;border:0px;'><a href='../../Handlers/OperateFile.ashx?id=" + dr["Id"].ToString() + "&type=download' rel='" + dr["Title"].ToString() + "' title='" + dr["Title"].ToString() + "'>" + (dr["Title"].ToString().Length > 15 ? (dr["Title"].ToString().Substring(0, 15) + "...") : dr["Title"].ToString()) + "</a></td><td style='width:20px;;color:red;cursor:pointer;text-align:right;padding-right:12px;border:0px;'></td><td style='border:0px;'></td></tr></table>");
                    imgs.Append("</div>");
                    ((Label)e.Item.FindControl("labImg")).Text = imgs.ToString();
                }

            }
        }
    }


    bool IsPositionExist(int lineId,out int id)
    {
        id=0;
        bool flag = false;
        DataSet ds = positionBll.GetList(string.Format(" PromotionId={0} and ProductLineId={1}",pid,lineId));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
            flag = true;
        }
        return flag;
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        LN.Model.PromotionPosition positionModel;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                int lineId = int.Parse(((HiddenField)item.FindControl("hfProductLineId")).Value);
                string positions = ((HiddenField)item.FindControl("hfPositions")).Value;
                int level = int.Parse(((DropDownList)item.FindControl("ddlLevel")).SelectedValue);
                positions = positions.TrimEnd(',');
                positionModel = new LN.Model.PromotionPosition();
                positionModel.Level = level;
                positionModel.Position = positions;
                int id = 0;
                if (!IsPositionExist(lineId, out id))
                {
                    positionModel.ProductLineId = lineId;
                    positionModel.PromotionId = pid;
                    positionBll.Add(positionModel);
                }
                else
                {
                    positionModel.Id = id;
                    positionBll.Update(positionModel);
                }
               
            }
        }
        Response.Redirect("PromotionFour.aspx?id=" + pid, false);
    }
    

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionTwo.aspx?id=" + pid, false);
    }
    protected void ddlAllLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        string levelId = (sender as DropDownList).SelectedValue;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                ((DropDownList)item.FindControl("ddlLevel")).SelectedValue = levelId;
            }
        }
    }
}
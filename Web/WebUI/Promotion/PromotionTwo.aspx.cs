using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LN.BLL;
using Common;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Text;

public partial class WebUI_Promotion_PromotionTwo : System.Web.UI.Page
{
    int pid;
    int userId;
    int isFinish;//本次推广订单是否已完成提交
    PromotionSonStoryBag sbApplyBll = new PromotionSonStoryBag();
    LN.Model.PromotionSonStoryBag sbApplyModel;
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
        BindData();
        if (!IsPostBack)
        {
            BindStoryBags();
        }

    }
    DataSet ds;
    void BindStoryBags()
    {

        ds = sbApplyBll.GetList(string.Format(" PromotionSonStoryBag.PromotionId={0} and PromotionSonStoryBag.IsSon=1", pid));
        if (isFinish == 0)
        {

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                StringBuilder json = new StringBuilder();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    json.Append("{\"ParentStoryBagId\":\"" + dr["ParentStoryBagId"] + "\",\"StoryBagName\":\"" + dr["StoryBagName"] + "\"},");
                }
                if (json.Length > 0)
                {
                    hfsbJson.Value = json.ToString().TrimEnd(',');
                }
            }

        }

        DataSet ds0 = new PromotionStorySeat().GetStoryBags(pid);
        Repeater2.DataSource = ds0;
        Repeater2.DataBind();
    }


    void BindData()
    {
        Promotion promotionBll = new Promotion();
        LN.Model.Promotion promotionModel = promotionBll.GetModel(pid);
        if (promotionModel != null)
        {
            isFinish = promotionModel.State ?? 0;
            labPromotionId.Text = promotionModel.PromotionId;
            labTitle.Text = promotionModel.PromotionName;
            hfPromotionId.Value = promotionModel.PromotionId;
            //PromotionProductLines pplBll = new PromotionProductLines();
            //DataSet ds = pplBll.GetList(string.Format(" PromotionId='{0}'", promotionModel.PromotionId));
            DataSet ds = promotionBll.GetRackInfo(pid);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            CombineCell();
        }
    }

    /// <summary>
    /// 合并单元格
    /// </summary>
    void CombineCell()
    {

        for (int i = Repeater1.Items.Count - 1; i > 0; i--)
        {

            HtmlTableCell cell1 = Repeater1.Items[i - 1].FindControl("StoryBagName") as HtmlTableCell;
            HtmlTableCell cell2 = Repeater1.Items[i].FindControl("StoryBagName") as HtmlTableCell;
            //HtmlTableCell rowNum = Repeater1.Items[i].FindControl("RowNum") as HtmlTableCell;
            cell1.RowSpan = (cell1.RowSpan == -1) ? 1 : cell1.RowSpan;
            cell2.RowSpan = (cell2.RowSpan == -1) ? 1 : cell2.RowSpan;
            if (cell2.InnerText == cell1.InnerText)
            {
                cell2.Visible = false;
                cell1.RowSpan += cell2.RowSpan;
            }


            HtmlTableCell cell3 = Repeater1.Items[i - 1].FindControl("seat") as HtmlTableCell;
            HtmlTableCell cell4 = Repeater1.Items[i].FindControl("seat") as HtmlTableCell;
            cell3.RowSpan = (cell3.RowSpan == -1) ? 1 : cell3.RowSpan;
            cell4.RowSpan = (cell4.RowSpan == -1) ? 1 : cell4.RowSpan;
            if (cell4.InnerText + cell2.InnerText == cell3.InnerText + cell1.InnerText)
            {
                cell4.Visible = false;
                cell3.RowSpan += cell4.RowSpan;
            }

            HtmlTableCell cell5 = Repeater1.Items[i - 1].FindControl("rackType") as HtmlTableCell;
            HtmlTableCell cell6 = Repeater1.Items[i].FindControl("rackType") as HtmlTableCell;
            cell5.RowSpan = (cell5.RowSpan == -1) ? 1 : cell5.RowSpan;
            cell6.RowSpan = (cell6.RowSpan == -1) ? 1 : cell6.RowSpan;
            if (cell6.InnerText + cell4.InnerText + cell2.InnerText == cell5.InnerText + cell3.InnerText + cell1.InnerText)
            {
                cell6.Visible = false;
                cell5.RowSpan += cell6.RowSpan;
            }



        }
    }


    //ProductLineData productLineBll = new ProductLineData();
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                int pkId = int.Parse(item["rackId"].ToString());

                FileUploadUC_UpLoadContraol fileUpload = (FileUploadUC_UpLoadContraol)e.Item.FindControl("UpLoadContraol1");
                fileUpload.Code = pkId.ToString();
                fileUpload.FileCode = ((int)FileCodeEnum.POPPromotionPicture).ToString();
                fileUpload.FileType = FileTypeEnum.Images.ToString();
                fileUpload.ItemTypeId = pid.ToString();
                fileUpload.ItemId = pkId.ToString();
                fileUpload.UserId = userId.ToString();

            }
        }
    }

    /// <summary>
    /// 下一步（保存子故事包，）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (isFinish == 0)
        {
            sbApplyBll.DeleteByPromotionId(pid);
            ForeachRepeater();
            List<int> subIds = new List<int>();
            if (!string.IsNullOrWhiteSpace(hfsbJson.Value))
            {
                List<LN.Model.PromotionSonStoryBag> list = JsonConvert.DeserializeObject<List<LN.Model.PromotionSonStoryBag>>(hfsbJson.Value);
                if (list.Any())
                {
                    list.ForEach(s =>
                    {
                        sbApplyModel = new LN.Model.PromotionSonStoryBag();
                        sbApplyModel.PromotionId = pid;
                        sbApplyModel.IsSon = 1;
                        sbApplyModel.ParentStoryBagId = s.ParentStoryBagId;
                        sbApplyModel.StoryBagName = s.StoryBagName;
                        sbApplyBll.Add(sbApplyModel);
                        if (!subIds.Contains(s.ParentStoryBagId))
                            subIds.Add(s.ParentStoryBagId);
                    });
                }
            }
            foreach (KeyValuePair<int, string> item in sbDic)
            {
                if (!subIds.Contains(item.Key))
                {
                    sbApplyModel = new LN.Model.PromotionSonStoryBag();
                    sbApplyModel.PromotionId = pid;
                    sbApplyModel.IsSon = 0;
                    sbApplyModel.ParentStoryBagId = item.Key;
                    sbApplyModel.StoryBagName = item.Value;
                    sbApplyBll.Add(sbApplyModel);
                }
            }
        }
        
        Response.Redirect("PromotionFour.aspx?id=" + pid, false);
    }
    //获取父故事包
    Dictionary<int, string> sbDic = new Dictionary<int, string>();
    void ForeachRepeater()
    {
        foreach (RepeaterItem item in Repeater2.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Label nameLab = (Label)item.FindControl("labStoryBagName");
                HiddenField idHf = (HiddenField)item.FindControl("hfStoryBagId");
                if (!sbDic.Keys.Contains(int.Parse(idHf.Value)))
                    sbDic.Add(int.Parse(idHf.Value), nameLab.Text);
            }
        }
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddPromotion.aspx?id=" + pid, false);
    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if (isFinish == 1)
            {
                DataRowView item = (DataRowView)e.Item.DataItem;
                if (item != null)
                {
                    int sbId = int.Parse(item["Id"].ToString());
                    StringBuilder names = new StringBuilder();
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        var list = from ds1 in ds.Tables[0].AsEnumerable()
                                   where ds1.Field<int>("ParentStoryBagId") == sbId
                                   select ds1;
                        foreach (DataRow dr in list)
                        {
                            names.Append(dr["StoryBagName"] + ",");
                        }
                    }
                    ((Label)e.Item.FindControl("labStoryBagNames")).Text = names.ToString().TrimEnd(',');
                    ((Panel)e.Item.FindControl("Panel2")).Visible = true;
                    ((Panel)e.Item.FindControl("Panel1")).Visible = false;
                }
            }
           
        }
    }
}
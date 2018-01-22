using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Common;
using LN.BLL;
using System.Web.UI.HtmlControls;

public partial class WebUI_Promotion_PromotionDetail : System.Web.UI.Page
{
    int pid;
    string promotionId = string.Empty;
    PromotionProductLines promotionLinesBll = new PromotionProductLines();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            pid = int.Parse(Request.QueryString["id"].ToString());
        }
        BindPromotionData();
        if (!IsPostBack)
        {
            //BindProduceLines();
            //BindTypes();
            BindStoryBag();
            BindData();
        }
    }

    void BindPromotionData()
    {
        Promotion promotionBll = new Promotion();
        LN.Model.Promotion model = promotionBll.GetModel(pid);
        if (model != null)
        {
            promotionId = model.PromotionId;
            labPromotionId.Text = promotionId;
            labTitle.Text = model.PromotionName;
            labStartDate.Text = model.BeginDate != null ? DateTime.Parse(model.BeginDate.ToString()).ToShortDateString() : "";
            labEndDate.Text = model.EndDate != null ? DateTime.Parse(model.EndDate.ToString()).ToShortDateString() : "";
            labRemark.Text = model.PromotionDesc;
            string attach = attachBll.GetAttachList(string.Format(" ItemTypeId={0} and FileCode='{1}' and (IsDelete=0 or IsDelete is null)", pid, ((int)FileCodeEnum.POPPromotionAttach)),"1");
            labAttachment.Text = attach;
        }
    }

   
    
    PromotionStorySeat storyBagBll = new PromotionStorySeat();
    /// <summary>
    /// 获取故事包
    /// </summary>
    void BindStoryBag()
    {
        
        DataSet ds = storyBagBll.GetList(string.Format(" PromotionStorySeat.PromotionId={0}", pid));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (!dic.Keys.Contains(int.Parse(dr["StoryBagId"].ToString())))
                {
                    dic.Add(int.Parse(dr["StoryBagId"].ToString()), dr["StoryBagName"].ToString());
                }
            }
            foreach (KeyValuePair<int, string> item in dic)
            {
                ListItem li = new ListItem();
                li.Text = item.Value;
                li.Value = item.Key.ToString();
                DDLStoryBag.Items.Add(li);
            }
        }
        

    }

    
    void BindData()
    {
        StringBuilder where = new StringBuilder();
        where.Append(string.Format(" seat.PromotionId={0}", pid));
        if (DDLStoryBag.SelectedValue != "0")
        {

            where.Append(" and seat.StoryBagId=" + DDLStoryBag.SelectedValue);
        }
        //DataSet ds = storyBagBll.GetList(where.ToString());
        Promotion promotionBll = new Promotion();
        DataSet ds = promotionBll.GetRackInfo(where.ToString());
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
        CombineCell();
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
            if (cell6.InnerText + cell2.InnerText == cell5.InnerText + cell1.InnerText)
            {
                cell6.Visible = false;
                cell5.RowSpan += cell6.RowSpan;
            }



        }
    }


    PromotionPosition promotionPositionBll = new PromotionPosition();
    Attachment attachBll = new Attachment();
    PromotionSonStoryBag sonStoryBagBll = new PromotionSonStoryBag();
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                int sbid = int.Parse(item["StoryBagId"].ToString());
                string sbName = item["StoryBagName"].ToString();

                DataSet ds = sonStoryBagBll.GetList(string.Format(" PromotionSonStoryBag.PromotionId={0} and PromotionSonStoryBag.ParentStoryBagId={1} and PromotionSonStoryBag.IsSon=1", pid, sbid));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder sbNames=new StringBuilder();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sbNames.Append(dr["StoryBagName"]+",");
                    }
                    sbName += "<br/>(" + sbNames.ToString().TrimEnd(',') + ")";
                    ((HtmlTableCell)e.Item.FindControl("StoryBagName")).InnerHtml = sbName;
                }
                int rackId = int.Parse(item["rackId"].ToString());
                string imgs = attachBll.GetAttachList(string.Format(" ItemTypeId={0} and ItemId={1} and FileCode='{2}' and (IsDelete=0 or IsDelete is null) ", pid, rackId, ((int)FileCodeEnum.POPPromotionPicture)));
                ((Label)e.Item.FindControl("labImg")).Text = imgs;
            }
        }
    }

    POPSeat seatBll = new POPSeat();
    LN.Model.POPSeat seatModel;
    string GetPOPSeat(string position)
    {
        StringBuilder sb = new StringBuilder();
        if (!string.IsNullOrWhiteSpace(position))
        {
            string[] arr = position.Split(',');
            if (arr.Length > 0)
            {
                foreach (string s in arr)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        seatModel = seatBll.GetModel(int.Parse(s));
                        if (seatModel != null)
                        {
                            sb.Append(seatModel.seat + "，");
                        }
                    }
                }
            }
        }
        return sb.ToString().TrimEnd('，');
    }


    protected void DDLStoryBag_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}
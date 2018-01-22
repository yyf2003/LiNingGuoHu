using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LN.BLL;
using System.Text;
using Common;

public partial class WebUI_Promotion_AddPromotion : System.Web.UI.Page
{
    int pid;
    string promotionId=string.Empty;
    int userId;
    Promotion promotionBll = new Promotion();
    LN.Model.Promotion promotionModel;
    POPSeat seatBll = new POPSeat();
    List<LN.Model.POPSeat> promotionSeats = new List<LN.Model.POPSeat>();
    PromotionStorySeat storySeatBll = new PromotionStorySeat();
    LN.Model.PromotionStorySeat storySeatModel;
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
        promotionSeats = seatBll.GetList(" IsPomosion=1");
        if (!IsPostBack)
        {
            BindData();
            //BindProductLines();
            BindStoryBags();
            if (pid > 0)
            {
                UpFilePanel1.Visible = false;

            }
            else
            {
                UpFilePanel2.Visible = false;
            }
        }
        UpLoadContraol1.FileCode = ((int)FileCodeEnum.POPPromotionAttach).ToString();
        UpLoadContraol1.FileType = FileTypeEnum.Files.ToString();
        UpLoadContraol1.ItemTypeId = pid.ToString();
        UpLoadContraol1.UserId = userId.ToString();
    }




    void BindData()
    {
        promotionModel = promotionBll.GetModel(pid);
        if (promotionModel != null)
        {
            txt_PromotionId.Text = promotionModel.PromotionId;
            promotionId = promotionModel.PromotionId;
            //DDL_price.SelectedValue = promotionModel.BoolPrice != null ? promotionModel.BoolPrice.ToString() : "";
            txt_btime.Text = promotionModel.BeginDate != null ? DateTime.Parse(promotionModel.BeginDate.ToString()).ToShortDateString() : "";
            txt_etime.Text = promotionModel.EndDate != null ? DateTime.Parse(promotionModel.EndDate.ToString()).ToShortDateString() : "";
            txt_poptitle.Text = promotionModel.PromotionName;
            txt_remarks.Text = promotionModel.PromotionDesc;

        }
        else
            txt_PromotionId.Text = DateTime.Now.ToString("yyyyMMddhhmmss");
    }

    
    void BindProductLines()
    {
        ProductLineType typeBll = new ProductLineType();
        ProductLineData productBll = new ProductLineData();
        IList<LN.Model.ProductLineType> list = typeBll.GetList(" IsDelete=1 ");
        if (list.Any())
        {
            List<int> lines = new List<int>();
            PromotionProductLines pplbll = new PromotionProductLines();
            DataSet ds = pplbll.GetList(string.Format(" PromotionId='{0}'", promotionId));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!string.IsNullOrWhiteSpace(dr["ProductLineId"].ToString()))
                    {
                        lines.Add(int.Parse(dr["ProductLineId"].ToString()));
                    }
                }
            }

            //var lineList = bll.GetByCondition(s => s.POPLanuchId == launchId);
            //if (lineList.Any())
            //{
            //    lineList.ForEach(s =>
            //    {
            //        lines.Add(s.ProductLineId);
            //    });
            //}
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='width:680px;'>");
            list.ToList().ForEach(s =>
            {
                sb.AppendFormat("<tr><td style='width: 80px;text-align: left;padding-left:10px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;'><input type='checkbox' name='checkType' value='{0}' /> {1}</td>", s.ProductTypeID, s.ProductTypeName);
                sb.Append("<td style='text-align: left;vertical-align:top;padding:5px;border:0px; border-bottom:1px solid #ccc;'>");
                var pList = productBll.GetList(string.Format(" TypeID={0}",s.ProductTypeID));
                if (pList.Any())
                {
                    string check = string.Empty;
                    pList.ForEach(p =>
                    {
                        check = string.Empty;
                        if (lines.Contains(p.ProductLineID))
                        {
                            check = "checked='checked'";
                        }
                        sb.AppendFormat("<div style='width:120px;float:left;'><input name='checkLines' type='checkbox' {2} value='{0}' /> {1}</div>", p.ProductLineID, p.ProductLine, check);
                    });
                }
                sb.Append("</td></tr>");
            });

            sb.Append("</table>");
            //labProductLine.Text = sb.ToString();
        }

    }

    void BindStoryBags()
    {
        PromotionStoryBag storyBll = new PromotionStoryBag();
        DataSet list = storyBll.GetList("");
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }



    protected void BtnNext_Click(object sender, EventArgs e)
    {
        //promotionModel = promotionBll.GetModel(id);
        //if (promotionModel != null)
        //{ 
           
        //}

        promotionModel = new LN.Model.Promotion();
        promotionModel.PromotionId = txt_PromotionId.Text;
        promotionId = txt_PromotionId.Text;
        //promotionModel.BoolPrice = int.Parse(DDL_price.SelectedValue);
        promotionModel.BeginDate = DateTime.Parse(txt_btime.Text.Trim());
        promotionModel.EndDate = DateTime.Parse(txt_etime.Text.Trim());
        promotionModel.PromotionName = txt_poptitle.Text.Trim();
        promotionModel.PromotionDesc = txt_remarks.Text.Trim();
        
        if (pid > 0)
        {
            promotionModel.Id = pid;
            promotionBll.Update(promotionModel);
        }
        else
        {
            promotionModel.AddDate = DateTime.Now;
            promotionModel.AddUserId = userId;
            promotionModel.IsDelete = 0;
            promotionModel.State = 0;
            pid = promotionBll.Add(promotionModel);
            upLoadFile();
        }
        //SaveProductLines();
        SaveStoryBag();
        Response.Redirect("PromotionTwo.aspx?id="+pid,false);
    }

    void upLoadFile()
    {
        if (FileUpload1.HasFile)
        {
            HttpPostedFile file=FileUpload1.PostedFile;
            if (file.ContentLength < 104857600)//小于100m
            {
                Attachment attaBll = new Attachment();
                LN.Model.Attachment attaModel = new LN.Model.Attachment();
                attaModel.FileType = FileTypeEnum.Files.ToString();
                attaModel.FileCode = ((int)FileCodeEnum.POPPromotionAttach).ToString();
                UploadFileHelper.UpFiles(file, ref attaModel);
                attaModel.AddDate = DateTime.Now;
                attaModel.AddUserId = userId;
                attaModel.IsDelete = 0;
                attaModel.ItemTypeId = pid.ToString();
                attaModel.FileNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
                attaBll.Add(attaModel);
            }
        }
    }

    void SaveProductLines()
    {
        PromotionProductLines pplbll = new PromotionProductLines();
        LN.Model.PromotionProductLines pplModel;
        pplbll.DeleteByPromotionId(promotionId);
        if (!string.IsNullOrWhiteSpace(hfProductLines.Value))
        {
            string[] arr = hfProductLines.Value.Split(',');
            foreach (string s in arr)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    pplModel = new LN.Model.PromotionProductLines();
                    pplModel.ProductLineId = int.Parse(s);
                    pplModel.PromotionId = promotionId;
                    pplbll.Add(pplModel);
                }
            }
        }
    }

    void SaveStoryBag()
    {
        storySeatBll.DeleteByPromotionId(pid);
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {
                CheckBox cb = (CheckBox)item.FindControl("cbStoryBag");
                if (cb.Checked)
                {
                    int storyId = int.Parse(((HiddenField)item.FindControl("hfStoryBagId")).Value);
                    CheckBoxList cbl = (CheckBoxList)item.FindControl("cblSeats");
                    foreach (ListItem cbItem in cbl.Items)
                    {
                        if (cbItem.Selected)
                        {
                            storySeatModel = new LN.Model.PromotionStorySeat();
                            storySeatModel.AddDate = DateTime.Now;
                            storySeatModel.AddUserId = userId;
                            storySeatModel.PromotionId = pid;
                            storySeatModel.SeatId = int.Parse(cbItem.Value);
                            storySeatModel.StoryBagId = storyId;
                            storySeatBll.Add(storySeatModel);
                        }
                    }
                }
            }
        }
    }
    
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            CheckBoxList seats = (CheckBoxList)e.Item.FindControl("cblSeats");
            seats.DataSource = promotionSeats;
            seats.DataTextField = "seat";
            seats.DataValueField = "SeatID";
            seats.DataBind();

            //object dataItem = e.Item.DataItem;
            DataRowView dataItem = e.Item.DataItem as DataRowView;
            if (dataItem != null)
            {
               
                int storyId = int.Parse(dataItem["Id"].ToString());
                CheckBox cb = (CheckBox)e.Item.FindControl("cbStoryBag");
                DataSet list = storySeatBll.GetList(string.Format(" PromotionId={0} and StoryBagId={1}", pid, storyId));
                if (list != null && list.Tables[0].Rows.Count > 0)
                {
                    cb.Checked = true;
                    foreach (DataRow dr in list.Tables[0].Rows)
                    {
                        foreach (ListItem li in seats.Items)
                        {
                            if (li.Value == dr["SeatId"].ToString())
                            {
                                li.Selected = true;
                            }
                        }
                    }
                }
            }
            
        }
    }
}
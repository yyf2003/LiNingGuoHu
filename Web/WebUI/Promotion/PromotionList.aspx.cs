using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LN.BLL;
using Common;

public partial class WebUI_Promotion_PromotionList : System.Web.UI.Page
{
    string isEdit = string.Empty;
    string isConfirm = string.Empty;
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        userId = int.Parse(Request.Cookies["UserID"].Value);
        if (Request.QueryString["edit"] != null)
        {
            //修改订单
            isEdit = Request.QueryString["edit"].ToString();
            labTitle.Text = "修改订单";
        }
        if (Request.QueryString["confirm"] != null)
        {
            //确认订单
            isConfirm = Request.QueryString["confirm"].ToString();
            labTitle.Text = "订单确认";
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        StringBuilder where = new StringBuilder();
        if (!string.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
        {
            where.AppendFormat(" and PromotionName like '%{0}%'", txtTitle.Text.Trim());
        }
        if (!string.IsNullOrWhiteSpace(txtBeginDate.Text))
        {
            //DateTime date = DateTime.Parse(txtBeginDate.Text);
            where.Append(" and BeginDate >= '" + txtBeginDate.Text.Trim() + "'");
        }
        if (!string.IsNullOrWhiteSpace(txtEndDate.Text))
        {
            DateTime date = DateTime.Parse(txtEndDate.Text).AddDays(1);
            where.Append(" and EndDate  < '"+date+"'");
        }
        if (!string.IsNullOrWhiteSpace(isEdit) || !string.IsNullOrWhiteSpace(isConfirm))
        {
            where.Append(" and State=1 and (IsConfirmOrder is null or IsConfirmOrder=0)");
        }
        //else if (!string.IsNullOrWhiteSpace(isConfirm))
        //{
        //    where.Append(" and State=1 ");
        //}
        Promotion promotionBll = new Promotion();
        AspNetPager1.RecordCount = promotionBll.GetPageCount(where.ToString());
        DataSet ds = promotionBll.GetList(where.ToString(),AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize);
        Repeater1.DataSource = ds;
        
        Repeater1.DataBind();

    }

    //PromotionProductLines promotionLinesBll = new PromotionProductLines();
    PromotionStorySeat storySeatBll=new PromotionStorySeat();
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                string promotionId = item["Id"].ToString();
               

                //显示故事包和位置信息
                DataSet ds = storySeatBll.GetList(" PromotionStorySeat.PromotionId=" + promotionId);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (!list.Keys.Contains(dr["StoryBagName"].ToString()))
                        {
                            List<string> linelist = new List<string>();
                            linelist.Add(dr["seat"].ToString());
                            list.Add(dr["StoryBagName"].ToString(), linelist);
                        }
                        else
                        {
                            List<string> linelist = list[dr["StoryBagName"].ToString()];
                            linelist.Add(dr["seat"].ToString());
                            list[dr["StoryBagName"].ToString()] = linelist;
                        }
                    }
                    if (list.Any())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<table style='width:200px;'>");
                        list.ToList().ForEach(s =>
                        {
                            sb.AppendFormat("<tr><td style='width: 50px;text-align: left;padding-left:10px;border:0px; border-bottom:1px solid #ccc;border-right:1px solid #ccc;'>{0}</td>", s.Key.ToString());
                            sb.Append("<td style='text-align: left;vertical-align:top;padding:5px;border:0px; border-bottom:1px solid #ccc;'>");
                            List<string> lines = s.Value;
                            if (lines.Any())
                            {
                                string check = string.Empty;
                                lines.ForEach(p =>
                                {
                                    sb.AppendFormat("{0}；", p);
                                });
                            }
                            sb.Append("</td></tr>");
                        });
                        sb.Append("</table>");
                        ((Label)e.Item.FindControl("labStoryBag")).Text = sb.ToString();
                    }
                }





                //提交状态：是否完成提交（1：完成，0和空：未完成）
                string submitState = item["State"].ToString();
                string confirmState = item["IsConfirmOrder"].ToString();
                if(submitState=="1")
                {
                   ((Label)e.Item.FindControl("labSubmitState")).Text = "已完成";
                   
                  
                }
                else
                {
                   ((Label)e.Item.FindControl("labSubmitState")).Text = "<span style='color:red;'>未完成</span>";
                   ((LinkButton)e.Item.FindControl("lbSubmit")).Visible = true;
                   ((LinkButton)e.Item.FindControl("lbDelete")).Visible = true;
                   ((LinkButton)e.Item.FindControl("lbEdit")).Visible = false;
                   ((LinkButton)e.Item.FindControl("lbUpdateOrder")).Enabled = false;
                   ((LinkButton)e.Item.FindControl("lbExport")).Enabled = false;
                   ((LinkButton)e.Item.FindControl("lbFinalExport")).Enabled = false;
                }
                
                ((Label)e.Item.FindControl("labConfirmState")).Text = confirmState == "1" ? "已确认" : "<span style='color:red;'>未确认</span>";

                //如果不是添加人，不显示“继续提交”和“编辑”
                int addUserId = int.Parse(item["AddUserId"].ToString()!=""?item["AddUserId"].ToString():"0");
                if (addUserId != userId)
                {
                    ((LinkButton)e.Item.FindControl("lbSubmit")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lbEdit")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lbDelete")).Visible = false;
                }
            }
            HtmlTableCell cellsbs = (HtmlTableCell)e.Item.FindControl("submitState");
            HtmlTableCell cellcfs = (HtmlTableCell)e.Item.FindControl("confirmState");
            HtmlTableCell cellcz = (HtmlTableCell)e.Item.FindControl("caozuo");
            HtmlTableCell cellck = (HtmlTableCell)e.Item.FindControl("check");
            HtmlTableCell celled = (HtmlTableCell)e.Item.FindControl("editOrder");
            HtmlTableCell cellcf = (HtmlTableCell)e.Item.FindControl("confirm");
            if (!string.IsNullOrWhiteSpace(isEdit))
            {
                cellcfs.Style.Add("display", "none");
                cellcz.Style.Add("display", "none");
                cellck.Style.Add("display", "none");
                cellcf.Style.Add("display", "none");
            }
            else if (!string.IsNullOrWhiteSpace(isConfirm))
            {
                cellsbs.Style.Add("display", "none");
                cellcz.Style.Add("display", "none");
                cellck.Style.Add("display", "none");
                celled.Style.Add("display", "none");

            }
            else
            {
               
                cellcfs.Style.Add("display", "none");
                cellcf.Style.Add("display", "none");
                celled.Style.Add("display", "none");
            }
        }
        if (e.Item.ItemType == ListItemType.Header)
        {
            HtmlTableCell cellsbs = (HtmlTableCell)e.Item.FindControl("submitState");
            HtmlTableCell cellcfs = (HtmlTableCell)e.Item.FindControl("confirmState");
            HtmlTableCell cellcz = (HtmlTableCell)e.Item.FindControl("caozuo");
            HtmlTableCell cellck = (HtmlTableCell)e.Item.FindControl("check");
            HtmlTableCell celled = (HtmlTableCell)e.Item.FindControl("editOrder");
            HtmlTableCell cellcf = (HtmlTableCell)e.Item.FindControl("confirm");
            if (!string.IsNullOrWhiteSpace(isEdit))
            {
                cellcfs.Style.Add("display", "none");
                cellcz.Style.Add("display", "none");
                cellck.Style.Add("display", "none");
                cellcf.Style.Add("display", "none");
            }
            else if (!string.IsNullOrWhiteSpace(isConfirm))
            {
                cellsbs.Style.Add("display", "none");
                cellcz.Style.Add("display", "none");
                cellck.Style.Add("display", "none");
                celled.Style.Add("display", "none");
            }
            else
            {
                //cellcz.Style.Add("display", "none");
                cellcfs.Style.Add("display", "none");
                cellcf.Style.Add("display", "none");
                celled.Style.Add("display", "none");
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "Submit" || e.CommandName == "Edit")
        {
            Response.Redirect("AddPromotion.aspx?id="+id,false);
        }
        if (e.CommandName == "Check")
        {
            Response.Redirect("PromotionDetail.aspx?id=" + id, false);
        }
        if (e.CommandName == "Delete")
        {
            new Promotion().Delete(id);
            BindData();
        }
        if (e.CommandName == "Update")
        {
            Response.Redirect("UpdateOrder.aspx?id=" + id, false);
        }
        if (e.CommandName == "Export")
        {
            Response.Redirect("PromotionFive.aspx?id=" + id+"&isexport=1", false);
        }
        if (e.CommandName == "FinalExport")
        {
            Response.Redirect("FinalExport.aspx?id=" + id, false);
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LN.BLL;


public partial class WebUI_Promotion_RackInfo_SetRackLimitCount : System.Web.UI.Page
{
    
    RackLimitCountBLL rackCountBll = new RackLimitCountBLL();
    LN.Model.RackLimitCount rackCountModel;
    POPSeat seatBll = new POPSeat();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindShopLevel();
        }
    }

    void BindShopLevel()
    {
        PromotionShopLevel shopLevelBll = new PromotionShopLevel();
        DataSet ds = shopLevelBll.GetList("");
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
    List<LN.Model.POPSeat> seatList = new List<LN.Model.POPSeat>();
    int levelId = 0;
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                levelId = int.Parse(item["Id"].ToString());
            }

            Repeater seatRepeater = (Repeater)e.Item.FindControl("Repeater2");
            if (seatList.Count==0)
            {
                seatList = seatBll.GetList(" IsPomosion=1");
            }
            seatRepeater.ItemDataBound += new RepeaterItemEventHandler(seatRepeater_ItemDataBound);
            seatRepeater.DataSource = seatList;
            seatRepeater.DataBind();
        }
    }

    void seatRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LN.Model.POPSeat item = (LN.Model.POPSeat)e.Item.DataItem;
            if (item != null)
            {
                
                TextBox tbCount = (TextBox)e.Item.FindControl("txtCount");
                rackCountModel = rackCountBll.GetModel(string.Format("ShopLevelId={0} and RackSeatId={1}", levelId, item.SeatID));
                if (rackCountModel != null)
                {
                    tbCount.Text = rackCountModel.Count != null ? rackCountModel.Count.ToString() : "";
                }
            }
        }
    }
    /// <summary>
    /// 提交更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType== ListItemType.AlternatingItem)
                {
                    HiddenField hfLevelId = (HiddenField)item.FindControl("hfLevelId");
                    int levelId = int.Parse(hfLevelId.Value != "" ? hfLevelId.Value : "0");
                    Repeater seatRepeater = (Repeater)item.FindControl("Repeater2");
                    foreach (RepeaterItem item1 in seatRepeater.Items)
                    {
                        HiddenField hfSeatId = (HiddenField)item1.FindControl("hfSeatId");
                        int seatId = int.Parse(hfSeatId.Value != "" ? hfSeatId.Value : "0");
                        TextBox tbCount = (TextBox)item1.FindControl("txtCount");
                        int count = !string.IsNullOrWhiteSpace(tbCount.Text) ? int.Parse(tbCount.Text.Trim()) : 0;
                        rackCountModel = rackCountBll.GetModel(string.Format("ShopLevelId={0} and RackSeatId={1}", levelId, seatId));
                        if (rackCountModel != null)
                        {
                            rackCountModel.Count = count;
                            rackCountBll.Update(rackCountModel);
                        }
                        else
                        {
                            rackCountModel = new LN.Model.RackLimitCount();
                            rackCountModel.Count = count;
                            rackCountModel.RackSeatId = seatId;
                            rackCountModel.ShopLevelId = levelId;
                            rackCountBll.Add(rackCountModel);
                        }
                    }
                }
            }
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('更新成功！')", true);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('更新失败：" + ex.Message + "')", true);
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LN.BLL;

public partial class WebUI_Promotion_RackInfo_SetRackLimitCount1 : System.Web.UI.Page
{
    POPSeat seatBll = new POPSeat();
    RackLimitCountBLL rackCountBll = new RackLimitCountBLL();
    LN.Model.RackLimitCount rackCountModel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindACL();
        }
    }

    void BindACL()
    {
       
        List<string> list = new List<string>() { "重点店铺", "基础店铺" };
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }

    

    List<LN.Model.POPSeat> seatList = new List<LN.Model.POPSeat>();
    string shopType = string.Empty;
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            shopType = (string)e.Item.DataItem;
           

            Repeater seatRepeater = (Repeater)e.Item.FindControl("Repeater2");
            if (seatList.Count == 0)
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
                rackCountModel = rackCountBll.GetModel(string.Format("ShopType='{0}' and RackSeatId={1}", shopType, item.SeatID));
                if (rackCountModel != null)
                {
                    tbCount.Text = rackCountModel.Count != null ? rackCountModel.Count.ToString() : "";
                }
            }
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hfShopType = (HiddenField)item.FindControl("hfShopType");
                    string shoptype = hfShopType.Value;
                    Repeater seatRepeater = (Repeater)item.FindControl("Repeater2");
                    foreach (RepeaterItem item1 in seatRepeater.Items)
                    {
                        HiddenField hfSeatId = (HiddenField)item1.FindControl("hfSeatId");
                        int seatId = int.Parse(hfSeatId.Value != "" ? hfSeatId.Value : "0");
                        TextBox tbCount = (TextBox)item1.FindControl("txtCount");
                        int count = !string.IsNullOrWhiteSpace(tbCount.Text) ? int.Parse(tbCount.Text.Trim()) : 0;
                        rackCountModel = rackCountBll.GetModel(string.Format("ShopType='{0}' and RackSeatId={1}", shoptype, seatId));
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
                            rackCountModel.ShopLevelId = 0;
                            rackCountModel.ShopType = shoptype;
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
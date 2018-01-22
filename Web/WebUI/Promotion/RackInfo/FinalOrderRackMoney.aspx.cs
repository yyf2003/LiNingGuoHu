using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LN.BLL;

public partial class WebUI_Promotion_RackInfo_FinalOrderRackMoney : System.Web.UI.Page
{
    int pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            pid = int.Parse(Request.QueryString["pid"].ToString());
        }
        if (!IsPostBack)
        {
            BindStoryBag();
        }
    }

    void BindStoryBag()
    {
        PromotionSonStoryBag sonStoryBagBll = new PromotionSonStoryBag();
        DataSet ds = sonStoryBagBll.GetList(pid);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    PromotionShopLevel shopLevelBll = new PromotionShopLevel();
    DataSet shopLevelList = null;
    int storyBagId = 0;
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                storyBagId = int.Parse(item["Id"].ToString());
            }

            Repeater shopLevelRepeater = (Repeater)e.Item.FindControl("Repeater2");
            if (shopLevelList==null)
            {
                shopLevelList = shopLevelBll.GetList("");
            }
            shopLevelRepeater.ItemDataBound += new RepeaterItemEventHandler(shopLevelRepeater_ItemDataBound);
            shopLevelRepeater.DataSource = shopLevelList;
            shopLevelRepeater.DataBind();
        }
    }

    void shopLevelRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int levelId = 0;
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                levelId = int.Parse(item["Id"].ToString());
            }
            decimal moneyNum=0;
            GetRackTotalMoney(storyBagId, levelId, out moneyNum);
            ((Label)e.Item.FindControl("labMoney")).Text = moneyNum.ToString();
        }
    }

    FinalPromotionShops finalShopBll = new FinalPromotionShops();
    ExportOrderRackBLL exportRackBll = new ExportOrderRackBLL();
    LN.Model.ExportOrderRack exportRackModel;
    Dictionary<int, List<LN.Model.PromotionShopInfo>> finalShopDic = new Dictionary<int, List<LN.Model.PromotionShopInfo>>();
    List<LN.Model.RackInfo> rackList = new List<LN.Model.RackInfo>();
    RackInShop rackInShopBll = new RackInShop();
    List<LN.Model.RackInShop> rackInShopList = new List<LN.Model.RackInShop>();
    void GetRackTotalMoney(int storyBagId, int shopLevelId, out decimal moneyNum)
    {
        moneyNum = 0;
        decimal subNum = 0;
        if (!finalShopDic.Keys.Contains(storyBagId))
        {
            List<LN.Model.PromotionShopInfo> list = finalShopBll.GetShopList(string.Format(" FinalPromotionShops.PromotionId={0} and FinalPromotionShops.StoryBagApplyId={1}", pid, storyBagId));
            if (list.Any())
            {
                finalShopDic.Add(storyBagId, list);
            }
        }
        if (finalShopDic.Keys.Contains(storyBagId))
        {
            List<LN.Model.PromotionShopInfo> list = finalShopDic[storyBagId];
            var shoplist = list.Where(s => s.ShopLevelId == shopLevelId);
            if (shoplist.Any())
            {
                //导入原始订单的时候，每个级别所选的道具
                exportRackModel = exportRackBll.GetModel(string.Format(" PromitionId={0} and StoryBagId={1} and ShopLevelId={2}", pid, storyBagId, shopLevelId));
                if (exportRackModel != null)
                {
                    string rackIds = exportRackModel.RackIds;
                    string[] rackIdArr = rackIds.Split(',');
                    if (!rackList.Any())
                    {
                        //所有道具信息
                        rackList = new RackInfo().GetRackList("");
                    }
                    if (rackIdArr.Length > 0)
                    { 
                        //累计每个店的道具(数量*价格）
                        shoplist.ToList().ForEach(s => {
                            if (!rackInShopList.Any())
                            {
                                rackInShopList = rackInShopBll.GetRackList("");
                            }
                            foreach (string rackid in rackIdArr)
                            {
                                if (!string.IsNullOrWhiteSpace(rackid))
                                {
                                    int rid = int.Parse(rackid);
                                    LN.Model.RackInShop rackInShopModel= rackInShopList.Where(r=>r.ShopId==s.ID && r.RackId==rid).FirstOrDefault();
                                    if (rackInShopModel != null)
                                    {
                                        int rackNum = rackInShopModel.RackCount??0;
                                        var rack = rackList.Where(r => r.Id == rid).FirstOrDefault();
                                        decimal price = rack != null ? (rack.Price ?? 0) : 0;
                                        subNum += rackNum * price;
                                    }
                                }
                            }
                        });
                    }
                }
            }
        }
        moneyNum = subNum;
    }
}
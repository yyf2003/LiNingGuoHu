using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using LN.BLL;
using System.Collections.Generic;

public partial class WebUI_Promotion_FinalExport : System.Web.UI.Page
{
    public int pid;
    int userId;
    Promotion promotionBll = new Promotion();
    LN.Model.Promotion promotionModel;
    
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

            promotionModel = promotionBll.GetModel(pid);
            if (promotionModel != null)
            {
                labPromotionId.Text = promotionModel.PromotionId;
                labTitle.Text = promotionModel.PromotionName;

            }
            BindSupplier();
            //BindRegion();
            BindBigArea();
            BindStoryBag();
            //BindShopLevel();
            BindACL();
           
        }
    }

    /// <summary>
    /// 绑定故事包
    /// </summary>
    void BindStoryBag()
    {

        //DataSet ds0 = new PromotionStorySeat().GetStoryBags(pid);
        DataSet ds0 = new PromotionSonStoryBag().GetList(pid);
        //rblStoryBag.DataSource = ds0;
        //rblStoryBag.DataTextField = "FullStoryBagName";
        //rblStoryBag.DataValueField = "Id";
        //rblStoryBag.DataBind();
        cblStoryBag.DataSource = ds0;
        cblStoryBag.DataTextField = "FullStoryBagName";
        cblStoryBag.DataValueField = "Id";
        cblStoryBag.DataBind();

    }

    /// <summary>
    /// 绑定店铺类型
    /// </summary>
    void BindShopLevel()
    {
        DataSet ds = new LN.BLL.PromotionShopLevel().GetList("");
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }


    void BindACL()
    {
        List<string> list = new List<string>() { "重点店铺", "基础店铺" };
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }
    /// <summary>
    /// 绑定分区
    /// </summary>
    void BindRegion()
    {
        DataSet ds = new DepartMentInfo().GetList(" State=1");
        rblRegion.DataSource = ds;
        rblRegion.DataTextField = "department";
        rblRegion.DataValueField = "ID";
        rblRegion.DataBind();
        rblRegion.Items.Add(new ListItem("全部", "0"));
    }

    void BindBigArea()
    {
        DataSet ds = new PromotionShopInfo().GetList("");
        List<string> areaList = new List<string>();
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            System.Text.StringBuilder allText = new System.Text.StringBuilder();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (!string.IsNullOrWhiteSpace(dr["BigArea"].ToString()) && !areaList.Contains(dr["BigArea"].ToString()))
                {
                    areaList.Add(dr["BigArea"].ToString());
                    ListItem li = new ListItem();
                    li.Text = dr["BigArea"].ToString();
                    li.Value = dr["BigArea"].ToString();
                    rblRegion.Items.Add(li);
                    //allText.AppendFormat("'{0}',",dr["BigArea"].ToString());
                }
            }
            ListItem li0 = new ListItem();
            li0.Text = "全部";
            li0.Value = "";
            rblRegion.Items.Add(li0);
        }
        
    }

    void BindSupplier()
    {
        IList<LN.Model.SupplierInfo> list = new SupplierInfo().GetList(" IsPromotion=1");
        if (list.Count > 0)
        {
            rblSupplier.DataSource = list;
            rblSupplier.DataTextField = "ShortName";
            rblSupplier.DataValueField = "SupplierID";
            rblSupplier.DataBind();
            rblSupplier.Items.Add(new ListItem("全部", "0"));
        }
    }

    /// <summary>
    /// 导出
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionList.aspx", false);
    }
    DataSet rackDs = null;
    /// <summary>
    /// 选择故事包获取道具
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rblStoryBag_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int sbApplyId = int.Parse((sender as RadioButtonList).SelectedValue);
        //LN.Model.PromotionSonStoryBag model = new PromotionSonStoryBag().GetModel(sbApplyId);
        //if (model != null)
        //{
        //    //hfSbId.Value = model.ParentStoryBagId.ToString();
        //    rackDs = promotionBll.GetExportRackInfo(pid, model.ParentStoryBagId);
        //    BindShopLevel();
        //}
    }
    /// <summary>
    /// 外层repeater行绑定，显示道具
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            //if (item != null)
            //{
            //    string levelName = item["ShortName"].ToString();
            //    shopLevelId = int.Parse(item["Id"].ToString());
            //    RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rblAddressType");
            //    if (levelName.ToLower() == "60+" || levelName.ToLower() == "big300")
            //    {
            //        rbl.Items[0].Selected = true;
            //    }
            //    else
            //    {
            //        rbl.Items[1].Selected = true;
            //    }
            //}
            Repeater dl = (Repeater)e.Item.FindControl("Repeater2");
            dl.ItemDataBound += new RepeaterItemEventHandler(dl_ItemDataBound);
            if (rackDs != null && rackDs.Tables[0].Rows.Count > 0)
            {
                dl.DataSource = rackDs;
                dl.DataBind();
            }
        }
    }

    int shopLevelId = 0;
    ExportOrderRackBLL exportRackBll = new ExportOrderRackBLL();
    LN.Model.ExportOrderRack exportRackModel;
    void dl_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if (shopLevelId > 0)
            {
                //int storyBagId = int.Parse(rblStoryBag.SelectedValue);
                int storyBagId = 0;
                System.Text.StringBuilder sbIds = new System.Text.StringBuilder();
                foreach (ListItem li in cblStoryBag.Items)
                {
                    if (li.Selected)
                    {
                        storyBagId = int.Parse(li.Value);
                        break;
                    }
                }
                
                int rackid = 0;
                DataRowView item = (DataRowView)e.Item.DataItem;
                if (item != null)
                {
                    rackid = int.Parse(item["rackId"].ToString());
                }
                CheckBox cb = (CheckBox)e.Item.FindControl("rackcbOne");
                exportRackModel = exportRackBll.GetModel(string.Format(" PromitionId={0} and StoryBagId={1} and ShopLevelId={2}", pid, storyBagId, shopLevelId));
                if (exportRackModel != null)
                {
                    string rackids = exportRackModel.RackIds;
                    if (!string.IsNullOrWhiteSpace(rackids))
                    {
                        string[] arr = rackids.Split(',');
                        foreach (string s in arr)
                        {
                            if (!string.IsNullOrWhiteSpace(s))
                            { 
                               if(string.Equals(s,rackid.ToString()))
                               {
                                   cb.Checked = true;
                                   break;
                               }
                            }
                        }
                    }
                }
            }
        }
    }


    /// <summary>
    /// 道具行绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
    //    {
            
    //    }
    //}
    protected void cblStoryBag_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int sbApplyId = int.Parse((sender as RadioButtonList).SelectedValue);
        //LN.Model.PromotionSonStoryBag model = new PromotionSonStoryBag().GetModel(sbApplyId);
        //if (model != null)
        //{
        //    //hfSbId.Value = model.ParentStoryBagId.ToString();
        //    rackDs = promotionBll.GetExportRackInfo(pid, model.ParentStoryBagId);
        //    BindShopLevel();
        //}
        hfParentStoryBagId.Value = "";
        hfSonStoryBagId.Value = "";
        System.Text.StringBuilder ids = new System.Text.StringBuilder();
        foreach (ListItem li in cblStoryBag.Items)
        {
            if (li.Selected)
            {
                ids.Append(li.Value + ",");
            }
        }
        hfSonStoryBagId.Value = ids.ToString().TrimEnd(',');
        string str = ids.Length > 0 ? ids.ToString().TrimEnd(',') : "0";
        List<LN.Model.PromotionSonStoryBag> storyBagList = new PromotionSonStoryBag().GetDataList(string.Format(" Id in ({0})", str));
        str = "0";
        if (storyBagList.Any())
        {
            System.Text.StringBuilder sbIds = new System.Text.StringBuilder();
            storyBagList.ForEach(s =>
            {
                sbIds.Append(s.ParentStoryBagId + ",");
            });

            hfParentStoryBagId.Value = str = sbIds.ToString().TrimEnd(',');
        }
        rackDs = promotionBll.GetExportRackInfo(pid, str);
        //BindShopLevel();
        BindACL();
    }

    protected void btnExportRackInfo_Click(object sender, EventArgs e)
    {

    }
}
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using LN.BLL;
using System.Collections.Generic;



public partial class WebUI_Promotion_PromotionFive : System.Web.UI.Page
{
    public int pid;
    int userId;
    PromotionPOPOrder orderBll = new PromotionPOPOrder();
    RackInShop rackInShopBll = new RackInShop();
    LN.Model.PromotionPOPOrder orderModel;

    Promotion promotionBll = new Promotion();
    LN.Model.Promotion promotionModel;
    public int orderCount = 0;
    DataSet rackInShopDs = new DataSet();
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
        if (Request.QueryString["isexport"] != null && Request.QueryString["isexport"].ToString()=="1")
        {
            Button1.Visible = false;
            btnOk.Text = "返回";
        }
        //rackInShopDs = rackInShopBll.GetList("");
        

        if (!IsPostBack)
        {

            promotionModel = promotionBll.GetModel(pid);
            if (promotionModel != null)
            {
                labPromotionId.Text = promotionModel.PromotionId;
                labTitle.Text = promotionModel.PromotionName;

            }
            BindACL();
            //BindShopLevel();
            BindStoryBag();
            //Panel1.Visible = orderCount > 0;
        }

    }

    /// <summary>
    /// 获取参加推广的店铺（非推广店铺的订单不能导入）
    /// </summary>
    /// 

    ArrayList GetAreaShop()
    {
        ArrayList shoplist = new ArrayList();
        PromotionShops promotionshopBll = new PromotionShops();
        DataSet ds = promotionshopBll.GetList(string.Format(" PromotionId={0}", pid));
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (!shoplist.Contains(dr["ShopId"].ToString()))
                {
                    shoplist.Add(dr["ShopId"].ToString());
                }
            }
        }
        return shoplist;
    }

    void BindStoryBag()
    {

        //DataSet ds0 = new PromotionStorySeat().GetStoryBags(pid);
        cblStoryBag.Items.Clear();
        DataSet ds0 = new PromotionSonStoryBag().GetList(pid);
        if (ds0 != null && ds0.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds0.Tables[0].Rows)
            {
                ListItem li = new ListItem();
                li.Value = dr["Id"].ToString();
                li.Text = dr["FullStoryBagName"].ToString();
                
                cblStoryBag.Items.Add(li);
            }
        }
        //rblStoryBag.DataSource = ds0;
        //rblStoryBag.DataTextField = "FullStoryBagName";
        //rblStoryBag.DataValueField = "Id";
        //rblStoryBag.DataBind();
        //cblStoryBag.DataSource = ds0;
        //cblStoryBag.DataTextField = "FullStoryBagName";
        //cblStoryBag.DataValueField = "Id";
        //cblStoryBag.DataBind();

        
    }

    /// <summary>
    /// 按照区县级城市级别导出
    /// </summary>
    void BindACL()
    {
        //List<ACLItem> list = new List<ACLItem>();
        //ACLItem model = new ACLItem() {Name="重点店铺" };
        //list.Add(model);
        //model = new ACLItem() { Name = "基础店铺" };
        //list.Add(model);
        List<string> list = new List<string>() { "重点店铺", "基础店铺" };
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }



    
    protected void BtnFinish_Click(object sender, EventArgs e)
    {
        promotionModel = new LN.Model.Promotion();
        promotionModel.State = 1;//1：提交成功
        promotionModel.Id = pid;
        promotionBll.Update(promotionModel);
        ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('提交成功！');window.location.href='PromotionList.aspx'", true);

    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionFour.aspx?id=" + pid, false);
    }
    

    

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("PromotionFour.aspx?id=" + pid, false);
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionList.aspx", false);
    }

    void BindShopLevel()
    {
        DataSet ds = new LN.BLL.PromotionShopLevel().GetList("");
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    int shopLevelId = 0;
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            //if (item != null)
            //{
                //string name = item["Name"].ToString();
                //shopLevelId = int.Parse(item["Id"].ToString());
                //RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rblAddressType");
                //if (levelName.ToLower() == "60+" || levelName.ToLower() == "big300")
                //{
                //    rbl.Items[0].Selected = true;
                //}
                //else
                //{
                //    rbl.Items[1].Selected = true;
                //}
                //string s = (string)item[0];
                //((Label)e.Item.FindControl("labACL")).Text = name;
                //((HiddenField)e.Item.FindControl("hfACL")).Value = name;
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
                if (!string.IsNullOrWhiteSpace(hfSonStoryBagId.Value))
                    storyBagId = int.Parse(hfSonStoryBagId.Value.Split(',')[0]);
                int rackid = 0;
                DataRowView item = (DataRowView)e.Item.DataItem;
                if (item != null)
                {
                    rackid = int.Parse(item["rackId"].ToString());
                }
                CheckBox cb = (CheckBox)e.Item.FindControl("rackcbOne");
                exportRackModel = exportRackBll.GetModel(string.Format(" PromitionId={0} and StoryBagId ={1} and ShopLevelId={2}", pid, storyBagId, shopLevelId));
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
                                if (string.Equals(s, rackid.ToString()))
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

    DataSet rackDs = null;
    protected void rblStoryBag_SelectedIndexChanged(object sender, EventArgs e)
    {
        int sbApplyId = int.Parse((sender as RadioButtonList).SelectedValue);
        LN.Model.PromotionSonStoryBag model = new PromotionSonStoryBag().GetModel(sbApplyId);
        if (model != null)
        {
            //hfSbId.Value = model.ParentStoryBagId.ToString();
            hfSbId.Value = model.Id.ToString();
            rackDs = promotionBll.GetExportRackInfo(pid, model.ParentStoryBagId);
            //BindShopLevel();
            BindACL();
        }
        
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    protected void cblStoryBag_SelectedIndexChanged(object sender, EventArgs e)
    {
        hfParentStoryBagId.Value = "";
        hfSonStoryBagId.Value = "";
        System.Text.StringBuilder ids = new System.Text.StringBuilder();
        foreach (ListItem li in cblStoryBag.Items)
        {
            if (li.Selected)
            {
                ids.Append(li.Value+",");
            }
        }
        hfSonStoryBagId.Value = ids.ToString().TrimEnd(',');
        string str=ids.Length>0?ids.ToString().TrimEnd(','):"0";
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
        BindACL();
    }
}

public class ACLItem
{
    public string Name { get; set; }
}
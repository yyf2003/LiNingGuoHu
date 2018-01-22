using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LN.BLL;

public partial class WebUI_Promotion_Shops_Edit : BasePage
{
    int shopId;
    PromotionShopInfo bll = new PromotionShopInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["shopid"] != null)
        {
            shopId = int.Parse(Request.QueryString["shopid"]);
        }
        if (!IsPostBack)
        {
            BindDLLData();
            BindData();
        }
    }

    void BindDLLData()
    {
        List<LN.Model.PromotionShopInfo> shopList = bll.GetDataList("");
        if (shopList.Any())
        {
            var CustomerCardLit = shopList.Select(s => s.CustomerCard).Distinct().OrderBy(s => s).ToList();
            CustomerCardLit.ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    ListItem li = new ListItem();
                    li.Text = s;
                    li.Value = s;
                    ddlCustomerCard.Items.Add(li);
                }
            });
            var BigAreaLit = shopList.Select(s => s.BigArea).Distinct().OrderBy(s => s).ToList();
            BigAreaLit.ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    ListItem li = new ListItem();
                    li.Text = s;
                    li.Value = s;
                    ddlBigArea.Items.Add(li);
                }
            });
            var ShopOwnerShipLit = shopList.Select(s => s.ShopOwnerShip).Distinct().OrderBy(s => s).ToList();
            ShopOwnerShipLit.ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    ListItem li = new ListItem();
                    li.Text = s;
                    li.Value = s;
                    ddlShopOwnerShip.Items.Add(li);
                }
            });
        }

        DataSet ShopStateDs = new ShopStateInfo().GetList("");
        if (ShopStateDs != null && ShopStateDs.Tables[0].Rows.Count > 0)
        {
            ddlShopState.DataSource = ShopStateDs;
            ddlShopState.DataTextField = "ShopState";
            ddlShopState.DataValueField = "ID";
            ddlShopState.DataBind();
            ddlShopState.Items.Insert(0,new ListItem("--请选择--","-1"));
        }

        DataSet DepartmentList = new DepartMentInfo().GetList(" State=1 ");
        if (DepartmentList != null && DepartmentList.Tables[0].Rows.Count > 0)
        {
            ddlArea.DataSource = DepartmentList;
            ddlArea.DataTextField = "department";
            ddlArea.DataValueField = "ID";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        IList<LN.Model.ProvinceData> ProvinceList = new ProvinceData().GetList("State=1");
        if (ProvinceList.Any())
        {
            ProvinceList.ToList().ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s.ProvinceName))
                {
                    ListItem li = new ListItem();
                    li.Text = s.ProvinceName;
                    li.Value = s.ProvinceID.ToString();
                    ddlProvince.Items.Add(li);
                }
            });
        }

        IList<LN.Model.TownCityLevel> TCLList = new TownCityLevel().GetList("");
        if (TCLList.Any())
        {
            TCLList.ToList().ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s.TCL_Name))
                {
                    ListItem li = new ListItem();
                    li.Text = s.TCL_Name;
                    li.Value = s.TCL_Id.ToString();
                    ddlTCL.Items.Add(li);
                }
            });
        }

        IList<LN.Model.AreaCityLevel> ACLList = new AreaCityLevel().GetList("");
        if (ACLList.Any())
        {
            ACLList.ToList().ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s.ACL_Name))
                {
                    ListItem li = new ListItem();
                    li.Text = s.ACL_Name;
                    li.Value = s.ACL_Id.ToString();
                    ddlACL.Items.Add(li);
                }
            });
        }

        DataSet SaleTypeList = new SaleTypeInfo().GetList("");
        if (SaleTypeList != null && SaleTypeList.Tables[0].Rows.Count > 0)
        {
            ddlSaleType.DataSource = SaleTypeList;
            ddlSaleType.DataTextField = "SaleType";
            ddlSaleType.DataValueField = "SaleTypeID";
            ddlSaleType.DataBind();
            ddlSaleType.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        List<LN.Model.ShopType> ShopTypeList = new ShopType().GetList("");
        if (ShopTypeList.Any())
        {
            ShopTypeList.ToList().ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s.ShopTypename))
                {
                    ListItem li = new ListItem();
                    li.Text = s.ShopTypename;
                    li.Value = s.ID.ToString();
                    ddlShopType.Items.Add(li);
                }
            });
        }

        DataSet ShopLevelList = new PromotionShopLevel().GetList("");
        if (ShopLevelList != null && ShopLevelList.Tables[0].Rows.Count > 0)
        {
            ddlShopLevel.DataSource = ShopLevelList;
            ddlShopLevel.DataTextField = "ShortName";
            ddlShopLevel.DataValueField = "Id";
            ddlShopLevel.DataBind();
            ddlShopLevel.Items.Insert(0, new ListItem("--请选择--", "0"));
        }

        DataSet ShopImageList = new PromotionShopImage().GetList("");
        if (ShopImageList != null && ShopImageList.Tables[0].Rows.Count > 0)
        {
            ddlShopImage.DataSource = ShopImageList;
            ddlShopImage.DataTextField = "ImageName";
            ddlShopImage.DataValueField = "Id";
            ddlShopImage.DataBind();
            ddlShopImage.Items.Insert(0, new ListItem("--请选择--", "0"));
        }
    }

    void BindCity()
    {
        ddlCity.Items.Clear();
        ddlCity.Items.Insert(0, new ListItem("--请选择--", "0"));
        int provinceId = int.Parse(ddlProvince.SelectedValue);
        IList<LN.Model.CityData> list = new CityData().GetList(string.Format(" ProvinceID={0}", provinceId));
        if (list.Any())
        {
            list.ToList().ForEach(s =>
            {
                if (!string.IsNullOrWhiteSpace(s.CityName))
                {
                    ListItem li = new ListItem();
                    li.Text = s.CityName;
                    li.Value = s.CItyID.ToString();
                    ddlCity.Items.Add(li);
                }
            });
        }
    }

    void BindData()
    {
        
        LN.Model.PromotionShopInfo model = bll.GetModel(shopId);
        if (model != null)
        {
            txtShopNo.Text = model.PosID;
            txtShopName.Text = model.Shopname;
            txtShopsamplename.Text = model.Shopsamplename;
            txtShopAddress.Text = model.ShopAddress;
            txtPostAddress.Text = model.PostAddress;
            txtShopCategory.Text = model.ShopCategory;
            txtLinkMan.Text = model.LinkMan;
            txtLinkPhone.Text = model.LinkPhone;
            txtDealerID.Text = model.DealerID;
            txtDealerName.Text = model.DealerName;
            txtFXID.Text = model.FXID;
            txtFXName.Text = model.FXName;
            ddlCustomerCard.SelectedValue = model.CustomerCard;
            if (model.ShopState!=null)
               ddlShopState.SelectedValue = model.ShopState.ToString();
            ddlBigArea.SelectedValue = model.BigArea;
            if (model.areaid != null)
               ddlArea.SelectedValue = model.areaid.ToString();
            if (model.ProvinceID != null)
            {
                ddlProvince.SelectedValue = model.ProvinceID.ToString();
                BindCity();
                if (model.CityID != null)
                   ddlCity.SelectedValue = model.CityID.ToString();
            }
            if (model.TCL_ID != null)
                ddlTCL.SelectedValue = model.TCL_ID.ToString();
            if (model.ACL_ID != null)
                ddlACL.SelectedValue = model.ACL_ID.ToString();
            if (model.SaleTypeID != null)
                ddlSaleType.SelectedValue = model.SaleTypeID.ToString();
            if (model.ShopType != null)
                ddlShopType.SelectedValue = model.ShopType.ToString();
            if (model.ShopLevelId != null)
                ddlShopLevel.SelectedValue = model.ShopLevelId.ToString();
            if (model.ShopImageId != null)
                ddlShopImage.SelectedValue = model.ShopImageId.ToString();
            ddlShopOwnerShip.SelectedValue = model.ShopOwnerShip;
        }
    }


    protected void btnSumbitEdit_Click(object sender, EventArgs e)
    {
        string posId = txtShopNo.Text.Trim();
        string shopName = txtShopName.Text.Trim();
        string shopsamplename = txtShopsamplename.Text.Trim();
        string shopAddress = txtShopAddress.Text.Trim();
        string postAddress = txtPostAddress.Text.Trim();
        string linkMan = txtLinkMan.Text.Trim();
        string linkPhone = txtLinkPhone.Text.Trim();
        string dealerID = txtDealerID.Text.Trim();
        string dealerName = txtDealerName.Text.Trim();
        string FXID = txtFXID.Text.Trim();
        string FXName = txtFXName.Text.Trim();
        string customerCard = ddlCustomerCard.SelectedValue;
        int shopState = int.Parse(ddlShopState.SelectedValue);
        string bigArea = ddlBigArea.SelectedValue;
        int areaId = int.Parse(ddlArea.SelectedValue);
        int provinceId = int.Parse(ddlProvince.SelectedValue);
        int cityId = int.Parse(ddlCity.SelectedValue);
        int TCLId = int.Parse(ddlTCL.SelectedValue);
        int ACLId = int.Parse(ddlACL.SelectedValue);
        int saleType = int.Parse(ddlSaleType.SelectedValue);
        int shopType = int.Parse(ddlShopType.SelectedValue);
        int shopLevel = int.Parse(ddlShopLevel.SelectedValue);
        int shopImage = int.Parse(ddlShopImage.SelectedValue);
        string shopOwnerShip = ddlShopOwnerShip.SelectedValue;
        string shopCategory = txtShopCategory.Text.Trim();

        var list= bll.GetDataList(string.Format(" PosID='{0}' and Id!={1}",posId,shopId));
        if (list.Any())
        {
            //ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('店铺编号重复')",true);
            Alert("店铺编号重复");
            return;
        }
        LN.Model.PromotionShopInfo model = bll.GetModel(shopId);
        if (model != null)
        {
            model.ACL_ID = ACLId;
            model.areaid = areaId;
            model.BigArea = bigArea;
            model.CityID = cityId;
            model.CustomerCard = customerCard;
            model.DealerID = dealerID;
            model.DealerName = dealerName;
            model.FXID = FXID;
            model.FXName = FXName;
            model.LinkMan = linkMan;
            model.LinkPhone = linkPhone;
            model.PosID = posId;
            model.ShopAddress = shopAddress;
            model.PostAddress = postAddress;
            model.ProvinceID = provinceId;
            model.SaleTypeID = saleType;
            model.ShopCategory = shopCategory;
            model.ShopImageId = shopImage;
            model.ShopLevelId = shopLevel;
            model.Shopname = shopName;
            model.ShopOwnerShip = shopOwnerShip;
            model.Shopsamplename = shopsamplename;
            model.ShopState = shopState;
            model.ShopType = shopType;
            model.TCL_ID = TCLId;
            bll.Update(model);
            //ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>Finish()</script>", true);
            ExcuteJs("Finish");
        }
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity();
    }
}
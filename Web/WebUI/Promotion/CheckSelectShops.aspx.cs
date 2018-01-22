using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LN.BLL;
using System.Data;

public partial class WebUI_Promotion_CheckSelectShops : System.Web.UI.Page
{
    string shopSaleType = string.Empty;
    string shopLevel = string.Empty;
    string shopType = string.Empty;
    string shopVI = string.Empty;
    string AreaCityLevel = string.Empty;
    string TownCityLevel = string.Empty;
    string Area = string.Empty;
    string Province = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["shopsaletype"] != null)
        {
            
            shopSaleType = Request.QueryString["shopsaletype"].ToString();
        }
        if (Request.QueryString["shoplevel"] != null)
        {
            
            shopLevel = Request.QueryString["shoplevel"].ToString();
        }
        if (Request.QueryString["shoptype"] != null)
        {
            shopType = Request.QueryString["shoptype"].ToString();
        }
        if (Request.QueryString["shopvi"] != null)
        {
            shopVI = Request.QueryString["shopvi"].ToString();
        }
        //if (Request.QueryString["areacitylevel"] != null)
        //{
        //    AreaCityLevel = Request.QueryString["areacitylevel"].ToString();
        //}
        //if (Request.QueryString["towncitylevel"] != null)
        //{
        //    TownCityLevel = Request.QueryString["towncitylevel"].ToString();
        //}
        if (Request.QueryString["area"] != null)
        {
            Area = Request.QueryString["area"].ToString();
        }
        if (Request.QueryString["province"] != null)
        {
            Province = Request.QueryString["province"].ToString();
        }
        if (!IsPostBack)
        {
            GetList();
        }
    }

    void GetList()
    {
        System.Text.StringBuilder where = new System.Text.StringBuilder();
        where.Append(" 1=1");
        if (!string.IsNullOrWhiteSpace(shopSaleType))
        {
            shopSaleType = shopSaleType.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.SaleTypeID in({0})", shopSaleType);
        }
        if (!string.IsNullOrWhiteSpace(shopLevel))
        {
            shopLevel = shopLevel.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ShopLevelId in({0})", shopLevel);
        }
        if (!string.IsNullOrWhiteSpace(shopType))
        {
            shopType = shopType.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ShopType in({0})", shopType);
        }
        if (!string.IsNullOrWhiteSpace(shopVI))
        {
            //店铺形象
            shopVI = shopVI.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ShopImageId in({0})", shopVI);
        }
        //if (!string.IsNullOrWhiteSpace(AreaCityLevel))
        //{
        //    AreaCityLevel = AreaCityLevel.TrimEnd(',');
        //    where.AppendFormat(" and PromotionShopInfo.ACL_ID in({0})", AreaCityLevel);
        //}
        //if (!string.IsNullOrWhiteSpace(TownCityLevel))
        //{
        //    TownCityLevel = TownCityLevel.TrimEnd(',');
        //    where.AppendFormat(" and PromotionShopInfo.TCL_ID in({0})", TownCityLevel);
        //}
        if (!string.IsNullOrWhiteSpace(Province))
        {
            Province = Province.TrimEnd(',');
            where.AppendFormat(" and PromotionShopInfo.ProvinceID in({0})", Province);
        }
        else if (!string.IsNullOrWhiteSpace(Area))
        {
            Area = Area.TrimEnd(',');
            //ProvinceData provinceBll = new ProvinceData();
            //IList<LN.Model.ProvinceData> list = provinceBll.GetList(string.Format(" PromotionShopInfo.areaid in ({0})", Area));
            //if (list.Count > 0)
            //{
            //    list.ToList().ForEach(s =>
            //    {
            //        Province += s.ProvinceID + ",";
            //    });
            //    if (!string.IsNullOrWhiteSpace(Province))
            //    {
            //        Province = Province.TrimEnd(',');
            //        where.AppendFormat(" and ProvinceID in({0})", Province);
            //    }
            //}
            where.AppendFormat(" and PromotionShopInfo.areaid in({0})", Area);
        }
        DataSet ds = new LN.BLL.PromotionShopInfo().GetJoinList(where.ToString());
        DataTable dt = ds.Tables[0];
        labTotalNum.Text = dt.Rows.Count.ToString();
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
}
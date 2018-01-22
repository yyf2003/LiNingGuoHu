using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using LN.BLL;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

public partial class WebUI_Promotion_Shops_ShopList : System.Web.UI.Page
{
    PromotionShopInfo shopBll = new PromotionShopInfo();
    StringBuilder where = new StringBuilder();
    string rackType = string.Empty;
    string rackOperater = string.Empty;
    int rackNum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSearch();
            BindData();
        }
    }

    

    /// <summary>
    /// 绑定查询条件
    /// </summary>
    void BindSearch()
    {
        //省区
        DepartMentInfo areaBll = new DepartMentInfo();
        DataSet areas = areaBll.GetList(" State=1");
        ddlArea.DataSource = areas;
        ddlArea.DataTextField = "department";
        ddlArea.DataValueField = "ID";
        ddlArea.DataBind();
        ddlArea.Items.Insert(0, new ListItem("全部","0"));

        //省份
        ProvinceData provinceBll = new ProvinceData();
        IList<LN.Model.ProvinceData> provinces = provinceBll.GetList(" State=1");
        ddlProvince.DataSource = provinces;
        ddlProvince.DataTextField = "ProvinceName";
        ddlProvince.DataValueField = "ProvinceID";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("全部", "0"));

        //店铺级别
        PromotionShopLevel levelBll = new PromotionShopLevel();
        DataSet levels = levelBll.GetList("");
        cblShopLevel.DataSource = levels;
        cblShopLevel.DataTextField = "ShopLevelName";
        cblShopLevel.DataValueField = "Id";
        cblShopLevel.DataBind();
        

        //店铺形象
        PromotionShopImage imageBll = new PromotionShopImage();
        DataSet imageds = imageBll.GetList("");
        cblShopImage.DataSource = imageds;
        cblShopImage.DataTextField = "ImageName";
        cblShopImage.DataValueField = "Id";
        cblShopImage.DataBind();

        //店铺类型
        ShopType ShopTypeBll = new ShopType();
        IList<LN.Model.ShopType> shopTypes = ShopTypeBll.GetList("");
        cblShopType.DataSource = shopTypes;
        cblShopType.DataTextField = "ShopTypename";
        cblShopType.DataValueField = "ID";
        cblShopType.DataBind();

        //零售属性
        SaleTypeInfo SaleTypeInfoBll = new SaleTypeInfo();
        DataSet saleTypeds = SaleTypeInfoBll.GetList("");
        cblShopSaleType.DataSource = saleTypeds;
        cblShopSaleType.DataTextField = "SaleType";
        cblShopSaleType.DataValueField = "SaleTypeID";
        cblShopSaleType.DataBind();

        //店铺状态
        ShopStateInfo ShopStateInfoBll = new ShopStateInfo();
        DataSet shopStateds = ShopStateInfoBll.GetList("");
        cblShopState.DataSource = shopStateds;
        cblShopState.DataTextField = "ShopState";
        cblShopState.DataValueField = "ID";
        cblShopState.DataBind();

        //道具类型
        POPSeat seatBll = new POPSeat();
        IList<LN.Model.POPSeat> seatList = seatBll.GetList(" IsPomosion=1");
        ddlRackType.DataSource = seatList;
        ddlRackType.DataTextField = "seat";
        ddlRackType.DataValueField = "SeatID";
        ddlRackType.DataBind();
        ddlRackType.Items.Insert(0, new ListItem("--请选择--", "0"));
    }


    void GetSearchCondition()
    {
        if (ddlArea.SelectedValue != "0")
        {
            where.AppendFormat(" and PromotionShopInfo.areaid={0}", ddlArea.SelectedValue);
        }
        //店铺级别
        StringBuilder levels = new StringBuilder();
        foreach (ListItem li in cblShopLevel.Items)
        {
            if (li.Selected)
            {
                levels.Append(li.Value+",");
            }
        }
        if (levels.Length > 0)
        {
            where.AppendFormat(" and PromotionShopInfo.ShopLevelId in ({0})", levels.ToString().TrimEnd(','));
        }

        //店铺形象
        StringBuilder images = new StringBuilder();
        foreach (ListItem li in cblShopImage.Items)
        {
            if (li.Selected)
            {
                images.Append(li.Value + ",");
            }
        }
        if (images.Length > 0)
        {
            where.AppendFormat(" and PromotionShopInfo.ShopImageId in ({0})", images.ToString().TrimEnd(','));
        }

        //店铺类型
        StringBuilder types = new StringBuilder();
        foreach (ListItem li in cblShopType.Items)
        {
            if (li.Selected)
            {
                types.Append(li.Value + ",");
            }
        }
        if (types.Length > 0)
        {
            where.AppendFormat(" and PromotionShopInfo.ShopType in ({0})", types.ToString().TrimEnd(','));
        }

        //零售属性
        StringBuilder saleTypes = new StringBuilder();
        foreach (ListItem li in cblShopSaleType.Items)
        {
            if (li.Selected)
            {
                saleTypes.Append(li.Value + ",");
            }
        }
        if (saleTypes.Length > 0)
        {
            where.AppendFormat(" and PromotionShopInfo.SaleTypeID in ({0})", saleTypes.ToString().TrimEnd(','));
        }

        //店铺状态
        StringBuilder states = new StringBuilder();
        foreach (ListItem li in cblShopState.Items)
        {
            if (li.Selected)
            {
                states.Append(li.Value + ",");
            }
        }
        if (states.Length > 0)
        {
            where.AppendFormat(" and PromotionShopInfo.ShopState in ({0})", states.ToString().TrimEnd(','));
        }
        string shopNo = txtShopNo.Text.Trim();
        if (!string.IsNullOrWhiteSpace(shopNo))
        {
            where.AppendFormat(" and PromotionShopInfo.PosID like '%{0}%'", shopNo);
        }
        string shopName = txtShopName.Text.Trim();
        if (!string.IsNullOrWhiteSpace(shopName))
        {
            where.AppendFormat(" and PromotionShopInfo.Shopname like '%{0}%'", shopName);
        }
        //道具信息
        if (ddlRackType.SelectedValue != "0")
        {
            rackType = ddlRackType.SelectedValue;
            rackOperater = ddlOperater.SelectedValue;
            if (!string.IsNullOrWhiteSpace(txtRackNum.Text))
                rackNum = int.Parse(txtRackNum.Text);
        }
    }
    
    void BindData()
    {
        where.Clear();
        GetSearchCondition();
        int totalRecord = 0;
        DataSet ds = shopBll.GetJoinList(where.ToString(), rackType, rackOperater, rackNum, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, out totalRecord);
        AspNetPager1.RecordCount = totalRecord;
        Repeater1.DataSource = ds.Tables[0];
        Repeater1.DataBind();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AspNetPager1.CurrentPageIndex = 1;
        BindData();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void lbExport_Click(object sender, EventArgs e)
    {
        GetSearchCondition();
        int totalRecord1 = 0;
        DataSet ds = shopBll.GetJoinList(where.ToString(), rackType, rackOperater, rackNum, 1, 1, out totalRecord1);
        NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
        NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
        NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
        row1.CreateCell(0).SetCellValue("店铺编号");
        row1.CreateCell(1).SetCellValue("店铺名称");
        row1.CreateCell(2).SetCellValue("店铺简称");
        row1.CreateCell(3).SetCellValue("店铺营业地址");
        row1.CreateCell(4).SetCellValue("上级客户编码");
        row1.CreateCell(5).SetCellValue("上级客户名称");
        row1.CreateCell(6).SetCellValue("直属客户编码");
        row1.CreateCell(7).SetCellValue("直属客户名称");
        row1.CreateCell(8).SetCellValue("直属客户身份");
        row1.CreateCell(9).SetCellValue("店铺状态");
        row1.CreateCell(10).SetCellValue("省区");
        row1.CreateCell(11).SetCellValue("省份");
        row1.CreateCell(12).SetCellValue("城市");
        row1.CreateCell(13).SetCellValue("城市级别");
        row1.CreateCell(14).SetCellValue("区县级城市级别");
        row1.CreateCell(15).SetCellValue("店铺零售属性");
        row1.CreateCell(16).SetCellValue("店铺类型");
        row1.CreateCell(17).SetCellValue("店铺级别");
        row1.CreateCell(18).SetCellValue("店铺形象");
        row1.CreateCell(19).SetCellValue("店铺产权关系");
        
        
        int rowIndex = 1;
        foreach (DataRow dr in ds.Tables[1].Rows)
        {
            NPOI.SS.UserModel.IRow rowTemp = sheet1.CreateRow(rowIndex);
            rowTemp.CreateCell(0).SetCellValue(dr["PosID"].ToString());
            rowTemp.CreateCell(1).SetCellValue(dr["Shopname"].ToString());
            rowTemp.CreateCell(2).SetCellValue(dr["Shopsamplename"].ToString());
            rowTemp.CreateCell(3).SetCellValue(dr["ShopAddress"].ToString());
            rowTemp.CreateCell(4).SetCellValue(dr["DealerID"].ToString());
            rowTemp.CreateCell(5).SetCellValue(dr["DealerName"].ToString());
            rowTemp.CreateCell(6).SetCellValue(dr["FXID"].ToString());
            rowTemp.CreateCell(7).SetCellValue(dr["FXName"].ToString());
            rowTemp.CreateCell(8).SetCellValue(dr["CustomerCard"].ToString());
            rowTemp.CreateCell(9).SetCellValue(dr["ShopState"].ToString());
            rowTemp.CreateCell(10).SetCellValue(dr["AreaName"].ToString());
            rowTemp.CreateCell(11).SetCellValue(dr["ProvinceName"].ToString());
            rowTemp.CreateCell(12).SetCellValue(dr["CityName"].ToString());
            rowTemp.CreateCell(13).SetCellValue(dr["TCL_Name"].ToString());
            rowTemp.CreateCell(14).SetCellValue(dr["ACL_Name"].ToString());
            rowTemp.CreateCell(15).SetCellValue(dr["SaleType"].ToString());
            rowTemp.CreateCell(16).SetCellValue(dr["ShopTypename"].ToString());
            rowTemp.CreateCell(17).SetCellValue(dr["ShopLevelName"].ToString());
            rowTemp.CreateCell(18).SetCellValue(dr["ImageName"].ToString());
            rowTemp.CreateCell(19).SetCellValue(dr["ShopOwnerShip"].ToString());
            
            rowIndex++;
        }

        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        book.Write(ms);
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", System.Web.HttpUtility.UrlEncode("店铺信息", System.Text.Encoding.UTF8)));
        Response.BinaryWrite(ms.ToArray());

        book = null;
        ms.Close();
        ms.Dispose();
    }
}
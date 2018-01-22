using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
public partial class WebUI_POPLanuch_POPLaunchSetCiyt : System.Web.UI.Page
{
    protected string POPID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
       
        POPID = Request.QueryString["popid"].ToString();

        if (!Page.IsPostBack)
        {
            GetShopST();
            GetShoplevel();
            GetShopType();
            GetShopVI();
            GetArea();
            GetProvince();
            GetShopACL();
            GetShopTCL();
            GetPOPName();
            GetPOPImageData();
            //GetCity();
            //GetTown();

        }
    }

    /// <summary>
    /// 获取全部大区域
    /// </summary>
    private void GetArea()
    {
        IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList("");
        StringBuilder areaStr = new StringBuilder();
        for (int i = 0; i < AreaList.Count; i++)
        {
            areaStr.Append("<input value=\"" + AreaList[i].AreaID.ToString() + "\" name=\"area\" id=\"" + AreaList[i].AreaID.ToString() + "\" onclick='GetProvince(this.id)' type=\"checkbox\"/ >" + AreaList[i].AreaName + "\t");
        }

        this.Lit_Area.Text = areaStr.ToString();
    }
    /// <summary>
    /// 得到店铺零售属性
    /// </summary>
    private void GetShopST()
    {
        DataSet ds = new LN.BLL.SaleTypeInfo().GetList("");
        DataTable dt = ds.Tables[0];
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            levelstr.Append("<input value=\"" + dt.Rows[i]["SaleTypeID"].ToString() + "\" id=\"" + dt.Rows[i]["SaleTypeID"].ToString() + "\"checked=\"checked\"  name=\"SaleType\" type=\"checkbox\"/ >" + dt.Rows[i]["SaleType"].ToString());
        }
        Literal_ShopSA.Text = levelstr.ToString();

    }

    /// <summary>
    /// 得到店铺级别
    /// </summary>
    private void GetShoplevel()
    {
        DataSet ds = new LN.BLL.ShopLevel().GetList("");
        DataTable dt = ds.Tables[0];
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            levelstr.Append("<input value=\"" + dt.Rows[i]["LevelID"].ToString() + "\" id=\"" + dt.Rows[i]["LevelID"].ToString() + "\"checked=\"checked\"  name=\"level\" type=\"checkbox\"/ >" + dt.Rows[i]["ShopLevel"].ToString());
        }
        Literal_Shoplevel.Text = levelstr.ToString();
    }

    /// <summary>
    /// 加载店铺类型 
    /// </summary>
    private void GetShopType()
    {
        IList<LN.Model.ShopType> typelist = new LN.BLL.ShopType().GetList("");
        StringBuilder typestr = new StringBuilder();
        foreach (LN.Model.ShopType model in typelist)
        {
            typestr.Append("<input value=\"" + model.ID + "\" id=\"" + model.ID + "\"checked=\"checked\"  name=\"ck_shoptype\" type=\"checkbox\"/ >" + model.ShopTypename);
        }
        Lit_shoptype.Text = typestr.ToString();
    }

    private void GetShopVI()
    {
        IList<LN.Model.ShopVI> VIlist = new LN.BLL.ShopVI().GetList("");
        StringBuilder vistr = new StringBuilder();
        foreach (LN.Model.ShopVI model in VIlist)
        {
            vistr.Append("<input value=\"" + model.ShopVIID + "\" id=\"" + model.ShopVIID + "\"checked=\"checked\"  name=\"ck_shopVI\" type=\"checkbox\"/ >" + model.ShopVIName);
        }
        Lit_shopVI.Text = vistr.ToString();
    }

    /// <summary>
    /// 地市级城市级别-市场定义
    /// </summary>
    private void GetShopACL()
    {
        IList<LN.Model.AreaCityLevel> list = new LN.BLL.AreaCityLevel().GetList("");
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            levelstr.Append("<input value=\"" + list[i].ACL_Id.ToString() + "\" id=\"" + list[i].ACL_Id.ToString() + "\"checked=\"checked\"  name=\"AreaCityLevel\" type=\"checkbox\"/ >" + list[i].ACL_Name);
        }
        Lit_ACL.Text = levelstr.ToString();
    }

    /// <summary>
    /// 区县级城市级别-市场定义
    /// </summary>
    private void GetShopTCL()
    {
        IList<LN.Model.TownCityLevel> list = new LN.BLL.TownCityLevel().GetList("");
        StringBuilder levelstr = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            levelstr.Append("<input value=\"" + list[i].TCL_Id.ToString() + "\" id=\"" + list[i].TCL_Id.ToString() + "\"checked=\"checked\"  name=\"TownCityLevel\" type=\"checkbox\"/ >" + list[i].TCL_Name);
        }
        Lit_TCL.Text = levelstr.ToString();
    }
    /// <summary>
    /// 获取全部省份
    /// </summary>
    private void GetProvince()
    {
        IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList("");
        string strHTML = String.Empty;
        for (int i = 0; i < AreaList.Count; i++)
        {
            string areaID = AreaList[i].AreaID.ToString().Trim();
            IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList(" AreaID = " + areaID);
            string startDIV = "<div id=\"a" + areaID + "\" style=\"width:90%; float:left; display:none;\">";
            string endDIV = "</div>";
            StringBuilder proStr = new StringBuilder();
            for (int j = 0; j < pList.Count; j++)
            {
                //proStr.Append(startDIV + "<input value=\"" + pList[i].ProvinceID.ToString() + "\" id=\"" + pList[i].ProvinceID.ToString() + "\" name=\"province\" onclick='GetCity(this.id)'  type=\"checkbox\"/ >" + pList[i].ProvinceName + endDIV);
                proStr.Append("<input value=\"" + pList[j].ProvinceID.ToString() + "\" id=\"" + pList[j].ProvinceID.ToString() + "\" name=\"province\"  type=\"checkbox\"/ >" + pList[j].ProvinceName);
            }
            strHTML +=  startDIV + proStr.ToString() + endDIV;

           
        }
        this.Lit_province.Text = strHTML;


        
        //StringBuilder proStr = new StringBuilder();
        //for (int i = 0; i < pList.Count; i++)
        //{
        //    string startDIV = "<div id=\"a" + pList[i].AreaID.ToString() + "\" style=\"width:160px; float:left; display:none;\">";
        //    string endDIV = "</div>";
        //    //proStr.Append(startDIV + "<input value=\"" + pList[i].ProvinceID.ToString() + "\" id=\"" + pList[i].ProvinceID.ToString() + "\" name=\"province\" onclick='GetCity(this.id)'  type=\"checkbox\"/ >" + pList[i].ProvinceName + endDIV);
        //    proStr.Append(startDIV + "<input value=\"" + pList[i].ProvinceID.ToString() + "\" id=\"" + pList[i].ProvinceID.ToString() + "\" name=\"province\"  type=\"checkbox\"/ >" + pList[i].ProvinceName + endDIV);
        //}
        //this.Lit_province.Text = proStr.ToString();
    }

    /// <summary>
    /// 获取全部POP发起名称
    /// </summary>
    private void GetPOPName()
    {
        IList<LN.Model.POPLaunch> POPList = new LN.BLL.POPLaunch().GetList(" id<>(select max(id) from [POPLaunch]) and [steps]=0 ");
        StringBuilder POPIDStr = new StringBuilder();
        for (int i = 0; i < POPList.Count; i++)
        {
            POPIDStr.Append("<input value=\"" + POPList[i].POPID.ToString() + "\" name=\"POPLaunch\" id=\"" + POPList[i].POPID.ToString() + "\" onclick='GetPOPImageData(this.id)' type=\"checkbox\"/ >" + POPList[i].POPTitle + "\t");
        }

        this.Lit_POPID.Text = POPIDStr.ToString();
    }

    /// <summary>
    /// 获取全部画面名称
    /// </summary>
    private void GetPOPImageData()
    {
        IList<LN.Model.POPLaunch> POPList = new LN.BLL.POPLaunch().GetList(" id<>(select max(id) from [POPLaunch]) and [steps]=0 ");
        string strHTML = String.Empty;
        for (int i = 0; i < POPList.Count; i++)
        {
            string popID = POPList[i].POPID.ToString().Trim();
            IList<string> imgList = new LN.BLL.POPImageData().GetImageLevel(" POPID = '" + popID + "'");
            string startDIV = "<div id=\"i" + popID + "\" style=\"width:99%; float:left; display:none;\">";
            string endDIV = "</div>";
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < imgList.Count; j++)
            {
                //proStr.Append(startDIV + "<input value=\"" + pList[i].ProvinceID.ToString() + "\" id=\"" + pList[i].ProvinceID.ToString() + "\" name=\"province\" onclick='GetCity(this.id)'  type=\"checkbox\"/ >" + pList[i].ProvinceName + endDIV);
                sb.Append("<p style=\"width:110px;float:left;\"><input id=\""+ imgList[j].ToString() + "\" name=\"POPImageData\" value=\"" + imgList[j].ToString() + "\"  type=\"checkbox\"/ >" + imgList[j].ToString() + "</p>");
            }
            strHTML += startDIV + sb.ToString() + endDIV;


        }
        this.Lit_POPImageData.Text = strHTML;
    }

    #region 隐藏部分
    /// <summary>
    /// 获取所有的市
    /// </summary>
    //private void GetCity()
    //{
    //    IList<LN.Model.CityData> cList = new LN.BLL.CityData().GetList("");
    //    StringBuilder cityStr = new StringBuilder();

    //    for (int i = 0; i < cList.Count; i++)
    //    {
    //        string startDIV = "<div id=\"a" + cList[i].ProvinceID.ToString() + "\" style=\"width:160px; float:left; display:none;\">";
    //        string endDIV = "</div>";
    //        cityStr.Append(startDIV + "<input value=\"" + cList[i].CItyID.ToString() + "\"  id=\"" + cList[i].CItyID.ToString() + "\" name=\"city\"  onclick='GetTown(this.id)'   type=\"checkbox\"/ >" + cList[i].CityName + "\t" + endDIV);
    //    }
    //    this.Lit_city.Text = cityStr.ToString();
    //}

    /// <summary>
    ///得到所有的区级市
    /// </summary>
    //private void GetTown()
    //{
    //    IList<LN.Model.TownData> townlist = new LN.BLL.TownData().GetList("");

    //    StringBuilder townstr = new StringBuilder();
    //    for (int i = 0; i < townlist.Count; i++)
    //    {
    //        string startDIV = "<div id=\"a" + townlist[i].CityID.ToString() + "\" style=\"width:160px; float:left; display:none;\">";
    //        string endDIV = "</div>";
    //        townstr.Append(startDIV + "<input value=\"" + townlist[i].TownID.ToString() + "\" name=\"Town\"   type=\"checkbox\"/ >" + townlist[i].TownName + "\t" + endDIV);
    //    }
    //    this.Lit_town.Text = townstr.ToString();
    //}
    #endregion

   
}

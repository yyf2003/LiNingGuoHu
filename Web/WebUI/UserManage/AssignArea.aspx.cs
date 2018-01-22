using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class WebUI_UserManage_AssignArea : System.Web.UI.Page
{
    public string UserID = string.Empty;
    public string UserName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.QueryString["UserID"] != null)
        {
            UserID = this.Request.QueryString["UserID"].ToString();
            UserName = new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Username;
            this.DataBind();
            if (!IsPostBack)
            {
                GetArea();
                GetProvince();
                GetCity();
                GetTown();
            }
        }
        else
        {
            Response.Redirect("../../Login.aspx");
        }
    }

    /// <summary>
    /// 获取全部大区域
    /// </summary>
    private void GetArea()
    {
        string UID = this.Request.QueryString["UserID"].ToString();
        DataTable dt = new LN.BLL.UserAreaMange().GetUserAssginArea(int.Parse(UID)).Tables[0];
        StringBuilder areaStr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            areaStr.Append("" + GetAreaName(dt.Rows[i]["AreaID"].ToString()) + "\t");
        }
        if (areaStr.ToString() == "")
            this.Lit_Area.Text = "没有分配区域";
        else
            this.Lit_Area.Text = areaStr.ToString();
    }

    /// <summary>
    /// 获取全部省份
    /// </summary>
    private void GetProvince()
    {
        string UID = this.Request.QueryString["UserID"].ToString();
        DataTable dt = new LN.BLL.UserAreaMange().GetUserAssginProvice(int.Parse(UID)).Tables[0];
        StringBuilder proStr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string startDIV = "<div id=\"a" + dt.Rows[i]["ProvinceID"].ToString() + "\" style=\"width:15%; float:left; display:block;\">";
            string endDIV = "</div>";
            proStr.Append(startDIV + "" + GetProviceName(dt.Rows[i]["ProvinceID"].ToString()) + endDIV);
        }
        if (proStr.ToString() == "")
            this.Lit_province.Text = "没有分配省份";
        else
            this.Lit_province.Text = proStr.ToString();
    }

    /// <summary>
    /// 获取所有的市
    /// </summary>
    private void GetCity()
    {
        string UID = this.Request.QueryString["UserID"].ToString();
        DataTable dt = new LN.BLL.UserAreaMange().GetUserAssginCity(int.Parse(UID)).Tables[0];
        StringBuilder cityStr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string startDIV = "<div id=\"a" + dt.Rows[i]["CityID"].ToString() + "\" style=\"width:150px; float:left; display:block;\">";
            string endDIV = "</div>";
            cityStr.Append(startDIV + "" + GetCityName(dt.Rows[i]["CityID"].ToString()) + "\t" + endDIV);
        }
        if (cityStr.ToString() == "")
            this.Lit_city.Text = "没有分配市区";
        else
            this.Lit_city.Text = cityStr.ToString();
    }



    /// <summary>
    /// 获取所有的城镇
    /// </summary>
    private void GetTown()
    {
        string UID = this.Request.QueryString["UserID"].ToString();
        DataTable dt = new LN.BLL.UserAreaMange().GetUserAssginTown(int.Parse(UID)).Tables[0];
        StringBuilder cityStr = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string startDIV = "<div id=\"a" + dt.Rows[i]["TownID"].ToString() + "\" style=\"width:150px; float:left; display:block;\">";
            string endDIV = "</div>";
            cityStr.Append(startDIV + "" + GetTownName(dt.Rows[i]["TownID"].ToString()) + "\t" + endDIV);
        }
        if (cityStr.ToString() == "")
            this.Lit_town.Text = "没有分配城镇";
        else
            this.Lit_town.Text = cityStr.ToString();
    }

    /// <summary>
    /// 得到区域名称
    /// </summary>
    /// <param name="AreaID"></param>
    /// <returns></returns>
    private string GetAreaName(string AreaID)
    {
        if (AreaID != "")
        {
            LN.Model.AreaData model = new LN.BLL.AreaData().GetModel(int.Parse(AreaID));
            if (model != null)
            {
                return model.AreaName;
            }
        }
        return ""; 
    }
    /// <summary>
    /// 得到省份名称
    /// </summary>
    /// <param name="ProviceID"></param>
    /// <returns></returns>
    private string GetProviceName(string ProviceID)
    {
        if (ProviceID != "")
        {
            LN.Model.ProvinceData model = new LN.BLL.ProvinceData().GetModel(int.Parse(ProviceID));
            if (model != null)
            {
                return model.ProvinceName;
            }
        }
        return "";
    }
    /// <summary>
    /// 得到城市名称
    /// </summary>
    /// <param name="CityID"></param>
    /// <returns></returns>
    private string GetCityName(string CityID)
    {
        if (CityID != "")
        {
            LN.Model.CityData model = new LN.BLL.CityData().GetModel(int.Parse(CityID));
            if (model != null)
            {
                return model.CityName;
            }
        } 
        return ""; 
    }

    /// <summary>
    /// 得到城镇名称
    /// </summary>
    /// <param name="CityID"></param>
    /// <returns></returns>
    private string GetTownName(string TownID)
    {
        if (TownID != "")
        {
            LN.Model.TownData model = new LN.BLL.TownData().GetModel(int.Parse(TownID));
            if (model != null)
            {
                return model.TownName;
            }
        }
        return ""; 
    }

}

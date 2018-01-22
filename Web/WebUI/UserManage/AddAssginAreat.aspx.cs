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
public partial class WebUI_UserManage_AddAssginAreat : System.Web.UI.Page
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
        IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList("");
        StringBuilder areaStr = new StringBuilder();
        for (int i = 0; i < AreaList.Count; i++)
        {
            areaStr.Append("<input value=\"" + AreaList[i].AreaID.ToString() + "\" name=\"area\" id=\"" + AreaList[i].AreaID.ToString() + "\" onclick='GetProvince(this.id)' type=\"checkbox\"/ >" + AreaList[i].AreaName + "\t");
        }

        this.Lit_Area.Text = areaStr.ToString();
    }

    /// <summary>
    /// 获取全部省份
    /// </summary>
    private void GetProvince()
    {
        IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
        StringBuilder proStr = new StringBuilder();
        for (int i = 0; i < pList.Count; i++)
        {
            string startDIV = "<div id=\"a" + pList[i].AreaID.ToString() + "\" style=\"width:15%; float:left; display:none;\">";
            string endDIV = "</div>";
            proStr.Append(startDIV + "<input value=\"" + pList[i].ProvinceID.ToString() + "\" id=\"" + pList[i].ProvinceID.ToString() + "\" name=\"province\" onclick='GetCity(this.id)'  type=\"checkbox\"/ >" + pList[i].ProvinceName + endDIV);
        }
        this.Lit_province.Text = proStr.ToString();
    }

    /// <summary>
    /// 获取所有的市
    /// </summary>
    private void GetCity()
    {
        IList<LN.Model.CityData> cList = new LN.BLL.CityData().GetList("");
        StringBuilder cityStr = new StringBuilder();

        for (int i = 0; i < cList.Count; i++)
        {
            string startDIV = "<div id=\"a" + cList[i].ProvinceID.ToString() + "\" style=\"width:150px; float:left; display:none;\">";
            string endDIV = "</div>";
            cityStr.Append(startDIV + "<input value=\"" + cList[i].CItyID.ToString() + "\" id=\"" + cList[i].CItyID.ToString() + "\" name=\"city\" onclick='GetTown(this.id)'   type=\"checkbox\"/ >" + cList[i].CityName + "\t" + endDIV);
        }
        this.Lit_city.Text = cityStr.ToString();
    }
    /// <summary>
    ///得到所有的区级市
    /// </summary>
    private void GetTown()
    {
        IList<LN.Model.TownData> townlist = new LN.BLL.TownData().GetList("");

        StringBuilder townstr = new StringBuilder();
        for (int i = 0; i < townlist.Count; i++)
        {
            string startDIV = "<div id=\"a" + townlist[i].CityID.ToString() + "\" style=\"width:150px; float:left; display:none;\">";
            string endDIV = "</div>";
            townstr.Append(startDIV + "<input value=\"" + townlist[i].TownID.ToString() + "\" name=\"Town\"   type=\"checkbox\"/ >" + townlist[i].TownName + "\t" + endDIV);
        }
        this.Lit_town.Text = townstr.ToString();
    }
}

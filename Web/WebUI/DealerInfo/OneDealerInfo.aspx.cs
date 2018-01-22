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

public partial class WebUI_DealerInfo_OneDealerInfo : System.Web.UI.Page
{
    protected string Qid = String.Empty;
    protected string DealerID = string.Empty;
    protected string DealerName = string.Empty;
    protected string Department = string.Empty;
    protected string Areaname = string.Empty;
    protected string Provincename = string.Empty;
    protected string Cityname = string.Empty;
    protected string Contactor = string.Empty;
    protected string ContactorPhone = string.Empty;
    protected string Address = string.Empty;
    protected string PostAddress = string.Empty;
    protected string DealerChannel = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        Qid = Request.QueryString["ID"] == null ? "0" : Request.QueryString["ID"].Trim();
        if (!IsPostBack)
        {
            GetOneDealerInfo();
        }
    }
    public void GetOneDealerInfo()
    {

        int dID;
        int.TryParse(Qid,out dID);
        DataSet ds = new LN.BLL.DealerInfo().GetList(" and  ID=" + dID);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            DealerID = dt.Rows[0]["DealerID"].ToString();
            DealerName = dt.Rows[0]["DealerName"].ToString();
            Department = dt.Rows[0]["Department"].ToString();
            Areaname = dt.Rows[0]["Areaname"].ToString();
            //  DDL_Area.SelectedValue = AreaID;
            Provincename = dt.Rows[0]["ProvinceName"].ToString();
            Cityname = dt.Rows[0]["cityname"].ToString();
            // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_a", "<script>GetCityname(" + ProvinceID + ");GetCity();</script>"); 
            Contactor = dt.Rows[0]["Contactor"].ToString();
            ContactorPhone = dt.Rows[0]["ContactorPhone"].ToString();
            Address = dt.Rows[0]["Address"].ToString();
            PostAddress = dt.Rows[0]["PostAddress"].ToString();
            DealerChannel = dt.Rows[0]["DealerChannel"].ToString();
        }
        this.DataBind();
    }

    /// <summary>
    /// 地区
    /// </summary>
    /// <param name="AreaIDs"></param>
    /// <returns></returns>
    public string AreaName(string AreaIDs)
    {
        if (AreaIDs != "0")
        {
            LN.Model.AreaData model = new LN.BLL.AreaData().GetModel(int.Parse(AreaIDs));
            if (model != null)
            {
                return model.AreaName;
            }
        }
        return "";
    }
    /// <summary>
    /// 省份
    /// </summary>
    /// <param name="ProvID"></param>
    /// <returns></returns>
    public string ProvinceName(string ProvID)
    {
        if (ProvID != "0")
        {
            LN.Model.ProvinceData model = new LN.BLL.ProvinceData().GetModel(int.Parse(ProvID));
            if (model != null)
            {
                return model.ProvinceName;
            }
        }
        return "";
    }
    /// <summary>
    /// 城市
    /// </summary>
    /// <param name="CityID"></param>
    /// <returns></returns>
    public string CityName(string CityID)
    {
        if (CityID != "0")
        {
            LN.Model.CityData model = new LN.BLL.CityData().GetModel(int.Parse(CityID));
            if (model != null)
            {
                return model.CityName; 
            }

        }
        return "";
    }
}

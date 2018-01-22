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

public partial class WebUI_DealerInfo_UpdateOneDealerInfo : System.Web.UI.Page
{

    protected string Qid = String.Empty;
    protected string DealerID = string.Empty;
    protected string DealerName = string.Empty;
    protected string AreaID = string.Empty;
    protected string ProvinceID = string.Empty;
    protected string CityID = string.Empty;
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
        LN.DAL.ProvinceData ProDAL = new LN.DAL.ProvinceData();
        IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
        for (int i = 0; i < pList.Count; i++)
        {
            ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
            DDL_Province.Items.Add(item);
        }

        IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList("");
        foreach (LN.Model.AreaData model in AreaList)
        {
            ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
            DDL_Area.Items.Add(item);
        }
        LN.Model.DealerInfo modelinfo = new LN.BLL.DealerInfo().GetModel(int.Parse(Qid));
        if (modelinfo != null)
        {
            DealerID = modelinfo.DealerID;
            DealerName = modelinfo.DealerName;
            AreaID = modelinfo.AreaID.ToString();
            DDL_Area.SelectedValue = AreaID;
            ProvinceID = modelinfo.ProvinceID.ToString();
            DDL_Province.SelectedValue = ProvinceID;
            CityID = modelinfo.CityID.ToString();
            IList<LN.Model.CityData> citylist = new LN.BLL.CityData().GetList("ProvinceID =" + ProvinceID + "");
            foreach (LN.Model.CityData modelcity in citylist)
            {
                ListItem item = new ListItem(modelcity.CityName, modelcity.CItyID.ToString());
                DDL_city.Items.Add(item);
            }
            DDL_city.SelectedValue = CityID;
            // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_a", "<script>GetCityname(" + ProvinceID + ");GetCity();</script>"); 
            Contactor = modelinfo.Contactor;
            ContactorPhone = modelinfo.ContactorPhone;
            Address = modelinfo.Address;
            PostAddress = modelinfo.PostAddress;
            DealerChannel = modelinfo.DealerChannel;
        }
        this.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Dealer_ID = this.Request.Form["txt_DealerID"].ToString();
        string Dealer_Name = this.txt_DealerName.Text;
        string Aread_ID = this.Request.Form["DDL_Area"].ToString();
        string Province_ID = this.Request.Form["DDL_Province"].ToString();
        string City_ID = this.Request.Form["DDL_city"].ToString();
        string Con_tactor = txt_Contactor.Text.Trim();
        string Con_tactorPhone = txt_UserMobile.Text.Trim();
        string Add_ress = txt_Address.Text.Trim();
        string Post_Address = txt_PostAddress.Text.Trim();
        
        string Qid = this.Request.QueryString["ID"].ToString();
        LN.Model.DealerInfo model = new LN.Model.DealerInfo();
        model.DealerID = Dealer_ID;
        model.DealerName = Dealer_Name;
        model.AreaID = int.Parse(Aread_ID);
        model.ProvinceID = int.Parse(Province_ID);
        model.CityID = int.Parse(City_ID);
        model.Contactor = Con_tactor;
        model.ContactorPhone = Con_tactorPhone;
        model.Address = Add_ress;
        model.PostAddress = Post_Address;
        model.DealerChannel = "";
        model.ID = int.Parse(Qid);
        new LN.BLL.DealerInfo().Update(model);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('修改成功！');window.location='DealerList.aspx';</script>");  
    }
}

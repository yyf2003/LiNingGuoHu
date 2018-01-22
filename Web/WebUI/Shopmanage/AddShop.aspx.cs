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

public partial class WebUI_Shopmanage_AddShop : System.Web.UI.Page
{
    protected string UserName = String.Empty,UserID=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
        if (!Page.IsPostBack)
        {

            #region 店铺相关属性绑定

            //绑定店铺级别
            LN.DAL.ShopLevel levelDLL = new LN.DAL.ShopLevel();
            DataSet ds = levelDLL.GetList("");
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                this.DDL_shopLevel.Items.Add(item);
            }
            //绑定店铺销售类型
            LN.DAL.SaleTypeInfo saleDLL = new LN.DAL.SaleTypeInfo();
            DataSet saleds = saleDLL.GetList("");
            DataTable saledt = saleds.Tables[0];
            for (int i = 0; i < saledt.Rows.Count; i++)
            {
                ListItem item = new ListItem(saledt.Rows[i][1].ToString(), saledt.Rows[i][0].ToString());
                SaleTypeID.Items.Add(item);
            }
            //绑定店铺的一级客户

            LN.DAL.DealerInfo dealerDAL = new LN.DAL.DealerInfo();

            DataTable dealerdt = dealerDAL.GetDealerName(" 1=1 ");
            for (int i = 0; i < dealerdt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                ddl_dealer.Items.Add(item);
            }

            //加载店铺类型
            LN.BLL.ShopType typebll = new LN.BLL.ShopType();
            IList<LN.Model.ShopType> typelist = typebll.GetList("");
            foreach (LN.Model.ShopType model in typelist)
            {
                ListItem item = new ListItem(model.ShopTypename, model.ID.ToString());
                DDL_Shoptype.Items.Add(item);
            }
            //加载店铺V/I模式
            LN.BLL.ShopVI vibll = new LN.BLL.ShopVI();
            IList<LN.Model.ShopVI> vilist = vibll.GetList("");
            foreach (LN.Model.ShopVI model in vilist)
            {
                ListItem item = new ListItem(model.ShopVIName, model.ShopVIID.ToString());
                DDL_shopVI.Items.Add(item);
            }
            //加载店铺状态
            LN.BLL.ShopStateInfo statebll = new LN.BLL.ShopStateInfo();
            IList<LN.Model.ShopStateInfo> statelist = statebll.GetModelList("");
            foreach (LN.Model.ShopStateInfo model in statelist)
            {
                ListItem item = new ListItem(model.ShopState, model.ID.ToString());
                DDL_ShopState.Items.Add(item);
            }
            DDL_ShopState.Text = "1";

            //绑定地市级城市级别_市场定义
            IList<LN.Model.TownCityLevel> TCLList = new LN.BLL.TownCityLevel().GetList("");
            foreach (LN.Model.TownCityLevel model in TCLList)
            {
                DDL_TownCityLevel.Items.Add(new ListItem(model.TCL_Name,model.TCL_Id.ToString()));
            }

            //绑定区县级城市级别_市场定义
            IList<LN.Model.AreaCityLevel> ACLList = new LN.BLL.AreaCityLevel().GetList("");
            foreach (LN.Model.AreaCityLevel model in ACLList)
            {
                DDL_AreaCityLevel.Items.Add(new ListItem(model.ACL_Name, model.ACL_Id.ToString()));
            }

            #endregion

            #region 根据登录人ID得到所属部门、区域

            DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                string UserAreaID = userdt.Rows[0][0].ToString();
                string UserAreaName = userdt.Rows[0][1].ToString();
                string UserDepartMent = userdt.Rows[0][2].ToString();

                //modify by mhj 20130319
                ////ListItem item = new ListItem(userdt.Rows[0][1].ToString(), userdt.Rows[0][0].ToString());
                ////DDL_Area.Items.Add(item);
                ////DDL_Area.SelectedValue = userdt.Rows[0][0].ToString();
                ////DDL_Area.Enabled = false;
                DDL_department.SelectedIndex = DDL_department.Items.IndexOf(DDL_department.Items.FindByValue(userdt.Rows[0][2].ToString()));
                ////DDL_department.Enabled = false;


                //add by mhj 20130319
                DDL_Area.Enabled = true;
                IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(" DepartMent='" + DDL_department.SelectedValue + "'");               
                foreach (LN.Model.AreaData model in arealist)
                {
                    ListItem item2 = new ListItem(model.AreaName, model.AreaID.ToString());
                    DDL_Area.Items.Add(item2);
                }

                //加载省份
                IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList(" AreaID = " + DDL_Area.SelectedValue);
                for (int i = 0; i < pList.Count; i++)
                {
                    ListItem PItem = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
                    DDL_Province.Items.Add(PItem);
                }

                ////DataSet userinfods = new LN.BLL.UserInfo().GetList(" userType=3 and userofarea=" + DDL_Area.Text);

                ////Txt_VMMaster.Text = userinfods.Tables[0].Rows[0]["username"].ToString();
                ////Txt_VMMasterPhone.Text = userinfods.Tables[0].Rows[0]["usermobel"].ToString();
                ////Txt_VMMaster.Enabled = false;
                ////Txt_VMMasterPhone.Enabled = false;

            }
            
            #endregion
        }
    }
 
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        string AreaID = String.Empty;
        if (DDL_Area.Enabled == false)
            AreaID = DDL_Area.SelectedValue;
        else
            AreaID = Request.Form["DDL_Area"].ToString();
        string ProvinceID = Request.Form["DDL_Province"].ToString();
        string CityID = Request.Form["DDL_city"].ToString();
        string TownID = Request.Form["DDL_town"].ToString();
        
        LN.Model.ShopInfo ShopModel = new LN.Model.ShopInfo();
        LN.BLL.ShopInfo shopBLL = new LN.BLL.ShopInfo();

        ShopModel.Shopname = this.Txt_Shopname.Text.Trim();
        ShopModel.SaleTypeID = int.Parse(this.SaleTypeID.SelectedValue);
        ShopModel.PosID = this.PosID.Text.Trim();
        ShopModel.ShopAddress ="";
        ShopModel.ShopLevelID = int.Parse(this.DDL_shopLevel.SelectedValue);
        ShopModel.ShopOpenDate = DateTime.Now.ToShortDateString();
        ShopModel.ProvinceID = int.Parse(ProvinceID);
        ShopModel.CityID = int.Parse(CityID);
        ShopModel.TownID = int.Parse(TownID);
        ShopModel.LinkMan = this.Txt_LineMan.Text.Trim();
        ShopModel.LinkPhone = this.Txt_LinkPhone.Text.Trim();
        ShopModel.ShopMaster = this.Txt_Shopmaster.Text.ToString();
        ShopModel.ShopMasterPhone = this.Txt_ShopMasterPhone.Text.ToString();
        ShopModel.Email = Txt_Email.Text.Trim();
        ShopModel.FaxNumber = Txt_FixNumber.Text.Trim();
        ShopModel.PostCode = Txt_PostCode.Text.Trim();
        ShopModel.Boolinstall = int.Parse(DDL_install.SelectedValue);
        ShopModel.PostAddress = Txt_PostAddress.Text.Trim();
        ShopModel.DealerID = ddl_dealer.SelectedValue;
        ShopModel.CustomerGroupID = txt_customergroupID.Text.Trim();
        ShopModel.CustomerGroupName = txt_customergroupname.Text.Trim();
        ShopModel.ShopPhone = txt_shopphone.Text.Trim();
        ShopModel.ShopState = int.Parse(DDL_ShopState.SelectedValue);
        if (Request.Form["Txt_VMMaster"] == null)
            ShopModel.VMMaster = Txt_VMMaster.Text;
        else
            ShopModel.VMMaster = Request.Form["Txt_VMMaster"];

        if (Request.Form["Txt_VMMasterPhone"] == null)
            ShopModel.VMMasterPhone = Txt_VMMasterPhone.Text;
        else
            ShopModel.VMMasterPhone = Request.Form["Txt_VMMasterPhone"];
        
        ShopModel.DSRMaster = Txt_DSRMaster.Text.Trim();
        ShopModel.DSRMasterPhone = Txt_DSRMasterPhone.Text.Trim();
        ShopModel.ShopArea = decimal.Parse(Txt_Shoparea.Text.Trim());
        ShopModel.ShopVI = int.Parse(DDL_shopVI.SelectedValue);
        ShopModel.ShopType = int.Parse(DDL_Shoptype.SelectedValue);
        ShopModel.Fxid = Request.Form["DDL_fx"].ToString();
        ShopModel.AreaID = int.Parse(AreaID);
        ShopModel.ShopSampleName = txt_samplename.Text.Trim();
        ShopModel.ShopOwnerShip = DDL_shopOwnerShip.Text;
        ShopModel.CustomerCard = DDL_KHSF.Text;
        ShopModel.ACL_ID = int.Parse(DDL_AreaCityLevel.SelectedValue);
        ShopModel.TCL_ID = int.Parse(DDL_TownCityLevel.SelectedValue);
        try
        {
            if (!shopBLL.Exists(ShopModel.PosID))
            {
                int ShopID = shopBLL.Add(ShopModel);
                if (new LN.BLL.SupplierAssignRecord().Exists(" [Remarks]='" + ShopModel.AreaID + "'"))
                {
                    string sid = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" [Remarks]='" + ShopModel.AreaID + "'");

                    LN.Model.SupplierAssignRecord amodel = new LN.Model.SupplierAssignRecord();
                    amodel.AssignCityID = ShopModel.CityID;
                    amodel.AssignProID = ShopModel.ProvinceID;
                    amodel.AssignRuleID = 0;
                    amodel.AssignShopID = new LN.BLL.ShopInfo().GetMaxId();
                    amodel.SupplierID = int.Parse(sid);
                    amodel.Remarks = ShopModel.AreaID.ToString();

                    new LN.BLL.SupplierAssignRecord().Add(amodel);
                }
                Response.Redirect("../ShopPOP/AddShopPOP.aspx?shopid=" + ShopID.ToString());
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "<script>alert('店铺编号已经存在，请更换此编号');</script>");
            }
        }
        catch
        {
            throw;
        }
       
  
        ClearText();
    }

    protected void ClearText()
    {
        for (int i = 0; i < Page.Controls.Count; i++)
        {
            foreach (System.Web.UI.Control control in Page.Controls[i].Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = "";
                }
                if (control is DropDownList)
                {
                    (control as DropDownList).SelectedIndex = 0;
                }
            }

        }
       
    }
}

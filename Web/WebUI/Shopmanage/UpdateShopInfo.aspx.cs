using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class WebUI_Shopmanage_UpdateShopInfo : System.Web.UI.Page
{
    protected string shopid = "", UserID = "", userName = "", UserTypeID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        userName = Server.UrlDecode(Request.Cookies["UserName"].Value);
        UserTypeID = new LN.BLL.UserInfo().GetModel(Int32.Parse(UserID)).Usertype.Trim();
        if (Request.QueryString["shopid"] != null)
        {
            shopid = Request.QueryString["shopid"].ToString();
        }
        else
        {
            DataTable dt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(userName);
            if (dt.Rows.Count > 0)
            {
                shopid = dt.Rows[0]["ShopID"].ToString();
            }
            else
            {
                Response.Write("<script>alert('没有此人负责的店铺');</script>");
                return;
            }
        }
        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
        {
            this.Btn_Save.Enabled = false;
        }
        if (!Page.IsPostBack)
        {
            #region 初始化绑定信息

            //绑定店铺级别
            LN.DAL.ShopLevel levelDLL = new LN.DAL.ShopLevel();
            DataSet levelds = levelDLL.GetList("");
            DataTable leveldt = levelds.Tables[0];
            for (int i = 0; i < leveldt.Rows.Count; i++)
            {
                ListItem item = new ListItem(leveldt.Rows[i][1].ToString(), leveldt.Rows[i][0].ToString());
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

            DataTable dealerdt = dealerDAL.GetDealerName("");
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
            //加载店铺状态
            LN.BLL.ShopStateInfo statebll = new LN.BLL.ShopStateInfo();
            IList<LN.Model.ShopStateInfo> statelist = statebll.GetModelList("");
            foreach (LN.Model.ShopStateInfo model in statelist)
            {
                ListItem item = new ListItem(model.ShopState, model.ID.ToString());
                DDL_ShopState.Items.Add(item);
            }
            //加载店铺V/I模式
            LN.BLL.ShopVI vibll = new LN.BLL.ShopVI();
            IList<LN.Model.ShopVI> vilist = vibll.GetList("");
            foreach (LN.Model.ShopVI model in vilist)
            {
                ListItem item = new ListItem(model.ShopVIName, model.ShopVIID.ToString());
                DDL_shopVI.Items.Add(item);
            }

            //add by mhj 20130322
            #region
            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_DepartMent.Items.Add(item);
            }
            #endregion

            //加载区域
            IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList("");
            //DDL_Area2.Items.Add(new ListItem("请选择省区","0"));
            foreach (LN.Model.AreaData model in arealist)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                DDL_Area2.Items.Add(item);
            }

            LN.BLL.ShopInfo oneInfo = new LN.BLL.ShopInfo();

            DataSet ds = oneInfo.GetList(" ShopID=" + shopid);//得到此shopid 店铺的信息


            DataTable dt = ds.Tables[0];

            this.PosID.Text = dt.Rows[0]["PosID"].ToString();
            this.Txt_Shopname.Text = dt.Rows[0]["ShopName"].ToString();
            this.txt_samplename.Text = dt.Rows[0]["Shopsamplename"].ToString();
            this.ddl_dealer.Text = dt.Rows[0]["DealerID"].ToString();
            this.Txt_Email.Text = dt.Rows[0]["Email"].ToString();
            this.Txt_FixNumber.Text = dt.Rows[0]["FaxNumber"].ToString();
            this.DDL_install.Text = dt.Rows[0]["BoolInstall"].ToString();
            this.Txt_LineMan.Text = dt.Rows[0]["LinkMan"].ToString().Replace(dt.Rows[0]["PosID"].ToString(), "");
            this.Txt_LinkPhone.Text = dt.Rows[0]["LinkPhone"].ToString();
            this.Txt_Shopmaster.Text = dt.Rows[0]["ShopMaster"].ToString();
            this.Txt_ShopMasterPhone.Text = dt.Rows[0]["ShopMasterPhone"].ToString();
            this.Txt_PostAddress.Text = dt.Rows[0]["PostAddress"].ToString();
            this.Txt_PostCode.Text = dt.Rows[0]["PostCode"].ToString();
            //////////////////////////////////////////////////////////////////////////////////
            //// this.SaleTypeID.Text = dt.Rows[0]["SaletypeID"].ToString();
            //DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName(" dealerid='" + dt.Rows[0]["DealerID"].ToString() + "'");
            //for (int i = 0; i < fxdt.Rows.Count; i++)
            //{
            //    ListItem fxitem = new ListItem(fxdt.Rows[i]["FXname"].ToString(), fxdt.Rows[i]["FXID"].ToString());
            //    DDL_fx.Items.Add(fxitem);
            //}

            //DDL_fx.Text = dt.Rows[0]["FXID"].ToString();
            //this.DDL_Shoptype.Text = dt.Rows[0]["ShopType"].ToString();
            //// this.Txt_ShopOpenDate.Text = dt.Rows[0]["ShopOpenDate"].ToString();
            //////////////////////////////////////////////////////////////////////////////////
            // this.SaleTypeID.Text = dt.Rows[0]["SaletypeID"].ToString();
            DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName(" dealerid='" + dt.Rows[0]["DealerID"].ToString() + "'");
            for (int i = 0; i < fxdt.Rows.Count; i++)
            {
                ListItem fxitem = new ListItem(fxdt.Rows[i]["FXname"].ToString(), fxdt.Rows[i]["FXID"].ToString());
                if (fxdt.Rows[i]["FXID"].ToString() == dt.Rows[0]["DealerID"].ToString())
                    fxitem.Selected = true;
                DDL_fx.Items.Add(fxitem);
            }

            //DDL_fx.Text = dt.Rows[0]["FXID"].ToString();
            this.DDL_Shoptype.Text = dt.Rows[0]["ShopType"].ToString();
            // this.Txt_ShopOpenDate.Text = dt.Rows[0]["ShopOpenDate"].ToString();
            this.DDL_ShopState.Text = dt.Rows[0]["ShopState"].ToString();
            Txt_DSRMaster.Text = dt.Rows[0]["DSRMaster"].ToString();
            Txt_DSRMasterPhone.Text = dt.Rows[0]["DSRMasterPhone"].ToString();
            Txt_Shoparea.Text = dt.Rows[0]["ShopArea"].ToString();
            DDL_shopLevel.Text = dt.Rows[0]["ShopType"].ToString();
            DDL_shopVI.Text = dt.Rows[0]["ShopVI"].ToString();
            txt_shopphone.Text = dt.Rows[0]["ShopPhone"].ToString();
            DDL_Area2.Text = dt.Rows[0]["areaid"].ToString();
            txt_customergroupID.Text = dt.Rows[0]["customerGroupID"].ToString();
            txt_customergroupname.Text = dt.Rows[0]["customergroupname"].ToString();
            DDL_Area2.Enabled = false;
            // DataSet userinfods = new LN.BLL.UserInfo().GetList(" userType=3 and userofarea=" + DDL_Area2.Text);

            Txt_VMMaster.Text = dt.Rows[0]["VMMaster"].ToString();
            Txt_VMMasterPhone.Text = dt.Rows[0]["VMMasterPhone"].ToString();
            DDL_shopOwnerShip.Text = dt.Rows[0]["shopOwnerShip"].ToString();
            DDL_KHSF.Text = dt.Rows[0]["CustomerCard"].ToString();
            SaleTypeID.Text = dt.Rows[0]["SaleTypeID"].ToString();
            DDL_shopOwnerShip.Text = dt.Rows[0]["shopOwnerShip"].ToString();
            DDL_KHSF.Text = dt.Rows[0]["CustomerCard"].ToString();
            HF_OldLinkman.Value = dt.Rows[0]["LinkMan"].ToString();

            //add by mhj 2012.12.13
            #region
            DDL_Citylevel.SelectedIndex = DDL_Citylevel.Items.IndexOf(DDL_Citylevel.Items.FindByValue(dt.Rows[0]["ACL_Id"].ToString()));
            DDL_TownLevel.SelectedIndex = DDL_TownLevel.Items.IndexOf(DDL_TownLevel.Items.FindByValue(dt.Rows[0]["TCL_Id"].ToString()));

            //add by mhj 2013.03.22
            DDL_DepartMent.Text = dt.Rows[0]["DepartMent"].ToString();

            //加载区域
            IList<LN.Model.AreaData> arealist2 = new LN.BLL.AreaData().GetList("");
            //DDL_Area.Items.Add(new ListItem("请选择省区","0"));
            foreach (LN.Model.AreaData model in arealist2)
            {
                ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                DDL_Area.Items.Add(item);
            }

            DDL_Area.Text = dt.Rows[0]["areaid"].ToString();
            
            IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
            foreach (LN.Model.ProvinceData pmodel in prolist)
            {
                DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
            }
            DDL_Province.Text = dt.Rows[0]["provinceid"].ToString();

            IList<LN.Model.CityData> citylist = new LN.BLL.CityData().GetList(" provinceid=" + DDL_Province.Text);
            foreach (LN.Model.CityData citymodel in citylist)
            {
                DDL_city.Items.Add(new ListItem(citymodel.CityName, citymodel.CItyID.ToString()));
            }
            DDL_city.Text = dt.Rows[0]["cityid"].ToString();

            IList<LN.Model.TownData> townlist = new LN.BLL.TownData().GetList(" cityid=" + DDL_city.Text);
            foreach (LN.Model.TownData townmodel in townlist)
            {
                DDL_town.Items.Add(new ListItem(townmodel.TownName, townmodel.TownID.ToString()));
            }
            DDL_town.Text = dt.Rows[0]["townid"].ToString();
            #endregion

            if (UserTypeID == "1" || UserTypeID == "2" || UserTypeID == "3")
                DDL_ShopState.Enabled = true;
            else
                DDL_ShopState.Enabled = false;

            #endregion
        }
    }

    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        //判断用户类型为
        //1	VM 管理部
        //2	区域VM经理
        //3	省区VM
        //4	DSR
        //5	一级客户
        //6	供应商
        //7	店铺主管
        //8	直属客户
        //9	自营零售管理部
        //10	VIP
        if (UserTypeID == "1" || UserTypeID == "2" || UserTypeID == "3")
        {
            string shopstate = "";//保存店铺修改状态的文字内容
            switch (DDL_ShopState.SelectedValue)
            {
                case "0":
                    shopstate = "关闭";
                    break;
                case "1":
                    shopstate = "开店";
                    break;
                case "2":
                    shopstate = "整改";
                    break;
                case "3":
                    shopstate = "维持";
                    break;
            }
            //判断修改类型为 2-整改 or 3-维持 则提示无权修改
            if (DDL_ShopState.SelectedValue == "2" || DDL_ShopState.SelectedValue == "3")
            {
                Response.Write("<script charset='utf-8'>alert('抱歉! 您当前无权将店铺修改为 " + shopstate + "状态');</script>");
                return;
            }
            else
            {
                //修改店铺状态 同时 修改登录帐号状态
                bool IsCloseShop = new LN.BLL.ShopInfo().ChangeShopState(Int32.Parse(shopid), Int32.Parse(UserID), Int32.Parse(DDL_ShopState.SelectedValue));
                //如果店铺修改状态为 1 or 3 成功,则修改用户密码为000000
                if (IsCloseShop && (DDL_ShopState.SelectedValue == "1" || DDL_ShopState.SelectedValue == "3"))
                    new LN.BLL.UserInfo().UpdateUserInfoPwd(shopid);

                if (IsCloseShop == true)
                {
                    Response.Write("<script charset='utf-8'>alert('" + shopstate + "成功！');</script>");
                    this.Btn_Save.Enabled = false;
                }
                else
                {
                    Response.Write("<script charset='utf-8'>alert('" + shopstate + "失败！');</script>");
                    this.Btn_Save.Enabled = false;
                }
            }
        }
        else
        {

            LN.Model.EditShopInfo ShopModel = new LN.Model.EditShopInfo();

            ShopModel.ShopID = int.Parse(shopid);
            ShopModel.PosID = this.PosID.Text.Trim();
            ShopModel.Shopname = this.Txt_Shopname.Text.Trim();
            ShopModel.ShopSampleName = this.txt_samplename.Text;
            ShopModel.SaleTypeID = int.Parse(this.SaleTypeID.SelectedValue);

            ShopModel.ShopLevelID = int.Parse(this.DDL_shopLevel.SelectedValue);
            ShopModel.ShopOpenDate = DateTime.Now.ToShortDateString();
            ShopModel.LinkMan = ShopModel.PosID + this.Txt_LineMan.Text.Trim();
            ShopModel.LinkPhone = this.Txt_LinkPhone.Text.Trim();
            ShopModel.ShopMaster = this.Txt_Shopmaster.Text.Trim();
            ShopModel.ShopMasterPhone = this.Txt_ShopMasterPhone.Text.Trim();
            ShopModel.Email = Txt_Email.Text.Trim();
            ShopModel.FaxNumber = Txt_FixNumber.Text.Trim();
            ShopModel.PostCode = Txt_PostCode.Text.Trim();
            ShopModel.Boolinstall = int.Parse(DDL_install.SelectedValue);
            ShopModel.PostAddress = Txt_PostAddress.Text.Trim();
            ShopModel.DealerID = ddl_dealer.SelectedValue;
            ShopModel.ShopState = int.Parse(DDL_ShopState.SelectedValue);
            ShopModel.VMMaster = Txt_VMMaster.Text.Trim();
            ShopModel.VMMasterPhone = Txt_VMMasterPhone.Text.Trim();
            ShopModel.DSRMaster = Txt_DSRMaster.Text.Trim();
            ShopModel.DSRMasterPhone = Txt_DSRMasterPhone.Text.Trim();
            ShopModel.ShopArea = decimal.Parse(Txt_Shoparea.Text.Trim());
            ShopModel.ShopVI = int.Parse(DDL_shopVI.SelectedValue);
            ShopModel.ShopType = int.Parse(DDL_Shoptype.SelectedValue);
            ShopModel.ShopPhone = txt_shopphone.Text.ToString();
            ShopModel.FXID = Request.Form["DDL_fx"].ToString();
            ShopModel.CustomerGroupID = txt_customergroupID.Text.Trim();
            ShopModel.CustomerGroupName = txt_customergroupname.Text.Trim();
            ShopModel.ShopOwnerShip = DDL_shopOwnerShip.Text;
            ShopModel.CustomerCard = DDL_KHSF.Text;

            //add by mhj 2012.12.13
            ShopModel.ACL_Id = int.Parse(DDL_Citylevel.SelectedValue);
            ShopModel.TCL_Id = int.Parse(DDL_TownLevel.SelectedValue);

            //add by mhj 2013.03.26
            ShopModel.areaid = int.Parse(h_areaid.Value);
            ShopModel.ProvinceID = int.Parse(h_provinceid.Value);
            ShopModel.CityID = int.Parse(h_cityid.Value);
            ShopModel.TownID = int.Parse(h_townid.Value);

            int result = new LN.BLL.EditShopInfo().UpdateSub(ShopModel);
            if (result > 0)
            {
                //modify by mhj 2012.12.13
                //Response.Write("<script charset='utf-8'>alert('等待VM区域经理审批才能生效！');</script>");
                //this.Btn_Save.Enabled = false;
                Response.Write("<script charset='utf-8'>alert('更新成功！');location.href='OneShopInfo.aspx';</script>");
            }
            else
            {
                Response.Write("<script charset='utf-8'>alert('更新失败！');</script>");
                this.Btn_Save.Enabled = false;
            }
        }


    }
}

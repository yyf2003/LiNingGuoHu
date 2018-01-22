using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;

public partial class WebUI_Shopmanage_ShopOrderformPreview : System.Web.UI.Page
{
    //add by mhj 2012.2.5
    public string strDisplay = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string UserID = String.Empty, userName = String.Empty;
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;//得到用户ID
        userName = Server.UrlDecode(Request.Cookies["UserName"].Value);

        //add by mhj 2012.2.5
        LN.Model.UserInfo model_user = new LN.BLL.UserInfo().GetModel(int.Parse(UserID));
        if (model_user.Usertype == "6")
        {
            //strDisplay = "none";
            h_supplierId.Value = new LN.BLL.SupplierInfo().GetSupplierIdByUserName(userName).ToString();
        }

        if (!Page.IsPostBack)
        {
            //加载POP发起ID
            IList<LN.Model.POPLaunch> plist = new LN.BLL.POPLaunch().GetPOPIDList();

            foreach (LN.Model.POPLaunch pl in plist)
            {
                ListItem item = new ListItem(pl.POPTitle, pl.POPID);
                DDL_POPID.Items.Add(item);
            }
            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_department.Items.Add(item);
            }


            //绑定店铺类型
            LN.DAL.ShopType typedll = new LN.DAL.ShopType();
            IList<LN.Model.ShopType> typelist = typedll.GetList("");
            foreach (LN.Model.ShopType model in typelist)
            {
                ListItem item = new ListItem(model.ShopTypename, model.ID.ToString());
                this.DDL_Shoptype.Items.Add(item);
            }
            //绑定销售属性类型

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

            //add by mhj 2012.2.5
            if (model_user.Usertype == "")
            {
                return;
            }

            // 根据登录人ID得到所属省区 并加载相应市

            //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
            if (userName.Length >= 9)
            {
                LN.Model.DistributorsInfo m = new LN.BLL.DistributorsInfo().GetModel(userName.Substring(0, 7));
                if (m != null)
                {
                    ddl_dealer.SelectedValue = m.DealerID;
                    DDL_fx.Items.Add(new ListItem(m.FXName, m.FXID));
                    DDL_fx.SelectedValue = m.FXID;
                    ddl_dealer.Enabled = false;
                    DDL_fx.Enabled = false;
                }
            }
            else
            {
                DataTable IsDealer = new LN.BLL.DealerInfo().GetDealerByUserName(string.Format(" DealerID = '{0}'", userName));

                if (IsDealer.Rows.Count > 0)
                {
                    string DealerID = IsDealer.Rows[0][0].ToString().Trim();
                    ddl_dealer.SelectedValue = DealerID;
                    ddl_dealer.Enabled = false;

                    DataTable DisDT = new LN.BLL.DistributorsInfo().GetIDName(string.Format(" DealerID = '{0}'", DealerID));

                    for (int i = 0; i < DisDT.Rows.Count; i++)
                    {
                        ListItem item = new ListItem(DisDT.Rows[i][1].ToString(), DisDT.Rows[i][0].ToString());
                        DDL_fx.Items.Add(item);
                    }
                }
                else
                {
                    if (userdt.Rows.Count > 0)
                    {
                        //DDL_department.Text = userdt.Rows[0][2].ToString();
                        //DDL_department.Enabled = false;
                        ////加载区域
                        //IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(string.Format(" department = '{0}'", DDL_department.Text));
                        //foreach (LN.Model.AreaData model in arealist)
                        //{
                        //    ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                        //    DDL_Area.Items.Add(item);
                        //}

                        //DDL_Area.Text = userdt.Rows[0][0].ToString();
                        //DDL_Area.Enabled = false;
                        //IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + DDL_Area.Text);
                        //foreach (LN.Model.ProvinceData pmodel in prolist)
                        //{
                        //    DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                        //}

                        List<string> DepartmentList = new List<string>();
                        StringBuilder areas = new StringBuilder();
                        foreach (DataRow dr in userdt.Rows)
                        {

                            if (!DepartmentList.Contains(dr["DepartMent"].ToString()))
                            {
                                DepartmentList.Add(dr["DepartMent"].ToString());
                            }
                            areas.Append(dr["AreaId"] + ",");
                        }
                        hfAreas.Value = areas.ToString().TrimEnd(',');
                        if (DepartmentList.Count > 0)
                        {

                            bool canDelete = true;
                            List<ListItem> ItemList = new List<ListItem>();
                            foreach (ListItem li in DDL_department.Items)
                            {
                                if (li.Value != "0")
                                {
                                    canDelete = true;
                                    foreach (string d in DepartmentList)
                                    {
                                        if (li.Text == d)
                                        {
                                            canDelete = false;
                                            break;
                                        }
                                    }
                                    if (canDelete)
                                    {
                                        ItemList.Add(li);
                                    }
                                }

                            }
                            if (ItemList.Count > 0)
                            {
                                foreach (ListItem li in ItemList)
                                {
                                    if (DDL_department.Items.Contains(li))
                                    {
                                        DDL_department.Items.Remove(li);
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}


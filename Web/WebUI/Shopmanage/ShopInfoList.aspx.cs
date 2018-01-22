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

public partial class WebUI_Shopmanage_ShopInfoList : System.Web.UI.Page
{
    private string deptname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }

        string UserID = Request.Cookies["UserID"].Value;//得到用户ID
        string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名

        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        //if (deptdt.Rows.Count > 0)
        //{
        //    deptname = deptdt.Rows[0]["department"].ToString();
        //}

        if (!Page.IsPostBack)
        {
            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_DepartMent.Items.Add(item);
            }

            //绑定店铺级别
            LN.DAL.ShopLevel levelDLL = new LN.DAL.ShopLevel();
            DataSet ds = levelDLL.GetList("");
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                this.DDL_ShopLevel.Items.Add(item);
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

            //加载POP类型

            IList<LN.Model.POPSeat> seatlist = new LN.BLL.POPSeat().GetList("");
            foreach (LN.Model.POPSeat model in seatlist)
            {
                ListItem item = new ListItem(model.seat, model.seat);
                this.DDL_Popseat.Items.Add(item);
            }
     
            //加载POP大类
            IList<LN.Model.ProductLineType> poptypelist = new LN.BLL.ProductLineType().GetList("");
            foreach (LN.Model.ProductLineType model in poptypelist)
            {
                ListItem item = new ListItem(model.ProductTypeName, model.ProductTypeID.ToString());
                DDL_ProductType.Items.Add(item);
            }
            //加载pop故事包
            DataTable prolinedt = new LN.BLL.ProductLineData().GetDistinctLine("");
            for (int i = 0; i < prolinedt.Rows.Count; i++)
            {
                ListItem item = new ListItem(prolinedt.Rows[i]["Productline"].ToString(), prolinedt.Rows[i]["Productline"].ToString());
                DDL_POPline.Items.Add(item);
            }
            //加载店铺状态
            DataSet  stateds = new LN.BLL.ShopStateInfo().GetAllList();
            DataTable statedt = stateds.Tables[0];
            for (int i = 0; i < statedt.Rows.Count; i++)
            {
                ListItem item = new ListItem(statedt.Rows[i]["shopstate"].ToString(), statedt.Rows[i]["ID"].ToString());
                DDL_shopstate.Items.Add(item);
            }


            // 根据登录人ID得到所属省区 并加载相应市

            //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
            if (userdt.Rows.Count > 0)
            {
                if (UserName.Length >= 9)
                {
                    LN.Model.DistributorsInfo m = new LN.BLL.DistributorsInfo().GetModel(UserName.Substring(0, 7));
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
                    DataTable IsDealer = new LN.BLL.DealerInfo().GetDealerByUserName(string.Format(" DealerID = '{0}'", UserName));

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
                        //加载区域
                
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
                            foreach (ListItem li in DDL_DepartMent.Items)
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
                                    if (DDL_DepartMent.Items.Contains(li))
                                    {
                                        DDL_DepartMent.Items.Remove(li);
                                    }
                                }
                            }
                        }


                    }
                    
                }
               
            }
            if (deptdt.Rows.Count > 0)
            {
                //DDL_DepartMent.Text = deptname;
                //DDL_DepartMent.Enabled = false;
                DDL_DepartMent.DataSource = deptdt;
                DDL_DepartMent.DataTextField = "department";
                DDL_DepartMent.DataValueField = "department";
                DDL_DepartMent.DataBind();
                //加载区域
                IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(string.Format(" department='{0}'", DDL_DepartMent.SelectedValue));
                //DDL_Area.Items.Add(new ListItem("请选择省区","0"));
                foreach (LN.Model.AreaData model in arealist)
                {
                    ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                    DDL_Area.Items.Add(item);
                }
            }
            IList<int> IsSupplier = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
            if (IsSupplier != null)
            {
                HidSupplierID.Value = IsSupplier[0].ToString().Trim();
                DDL_DepartMent.SelectedValue = "0";
                DDL_Area.SelectedValue = "0";
                DDL_DepartMent.Enabled = true;
                DDL_Area.Enabled = true;
            }
        }
    }
}

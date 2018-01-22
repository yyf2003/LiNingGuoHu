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

public partial class WebUI_POPAddition_ExamPOPAddition : System.Web.UI.Page
{
    protected string UserType = string.Empty,deptname = string.Empty, UserName=string.Empty;
    protected string UserID = string.Empty;
    protected string ReUrl = string.Empty;
    protected int POPAddtionCount = 0;
    protected decimal POPAddtitionArea = 0;
    string areaid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }

        else
        {
            UserID = this.Request.Cookies["UserID"].Value;
            UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
            DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
            DataTable deptdt = deptds.Tables[0];
            //if (deptdt.Rows.Count > 0)
            //{
            //    deptname = deptdt.Rows[0]["department"].ToString();
            //}
            if (!IsPostBack)
            {
                //绑定店铺的供应商
                IList<LN.Model.SupplierInfo> SList = new LN.BLL.SupplierInfo().GetList("");
                for (int i = 0; i < SList.Count; i++)
                {
                    ListItem item = new ListItem(SList[i].SupplierName, SList[i].SupplierID.ToString());
                    ddl_supplier.Items.Add(item);
                }
                //加载部门名称
                List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
                foreach (LN.Model.DepartMentInfo deptmodel in listdept)
                {
                    ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                    DDL_department.Items.Add(item);
                }

                //判断人员类别
                UserID = this.Request.Cookies["UserID"].Value;
                //UserType = new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Usertype;

                string supplierID = "0";//如果是VM进来 供应商ID 为 0 
                IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
                if (supplierBody != null)
                {
                    supplierID = supplierBody[0].ToString();
                    ddl_supplier.Text = supplierID;
                    ddl_supplier.Enabled = false;
                }
                string strarea = "";
                if (deptdt.Rows.Count > 0)
                {
                    
                    //DDL_department.Text = deptname;
                    //DDL_department.Enabled = false;
                    DDL_department.DataSource = deptdt;
                    DDL_department.DataTextField = "department";
                    DDL_department.DataValueField = "department";
                    DDL_department.DataBind();
                    strarea += string.Format(" department='{0}' ", DDL_department.SelectedValue);
                }

                //加载区域
                IList<LN.Model.AreaData> arealist = new LN.BLL.AreaData().GetList(strarea);
                //DDL_Area.Items.Add(new ListItem("请选择省区","0"));
                foreach (LN.Model.AreaData model in arealist)
                {
                    ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
                    DDL_Area.Items.Add(item);
                }
                //绑定店铺的一级客户
                LN.DAL.DealerInfo dealerDAL = new LN.DAL.DealerInfo();

                DataTable dealerdt = dealerDAL.GetDealerName("");
                for (int i = 0; i < dealerdt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
                    ddl_dealer.Items.Add(item);
                }
                //根据等了人员得到人员所管辖的区域
                /*
                DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
                if (userdt.Rows.Count > 0)
                {
                    HF_areaid.Value = userdt.Rows[0][0].ToString();
                    DDL_department.Text = userdt.Rows[0][2].ToString();
                    DDL_department.Enabled = false;
                    DDL_Area.Text = userdt.Rows[0][0].ToString();
                    DDL_Area.Enabled = false;
                    //根据人员区域加载相应的省份
                    IList<LN.Model.ProvinceData> prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + userdt.Rows[0][0].ToString());
                    foreach (LN.Model.ProvinceData pmodel in prolist)
                    {
                        DDL_Province.Items.Add(new ListItem(pmodel.ProvinceName, pmodel.ProvinceID.ToString()));
                    }
                    //根据登录人的区域来地位供应商
                    ddl_supplier.Text = new LN.BLL.SupplierAssignRecord().GetSuplierIDbyArea(" remarks='" + userdt.Rows[0][0].ToString() + "'");
                    ddl_supplier.Enabled = false;
                }
                else
                {
                    //加载省份
                    IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
                    for (int i = 0; i < pList.Count; i++)
                    {
                        ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
                        DDL_Province.Items.Add(item);
                    }
                }
                */

                DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
                if (userdt.Rows.Count > 0)
                {
                    DDL_Area.Items.Clear();
                    DDL_Area.Items.Insert(0,new ListItem("请选择区域","0"));
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

                //加载发起的POP的ID
               string newPOPID = new LN.BLL.POPLaunch().GetLastPOPID();
               ddl_poplaunch.Items.Add(new ListItem(newPOPID, newPOPID));
                
            }
        }


    }
    protected void Btn_search_ServerClick(object sender, EventArgs e)
    {
        string posid = Txt_PosID.Text.Trim();
        string shopname = Txt_ShopName.Text.Trim();
        string proviceid =  DDL_Province.SelectedValue;
        string cityid = DDL_city.SelectedValue;
        string dept = DDL_department.SelectedValue != "0" ? DDL_department.SelectedItem.Text : "0";
        string areaID = "0";
        if (DDL_Area.SelectedValue != "0")
        {
            areaID= DDL_Area.SelectedValue;
        }
        else
        {
            areaID=hfAreas.Value != "" ? hfAreas.Value : "0";
        }
        string deaclerid = ddl_dealer.Text.ToString();
        string examstate = DDL_examstate.SelectedItem.Value;
        string supplierid = ddl_supplier.SelectedItem.Value;
        string strWhere = " 1=1 ";
        string poplaunch = ddl_poplaunch.SelectedItem.Value;
        if (posid != "")
            strWhere += " AND PosID='" + posid + "'";
        if (shopname != "")
            strWhere += " AND Shopname='" + shopname + "'";
        if (dept != "0")
            strWhere += " and department='"+dept+"'";
        if (areaID != "0")
            strWhere += " and areaID in(" + areaID+")";
        if (proviceid != "0")
            strWhere += " AND ProvinceID="+proviceid;
        if (cityid != "0")
            strWhere += " AND cityID="+cityid;
        if (deaclerid != "0")
            strWhere += " AND dealerID='" + deaclerid + "'";
        if (examstate != "-1")
        {
            string strdept = string.Empty;
            if (deptname.Length > 0)
            {
                strWhere += " and VMExamState=" + examstate + " and  ExamState=0  ";
            }
            else
            {
                strWhere += " and VMExamState=" + examstate;
            }

        }
        if (supplierid != "0")
            strWhere += " AND supplierID='" + ddl_supplier.Text + "'";
        if (poplaunch != "0")
            strWhere += " and POPID='"+poplaunch+"'";
        if (HF_areaid.Value != "")
            strWhere += " and areaid=" + HF_areaid.Value;
        DataTable dt = new LN.BLL.POPAddition().GetPOPExamlist(strWhere).Tables[0];
        if (dt.Rows.Count > 0)
        {
            gv_popaddition.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                POPAddtitionArea+=decimal.Parse( dt.Rows[i]["POPArea"].ToString());
            }
            POPAddtionCount = dt.Rows.Count;
            gv_popaddition.DataBind();
        }
        else
        {
            POPAddtionCount = 0;
            POPAddtitionArea = 0;
            gv_popaddition.DataSource = null;
            gv_popaddition.DataBind();

        }
    }

    ///// <summary>
    ///// 得到一级客户名称
    ///// </summary>
    ///// <param name="Dealerid"></param>
    ///// <returns></returns>
    //protected string GetDealerName(string Dealerid)
    //{
    //    if (Dealerid != "")
    //    {
    //        return new LN.BLL.DealerInfo().GetDealerName("Dealerid='" + Dealerid + "'").Rows[0]["Dealername"].ToString();
    //    }
    //    return "";
    //}
    ///// <summary>
    ///// 得到省份名称
    ///// </summary>
    ///// <returns></returns>
    //protected string GetProviceName(string ProID)
    //{
    //    if (!string.IsNullOrEmpty(ProID))
    //    {
    //        return new LN.BLL.ProvinceData().GetModel(int.Parse(ProID)).ProvinceName;
    //    }
    //    return "";
    //}
    ///// <summary>
    ///// 得到市的名称
    ///// </summary>
    ///// <param name="CityID"></param>
    ///// <returns></returns>
    //protected string GetCityName(string CityID)
    //{
    //    if (!string.IsNullOrEmpty(CityID))
    //    {
    //        return new LN.BLL.CityData().GetModel(int.Parse(CityID)).CityName;
    //    }
    //    return "";

    //}
    /// <summary>
    /// 判断用户是否VM 管理部 大区域 VM 区域 VM
    /// </summary>
    /// <param name="UserType"></param>
    /// <returns></returns>
    protected bool CheckUserVm(string UserType)
    {
        string[] tyes ={ "1", "2", "3" };
        foreach (string ab in tyes)
        {
            if (ab == UserType)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 选择部门
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDL_department_SelectedIndexChanged(object sender, EventArgs e)
    {
        string depName = (sender as DropDownList).SelectedItem.Text;
        DDL_Area.Items.Clear();
        DDL_Area.Items.Add(new ListItem("请选择区域", "0"));
        DDL_Province.Items.Clear();
        DDL_Province.Items.Add(new ListItem("请选择省份", "0"));
        DDL_city.Items.Clear();
        DDL_city.Items.Add(new ListItem("请选择地级城市", "0"));
        string strWhere = string.Format("department='{0}'", depName);
        IList<LN.Model.AreaData> list = new LN.BLL.AreaData().GetList(strWhere);
        if (list != null && list.Count > 0)
        {
            List<int> myAreas = new List<int>();
            if (hfAreas.Value != "")
            {
                string[] arr = hfAreas.Value.Split(',');
                foreach (string s in arr)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        myAreas.Add(int.Parse(s));
                    }
                }
            }
            foreach (LN.Model.AreaData model in list)
            {

                if (myAreas.Count > 0)
                {
                    if (myAreas.Contains(model.AreaID))
                        DDL_Area.Items.Add(new ListItem(model.AreaName, model.AreaID.ToString()));
                }
                else
                    DDL_Area.Items.Add(new ListItem(model.AreaName, model.AreaID.ToString()));
            }


        }
    }
    /// <summary>
    /// 选择区域
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDL_Area_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDL_city.Items.Clear();
        DDL_city.Items.Add(new ListItem("请选择地级城市", "0"));
        string areaId = (sender as DropDownList).SelectedValue;
        IList<LN.Model.ProvinceData> prolist = null;
        if (areaId == "-1")
            prolist = new LN.BLL.ProvinceData().GetList("");
        else
            prolist = new LN.BLL.ProvinceData().GetList(" AreaID=" + areaId);
        DDL_Province.DataSource = prolist;
        DDL_Province.DataTextField = "ProvinceName";
        DDL_Province.DataValueField = "ProvinceID";
        DDL_Province.DataBind();
        DDL_Province.Items.Insert(0, new ListItem("请选择省份", "0"));
    }
    /// <summary>
    /// 选择省份
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DDL_Province_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pid = (sender as DropDownList).SelectedValue;
        LN.DAL.CityData cityDAL = new LN.DAL.CityData();
        DataTable citydt = cityDAL.GetCityList("provinceID=" + pid);
        DDL_city.DataSource = citydt;
        DDL_city.DataTextField = "CityName";
        DDL_city.DataValueField = "CItyID";
        DDL_city.DataBind();
        DDL_city.Items.Insert(0, new ListItem("请选择地级城市", "0"));
    }
}

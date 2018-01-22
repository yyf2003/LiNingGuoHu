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
using System.Text;

public partial class WebUI_Supplier_Supplier_POPOderList : System.Web.UI.Page
{
    public string POPID = string.Empty, UserID = string.Empty, daochuurl = string.Empty,daochuAllurl = string.Empty, nosubmiturl = string.Empty, deptname = string.Empty, UserName = string.Empty, supplierID = "0", sqlstr = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value.ToString();
        UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        if (deptdt.Rows.Count > 0)
        {
            deptname = deptdt.Rows[0]["department"].ToString().Trim();
        }

        IList<int> supplierBody = new LN.BLL.SupplierInfo().GetSupplierID(UserID);
        if (supplierBody != null)
            supplierID = supplierBody[0].ToString();

        if (!Page.IsPostBack)
        {
            //List<string> poplist = new LN.BLL.POPLaunch().GetPOPID();
            IList<LN.Model.POPLaunch> list = new LN.BLL.POPLaunch().GetPOPIDList();
            foreach (LN.Model.POPLaunch m in list)
            {
                DDL_poplist.Items.Add(new ListItem(m.POPTitle, m.POPID));
            }
            initBind();
            //bind();
        }
    }

    private void initBind()
    {
        DDL_Area.Items.Add(new ListItem("请选择区域", "0"));
        DDL_Province.Items.Add(new ListItem("请选择省份", "0"));
        DDL_DealerInfo.Items.Add(new ListItem("请选择一级客户名称", "0"));
        DDL_Dis.Items.Add(new ListItem("请选择直属客户名称", "0"));

        txtBeginDate.Text = new LN.BLL.tb_OrderSearch_Time().GetOrderSearchByPOPID(DDL_poplist.SelectedValue, Convert.ToInt32(Request.Cookies["UserID"].Value));

        #region 初始化数据显示

        if (supplierID == "0")  //用户不是供应商
        {
            IList<LN.Model.AreaData> areaList = new LN.BLL.AreaData().GetList(string.Format(" DepartMent='{0}' ", deptname));//区域VM经理

            //省区VM经理
            //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);//得到人员所在的省区
            DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
            if (deptname.Length > 0)
            {
                foreach (LN.Model.AreaData model in areaList)
                {
                    DDL_Area.Items.Add(new ListItem(model.AreaName, model.AreaID.ToString()));
                }
            }
            else
            {
                if (userdt.Rows.Count > 0)
                {
                    //DDL_Area.Items.Add(new ListItem(userdt.Rows[0][1].ToString(), userdt.Rows[0][0].ToString()));
                    //DDL_Area.SelectedValue = userdt.Rows[0][0].ToString();
                    //DDL_Area.Enabled = false;

                    //IList<LN.Model.ProvinceData> listProvince = new LN.BLL.ProvinceData().GetList(string.Format(" AreaID = {0} ", DDL_Area.SelectedValue));
                    //if (listProvince.Count > 0)
                    //{
                    //    foreach (LN.Model.ProvinceData model in listProvince)
                    //    {
                    //        DDL_Province.Items.Add(new ListItem(model.ProvinceName, model.ProvinceID.ToString()));
                    //    }
                    //}
                    StringBuilder areas = new StringBuilder();
                    foreach (DataRow dr in userdt.Rows)
                    {
                        areas.Append(dr["AreaId"] + ",");
                        DDL_Area.Items.Add(new ListItem(dr["AreaName"].ToString(), dr["AreaId"].ToString()));
                    }
                    hfAreas.Value = areas.ToString().TrimEnd(',');





                    DataTable dtDealer = new LN.BLL.DealerInfo().GetDealerName(string.Format(" AreaID = {0} ", DDL_Area.SelectedValue));
                    if (dtDealer.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtDealer.Rows)
                        {
                            DDL_DealerInfo.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                        }
                    }
                }
                else
                {
                    IList<LN.Model.AreaData> AllAreaList = new LN.BLL.AreaData().GetList("");//VM 管理部
                    foreach (LN.Model.AreaData model in AllAreaList)
                    {
                        DDL_Area.Items.Add(new ListItem(model.AreaName, model.AreaID.ToString()));
                    }
                }
            }
        }
        else
        {
            DDL_Area.Enabled = false;
            DDL_Province.Enabled = false;
            DDL_DealerInfo.Enabled = false;
            DDL_Dis.Enabled = false;
        }
        #endregion



    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {
        string strBeginDateTime = String.Empty;
        string strEndDateTime = String.Empty;

        POPID = DDL_poplist.SelectedValue.Trim();
        sqlstr = " and POPID='" + POPID + "'";
        string strProvince = "0";
        string strDealerInfo = "0";
        string strFXID = "0";
        if (Request.Form["DDL_Province"] != null)
            strProvince = Request.Form["DDL_Province"].Trim();
        if (Request.Form["DDL_DealerInfo"] != null)
            strDealerInfo = Request.Form["DDL_DealerInfo"].Trim();
        if (Request.Form["DDL_Dis"] != null)
            strFXID = Request.Form["DDL_Dis"].Trim();

        if (txtBeginDate.Text.Trim() != "")
            strBeginDateTime = txtBeginDate.Text.Trim() ;

        if (deptname.Length > 0)
        {
            sqlstr += " and  department='" + deptname + "' ";

            daochuAllurl = "<a href='POPOrderdaochu.aspx?dept=" + Server.UrlEncode(deptname) + "&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>当前所有已完成订单</a>";
            daochuurl = "<a href='POPOrderdaochu.aspx?dept=" + Server.UrlEncode(deptname) + "&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "&begdate=" + strBeginDateTime.Trim() + "'>当前分批次订单</a>";
            nosubmiturl = "<a href='POP_NoSubmitOrder.aspx?dept=" + Server.UrlEncode(deptname) + "&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>导出所有未提交订单的店铺</a>";
        }
        else
        {
            if (supplierID == "0")
            {
                //modify by mhj 2012.08.17
                //daochuAllurl = "<a href='POPOrderdaochu.aspx?POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>当前所有已完成订单</a>";
                //daochuurl = "<a href='POPOrderdaochu.aspx?POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "&begdate=" + strBeginDateTime.Trim() + "'>当前分批次订单</a>";
                //nosubmiturl = "<a href='POP_NoSubmitOrder.aspx?dept=" + Server.UrlEncode(deptname) + "&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>导出所有未提交订单的店铺</a>";
                daochuAllurl = "<a href='POPOrderdaochu.aspx?SpecialType=-1&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>当前所有已完成订单（全部）</a>";
                daochuAllurl += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                daochuAllurl += "<a href='POPOrderdaochu.aspx?SpecialType=1&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>当前所有已完成订单（标杆店）</a>";
                daochuAllurl += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                daochuAllurl += "<a href='POPOrderdaochu.aspx?SpecialType=0&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>当前所有已完成订单（普通店）</a>";

                daochuurl = "<br><br><a href='POPOrderdaochu.aspx?POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "&begdate=" + strBeginDateTime.Trim() + "'>当前分批次订单</a>";
                nosubmiturl = "<a href='POP_NoSubmitOrder.aspx?dept=" + Server.UrlEncode(deptname) + "&POPID=" + POPID + "&areaid=" + DDL_Area.SelectedValue + "&province=" + strProvince + "&dealer=" + strDealerInfo + "&fxid=" + strFXID + "'>导出所有未提交订单的店铺</a>";
           
            
            }
            else
            {
                //modify by mhj 2012.08.17
                //daochuAllurl = "<a href='POPOrderdaochu.aspx?POPID=" + POPID + "&sid=" + supplierID + "'>当前所有已完成订单</a>";//供应商导出POP订单
                //daochuurl = "<a href='POPOrderdaochu.aspx?POPID=" + POPID + "&sid=" + supplierID + "&begdate=" + txtBeginDate.Text.Trim() + "'>当前分批次订单</a>";//供应商导出POP订单
                //nosubmiturl = "<a href='POP_NoSubmitOrder.aspx?POPID=" + POPID + "&sid=" + supplierID + "'>导出所有未提交订单的店铺</a>";//供应商导出POP订单
                //sqlstr += " and c.supplierID=" + supplierID;
                daochuAllurl = "<a href='POPOrderdaochu.aspx?SpecialType=-1&POPID=" + POPID + "&sid=" + supplierID + "'>当前所有已完成订单（全部）</a>";//供应商导出POP订单
                daochuAllurl += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                daochuAllurl = "<a href='POPOrderdaochu.aspx?SpecialType=1&POPID=" + POPID + "&sid=" + supplierID + "'>当前所有已完成订单（标杆店）</a>";
                daochuAllurl += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                daochuAllurl = "<a href='POPOrderdaochu.aspx?SpecialType=0&POPID=" + POPID + "&sid=" + supplierID + "'>当前所有已完成订单（普通店）</a>";
                
                daochuurl = "<br><br><a href='POPOrderdaochu.aspx?POPID=" + POPID + "&sid=" + supplierID + "&begdate=" + txtBeginDate.Text.Trim() + "'>当前分批次订单</a>";//供应商导出POP订单
                nosubmiturl = "<a href='POP_NoSubmitOrder.aspx?POPID=" + POPID + "&sid=" + supplierID + "'>导出所有未提交订单的店铺</a>";//供应商导出POP订单
                sqlstr += " and c.supplierID=" + supplierID;
            }
        }

        DataTable dt = new LN.BLL.imageToPOP().Supplier_POPcount(sqlstr);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();      
    }
}

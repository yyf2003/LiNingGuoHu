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

public partial class WebUI_Shopmanage_test : System.Web.UI.Page
{
    protected string UserName = String.Empty, UserID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
        if (!IsPostBack)
        {
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
}

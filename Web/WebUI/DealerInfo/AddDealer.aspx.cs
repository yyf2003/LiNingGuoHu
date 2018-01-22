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

public partial class WebUI_DealerInfo_AddDealer : System.Web.UI.Page
{
    string deptname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
       
        string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名
        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        if (deptdt.Rows.Count > 0)
        {
            deptname = deptdt.Rows[0]["department"].ToString();
        }
        if (!IsPostBack)
        {
            LoadProviceData();
        }
    }
    public void LoadProviceData()
    {

        //IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
        //for (int i = 0; i < pList.Count; i++)
        //{
        //    ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
        //    DDL_Province.Items.Add(item);
        //}

        //加载部门名称
        List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
        foreach (LN.Model.DepartMentInfo deptmodel in listdept)
        {
            ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
            DDL_department.Items.Add(item);
        }
        string strarea = "";
        if (!string.IsNullOrEmpty(deptname))
        {
            strarea += string.Format(" department='{0}' ", deptname);
            DDL_department.Text = deptname;
            DDL_department.Enabled = false;
        }
        string UserID = Request.Cookies["UserID"].Value;//得到用户ID
        IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList(strarea);
        foreach (LN.Model.AreaData model in AreaList)
        {
            ListItem item = new ListItem(model.AreaName, model.AreaID.ToString());
            DDL_Area.Items.Add(item);
        }

        
        //根据登录人ID得到所属省区 并加载相应市
        //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);
        if (userdt.Rows.Count > 0)
        {
            //DDL_department.Text = userdt.Rows[0][2].ToString();//add by mhj 20130529
            //DDL_department.Enabled = false;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string DealerID = this.Request.Form["txt_DealerID"].ToString();
        string DealerName = this.txt_DealerName.Text;
        string AreadID = DDL_Area.SelectedValue;//this.Request.Form["DDL_Area"].ToString();
        string ProvinceID = DDL_Province.SelectedValue;//this.Request.Form["DDL_Province"].ToString();
        string CityID = DDL_city.SelectedValue;//this.Request.Form["DDL_city"].ToString();
        string Contactor = this.Request.Form["txt_Contactor"].ToString();
        string ContactorPhone = this.Request.Form["txt_UserMobile"].ToString();
        string Address = this.Request.Form["txt_Address"].ToString();
        string PostAddress = this.Request.Form["txt_PostAddress"].ToString();
        string DealerChannel = txt_Dealerchannel.Text.Trim();
        LN.Model.DealerInfo model = new LN.Model.DealerInfo();
        model.DealerID = DealerID;
        model.DealerName = DealerName;
        model.AreaID = int.Parse(AreadID);
        model.ProvinceID = int.Parse(ProvinceID);
        model.CityID = int.Parse(CityID);
        model.Contactor = Contactor;
        model.ContactorPhone = ContactorPhone;
        model.Address = Address;
        model.PostAddress = PostAddress;
        model.DealerChannel = DealerChannel;
        model.ExamState = 0;
        new LN.BLL.DealerInfo().Add(model);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('添加成功！');window.location='DealerList.aspx';</script>");



    }
}

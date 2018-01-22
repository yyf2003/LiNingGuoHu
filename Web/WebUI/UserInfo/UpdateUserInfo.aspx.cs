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
using System.Linq;

public partial class WebUI_UserInfo_UpdateUserInfo : System.Web.UI.Page
{
    public string UserID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value.ToString();//登录人ID
        if (!IsPostBack)
        {
            //GetOneUserInfo();
            BindData();
        }
    }

    //public void GetOneUserInfo()
    //{
    //    IList<LN.Model.UserTypeData> list = new LN.BLL.UserTypeData().GetList("");
    //    ddl_UserType.DataSource = list;
    //    ddl_UserType.DataTextField = "Usertype";
    //    ddl_UserType.DataValueField = "ID";
    //    ddl_UserType.DataBind();
    //    ddl_UserType.SelectedValue = new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Usertype;

    //    List<LN.Model.DealerInfo> listdea = new LN.BLL.DealerInfo().GetModelList("");

    //    for (int j = 0; j < listdea.Count; j++)
    //    {
    //        ListItem ltdea = new ListItem(listdea[j].DealerName, listdea[j].DealerID.ToString());
    //        this.DDL_dealerList.Items.Add(ltdea);
    //    }
    //    //加载部门名称
    //    List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
    //    foreach (LN.Model.DepartMentInfo deptmodel in listdept)
    //    {
    //        ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
    //        DDL_department.Items.Add(item);
    //    }


    //    LN.Model.UserInfo model = new LN.BLL.UserInfo().GetModel(int.Parse(UserID));
    //    if (model != null)
    //    {
    //        UserID = model.UserID.ToString();
    //        txt_UserName.Text = model.Username;
    //        ddl_Sex.SelectedValue = model.Sex;
    //        txt_Pwd.Text = model.UserPassword;
    //        txt_UserMail.Text = model.UserEmail;
    //        txt_UserAddress.Text = model.UserAddress;
    //        txt_UserPhone.Text = model.UserPhone;
    //        txt_UserMobile.Text = model.UserMobel;
    //        lblUserState.Text = model.UserState == 1 ? "在职" : "离职";
    //        //LN.Model.AreaData areamodel = new LN.BLL.AreaData().GetModel(model.Userofarea);
    //        //if (areamodel != null)
    //        //    DDL_department.Text = areamodel.DepartMent;
    //        //else
    //        //    DDL_department.Text = "0";
    //        //if (DDL_department.Text != "0")
    //        //{
    //        //    IList<LN.Model.AreaData> listmodel = new LN.BLL.AreaData().GetList("department='"+DDL_department.Text+"'");
    //        //    foreach (LN.Model.AreaData m in listmodel)
    //        //    {
    //        //        ListItem item = new ListItem(m.AreaName, m.AreaID.ToString());
    //        //        DDL_Area.Items.Add(item);
    //        //    }

    //        //    DDL_Area.Text = model.Userofarea.ToString();
    //        //}
    //        //txt_UserDesc.Text = model.UserDesc;
    //    }
    //    //this.DataBind();
    //}

    LN.BLL.DepartMentInfo departmentBll = new LN.BLL.DepartMentInfo();
    LN.BLL.UserInAreaBLL userInAreaBll = new LN.BLL.UserInAreaBLL();
    void BindData()
    {
        LN.Model.UserInfo model = new LN.BLL.UserInfo().GetModel(int.Parse(UserID));
        if (model != null)
        {
            labUserName.Text = model.Username;
            ddl_Sex.SelectedValue = model.Sex;
            //labRole.SelectedValue = model.Usertype;
            txt_UserMail.Text = model.UserEmail;
            txt_UserAddress.Text = model.UserAddress;
            txt_UserPhone.Text = model.UserPhone;
            txt_UserMobile.Text = model.UserMobel;

            txt_UserDesc.Text = model.UserDesc;
            lblUserState.Text = model.UserState != null && model.UserState == 1 ? "在职" : "离职";
            if (model.Usertype != null && !string.IsNullOrWhiteSpace(model.Usertype))
            {
                LN.Model.UserTypeData userTypeModel = new LN.BLL.UserTypeData().GetModel(int.Parse(model.Usertype));
                if (userTypeModel != null)
                {
                    labRole.Text = userTypeModel.Usertype;
                }
            }
            

            //加载部门和区域
            if (model.Usertype == "2")
            {
                //区域VM经理
                DataSet ds = departmentBll.GetList(string.Format("Department_Master='{0}'", model.Username));
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    
                    labDepart.Text = ds.Tables[0].Rows[0]["department"].ToString(); ;
                }
            }
            else
            {
                //省区VM
                DataTable dt = userInAreaBll.GetAreaByUserId(UserID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!dic.Keys.Contains(dr["DepartMent"].ToString()))
                        {
                            List<string> list = new List<string>();
                            list.Add(dr["AreaName"].ToString());
                            dic.Add(dr["DepartMent"].ToString(), list);
                        }
                        else
                        {
                            List<string> list = dic[dr["DepartMent"].ToString()];
                            list.Add(dr["AreaName"].ToString());
                            dic[dr["DepartMent"].ToString()] = list;
                        }
                    }
                    if (dic.Any())
                    {

                        StringBuilder sb = new StringBuilder();
                        int index = 0;
                        dic.ToList().ForEach(s =>
                        {
                            if (index == 0)
                            {
                                labDepart.Text = s.Key;
                            }
                            index++;
                            List<string> lines = s.Value;
                            if (lines.Any())
                            {
                                string check = string.Empty;
                                lines.ForEach(p =>
                                {
                                    sb.AppendFormat("{0},", p);
                                });
                            }
                            
                        });
                        labAreas.Text = sb.ToString();
                    }
                    
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //string Username = this.txt_UserName.Text;
        //string UserPassword = this.txt_Pwd.Text;
        string Sex = this.ddl_Sex.SelectedValue;
        //string UserType = this.ddl_UserType.SelectedItem.Value;
        string UserEmail = this.txt_UserMail.Text;
        string UserAddress = this.txt_UserAddress.Text;
        string UserPhone = this.txt_UserPhone.Text;
        string UserMobile = this.txt_UserMobile.Text; 
        string UserDes = this.txt_UserDesc.Text;
        string Qid = UserID;
        LN.Model.UserInfo model = new LN.Model.UserInfo();
        model.Sex = Sex;
        model.UserAddress = UserAddress;
        model.UserDesc = UserDes;
        model.UserEmail = UserEmail;
        model.UserMobel = UserMobile;
        //model.Username = Username;
        //model.UserPassword = UserPassword;
        model.UserPhone = UserPhone;
        //model.UserState = 1;
        //model.Usertype = UserType;
        model.ID = int.Parse(Qid);
        //model.UserID = int.Parse(Qid);
        //model.Userofarea = int.Parse(Request.Form["DDL_Area"].ToString());
        new LN.BLL.UserInfo().NewUpdate(model);
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('修改成功！');</script>"); 

//window.location='UserList.aspx'
    }
}

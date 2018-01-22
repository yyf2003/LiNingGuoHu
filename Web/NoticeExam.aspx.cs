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
using System.Text;
using LN.DBUtility;
public partial class NoticeExam : System.Web.UI.Page
{
    string UserID = string.Empty, deptname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='./Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        string UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);//得到登录人姓名

        DataSet deptds = new LN.BLL.DepartMentInfo().GetList(string.Format(" department_Master='{0}'", UserName));
        DataTable deptdt = deptds.Tables[0];
        //if (deptdt.Rows.Count > 0)
        //{
        //    deptname = deptdt.Rows[0]["department"].ToString();
        //}

        int usertype = new LN.BLL.UserTypeData().GetUserType(UserID);
        //DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);

        DataTable userdt = new LN.BLL.UserInAreaBLL().GetAreaByUserId(UserID);

        string strdept = string.Empty;
        //if (deptname.Length > 0)
        //{
        //    strdept = " and a.VMExamState=1 and  a.ExamState=0 and areadata.department='" + deptname + "' ";
        //}
        if (deptdt.Rows.Count > 0)
        {
            System.Text.StringBuilder departs = new StringBuilder();
            foreach (DataRow dr in deptdt.Rows)
            {
                departs.Append("'" + dr["department"] + "',");
                
            }
            if (departs.Length>0)
            {
                strdept = " and a.VMExamState=1 and  a.ExamState=0 and areadata.department in(" + departs.ToString().TrimEnd(',') + ")";
            }
        }
        else if (usertype == 3)//省区vm经理
        {
            if (userdt.Rows.Count > 0)
            {
                StringBuilder areas = new StringBuilder();
                foreach (DataRow dr in userdt.Rows)
                {
                    areas.Append(dr["AreaId"] + ",");
                }
                strdept = " and (a.VMExamState=0 or a.VMExamState is null) and areadata.areaid in (" + areas.ToString().TrimEnd(',') + ")";
            }
            //strdept = " and (a.VMExamState=0 or a.VMExamState is null) and areadata.areaid=" + userdt.Rows[0][0].ToString();
        }

        string newpopid = new LN.BLL.POPLaunch().GetLastPOPID();
        string strpop = "1 = 1";
        if (newpopid.Length > 0)
            strpop = " popid='" + newpopid + "'";

        StringBuilder sb = new StringBuilder();
        sb.Append("  select ( select count(*)  from dealerinfo a inner join areadata  on a.areaid=areadata.areaid where 1=1 " + strdept + ") e ,");

        sb.Append("(select count(*)  from DistributorsInfo  a inner join areadata  on a.areaid=areadata.areaid where 1=1 " + strdept + ") f,");

        sb.Append("(select count(*)  from View_POPInfo a inner join shopinfo b on a.shopid=b.shopid ");
        sb.Append(" inner join areadata  on b.areaid=areadata.areaid  where 1=1  " + strdept + ") g,");

        sb.Append("(select count(*)  from shopinfo  a inner join areadata  on a.areaid=areadata.areaid  where shopstate>0 " + strdept + ") h,");

        sb.Append("(select count(*)  from dbo.POPAddition a inner join shopinfo b on a.shopid=b.shopid ");
        sb.Append("inner join areadata  on b.areaid=areadata.areaid where   1=1  " + strdept + " and " + strpop + ") x,");

        sb.Append("(select count(*)  from EditShopInfo  a inner join areadata  on a.areaid=areadata.areaid  where shopstate>0 " + strdept + " ) y");


        DataSet ds = DbHelperSQL.Query(DbHelperSQL.connectionString(), sb.ToString());

        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            StringBuilder str = new StringBuilder();
            if (usertype == 3 || deptname.Length > 0)//省区vm经理
            {

                str.Append("店铺季度新增POP审核：<a href=\"../ShopPOP/ConfirmPOP.aspx\">" + dt.Rows[0]["g"].ToString() + "条</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                str.Append("季度原损加单审核：<a href=\"../POPAddition/ExamPOPAddition.aspx\">" + dt.Rows[0]["x"].ToString() + "条</a><br/><br/>");

                str.Append("季度新增店铺审核：<a href=\"../Shopmanage/ExamNewShopList.aspx\">" + dt.Rows[0]["h"].ToString() + "条</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                str.Append("一级客户审核：<a href=\"../DealerInfo/ExamDealerInfo.aspx\">" + dt.Rows[0]["e"].ToString() + "条</a><br/><br/>");

                str.Append("店铺修改信息审核：<a href=\"../Shopmanage/ExamEditShopinfo.aspx\">" + dt.Rows[0]["y"].ToString() + "条</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                str.Append("直属客户从属关系审核：<a href=\"../Distribution/ExamFx.aspx\">" + dt.Rows[0]["f"].ToString() + "条</a><br/><br/>");
                Response.Write(str.ToString());
            }
            else
                Response.Write("");
        }
        else
            Response.Write("");

    }
}

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

public partial class WebUI_Affiche_Index : System.Web.UI.Page
{
    public bool boolshow;
    public string nodata = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (this.Request.Cookies["UserID"] != null)
        {
            boolshow = CheckUser();
            this.DataBind();
            GetData();
        }
        else
        {
            Response.Redirect("../../login.aspx");
        }
    }
    public void GetData()
    {
        DataTable dt = new LN.BLL.AfficheData().GetTop6ScrollList().Tables[0];
        if (dt.Rows.Count > 0)
        {
            //Repeater3.DataSource = dt;
            //Repeater3.DataBind();
            Repeater4.DataSource=dt;
            Repeater4.DataBind();
            //if (dt.Rows.Count > 5)
            //{
            //    string mainjs = "  <script>" +
            //    "var t=demo.scrollTop\r\n" +

            //    "demo2.innerHTML =demo1.innerHTML\r\n" +
            //    "function qswhMarquee(){\r\n" +
            //    "if(demo2.offsetTop-demo.scrollTop<=0)\r\n" +
            //    "demo.scrollTop-=demo1.offsetHeight\r\n" +
            //    "else\r\n" +
            //    "demo.scrollTop++\r\n" +
            //    "}\r\n" +
            //    "var t =setInterval(qswhMarquee,40)\r\n" +
            //    "demo.onmouseover=function(){clearInterval(t)}\r\n" +
            //            "demo.onmouseout=function(){t=setInterval(qswhMarquee,40)};" +
            //    "  </script>";
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "scroll", mainjs);

            //}
        }  
    }
    //public void BindRepeater2()
    //{
    //    for (int i = 0; i < Repeater1.Items.Count; i++)
    //    {
    //        string affichetypeid = ((Label)Repeater1.Items[i].FindControl("Label2")).Text;
    //        LN.BLL.AfficheData nbadata = new LN.BLL.AfficheData();
    //        DataSet ds = nbadata.GetTop6List("typeid=" + affichetypeid);
    //        Repeater rep2 = (Repeater)Repeater1.Items[i].FindControl("Repeater2");
    //        rep2.DataSource = ds;
    //        rep2.DataBind();
    //    }
    //}
    protected bool CheckUser()
    {
        //得到管理公告的编号
        //string affichepageid = new LN.BLL.sysFunction().GetDataWithkeywords("funcName='公告' and callFormClass='Index.aspx' ").ToString();
        //string UserID = this.Request.Cookies["UserID"].Value;
        //string UsreType = new LN.BLL.UserManage().GetUserTypeByUserId(UserID);
        //if (UsreType != "0")
        //{
        //    LN.Model.roleAndPower nmrmodel = new LN.Model.roleAndPower();
        //    nmrmodel = new LN.BLL.roleAndPower().GetModel(Convert.ToInt32(UsreType));
        //    string functinids = nmrmodel.functionId;
        //    string[] fun = functinids.Split('-');
        //    foreach (string dd in fun)
        //    {
        //        if (dd == affichepageid)
        //        {
        //            return true;
        //        }
        //    }
        //}
        //return false;
        return true;
    }
}

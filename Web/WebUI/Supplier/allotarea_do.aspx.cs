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

public partial class WebUI_Supplier_allotarea_do : System.Web.UI.Page
{
    private string ProIDlist = "",Areaidlist=string.Empty,deptlist=string.Empty,PosIDstr=string.Empty;  //省份编号
    //private string CityIDlist = ""; //城市编号
    private string sname = "";      //一级客户编号
    private string gid = "";        //一级客户名称
    //private string townlist = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        deptlist = Request.Form["dept"].ToString();
        Areaidlist = Request.Form["area"] == null ? "" : Request.Form["area"].ToString();

        ProIDlist = Request.Form["province"] == null ? "" : Request.Form["province"].ToString();
        PosIDstr = Request.Form["HF_shopid"] == null ? "" : Request.Form["HF_shopid"].ToString();
        //CityIDlist = Request.Form["city"]==null?"":Request.Form["city"].ToString();
        //townlist = Request.Form["Town"] == null ? "" : Request.Form["Town"].ToString();
        gid = Request.QueryString["id"].ToString();
        //bool Boolcity = true;
        //if (ProIDlist.Length <= 0)
        //{
        //    Boolcity = false;
        //    CityIDlist = ProIDlist;
        //}
        if (deptlist.Length > 0)
        {
            string tempstr = string.Empty;
            if (deptlist.IndexOf(',') > 0)
            {
                string[] deptarr = deptlist.Split(new char[] { ',' });
                for (int i = 0; i < deptarr.Length; i++)
                {
                    tempstr += "'" + deptarr[i].ToString() + "',";
                }
                tempstr = tempstr.Remove(tempstr.Length - 1);
            }
            else
                tempstr = "'" + deptlist + "'";

            deptlist = tempstr;
        }
        sname = Request.QueryString["name"].ToString();
        if (allot(gid,PosIDstr,deptlist, Areaidlist, ProIDlist))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", "<script>alert('分配成功！');location.href='ShowAllotArea.aspx?id=" + gid + "'</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", "<script>alert('分配失败！，请从新操作或者联系维护人员');location.href='ShowAllotArea.aspx?id=" + gid + "'</script>");
        }
    }
    protected bool allot(string gid,string posIDlist, string dept, string Arealist, string Prolist)
    {
        return new LN.BLL.SupplierAssignRecord().allotshop(gid, posIDlist,dept, Arealist, Prolist);
    }
}

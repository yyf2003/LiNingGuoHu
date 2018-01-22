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

public partial class WebUI_Supplier_allotarea_getShopByarea : System.Web.UI.Page
{

    string provincelist = string.Empty, arealist = string.Empty, deptlist = string.Empty,id=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        provincelist = Request.QueryString["citylist"].ToString();
        deptlist = Request.QueryString["deptlist"].ToString();
        arealist = Request.QueryString["arealist"].ToString();
        id = Request.QueryString["id"].ToString();

        if (deptlist.Length > 0)
            deptlist = deptlist.Remove(deptlist.Length - 1);
        if (arealist.Length > 0)
            arealist = arealist.Remove(arealist.Length - 1);
        if (provincelist.Length > 0)
            provincelist = provincelist.Remove(provincelist.Length - 1);
       

        string strsql = " 1=1 ";
        if (provincelist.Length > 0)
        {
            strsql += " and ProvinceID in ("+provincelist+")";
        }
        if (arealist.Length > 0)
            strsql += " and areaid in ("+arealist+")";
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
                tempstr = tempstr.Remove(tempstr.Length-1);
            }
            else
                tempstr = "'"+deptlist + "'";


            strsql += " and department in  (" + tempstr + ")";
        }
        //strsql += " and shopid not in (select distinct assignshopid from SupplierAssignRecord where supplierID="+id+") ";
        DataSet ds = new LN.BLL.ShopInfo().GetSublist( strsql+ " order by shopname");
        DataTable dt = ds.Tables[0];
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
}



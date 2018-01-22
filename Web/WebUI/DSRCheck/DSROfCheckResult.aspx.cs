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
public partial class WebUI_DSRCheck_DSROfCheckResult : System.Web.UI.Page
{
    protected StringBuilder Bigtable = new StringBuilder();
    protected int checkshopnum = 0,shouldcheck=0;
    string UserID = "";
    protected string resultstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        txt_DsrName.Text = Server.UrlDecode(Request.Cookies["UserName"].Value);

        
        if (!Page.IsPostBack)
        {
            //加载供应商


            IList<LN.Model.SupplierInfo> list = new LN.BLL.SupplierInfo().GetList("");
            for (int i = 0; i < list.Count; i++)
            {
                ListItem item = new ListItem(list[i].SupplierName, list[i].SupplierID.ToString());
                this.ddl_supplier.Items.Add(item);
            }
            //加载所有的 POP发起ID
            IList<string> plist = new LN.BLL.POPLaunch().GetPOPID();

            for (int i = 0; i < plist.Count; i++)
            {
                ListItem item = new ListItem(plist[i].ToString(), plist[i].ToString());
                DDL_POPID.Items.Add(item);
            }
        }
    }
    protected void Btn_search_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("supplerID", ddl_supplier.Text);
        ht.Add("beginDate", "");
        ht.Add("endDate","");
        ht.Add("POPID", DDL_POPID.Text);
        ht.Add("areaID", "0");
        ht.Add("provinceID","0");
        ht.Add("cityID", "0");
        ht.Add("checkname", UserID);
        ht.Add("boolstall", "请选择");
        DataTable userdt = new LN.BLL.UserInfo().GetAreaByUserId(UserID);
        ht.Add("department", userdt.Rows[0][2].ToString());
        DataSet ds = new LN.BLL.DSRExamData().GetResultlist(ht);
        DataTable dt1 = ds.Tables[0];
        DataTable dt2 = ds.Tables[1];
        DataTable dt3 = ds.Tables[2];
        checkshopnum = int.Parse(dt3.Rows[0][0].ToString());
        Bigtable.Append("<table class='table' style=' margin-left:5%'");
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            Bigtable.Append("<tr>");
            Bigtable.Append("<td valign='middle' align='center'>" + dt2.Rows[i][0].ToString() + "</td><td>" + GetSubtable(dt1, dt2.Rows[i][0].ToString()) + "</td><td valign='middle' align='center'>" + ((float)dt2.Rows[i][1]).ToString("##0.00") + "%</td>");
            Bigtable.Append("</tr>");
        }
        Bigtable.Append("</table>");

        shouldcheck = new LN.DAL.Base_set().GetBase_value("DSRCheckShop");//应该检查的店铺
        if (txt_DsrName.Text != "")
        {
            resultstr = txt_DsrName.Text + "应检查" + shouldcheck.ToString() + "家店铺,实际检查&nbsp;&nbsp;&nbsp;&nbsp;<a href='OneDsrCheckshop.aspx?POPID=" + DDL_POPID.Text + "&checkuser=" + UserID + "&checkname=" + Server.HtmlEncode(txt_DsrName.Text) + "'>" + checkshopnum.ToString() + "</a>&nbsp;&nbsp;&nbsp;&nbsp;加店铺，检查了" + (decimal)checkshopnum * 100 / (decimal)shouldcheck + "%";
        }
    }

    public string GetSubtable(DataTable dt, string Dsrtype)
    {
        StringBuilder strtable = new StringBuilder();
        strtable.Append("<table style='width:100%'>");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Dsrtype.Equals(dt.Rows[i][0].ToString()))
            {
                strtable.Append("<tr>");
                strtable.Append("<td style='width:300px'>" + dt.Rows[i][1].ToString() + "</td><td>" + ((float)dt.Rows[i][2]).ToString("##0.00") + "%</td>");
                strtable.Append("</tr>");
            }
        }
        strtable.Append("</table>");

        return strtable.ToString();
    }
}


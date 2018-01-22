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
public partial class WebUI_DSRCheck_DSRCheckShop : System.Web.UI.Page
{
    int noRules = 0;//gridView 第一列所显示的序列号
    string shopid = "", UserID = "", POPID = "", cityID = "", ProvinceID = "";//店铺ID，检查人ID，POP发起ID，店铺所属供应商ID
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        shopid = Request.QueryString["shopid"].ToString();
        UserID = Request.Cookies["UserID"].Value;
        string Username = Server.UrlDecode(Request.Cookies["UserName"].Value);//从Cookie中得到

        //LN.Model.POPLaunch launchmodel = new LN.BLL.POPLaunch().GetNewestModel();

        POPID = new LN.BLL.POPChangeSet().GetPOPIDByShopID(shopid);
        //if (launchmodel != null)
        //{
        //    POPID = launchmodel.POPID;
        //}
        if(string.IsNullOrEmpty(POPID))
        {
            Response.Write("<script>alert('没有发起的POP您还不能进行检查；');</script>");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            LN.BLL.DSRCheckRules rulesBLL = new LN.BLL.DSRCheckRules();
            DataSet ruleds = rulesBLL.GetList(" rulesState=1 order by  Dsrchecktype,RulesID,Dsrrules");
            DataTable rulesdt = ruleds.Tables[0];
            this.GridView1.DataSource = rulesdt;
            this.GridView1.DataBind();

            LN.BLL.ShopInfo oneInfo = new LN.BLL.ShopInfo();
            DataSet ds = oneInfo.GetList(" ShopID=" + shopid);

            DataTable dt = ds.Tables[0];
            DataTable supplierdt = new LN.BLL.SupplierAssignRecord().GetSpplierAssignRecordWithShopID(int.Parse(shopid));

            if (supplierdt.Rows.Count>0)
            {
                this.Txt_gyx.Text = supplierdt.Rows[0]["SupplierName"].ToString();
                this.HF_supplierID.Value = supplierdt.Rows[0]["SupplierID"].ToString();
            }
            this.PosID.Text = dt.Rows[0]["PosID"].ToString();
            this.Txt_Shopname.Text = dt.Rows[0]["ShopName"].ToString();
            this.Txt_City.Text = dt.Rows[0]["ProvinceName"].ToString()+"，"+dt.Rows[0]["CityName"].ToString();
            this.Txt_Dealer.Text = dt.Rows[0]["DealerName"].ToString();
            this.Txt_checkman.Text = Username;
            HF_ProvinceID.Value = dt.Rows[0]["ProvinceID"].ToString();
            HF_cityID.Value = dt.Rows[0]["CityID"].ToString();
            
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ECECEC'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            e.Row.Cells[7].Visible=false;

            
        }
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            noRules++;
            e.Row.Cells[0].Text = noRules.ToString();
            CheckBox cb1 = e.Row.Cells[3].FindControl("Check_Yes") as CheckBox;
            CheckBox cb2 =e.Row.Cells[4].FindControl("Check_No") as CheckBox;
            TextBox fen = e.Row.Cells[5].FindControl("Label_result") as TextBox;
            TextBox txt_remark = e.Row.Cells[6].FindControl("txt_remarks") as TextBox;
            cb1.Attributes.Add("onclick", "javascript:chooesYes(this.id,'" + txt_remark.ClientID + "','"+cb2.ClientID+"','" + fen.ClientID + "');");
            cb2.Attributes.Add("onclick", "javascript:chooesNo(this.id,'" + txt_remark.ClientID + "','"+cb1.ClientID+"','" + fen.ClientID + "');");
           
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        int Flag = 0;
        int rulesID = 0, Yesnum = 0, Nonum = 0;
        string strSql = "";
        string DataID = DateTime.Now.Ticks.ToString();
        StringBuilder MainStr = new StringBuilder();
        foreach (GridViewRow Grow in GridView1.Rows)
        {
            CheckBox cb1 = Grow.Cells[3].FindControl("Check_Yes") as CheckBox;
            CheckBox cb2 = Grow.Cells[4].FindControl("Check_No") as CheckBox;
            TextBox fen = Grow.Cells[5].FindControl("Label_result") as TextBox;
            TextBox txt_remark = Grow.Cells[6].FindControl("txt_remarks") as TextBox;

            if (cb1.Checked)
            {
                Flag = 1;
                Yesnum++;
            }
            if (cb2.Checked)
            {
                Flag = 0;
                Nonum++;
            }
            rulesID = int.Parse(Grow.Cells[7].Text.ToString());

            strSql = "INSERT into DSRResultsList values ('" + DataID + "'," + rulesID + ",'" + Flag + "','" + txt_remark.Text.Trim() + "')";
            list.Add(strSql);
        }
        cityID = HF_cityID.Value;
        ProvinceID = HF_ProvinceID.Value;
        MainStr.Append("INSERT INTO [DSRExamData]([POPID],[CheckUserID],[ProvinceID],[CityID],[ShopID],[SupplierID]");
        MainStr.Append(" ,[CheckDate],[SysDateTime],[YesCount],[NoCount],[DataID])");
        MainStr.Append(" VALUES ");
        MainStr.Append(" ('" + POPID + "','" + UserID + "','" + ProvinceID + "','" + cityID + "','" + shopid + "','" + this.HF_supplierID.Value + "' ,'" + Txt_CheckDate.Text.Trim() + "','" + DateTime.Now.ToString() + "'," + Yesnum + "," + Nonum + ",'" + DataID + "')");

        list.Add(MainStr.ToString());

        if (new LN.BLL.DSRExamData().InsertResult(list))
        {
            Txt_result.Text = "是"+Yesnum+"个/否"+Nonum+"个";
            btn_save.Enabled = false;
        }
    }

}

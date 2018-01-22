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
using System.Collections.Generic;
using System.Text;
public partial class PDADSR : System.Web.UI.Page
{


    int noRules = 0;//gridView 第一列所显示的序列号
    string shopid = "", UserID = "", POPID = "", cityID = "", ProvinceID = "";//店铺ID，检查人ID，POP发起ID，店铺所属供应商ID
    int rulesID = 0, Yesnum = 0, Nonum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        //{
        //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
        //    return;
        //}
       
        if (Session["UserID"] == null)
        {
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Session["UserID"].ToString();
        LN.Model.POPLaunch launchmodel = new LN.BLL.POPLaunch().GetNewestModel();
        if (launchmodel != null)
        {
            POPID = launchmodel.POPID;
        }
        else
        {
            //Response.Write("<script>alert('没有发起的POP您还不能进行检查；');</script>");
            Response.End();
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            e.Row.Cells[5].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            noRules++;
            e.Row.Cells[0].Text = noRules.ToString();
            CheckBox cb1 = e.Row.Cells[3].FindControl("Check_Yes") as CheckBox;
            CheckBox cb2 = e.Row.Cells[4].FindControl("Check_No") as CheckBox;

        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        int Flag = 0;
        int nocheck = 0;
        string strSql = "";
        string DataID = DateTime.Now.Ticks.ToString();
        StringBuilder MainStr = new StringBuilder();
        foreach (GridViewRow Grow in GridView1.Rows)
        {
            CheckBox cb1 = Grow.Cells[3].FindControl("Check_Yes") as CheckBox;
            CheckBox cb2 = Grow.Cells[4].FindControl("Check_No") as CheckBox;

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
            if (!(cb2.Checked || cb1.Checked))
            {
                nocheck++;
            }
            rulesID = int.Parse(Grow.Cells[5].Text.ToString());

            strSql = "INSERT into DSRResultsList values ('" + DataID + "'," + rulesID + ",'" + Flag + "','')";
            list.Add(strSql);
        }
        cityID = HF_cityID.Value;
        ProvinceID = HF_ProvinceID.Value;
        shopid = HF_shopid.Value;
        MainStr.Append("INSERT INTO [DSRExamData]([POPID],[CheckUserID],[ProvinceID],[CityID],[ShopID],[SupplierID]");
        MainStr.Append(" ,[CheckDate],[SysDateTime],[YesCount],[NoCount],[DataID])");
        MainStr.Append(" VALUES ");
        MainStr.Append(" ('" + POPID + "','" + UserID + "','" + ProvinceID + "','" + cityID + "','" + shopid + "','" + this.HF_supplierID.Value + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToString() + "'," + Yesnum + "," + Nonum + ",'" + DataID + "')");

        list.Add(MainStr.ToString());
        if (nocheck <= 0)
        {
            new LN.BLL.DSRExamData().InsertResult(list);
            GridView1.DataSource = null;
            GridView1.DataBind();
            this.btn_save.Enabled = false;
        }
    }

    protected void btn_find_Click(object sender, EventArgs e)
    {
    

        LN.BLL.ShopInfo oneInfo = new LN.BLL.ShopInfo();
        DataSet ds = oneInfo.GetList(" PosID='" + this.PosID.Text.Trim()+"'");

        DataTable dt = ds.Tables[0];
        DataTable supplierdt = new DataTable();
        if (dt.Rows.Count > 0)
        {
            LN.BLL.DSRCheckRules rulesBLL = new LN.BLL.DSRCheckRules();
            DataSet ruleds = rulesBLL.GetList(" rulesState=1 order by  Dsrchecktype,RulesID,Dsrrules");
            DataTable rulesdt = ruleds.Tables[0];
            this.GridView1.DataSource = rulesdt;
            this.GridView1.DataBind();

            supplierdt = new LN.BLL.SupplierAssignRecord().GetSpplierAssignRecordWithShopID(int.Parse(dt.Rows[0]["shopid"].ToString()));
            HF_ProvinceID.Value = dt.Rows[0]["ProvinceID"].ToString();
            HF_cityID.Value = dt.Rows[0]["CityID"].ToString();
            HF_shopid.Value = dt.Rows[0]["shopid"].ToString();
            this.btn_save.Enabled = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            this.btn_save.Enabled = false;
        }
        if (supplierdt.Rows.Count > 0)
        {
            this.HF_supplierID.Value = supplierdt.Rows[0]["SupplierID"].ToString();
        }
       
       
    }
}



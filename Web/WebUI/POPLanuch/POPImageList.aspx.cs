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
using System.Collections.Generic;
public partial class WebUI_POPLanuch_POPImageList : System.Web.UI.Page
{
    protected string POPID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }


        POPID = Request.QueryString["POPID"].ToString();
        StringBuilder imgstr = new StringBuilder();
        if (!Page.IsPostBack)
        {


            IList<LN.Model.POPImageData> modellist = new LN.BLL.POPImageData().GetList("POPID='" + POPID + "' order by productlevel,ImageLevel ");
            this.Repeater1.DataSource = modellist;
            Repeater1.DataBind();
        }

    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        Hashtable ht = null;
        List<Hashtable> imglist = new List<Hashtable>();
        foreach (RepeaterItem item in Repeater1.Items)
        {
            ht = new Hashtable();
            TextBox txt = (TextBox)item.FindControl("imgRemark");
            DropDownList ddl_level = (DropDownList)item.FindControl("DDL_imgLevel");
            DropDownList ddl_prolevel = (DropDownList)item.FindControl("DDL_ProLevel");
            HiddenField hf = (HiddenField)item.FindControl("imgID");

            ht.Add("imgRemark", txt.Text.Trim());
            ht.Add("prolevel", ddl_prolevel.Text);
            ht.Add("imglevel", ddl_level.Text);
            ht.Add("imgid", hf.Value);

            imglist.Add(ht);
        }

        try
        {
            new LN.BLL.POPImageData().UpdateImgDesc(imglist);
            LN.BLL.POPLaunch bll = new LN.BLL.POPLaunch();
            int intsteps = bll.getsetps(POPID);//得到此pop已经完成第几步了
            if (intsteps != 0 && intsteps < 4)
            {
                bll.Updatesteps(4, POPID);
            }
            Response.Redirect("POPLaunchSetCiyt.aspx?POPID=" + POPID);
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        Hashtable ht = null;
        List<Hashtable> imglist = new List<Hashtable>();
        foreach (RepeaterItem item in Repeater1.Items)
        {
            ht = new Hashtable();
            TextBox txt = (TextBox)item.FindControl("imgRemark");
            DropDownList ddl_level = (DropDownList)item.FindControl("DDL_imgLevel");
            DropDownList ddl_prolevel = (DropDownList)item.FindControl("DDL_ProLevel");
            HiddenField hf = (HiddenField)item.FindControl("imgID");

            ht.Add("imgRemark", txt.Text.Trim());
            ht.Add("prolevel", ddl_prolevel.Text);
            ht.Add("imglevel", ddl_level.Text);
            ht.Add("imgid", hf.Value);


            imglist.Add(ht);
        }
        new LN.BLL.POPImageData().UpdateImgDesc(imglist);
        Response.Redirect("POPLaunchTwo.aspx?POPID=" + POPID);
    }

    protected DataTable Getprolevel(object prolevel)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("prolevel");
        if (prolevel != null)
        {
            DataRow dr = dt.NewRow();
            dr[0] = prolevel.ToString();
            dt.Rows.Add(dr);
           
        }
        else
        {
            DataRow dr = dt.NewRow();
            dr[0] = "0";
            dt.Rows.Add(dr);
            
        }
        for (int i = 30; i >=0; i--)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i.ToString();
            dt.Rows.Add(dr);
        }
        return dt;
    }

    protected DataTable Getimglevel(object imglevel)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("imglevel");
        if (imglevel != null)
        {
            DataRow dr = dt.NewRow();
            dr[0] = imglevel.ToString();
            dt.Rows.Add(dr);

        }
        else
        {
            DataRow dr = dt.NewRow();
            dr[0] = "0";
            dt.Rows.Add(dr);

        }
        for (int i = 30; i >= 0; i--)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i.ToString();
            dt.Rows.Add(dr);
        }
        return dt;
    }
}

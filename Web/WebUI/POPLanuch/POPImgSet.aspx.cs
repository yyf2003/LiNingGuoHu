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
public partial class WebUI_POPLanuch_POPImgSet : System.Web.UI.Page
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
            IList<LN.Model.POPImageData> modellist = new LN.BLL.POPImageData().GetList("POPID='" + POPID + "' ");
            this.Repeater1.DataSource = modellist;
            Repeater1.DataBind();

            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBoxList chklist = item.FindControl("chkSetPOPList") as CheckBoxList;

                for(int i= 0; i < chklist.Items.Count; i++)
                {
                    chklist.Items[i].Selected = true;
                }
            }
        }
       
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        if (!BoolLevel())
        {
            Hashtable ht = null;
            List<Hashtable> imglist = new List<Hashtable>();
            foreach (RepeaterItem item in Repeater1.Items)
            {
                ht = new Hashtable();
                string strCheck = String.Empty;
                CheckBoxList chklist = item.FindControl("chkSetPOPList") as CheckBoxList;
                TextBox txt_level = (TextBox)item.FindControl("txt_imgLevel");
                DropDownList ddl_prolevel = (DropDownList)item.FindControl("DDL_ProLevel");
                HiddenField hf = (HiddenField)item.FindControl("imgID");

                for (int i = 0; i < chklist.Items.Count; i++)
                {
                    if (chklist.Items[i].Selected == true)
                        strCheck += chklist.Items[i].Value.Trim() + ",";
                }
                ht.Add("imgRemark", strCheck.TrimEnd(new char[] {','}));
                ht.Add("prolevel", ddl_prolevel.Text);
                ht.Add("imglevel", txt_level.Text.Trim());
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
        else
        {
            Response.Write("<script>alert('请将图片编号填写完整！');</script>");
        }
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        if (!BoolLevel())
        {
            Hashtable ht = null;
            List<Hashtable> imglist = new List<Hashtable>();
            foreach (RepeaterItem item in Repeater1.Items)
            {
                ht = new Hashtable();
                string strCheck = String.Empty;
                TextBox txt_level = (TextBox)item.FindControl("txt_imgLevel");
                DropDownList ddl_prolevel = (DropDownList)item.FindControl("DDL_ProLevel");
                HiddenField hf = (HiddenField)item.FindControl("imgID");

                CheckBoxList chklist = item.FindControl("chkSetPOPList") as CheckBoxList;
                for (int i = 0; i < chklist.Items.Count; i++)
                {
                    if (chklist.Items[i].Selected == true)
                        strCheck += chklist.Items[i].Value.Trim() + ",";
                }

                ht.Add("imgRemark", strCheck.TrimEnd(new char[] { ',' }));
                ht.Add("prolevel", ddl_prolevel.Text);
                ht.Add("imglevel", txt_level.Text);
                ht.Add("imgid", hf.Value);


                imglist.Add(ht);
            }
            new LN.BLL.POPImageData().UpdateImgDesc(imglist);
            Response.Redirect("POPLaunchTwo.aspx?POPID=" + POPID);
        }
        else
        {
            Response.Write("<script>alert('请将图片编号填写完整！');</script>");
        }

    }

    protected void first_prolevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {

            DropDownList ddl_prolevel = (DropDownList)item.FindControl("DDL_ProLevel");
            ddl_prolevel.SelectedValue = first_prolevel.Text;
        }
    }

    private bool BoolLevel()
    {
        Boolean flag = false;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            TextBox txt_level = (TextBox)item.FindControl("txt_imgLevel");
            if (txt_level.Text.Trim().Length <= 0)
            {
                flag = true;
                break;
            }
        }
        return flag;
    }

    /// <summary>
    /// 获取图片位置描述
    /// </summary>
    /// <returns></returns>
    protected List<LN.Model.POPSeat> GetPOPSeat()
    {
        List<LN.Model.POPSeat> list = new LN.BLL.POPSeat().GetList("");

        return list;
    }
    //protected void frist_imgLevel_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    foreach (RepeaterItem item in Repeater1.Items)
    //    {
    //        DropDownList ddl_level = (DropDownList)item.FindControl("DDL_imgLevel");
    //        ddl_level.SelectedValue = frist_imgLevel.Text;
    //    }
    //}
}

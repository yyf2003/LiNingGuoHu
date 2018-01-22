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

public partial class WebUI_SetUpConfirm_AddOne : System.Web.UI.Page
{
    public string UserName = string.Empty;
    public string Shopid = string.Empty;
    public string Dealreid = string.Empty;
    public string Supplierid = string.Empty;
    public string Popid = string.Empty;
    public string Poptitle = string.Empty;
     public int shouldsetup = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (this.Request.Cookies["UserID"] == null)
        //{
        //    Response.Redirect("../../Login.aspx");
        //}
        //else
        //{

                LoadSetUpData();

        //}
    }
    public void LoadSetUpData()
    {
        string UserID = this.Request.Cookies["UserID"].Value;
        UserName = Server.UrlDecode(this.Request.Cookies["UserName"].Value); 
            //new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Username;
       // string qid = "";
        DataTable dtShopinfo = null;
        //if (this.Request.QueryString["ID"] != null)
        //{
        //    qid = this.Request.QueryString["ID"].ToString();
        //    dtShopinfo = new LN.BLL.ShopInfo().GetList("shopid =" + qid).Tables[0];
        //}
        //else
        //{
            dtShopinfo = new LN.BLL.ShopInfo().GetList("linkman ='" + UserName + "'").Tables[0];
        //}

            if (dtShopinfo.Rows.Count > 0)
            {


                Shopid = dtShopinfo.Rows[0]["ShopID"].ToString();
                string shopname = dtShopinfo.Rows[0]["Shopname"].ToString();
                this.Label2.Text = shopname;
                DataTable sdt  = new LN.BLL.SupplierAssignRecord().GetList("AssignShopID =" + Shopid).Tables[0];
                if (sdt.Rows.Count <= 0)
                {
                    Response.Write("<script>alert('此店无供应商供应POP，无法进行安装确认');location.href='../Affiche/Index.aspx';</script>");
                    return;
                }
                else
                {
                    Supplierid = sdt.Rows[0]["SupplierID"].ToString();
                }

                string suppliername = new LN.BLL.SupplierInfo().GetModel(int.Parse(Supplierid)).SupplierName;
                this.Label3.Text = suppliername;
                Dealreid = dtShopinfo.Rows[0]["DealerID"].ToString();
                string dealrename = dtShopinfo.Rows[0]["DealerName"].ToString();
                this.Label1.Text = dealrename;
                if (dtShopinfo.Rows[0]["Boolinstall"].ToString() == "1")
                    Response.Redirect("../PhysicalDistribution/SetupToShop.aspx?id=" + dtShopinfo.Rows[0]["ShopID"].ToString() + "&sid=" + Supplierid + "&did=" + Dealreid + "&fxid=" + dtShopinfo.Rows[0]["FXID"].ToString());

               

                IList<LN.Model.POPLaunch> list = new LN.BLL.POPLaunch().GetList("steps =0");
                if (list.Count > 0)
                {
                    Popid = list[0].POPID;
                   shouldsetup = new LN.BLL.POPInfo().Getsetupcount(Shopid, Popid);//得到需要安装的数量
                    Poptitle = list[0].POPTitle;
                    this.Label4.Text = Poptitle;

                    this.TextBox1.Text = "应安装"+shouldsetup+"张";
                }
            }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string UserID = this.Request.Cookies["UserID"].Value;
        int Boolinstall = 0;
        UserName = new LN.BLL.UserInfo().GetModel(int.Parse(UserID)).Username;
        DataTable dtShopinfo = new LN.BLL.ShopInfo().GetList("linkman ='" + UserName + "'").Tables[0];
        if (dtShopinfo.Rows.Count > 0)
        {
            Shopid = dtShopinfo.Rows[0]["ShopID"].ToString();
            if (dtShopinfo.Rows[0]["Boolinstall"] != null)
            {
                Boolinstall = int.Parse(dtShopinfo.Rows[0]["Boolinstall"].ToString());
            }
            Supplierid = new LN.BLL.SupplierAssignRecord().GetList("AssignShopID =" + int.Parse(Shopid) + "").Tables[0].Rows[0]["SupplierID"].ToString();
            Dealreid = dtShopinfo.Rows[0]["DealerID"].ToString();
            IList<LN.Model.POPLaunch> list = new LN.BLL.POPLaunch().GetList("steps =0");
            if (list.Count > 0)
            {
                Popid = list[0].POPID;
            }
        }
        string Count = this.txt_Num.Text;

        //if (int.Parse(Count) < shouldsetup &&  "".Equals(txt_Desc.Text.Trim()))
        //{
        //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "1", "<script>alert('请填写未全部安装的原因');</script>");
        //    return;
        //}

        LN.Model.SetUpConfirm model = new LN.Model.SetUpConfirm();
        model.DealerID = Dealreid;
        model.Shopid = int.Parse(Shopid);
        model.Boolinstall = Boolinstall;
        model.SupplierID = int.Parse(Supplierid);
        model.POPID = Popid;
       


        model.SetUpCount = int.Parse(Count);
        model.OperatorID = int.Parse(UserID);
        model.SetUpDesc = this.txt_Desc.Text;
        model.FXID = dtShopinfo.Rows[0]["FXID"].ToString();
        model.PicUrl = "";
        try
        {
            DataTable checkdt = new LN.BLL.SetUpConfirm().GetList("Shopid= " + model.Shopid + "  and POPID=" + model.POPID + " ").Tables[0];
            if (checkdt.Rows.Count > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('您已经提交过安装确认了，不能再次提交');window.location=window.location;</script>");
                return;
            }
            else
            {
                new LN.BLL.SetUpConfirm().Add(model);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('提交成功');window.location=window.location;</script>");
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('提交失败，异常在：" + ex.Message + "');</script>");
        }

    }


}

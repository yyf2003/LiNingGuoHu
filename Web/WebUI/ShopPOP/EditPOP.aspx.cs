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
using LN.DAL;

using System.Linq;
public partial class WebUI_ShopPOP_EditPOP : System.Web.UI.Page
{
    string id = string.Empty,shopid=string.Empty;

    protected string PlatformHeight = string.Empty, PlatformLong = string.Empty, PlatformWith = string.Empty, POPArea = string.Empty;
    protected string POPHeight = string.Empty, POPMaterial = string.Empty, POPSeat = string.Empty, POPWith = string.Empty, ProductLineID = string.Empty, RealHeight = string.Empty, realWith = string.Empty, POPplwz = string.Empty, POPpljd = string.Empty;
    protected string SeatDesc = string.Empty, SeatNum = string.Empty, Sexarea = string.Empty, Glass = string.Empty, TwoSided=string.Empty,POPID=string.Empty;
    protected int IsFOS = 0;                //是否是FOS店铺
    LN.BLL.POPInfo bll = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //加载pop故事包
        //IList<LN.Model.ProductLineData> linelist = new LN.BLL.ProductLineData().GetList("");
        //foreach (LN.Model.ProductLineData model in linelist)
        //{
        //    ListItem item = new ListItem(model.ProductLine, model.ProductLineID.ToString());
        //    this.DDL_ProductLine.Items.Add(item);
        //}

        id = Request.QueryString["ID"].ToString();
        shopid = Request.QueryString["shopid"].ToString(); 
        bll = new LN.BLL.POPInfo();

        //POPID = new LN.BLL.POPLaunch().GetLastPOPID();
        POPID = Request.QueryString["popid"].ToString();

        LN.Model.POPInfo model = bll.GetModel(int.Parse(id));
        PlatformHeight = model.PlatformHeight.ToString();
        PlatformLong = model.PlatformLong.ToString();
        PlatformWith = model.PlatformWith.ToString();
        POPArea = model.POPArea.ToString();
        POPHeight = model.POPHeight.ToString();
        POPSeat = model.POPSeat.ToString();

        //add by mhj 2012.11.30
        ViewState["POPSeat"] = POPSeat;

        POPWith = model.POPWith.ToString();
        SeatDesc = model.SeatDesc.ToString();
        SeatNum = model.SeatNum.ToString();
        Sexarea = model.Sexarea.ToString();
        Glass = model.Glass.ToString();
        TwoSided = model.TwoSided.ToString();
        RealHeight = model.RealHeight.ToString();
        realWith = model.RealWith.ToString();
        POPpljd = model.POPPljd.ToString();
        POPplwz = model.POPPlwz;
        if (TwoSided == "1")
            twoside.Text = "是";
        else
            twoside.Text = "否";
        if (Glass == "1")
            txt_Glass.Text = "是";
        else
            txt_Glass.Text = "否";

        if (POPID.Length <= 0)
        {
            Response.Write("<script>alert('没有发起的季度POP活动，无法提交订单');</script>");
           // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "notadd", "<script language='javascript'>alert('没有发起的季度POP活动，无法提交订单');</script>");
            Response.End();



            int submitday = int.Parse(ConfigurationManager.AppSettings["POPsubmit"]);//设置订单提交时间 如果超出时间则无法提交

            string sqlstr = "select Datediff(day,(select top 1 beginDate from poplaunch where POPID='" + POPID + "'),getdate())";

            string diffday = GetTableListSqlExec.GetPOPOfBegindate(sqlstr);
            int tempday = 0;
            int.TryParse(diffday,out tempday);

            if (tempday < 0)
            {
                Response.Write("<script>alert('发起的季度POP活动还未开始，无法提交订单');</script>");
                Response.End();
            }
            if (tempday > submitday)
            {
                Response.Write("<script>alert('已超出订单提交时间，无法提交订单');</script>");
                Response.End();
            }
        }
        if (!Page.IsPostBack)
        {

            DataTable protypedt = new LN.BLL.ProductLineData().getPOPProductTypelist(POPID, POPSeat);
            for (int i = 0; i < protypedt.Rows.Count; i++)
            {
                ListItem item = new ListItem(protypedt.Rows[i]["ProductTypeName"].ToString(), protypedt.Rows[i]["ProductTypeID"].ToString());
                DDL_ProductType.Items.Add(item);
            }
            //DDL_ProductLine.Text = ProductLineID;
            //ProductLineID = model.ProductLineID.ToString();
            //if ("橱窗".Equals(POPSeat) || "收银台背景".Equals(POPSeat))
            //{
            //    DDL_ProductType.Text = "6";//和主画面的TypeID相对应
            //    DDL_ProductType.Enabled = false;
            //    bindLine();
            //}
            IsFOS = new LN.BLL.ShopInfo().GetSaleTypeID(Int32.Parse(shopid));
            if(IsFOS<=0)
            {
                DataTable dt = new LN.BLL.POPMateriaData().GetMaterialByshopID(shopid);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem item = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][1].ToString());
                    DDL_material.Items.Add(item);
                }
                DDL_material.Text = model.POPMaterial;
            }
            else
            {
                DDL_material.Items.Add(new ListItem(model.POPMaterial, model.POPMaterial));
                DDL_material.SelectedValue = model.POPMaterial;
                DDL_material.Enabled = false;
            }

            //add by mhj 2012.11.30
            bindAllImag();
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        string pro = DDL_ProductLine.Text;
        string material = DDL_material.Text;
        try
        {
            if (Request.Form["chooseimage"] != null)
            {
                int IsExist = new LN.BLL.imageToPOP().IsExist(id);
                if (IsExist <= 0)
                {

                    if (!"".Equals(Request.Form["chooseimage"].ToString()))
                    {
                        LN.Model.imageToPOPTemp tempmodel = new LN.Model.imageToPOPTemp();
                        tempmodel.imageID = int.Parse(Request.Form["chooseimage"].ToString());
                        tempmodel.POPID = POPID;
                        tempmodel.POPinfoID = int.Parse(id);
                        tempmodel.prolineID = int.Parse(pro);
                        tempmodel.shopid = int.Parse(shopid);
                        tempmodel.sysTime = DateTime.Now;
                        new LN.BLL.imageToPOPTemp().Delete(" shopid= " + shopid + " and popinfoid= " + id);//如果本次活动设置过就先将设置的数据删掉 保证一个pop位置只配一张图片。
                        new LN.BLL.imageToPOPTemp().Add(tempmodel);
                    }

                    new LN.BLL.POPInfo().Update_type(id, pro, material);//将POPinfo信息表中的产品系列更新成最新的提交的系列
                    
                    
                    //modify by mhj 2012.11.30
                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", "<script>alert('成功');window.location.href='ShopPOPListOpration.aspx?shopid=" + shopid + "'</script>");
                    Response.Write("<script>window.returnValue = \"ok\";window.close();</script>");
                }
                else
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "no", "<script>alert('该POP已经提交了订单！！');</script>");

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "no", "<script>alert('请选择相应的图片');</script>");

            }


        }
        catch (Exception)
        {

            throw;
        }        
    }
    protected void DDL_ProductType_SelectedIndexChanged(object sender, EventArgs e)
    {

        
        //Response.Write(DDL_ProductType.Text);
        bindLine();
    }
    protected void DDL_ProductLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindimg();
    }

    private void bindLine()
    {
        DataTable dt = new LN.BLL.ProductLineData().GetPOPproductLineByTypeID(POPID, int.Parse(DDL_ProductType.Text));
        DDL_ProductLine.Items.Clear();
        ListItem oneitem = new ListItem("请选择产品系列", "0");
        DDL_ProductLine.Items.Add(oneitem);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem item = new ListItem(dt.Rows[i]["ProductLine"].ToString(), dt.Rows[i]["ProductLineID"].ToString());
            DDL_ProductLine.Items.Add(item);
        }
    }
    private void bindimg()
    {
        IList<LN.Model.POPImageData> modellist = new LN.BLL.POPImageData().GetList("POPID='" + POPID + "' and productline=" + DDL_ProductLine.Text);

        this.Repeater1.DataSource = modellist;
        Repeater1.DataBind();

        foreach (RepeaterItem item in Repeater1.Items)
        {
            Label lblPOPSeatID = item.FindControl("lblPOPSeatID") as Label;
            Label lblPOPSeatName = item.FindControl("lblPOPSeatName") as Label;

            if (lblPOPSeatID.Text.Trim() != "")
            {
                List<LN.Model.POPSeat> list = new LN.BLL.POPSeat().GetList(string.Format(" SeatID IN ({0})",lblPOPSeatID.Text.Trim()));
                string strSeatName = String.Empty;
                foreach (LN.Model.POPSeat model in list)
                {
                    strSeatName += model.seat + " -";
                }
                lblPOPSeatName.Text = strSeatName.Trim(new char[] {'-'});
            }
        }
    }

    //add by mhj 2012.11.30
    void bindAllImag()
    {
        List<LN.Model.POPSeat> list_seat = new LN.BLL.POPSeat().GetList("seat='" + ViewState["POPSeat"] .ToString()+ "'");
        string strSeatId ="0";
        if(list_seat.Any())
           strSeatId = list_seat[0].SeatID.ToString();

        IList<LN.Model.POPImageData> modellist = new LN.BLL.POPImageData().GetList("POPID='" + POPID + "' and (imagedesc like '" + strSeatId + ",%' or imagedesc like '%," + strSeatId + ",%' or  imagedesc like '%," + strSeatId + "' or imagedesc='" + strSeatId + "') ");

        //add by mhj 2015.5.17
        LN.BLL.ShopInfo oneInfo = new LN.BLL.ShopInfo();
        DataSet ds = oneInfo.GetList(" ShopID=" + shopid);

        DataTable dt = ds.Tables[0];
        string ACL_ID = dt.Rows[0]["ACL_ID"].ToString();
        string areaid = dt.Rows[0]["areaid"].ToString(); 
        string[] arr_acl, arr_area;
        List<LN.Model.POPImageData> modellist_new = new List<LN.Model.POPImageData>();
        foreach (var temp in modellist)
        {
            if (!string.IsNullOrEmpty(temp.ACL_IDs) && !string.IsNullOrEmpty(temp.AreaIDs))
            {
                arr_acl = temp.ACL_IDs.Split(',');
                arr_area = temp.AreaIDs.Split(',');
                if (!arr_area.Contains(areaid) || !arr_acl.Contains(ACL_ID))
                {
                    continue;
                }
            }
            modellist_new.Add(temp);
        }

        this.Repeater1.DataSource = modellist_new;
        Repeater1.DataBind();

        foreach (RepeaterItem item in Repeater1.Items)
        {
            Label lblPOPSeatID = item.FindControl("lblPOPSeatID") as Label;
            Label lblPOPSeatName = item.FindControl("lblPOPSeatName") as Label;

            if (lblPOPSeatID.Text.Trim() != "")
            {
                List<LN.Model.POPSeat> list = new LN.BLL.POPSeat().GetList(string.Format(" SeatID IN ({0})", lblPOPSeatID.Text.Trim()));
                string strSeatName = String.Empty;
                foreach (LN.Model.POPSeat model in list)
                {
                    strSeatName += model.seat + " -";
                }
                lblPOPSeatName.Text = strSeatName.Trim(new char[] { '-' });
            }
        }
    }
}

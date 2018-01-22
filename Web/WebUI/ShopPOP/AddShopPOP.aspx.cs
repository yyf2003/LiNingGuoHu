using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class WebUI_ShopPOP_AddShopPOP : System.Web.UI.Page
{
    protected string shopid = String.Empty; //店铺编号 
    protected int IsFOS = 0;                //是否是FOS店铺
    string UserID = string.Empty, UserName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        UserName = Request.Cookies["UserName"].Value;
        if (Request.QueryString["shopid"] != null)
        {
            shopid = Request.QueryString["shopid"].ToString();
        }
        else
        {
            UserName = Server.UrlDecode(Request.Cookies["UserName"].Value);
            DataTable shopdt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(UserName);
            if (shopdt.Rows.Count > 0)
            {
                shopid = shopdt.Rows[0]["ShopID"].ToString();

            }
            else
            {
                Response.Write("<script language='javascript'>alert('没有您负责的店铺');</script>");
                Response.End();
            }

        }
        if (!Page.IsPostBack)
        {
            //加载pop的材质
            DataTable materdt = new LN.BLL.POPMateriaData().GetMaterialByshopID(shopid);

            foreach (DataRow dr in materdt.Rows)
            {
                ListItem item = new ListItem(dr["MateriaPro"].ToString(), dr["MateriaPro"].ToString());
                this.DDL_POPMaterial.Items.Add(item);
            }

            IsFOS = new LN.BLL.ShopInfo().GetSaleTypeID(Int32.Parse(shopid));
            if (IsFOS<=0)
            {
                //加载pop 的位置
                IList<LN.Model.POPSeat> seatlist = new LN.BLL.POPSeat().GetList("");
                foreach (LN.Model.POPSeat model in seatlist)
                {
                    ListItem item = new ListItem(model.seat, model.seat);
                    this.DDL_Popseat.Items.Add(item);
                }
            }
            else
            {
                //注释掉by mhj 20130531
                //IList<LN.Model.tb_FOSPOP> FosSeatList = new LN.BLL.tb_FOSPOP().GetList("");
                //foreach (LN.Model.tb_FOSPOP model in FosSeatList)
                //{
                //    ListItem item = new ListItem(model.FOS_POPSeat, model.FOS_POPSeat);
                //    this.DDL_Popseat.Items.Add(item);
                //}
                //this.DDL_Popseat.Attributes.Add("onchange", "javascript:GetFosPOPSeat(this.value," + shopid + ")");
                //this.DDL_POPMaterial.Items.Clear();
                //this.DDL_POPMaterial.Items.Add(new ListItem("请选择POP材质", "0"));

                //加载pop 的位置 add by mhj 20130531
                IList<LN.Model.POPSeat> seatlist = new LN.BLL.POPSeat().GetList("");
                foreach (LN.Model.POPSeat model in seatlist)
                {
                    ListItem item = new ListItem(model.seat, model.seat);
                    this.DDL_Popseat.Items.Add(item);
                }
            }

            //加载故事包类型
            IList<LN.Model.ProductLineType> typelist = new LN.BLL.ProductLineType().GetList("");
            foreach (LN.Model.ProductLineType model in typelist)
            {
                ListItem item = new ListItem(model.ProductTypeName, model.ProductTypeID.ToString());
                DDL_ProductType.Items.Add(item);
            }

            ////加载pop故事包
            //IList<LN.Model.ProductLineData> linelist = new LN.BLL.ProductLineData().GetList("");
            //foreach (LN.Model.ProductLineData model in linelist)
            //{
            //    ListItem item = new ListItem(model.ProductLine, model.ProductLineID.ToString());
            //    this.DDL_ProductLine.Items.Add(item);
            //}

            //加载店铺的pop信息
            //if ("橱窗".Equals(POPSeat) || "收银台背景".Equals(POPSeat) || "户外".Equals(POPSeat))
            //{

            //    //DDL_ProductType.SelectedItem.Text = "主画面";
            //    // DDL_ProductType.Items[DDL_ProductType.SelectedIndex].Text = "主画面";
            //    DDL_ProductType.Text = "6";//和主画面的TypeID相对应
            //    DDL_ProductType.Enabled = false;
              
            //}

            bind(shopid);
            string nextid=new LN.BLL.POPInfo().Getnextseatnum(shopid);
            txt_seatNum.Text = nextid == "" ? "1" : nextid;//得到最新的位置编号
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        //Response.Write(Request.Form["DDL_ProductLine"]);
        LN.Model.POPInfo model = new LN.Model.POPInfo();

        model.POPSeat = this.DDL_Popseat.Text;
        model.SeatNum = this.txt_seatNum.Text.Trim();
        model.SeatDesc = this.txt_SeatDesc.Text.Trim();

        model.POPWith = Decimal.Parse(Request.Form["txt_POPWith"]);
        model.POPHeight = Decimal.Parse(Request.Form["txt_POPHeight"]);
        model.RealHeight = Decimal.Parse(Request.Form["txt_realheight"]);
        model.RealWith = Decimal.Parse(Request.Form["txt_realwidth"]);
        model.POPMaterial = Request.Form["DDL_POPMaterial"];

        model.POPArea = (model.POPHeight * model.POPWith)/(1000*1000);
        model.ProductLineID =int.Parse(Request.Form["DDL_ProductLine"]);
        model.ShopID =int.Parse(shopid);
        model.TwoSided = Int32.Parse(CB_TwoSided.SelectedValue);
        model.Glass = Int32.Parse(CB_Glass.SelectedValue);
        model.Sexarea = DDL_sexarea.Text;
        model.PlatformLong = Decimal.Parse(txt_PlatformLong.Text.Trim() == "" ? "0" : txt_PlatformLong.Text.Trim());
        model.PlatformWith = Decimal.Parse(txt_PlatformWith.Text.Trim() == "" ? "0" : txt_PlatformWith.Text.Trim());
        model.PlatformHeight = Decimal.Parse(txt_PlatformHeight.Text.Trim() == "" ? "0" : txt_PlatformHeight.Text.Trim());
        model.POPPlwz = DDL_plwz.Text;
        model.POPPljd = int.Parse(DDL_pljd.Text);
        

        int intUserType = new LN.BLL.UserTypeData().GetUserType(UserID);
        if (intUserType == 3)
        {
            model.VMExamState = 1;
            model.VMExamUserId = int.Parse(UserID);
            model.VMExamDate = DateTime.Now.ToString();

            
        }
        else if (intUserType == 2)
        {
            model.ExamState = 1;
            model.ExamUserID = int.Parse(UserID);
            model.ExamDesc = "";
        }
        else
        {
            model.ExamState = 0;
            model.ExamUserID = 0;
            model.ExamDesc = "";
            model.VMExamState = 0;
            model.VMExamUserId = 0;
            model.VMExamDate = "";
        }


        model.AddState = UserName + "-" + UserID + "-新增";
        model.ExamDesc = "";
        model.POPMaterialRemark = txt_POPMaterialRemark.Text.Trim();
        try
        {
            int NewPOPInfoID = new LN.BLL.POPInfo().Add(model);
            int IsUpLoadImg1 = UpLoadImg(FupPOPImg1, Int32.Parse(shopid), NewPOPInfoID, txtImgDescribe1.Text.Trim());
            int IsUpLoadImg2 = UpLoadImg(FupPOPImg2, Int32.Parse(shopid), NewPOPInfoID, txtImgDescribe2.Text.Trim());
            int IsUpLoadImg3 = UpLoadImg(FupPOPImg3, Int32.Parse(shopid), NewPOPInfoID, txtImgDescribe3.Text.Trim());
            if (IsUpLoadImg1 == 0 && IsUpLoadImg2 == 0 && IsUpLoadImg3==0)
            {
                new LN.BLL.POPInfo().Delete(NewPOPInfoID);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=\"javascript\">alert('增加POP失败!!'); window.location=window.location</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=\"javascript\">alert('增加POP成功!!'); window.location=window.location</script>");
            }
            
          
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    /// <summary>
    /// 上传POP图片
    /// </summary>
    /// <param name="ShopID">所属店铺编号</param>
    /// <param name="POPInfoID">所属POP编号</param>
    /// <returns>返回上传图片是否成功</returns>
    private int UpLoadImg(FileUpload FupName, int ShopID, int POPInfoID, string ImgDescribe)
    {
        int _return = 0;
        if (FupName.HasFile)
        {
            string saveFilePath = String.Empty;
            string filePath = "../../UpLoad/POPImages/" + ShopID + "/" + POPInfoID;
            if (!Directory.Exists(Server.MapPath(filePath)))
                Directory.CreateDirectory(Server.MapPath(filePath));
            try
            {
                int result = Upload_File.FileSave(filePath, FupName, ref saveFilePath);

                LN.Model.tb_POPInfo_Img m = new LN.Model.tb_POPInfo_Img();
                m.Img_ShopID = ShopID;
                m.Img_POPInfoID = POPInfoID;
                m.Img_URL = saveFilePath;
                m.Img_Describe = ImgDescribe;
                m.Img_CreateTime = DateTime.Now;

                _return = new LN.BLL.tb_POPInfo_Img().Add(m);
            }
            catch
            {
                _return = 0;
            }
        }

        return _return;
    }

    private void bind(string _shopid)
    {
        IList<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetList(" vsl.shopid=" + _shopid);

        this.GridView1.DataSource = list;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[19].Text.ToString() == "1")
            {
                e.Row.Cells[19].Text = "已通过";
            }
            else
            {
                e.Row.Cells[19].Text = "未通过";
            }
        }
    }
}

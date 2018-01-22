using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;

public partial class WebUI_ShopPOP_ShopPOPEdit : System.Web.UI.Page
{
    protected string id = string.Empty, shopid = string.Empty;
    protected int IsFOS = 0;                //是否是FOS店铺

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        shopid = Request.QueryString["shopid"] == null ? "0" : Request.QueryString["shopid"].ToString();

        if (!IsPostBack)
        {
            //加载pop 的位置 add by mhj 2012.09.14
            GetPopSeat();

            IsFOS = new LN.BLL.ShopInfo().GetSaleTypeID(Int32.Parse(shopid));
            if (IsFOS <= 0)
                GetPOPMateriaData();
            GetPOPInfo();
        }
    }

    //加载pop 的位置 add by mhj 2012.09.14
    void GetPopSeat()
    {
        //加载pop 的位置
        IList<LN.Model.POPSeat> seatlist = new LN.BLL.POPSeat().GetList("");
        foreach (LN.Model.POPSeat model in seatlist)
        {
            ListItem item = new ListItem(model.seat, model.seat);
            this.DDL_Popseat.Items.Add(item);
        }
    }

    /// <summary>
    /// 绑定POP材质
    /// </summary>
    private void GetPOPMateriaData()
    {
        DataTable materdt = new LN.BLL.POPMateriaData().GetMaterialByshopID(shopid);

        foreach (DataRow dr in materdt.Rows)
        {
            ListItem item = new ListItem(dr["MateriaPro"].ToString(), dr["MateriaPro"].ToString());
            DDL_material.Items.Add(item);
        }
    }

    /// <summary>
    /// 获取POP信息
    /// </summary>
    private void GetPOPInfo()
    {
        LN.Model.POPInfo model = new LN.BLL.POPInfo().GetModel(int.Parse(id));
        txtPlatformHeight.Text = model.PlatformHeight.ToString();
        txtPlatformLong.Text = model.PlatformLong.ToString();
        txtPlatformWith.Text = model.PlatformWith.ToString();
        txtPOPHeight.Text = model.POPHeight.ToString();

        //modify by mhj 2012.09.14
        //txtPOPSeat.Text = model.POPSeat.Trim();
        DDL_Popseat.SelectedIndex = DDL_Popseat.Items.IndexOf(DDL_Popseat.Items.FindByText(model.POPSeat.Trim()));

        txtPOPWith.Text = model.POPWith.ToString();
        txtSeatDesc.Text = model.SeatDesc.Trim();
        txtSeatNum.Text = model.SeatNum.Trim();
        txtSexarea.Text = model.Sexarea.Trim();
        txtGlass.Text = model.Glass.ToString();
        txtTwoSided.Text = model.TwoSided.ToString();
        txtRealHeight.Text = model.RealHeight.ToString();
        txtrealWith.Text = model.RealWith.ToString();
        txtPOPpljd.Text = model.POPPljd.ToString();
        txtPOPplwz.Text = model.POPPlwz.Trim();
        if (txtTwoSided.Text == "1")
            txtTwoSided.Text = "是";
        else
            txtTwoSided.Text = "否";
        if (txtGlass.Text == "1")
            txtGlass.Text = "是";
        else
            txtGlass.Text = "否";
        

        
        txtPOPMaterialRemark.Text = model.POPMaterialRemark.Trim();
        string strPOPMaterial = model.POPMaterial.Trim();
        
        if (IsFOS <= 0)
        {
            for (int i = 0; i < DDL_material.Items.Count; i++)
            {
                if (DDL_material.Items[i].Value == strPOPMaterial)
                {
                    DDL_material.SelectedValue = strPOPMaterial;
                    break;
                }
            }
        }
        else
        {
            DDL_material.Items.Add(new ListItem(strPOPMaterial, strPOPMaterial));
            DDL_material.SelectedValue = strPOPMaterial;
            DDL_material.Enabled = false;
            txtPOPHeight.Enabled = false;
            txtPOPWith.Enabled = false;
            txtRealHeight.Enabled = false;
            txtrealWith.Enabled = false;
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

    protected void btn_save_Click(object sender, EventArgs e)
    {
        LN.Model.POPInfo model = new LN.Model.POPInfo();

        //add by mhj 2012.09.14
        if (DDL_Popseat.SelectedValue == "0")
        {
            Response.Write("<script>alert('请选择pop位置')</script>");
            DDL_Popseat.Focus();
            return;
        }
        model.POPSeat = DDL_Popseat.Text;

        model.ID = Int32.Parse(id);
        model.PlatformHeight = Decimal.Parse(txtPlatformHeight.Text.Trim());
        model.PlatformLong = Decimal.Parse(txtPlatformLong.Text.Trim());
        model.PlatformWith = Decimal.Parse(txtPlatformWith.Text.Trim());
        model.POPHeight = Decimal.Parse(txtPOPHeight.Text.Trim());
        model.POPWith = Decimal.Parse(txtPOPWith.Text.Trim());
        model.SeatDesc = txtSeatDesc.Text.Trim();
        model.Sexarea=txtSexarea.Text.Trim();
        if (txtTwoSided.Text == "是")
            txtTwoSided.Text = "1";
        else
            txtTwoSided.Text = "0";

        if (txtGlass.Text == "是")
            txtGlass.Text = "1";
        else
            txtGlass.Text = "0";

        model.Glass = Int32.Parse(txtGlass.Text.Trim());
        model.TwoSided = Int32.Parse(txtTwoSided.Text.Trim());
        model.RealHeight = Decimal.Parse(txtRealHeight.Text.Trim());
        model.RealWith = Decimal.Parse(txtrealWith.Text.Trim());
        if (txtPOPpljd.Text.Trim() != "")
            model.POPPljd = Int32.Parse(txtPOPpljd.Text.Trim());
        model.POPPlwz=txtPOPplwz.Text.Trim();
        model.POPMaterial = DDL_material.SelectedValue;
        if (DDL_material.SelectedValue.Trim()=="其他")
            model.POPMaterialRemark = txtPOPMaterialRemark.Text.Trim();
        else
            model.POPMaterialRemark = "";

        int IsExist = new LN.BLL.tb_POPInfo_Img().IsExistByPOPInfoID(Int32.Parse(id));

        if (IsExist > 0)
        {
            int result = new LN.BLL.POPInfo().UpdatePOP(model);
            if (result > 0)
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", "<script>alert('店铺POP信息修改成功,请等待审核！！');window.location.href=window.location.href</script>");
            else
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "no", "<script>alert('店铺POP信息修改失败！！');window.location.href=window.location.href</script>");
        }
        else
        {
            if (FupPOPImg1.HasFile == false && FupPOPImg2.HasFile == false && FupPOPImg3.HasFile == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", "<script>alert('请您上传POP相关图片！！');</script>");
            }
            else
            {
                int result = new LN.BLL.POPInfo().UpdatePOP(model);
                int IsUpLoadImg1 = UpLoadImg(FupPOPImg1, Int32.Parse(shopid), Int32.Parse(id), txtImgDescribe1.Text.Trim());
                int IsUpLoadImg2 = UpLoadImg(FupPOPImg2, Int32.Parse(shopid), Int32.Parse(id), txtImgDescribe2.Text.Trim());
                int IsUpLoadImg3 = UpLoadImg(FupPOPImg3, Int32.Parse(shopid), Int32.Parse(id), txtImgDescribe3.Text.Trim());
                if (IsUpLoadImg1 == 0 && IsUpLoadImg2 == 0 && IsUpLoadImg3 == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=\"javascript\">alert('店铺POP信息修改失败!!'); window.location=window.location</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script language=\"javascript\">alert('店铺POP信息修改成功,请等待审核！！!!'); window.location=window.location</script>");
                }
            }
        }
    }
}

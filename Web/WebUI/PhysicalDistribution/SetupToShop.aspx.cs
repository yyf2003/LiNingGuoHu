using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WebUI_PhysicalDistribution_SetupToShop : System.Web.UI.Page
{
    protected string UserID = String.Empty; //登录用户编号
    protected string ShopID = String.Empty; //店铺名称
    protected string SupplierID = String.Empty; //所属供应商编号
    protected string DealerID = String.Empty; //所属一级客户编号
    protected string ShopName = String.Empty; //店铺名称
    string fxid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        ShopID = Request.QueryString["id"] == null ? "0" : Request.QueryString["id"].ToString();
        SupplierID = Request.QueryString["sid"] == null ? "0" : Request.QueryString["sid"].ToString();
        DealerID = Request.QueryString["did"] == null ? "0" : Request.QueryString["did"].ToString();
        ShopName = new LN.BLL.ShopInfo().GetModel(Int32.Parse(ShopID)).Shopname;
        fxid = Request.QueryString["fxid"] == null ? "0" : Request.QueryString["fxid"].ToString();
        if (!IsPostBack)
        {
            GetPOPLaunchID();
            GetPOPList();
        }
    }
    /// <summary>
    /// 获取最最新发起的POP
    /// </summary>
    private void GetPOPLaunchID()
    {
        DataTable dt = new LN.BLL.POPLaunch().GetNewPOPID();
        //LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetNewestModel();
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddlPOPID.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                }
            }
            else
                btnAdd.Enabled = false;
        }
        else
            btnAdd.Enabled = false;
    }

    ///// <summary>
    ///// 获取最最新发起的POP
    ///// </summary>
    //private void GetPOPLaunchID()
    //{
    //    LN.Model.POPLaunch model = new LN.BLL.POPLaunch().GetNewestModel();
    //    if (model != null)
    //        txtPOPID.Text = model.POPID.Trim();
    //    else
    //        btnAdd.Enabled = false;
    //}

    /// <summary>
    /// 获取指定店铺的POP列表
    /// </summary>
    private void GetPOPList()
    {
        if (ddlPOPID.SelectedValue.ToString().Trim() != "")
        {
            string ProductLineID = new LN.BLL.POPLaunch().GetProline(ddlPOPID.SelectedValue.ToString().Trim());
            List<LN.Model.POPInfo> list = new LN.BLL.POPInfo().GetList(" ExamState=1 and vsl.ShopID = " + ShopID + " AND ProductLineID IN (" + ProductLineID + ")");
            if (list != null && list.Count > 0)
            {
                RepPOPList.DataSource = list;
                RepPOPList.DataBind();
            }
            else
                btnAdd.Enabled = false;
        }
        else
            btnAdd.Enabled = false;

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        List<string> strList = new List<string>();
        int POPNum = 0;
        foreach (RepeaterItem item in RepPOPList.Items)
        {
            CheckBox chk = item.FindControl("chkSelect") as CheckBox;
            Label lblID = item.FindControl("lblID") as Label;
            if (chk.Checked)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO [ShippingPOPData](");
                strSql.Append("[POPinfoID] ,");
                strSql.Append("[FHID]) VALUES (");
                strSql.AppendFormat("{0} ,", lblID.Text.Trim());
                strSql.AppendFormat("'{0}')", "");

                strList.Add(strSql.ToString());
                POPNum++;
            }
        }
        //判断是否选择POP列表
        if (strList.Count <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请选择POP信息列表！！');</script>");
            return;
        }
        //判断安装数量是否为空
        if (txt_Num.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入安装数量！！');</script>");
            return;
        }
        //收货人地址
        if (txt_SendAddress.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入发货地址！！');</script>");
            return;
        }
        //收货人
        if (txt_Consignee.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入收货人！！');</script>");
            return;
        }
        //收货人移动电话
        if (txt_ConsigneeMobile.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入收货人移动电话！！');</script>");
            return;
        }
        //收货人固定电话
        if (txt_ConsigneePhone.Text.Length <= 0)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请输入收货人固定电话！！');</script>");
            return;
        }
        StringBuilder sb = new StringBuilder();

        sb.Append("INSERT INTO [ShippingSpeedData] ( ");
        sb.Append("[SendAddress] ,");
        sb.Append("[Consignee] ,");
        sb.Append("[ConsigneeMobile] ,");
        sb.Append("[ConsigneePhone] ,");
        sb.Append("[POPID] ,");
        sb.Append("[GoodsOrderNO] ,");
        sb.Append("[POPCount] ,");
        sb.Append("[CompanyID] ,");
        sb.Append("[FHDate] ,");
        sb.Append("[OperatorID] ,");
        sb.Append("[DealerID] ,");
        sb.Append("[SupplierID] ,");
        sb.Append("[ShopID] ,");
        sb.Append("[IsState] ,");
        sb.Append("[Remars] ,");
        sb.Append("[GetInUserID] ,");
        sb.Append("[GetInState] ,");
        sb.Append("[GetInFeedBack],SHDate,FXID) VALUES (");

        sb.AppendFormat("'{0}' ,", txt_SendAddress.Text.Trim());
        sb.AppendFormat("'{0}' ,", txt_Consignee.Text.Trim());
        sb.AppendFormat("'{0}' ,", txt_ConsigneeMobile.Text.Trim());
        sb.AppendFormat("'{0}' ,", txt_ConsigneePhone.Text.Trim());
        sb.AppendFormat("'{0}' ,", ddlPOPID.SelectedValue.ToString().Trim());
        sb.AppendFormat("'{0}',", "");
        sb.AppendFormat("{0} ,", POPNum.ToString().Trim());
        sb.AppendFormat("'{0}' ,", "");
        sb.AppendFormat("'{0}' ,", DateTime.Now.ToString().Trim());
        sb.AppendFormat("{0} ,", UserID.Trim());
        sb.AppendFormat("'{0}' ,", DealerID.Trim());
        sb.AppendFormat("{0} ,", SupplierID.Trim());
        sb.AppendFormat(" {0},", ShopID.Trim());
        sb.Append("'安装到店' ,");
        sb.AppendFormat("'{0}' ,", txt_Desc.Text.Trim());
        sb.AppendFormat("{0},", 0);
        //if (POPNum == RepPOPList.Items.Count)
        //    sb.Append("'全部发送' ,");
        //else
        //    sb.Append("'部分发送' ,");
        sb.Append("'已收货' ,getdate(),");
        sb.Append("'','" + fxid + "')");
        strList.Add(sb.ToString());



        string PicUrl = "";
        if (this.FileUpload1.HasFile)
        {
            string filename = System.DateTime.Now.ToString().Replace(":", "").Replace("-", "").Replace(" ", "");
            string ex = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();
            if (CheckFile(ex))
            {
                this.FileUpload1.SaveAs(Server.MapPath("../../UpLoad/setUpFiles/") + filename + ex);
                PicUrl = "UpLoad/setUpFiles/" + filename + ex;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请选择正确的格式文件 .jpg, .jpeg, .gif, .png, .bmp, .rar, .zip');</script>"); return;
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('请选择要上传的文件');</script>");
            return;
        }

        LN.Model.SetUpConfirm model = new LN.Model.SetUpConfirm();
        model.DealerID = DealerID.Trim();
        model.Shopid = int.Parse(ShopID.Trim());
        model.Boolinstall = 1;
        model.FXID = fxid;
        model.SupplierID = int.Parse(SupplierID.Trim());
        model.POPID = ddlPOPID.SelectedValue.ToString().Trim();
        string Count = this.txt_Num.Text;
        model.SetUpCount = int.Parse(Count);
        model.OperatorID = int.Parse(UserID);
        model.SetUpDesc = this.txt_Desc.Text;
        model.PicUrl = PicUrl;
        try
        {
            DataTable checkdt = new LN.BLL.SetUpConfirm().GetList("Shopid= " + model.Shopid + "  and POPID='" + model.POPID + "' ").Tables[0];
            if (checkdt.Rows.Count > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('您已经提交过安装确认了，不能再次提交');window.location=window.location;</script>");
                return;
            }
            if (strList.Count > 0)
            {
                int result = new LN.BLL.ShippingSpeedData().Add(strList);
                if (result > 0)
                {
                    new LN.BLL.SetUpConfirm().Add(model);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('提交安装成功！！');window.location.href='./SetupToShopList.aspx';</script>");
                    return;
                }

            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('提交失败，异常在：" + ex.Message + "');</script>");
        }

    }

    public bool CheckFile(string ex)
    {
        string[] exs ={ ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".rar", ".zip" };
        for (int i = 0; i < exs.Length; i++)
        {
            if (ex == exs[i])
            {
                return true;
            }
        }
        return false;
    }


}

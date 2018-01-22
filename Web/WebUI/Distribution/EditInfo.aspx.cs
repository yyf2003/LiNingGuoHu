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
public partial class WebUI_Distribution_EditInfo : System.Web.UI.Page
{
    string FXID = string.Empty, UserID = string.Empty,dealerID=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='../../Login.aspx'</script>");
            return;
        }
        UserID = Request.Cookies["UserID"].Value;
        FXID = Request.QueryString["fxid"].ToString();

        if (!Page.IsPostBack)
        {
            //加载部门名称
            List<LN.Model.DepartMentInfo> listdept = new LN.BLL.DepartMentInfo().GetModelList("");
            foreach (LN.Model.DepartMentInfo deptmodel in listdept)
            {
                ListItem item = new ListItem(deptmodel.department, deptmodel.department.ToString());
                DDL_department.Items.Add(item);
            }
            DataTable dt = new LN.BLL.DistributorsInfo().GetOneFX(FXID);

            this.txtFXID.Value = dt.Rows[0]["FXID"].ToString();
            this.txtFXName.Value = dt.Rows[0]["FXName"].ToString();
            this.txtFXPhone.Text = dt.Rows[0]["FXPhone"].ToString();
            this.txtFXContactor.Text = dt.Rows[0]["FXContactor"].ToString();
            this.txtdealerID.Value = dt.Rows[0]["DealerID"].ToString();
            HF1.Value = dt.Rows[0]["DealerID"].ToString();
            this.txtDealerName.Value = dt.Rows[0]["DealerName"].ToString();
            this.txtFXAddress.Text = dt.Rows[0]["FXaddress"].ToString();
            DDL_department.Items.Add(new ListItem(dt.Rows[0]["department"].ToString(), dt.Rows[0]["department"].ToString()));
            DDL_Area.Items.Add(new ListItem(dt.Rows[0]["areaName"].ToString(), dt.Rows[0]["areaID"].ToString()));
            DDL_Province.Items.Add(new ListItem(dt.Rows[0]["ProvinceName"].ToString(), dt.Rows[0]["ProvinceID"].ToString()));
            DDL_city.Items.Add(new ListItem(dt.Rows[0]["CityName"].ToString(), dt.Rows[0]["CityID"].ToString()));

            if (dt.Rows[0]["department"].ToString() == "")
                DDL_department.Text = "0";
            else
                DDL_department.Text = dt.Rows[0]["department"].ToString();

            if (dt.Rows[0]["areaName"].ToString() == "")
                DDL_Area.Text = "0";
            else
                DDL_department.Text = dt.Rows[0]["areaID"].ToString();
            if (dt.Rows[0]["CityName"].ToString() == "")
                DDL_city.Text = "0";
            else
                DDL_city.Text = dt.Rows[0]["CityID"].ToString();
        }

    }
    protected void Btn_update_Click(object sender, EventArgs e)
    {
        LN.Model.DistributorsInfo FXmodel = new LN.Model.DistributorsInfo();
        int areaid=0;
        int.TryParse(Request.Form["DDL_Area"].ToString(),out areaid);
        FXmodel.AreaID =areaid;
        int cityid=0;
        int.TryParse(Request.Form["DDL_city"].ToString(),out cityid);
        FXmodel.CityID = cityid;
        int proID = 0;
        int.TryParse(Request.Form["DDL_Province"].ToString(),out proID);
        FXmodel.ProvinceID = proID;
        FXmodel.DealerID = txtdealerID.Value;
        FXmodel.ExamDate = "";
        FXmodel.FXAddress = txtFXAddress.Text.Trim();
        FXmodel.FXContactor = txtFXContactor.Text.Trim();
        FXmodel.FXName = txtFXName.Value.Trim();
        FXmodel.FXPhone = txtFXPhone.Text.Trim();
        FXmodel.NewDealerID = HF1.Value;
        FXmodel.FXtel = "0";
        FXmodel.FXID = txtFXID.Value;
        if (FXmodel.DealerID != FXmodel.NewDealerID)
            FXmodel.ExamState = 0;
        else
            FXmodel.ExamState = 1;

        try
        {
            new LN.BLL.DistributorsInfo().Update(FXmodel);

            Response.Write("<script>alert('更新成功');location.href='DisList.aspx'</script>");
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}

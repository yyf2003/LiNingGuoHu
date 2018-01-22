using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUI_POPLanuch_POPPhotoSetCity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindArea();
            setSelectState();
        }
    }
    void bindArea()
    {
        IList<LN.Model.AreaData> AreaList = new LN.BLL.AreaData().GetList("");
        chbArea.DataSource = AreaList;
        chbArea.DataValueField = "AreaID";
        chbArea.DataTextField = "AreaName";
        chbArea.DataBind();
    }

    //设置选中状态
    void setSelectState()
    {
        int imageID = int.Parse(Request.QueryString["ImageID"]);
        LN.BLL.POPImageData bll = new LN.BLL.POPImageData();
        LN.Model.POPImageData model = bll.GetModel(imageID);
        if (!string.IsNullOrEmpty(model.AreaIDs))
        {
            string[] arr = model.AreaIDs.Split(',');
            foreach (ListItem item in chbArea.Items)
            {
                if (arr.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }
        }
        if (!string.IsNullOrEmpty(model.ACL_IDs))
        {
            string[] arr = model.ACL_IDs.Split(',');
            foreach (ListItem item in chbCityLevel.Items)
            {
                if (arr.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["ImageID"]))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('请传递参数');</script>");
            return;
        }
        string AreaIDs = "", ACL_IDs = "";
        //区域
        foreach (ListItem item in chbArea.Items)
        {
            if (item.Selected)
            {
                AreaIDs += item.Value + ",";
            }
        }
        if (AreaIDs == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('请选择区域');</script>");
            return;
        }

        //城市级别
        foreach (ListItem item in chbCityLevel.Items)
        {
            if (item.Selected)
            {
                ACL_IDs += item.Value + ",";
            }
        }
        if (ACL_IDs == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('请选择城市级别');</script>");
            return;
        }
        int imageID = int.Parse(Request.QueryString["ImageID"]);
        LN.BLL.POPImageData bll = new LN.BLL.POPImageData();
        LN.Model.POPImageData model = bll.GetModel(imageID);
        model.AreaIDs = AreaIDs;
        model.ACL_IDs = ACL_IDs;
        //if (new LN.BLL.POPImageData().SetPOPImageUseRange(int.Parse(Request.QueryString["ImageID"]), AreaIDs, ACL_IDs) > 0)
        bll.Update(model);
        ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('设置成功');window.close();</script>");
    }
}
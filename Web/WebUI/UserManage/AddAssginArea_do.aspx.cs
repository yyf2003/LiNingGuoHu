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

public partial class WebUI_UserManage_AddAssginArea_do : System.Web.UI.Page
{
    string ProIDlist = "", CityIDlist = "", UserID = "", TownList = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ProIDlist = Request.Form["province"];
        CityIDlist = Request.Form["city"];
        UserID = Request.QueryString["UserID"];
        TownList = Request.Form["Town"] == null ? "" : Request.Form["Town"].ToString();
        LN.Model.UserAreaMange model = new LN.Model.UserAreaMange();
        if (CityIDlist != null && CityIDlist != "" && UserID != null && UserID != "" && TownList != null && TownList != "")
        {
            DataTable dt = new LN.BLL.UserAreaMange().GetList("UserID=" + UserID + "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                new LN.BLL.UserAreaMange().DeleteUserData(int.Parse(UserID));
            }
            string[] townList = TownList.Split(',');
            for (int i = 0; i < townList.Length; i++)
            {
                int townid = int.Parse(townList[i]);
                int cityid = int.Parse(new LN.BLL.TownData().GetModel(townid).CityID.ToString());
                int provid = int.Parse(new LN.BLL.CityData().GetModel(cityid).ProvinceID.ToString());
                int areaid = int.Parse(new LN.BLL.ProvinceData().GetModel(provid).AreaID.ToString());
                model.AreaID = areaid;
                model.ProvinceID = provid;
                model.CityID = cityid;
                model.UserID = int.Parse(UserID);
                model.TownID = townid;
                new LN.BLL.UserAreaMange().Add(model);
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_ok", "<script>alert('操作成功！');window.location='AssignArea.aspx?UserID=" + UserID + "'</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "_erro", "<script>alert('请求失败，操作异常！');window.location='UserList.aspx';</script>");

        }

    }
}

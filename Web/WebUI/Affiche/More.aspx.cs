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

public partial class WebUI_Affiche_More : System.Web.UI.Page
{
    public string AfficheType = string.Empty;
    public string Typeid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Request.QueryString["TypeID"] != null)
        {
            Typeid = this.Request.QueryString["TypeID"].ToString();
            AfficheType = new LN.BLL.AfficheType().GetModel(int.Parse(Typeid)).Type;
            this.lblafficetypename.Text = AfficheType;
            List<LN.Model.AfficheData> list = new LN.BLL.AfficheData().GetModelList("IsDel = 0 and Typeid =" + Typeid + "");
            this.GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}

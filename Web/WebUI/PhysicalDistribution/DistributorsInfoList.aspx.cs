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

public partial class WebUI_PhysicalDistribution_DistributorsInfoList : System.Web.UI.Page
{
    protected string DealerID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DealerID = Request.QueryString["DealerID"] == null ? "" : Request.QueryString["DealerID"].ToString();
        if (!IsPostBack)
            GetList();
    }


    /// <summary>
    /// 获取列表
    /// </summary>
    private void GetList()
    {
        string strWhere = String.Empty; //搜索条件
        strWhere += " 1=1 ";
        if (DealerID != "")
            strWhere += string.Format(" AND DealerID = '{0}' ", DealerID);

        DataSet ds = new LN.BLL.DistributorsInfo().GetList(strWhere);

        if (ds != null)
        {
            RepShopList.DataSource = ds.Tables[0];
            RepShopList.DataBind();
        }
    }
}

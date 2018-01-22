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
using System.Text;
public partial class WebUI_POPAddition_POPAddition : System.Web.UI.Page
{
    protected string dealerdispaly = "";
    string userid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "login", "<script language='javascript'>window.top.location.href='../../login.aspx'</script>");
            return;
        }

        //pop发起活动20天以后将不在接受破损增补
        string popadd = System.Configuration.ConfigurationManager.AppSettings["POPadd"].ToString();//在web.config中配置的pop增补的时间限制 就是从发起多少天内可以增补

        if (!new LN.BLL.POPAddition().BoolPOPadd(int.Parse(popadd)))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "notadd", "<script language='javascript'>alert('已超过增补的规定时间，现已不能进行增补');location.href='../Affiche/Index.aspx'</script>");
           
        }
        /////////////////
        //////////////////////////////////////////确定增补人的权限 增补只能是 一级客户 直属客户 和店铺负责人来进行增补。
        string username = string.Empty;
        username = Server.UrlDecode(Request.Cookies["UserName"].Value);//根据cookie得到登录人姓名
        userid = Request.Cookies["UserID"].Value;
        string usertype = new LN.BLL.UserInfo().GetTypeByName(username);//得到登录人的角色
        if ("店铺主管".Equals(usertype))
            dealerdispaly = "style=\"display:none\"";
        
        /////////////////////////////////////////

        if (!Page.IsPostBack)
        {
            //GetShopInfoWithShopMaster

            //绑定店铺的一级客户
            //LN.DAL.DealerInfo dealerDAL = new LN.DAL.DealerInfo();

            //DataTable dealerdt = dealerDAL.GetDealerName("");
            //for (int i = 0; i < dealerdt.Rows.Count; i++)
            //{
            //    ListItem item = new ListItem(dealerdt.Rows[i][1].ToString(), dealerdt.Rows[i][0].ToString());
            //    ddl_dealer.Items.Add(item);
            //} 
            ///////////////////////////////////////////////
            if ("店铺主管".Equals(usertype))
            {
                DataTable shopdt = new LN.BLL.ShopInfo().GetShopInfoWithShopMaster(username);
                if (shopdt.Rows.Count > 0)
                {
                    this.Txt_PosID.Text = shopdt.Rows[0]["PosID"].ToString();
                    this.Txt_ShopName.Text = shopdt.Rows[0]["Shopname"].ToString();
                    Txt_PosID.Enabled = false;
                    Txt_ShopName.Enabled = false;
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "jump", "<script language='javascript'>alert('您没有负责的店铺，请联系管理员');location.href='../Affiche/Index.aspx'</script>");

                }
            }
            else if ("一级客户".Equals(usertype))
            {
                DataTable dealerdt = new LN.BLL.DealerUser().GetDealerIdByUserID(int.Parse(userid));
                if (dealerdt.Rows.Count > 0)
                {
                    ddl_dealer.Items.Add(new ListItem(dealerdt.Rows[0]["DealerName"].ToString(), dealerdt.Rows[0]["DealerID"].ToString()));
                    ddl_dealer.Text = dealerdt.Rows[0]["DealerID"].ToString();
                    ddl_dealer.Enabled = false;
                    DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName(" DealerID='" + ddl_dealer.Text + "'");
                    for (int i = 0; i < fxdt.Rows.Count; i++)
                    {
                        ListItem fxitem = new ListItem(fxdt.Rows[i]["FXName"].ToString(), fxdt.Rows[i]["FXID"].ToString());
                        DDL_fx.Items.Add(fxitem);

                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "jump", "<script language='javascript'>alert('没有你负责的一级客户，请联系管理员');location.href='../Affiche/Index.aspx'</script>");
                }

            }
            else if ("直属客户".Equals(usertype))
            {
                DataTable fxdt = new LN.BLL.DistributorsInfo().GetIDName("FXContactor='" + username + "'");
                if (fxdt.Rows.Count > 0)
                {
                    ListItem fxitem = new ListItem(fxdt.Rows[0]["FXName"].ToString(), fxdt.Rows[0]["FXID"].ToString());
                    DDL_fx.Items.Add(fxitem);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "jump", "<script language='javascript'>alert('没有你负责的直属客户，请联系管理员');location.href='../Affiche/Index.aspx'</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "no", "<script language='javascript'>alert('您没有操作增补的权限，请联系管理员');location.href='../Affiche/Index.aspx'</script>");

                return;
            }

            ////绑定店铺级别
            //LN.DAL.ShopLevel levelDLL = new LN.DAL.ShopLevel();
            //DataSet ds = levelDLL.GetList("");
            //DataTable dt = ds.Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ListItem item = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
            //    this.DDL_Shoptype.Items.Add(item);
            //} 
            ////绑定店铺类型
            //LN.DAL.SaleTypeInfo saleDLL = new LN.DAL.SaleTypeInfo();
            //DataSet saleds = saleDLL.GetList("");
            //DataTable saledt = saleds.Tables[0];
            //for (int i = 0; i < saledt.Rows.Count; i++)
            //{
            //    ListItem item = new ListItem(saledt.Rows[i][1].ToString(), saledt.Rows[i][0].ToString());
            //    SaleTypeID.Items.Add(item);
            //} 
           
            ////加载省份
            //IList<LN.Model.ProvinceData> pList = new LN.BLL.ProvinceData().GetList("");
            //for (int i = 0; i < pList.Count; i++)
            //{
            //    ListItem item = new ListItem(pList[i].ProvinceName, pList[i].ProvinceID.ToString());
            //    DDL_Province.Items.Add(item);
            //}

            bind();
        }
    }

    public void bind()
    {
        StringBuilder StrWhere = new StringBuilder();
        StrWhere.Append(" 1=1 ");
        if (Txt_PosID.Text.Trim() != "")
        {
            StrWhere.Append(" and posid= '");
            StrWhere.Append(Txt_PosID.Text+"'");
        }
        if (Txt_ShopName.Text.Trim() != "")
        {
            StrWhere.Append(" and shopname='");
            StrWhere.Append(Txt_ShopName.Text.Trim()+"'");
        }
        if (ddl_dealer.Text != "0")
        {
            StrWhere.Append(" and DealerID='");
            StrWhere.Append(ddl_dealer.Text+"'");
        }
        if (DDL_fx.Text != "0")
        {
            StrWhere.Append(" and FXID='");
            StrWhere.Append(DDL_fx.Text+"'");
        }

        LN.Model.PageModel pagemodel = new LN.Model.PageModel();

        pagemodel.SelectSql = "";
        pagemodel.pageSize = ListPages.PageSize;
        pagemodel.pageIndex = ListPages.CurrentPageIndex;
        pagemodel.OrderField = " shopname desc";
        int totalnum=0;
        DataTable dt = new LN.BLL.POPAddition().getShopPOP(StrWhere.ToString(), pagemodel, out totalnum);
        ListPages.RecordCount = totalnum;
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }

    protected void Btn_search_Click(object sender, EventArgs e)
    {
        bind();
    }
    protected void ListPages_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        ListPages.CurrentPageIndex=e.NewPageIndex;


       
    }
}

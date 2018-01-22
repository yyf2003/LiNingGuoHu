using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Left : System.Web.UI.Page
{
    private string UserID = String.Empty;     //登录用户名
    private string typeID = String.Empty;       //用户权限
    private string rolePage = String.Empty;     //用户功能编号
    protected string strOutput = String.Empty;  //输出的html标签
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserID"].Value == null)
        {
            Response.Write("<script language='javascript'>window.top.location='./Login.aspx'</script>");
            return;
        }
        else
            UserID = Request.Cookies["UserID"].Value;
        if (!IsPostBack)
        {
            GetRolePageList();
        }
    }

    private void GetRolePageList()
    {
        typeID = new LN.BLL.UserInfo().GetModel(Int32.Parse(UserID)).Usertype;
        LN.Model.roleAndPower model = new LN.BLL.roleAndPower().GetModel(Int32.Parse(typeID));
        if (model != null)
            rolePage = model.functionId;
        StringBuilder sb = new StringBuilder();
        IList<int> upIdList = new LN.BLL.sysFunction().GetupIdGroup(string.Format(" id in ({0})", rolePage));
        
        
        if (upIdList.Count > 0)
        {
            foreach (int item in upIdList)
            {
                LN.Model.sysFunction upIdModel = new LN.BLL.sysFunction().GetModel(item);
                sb.Append("<div class=\"Panel AccordionPanelOpen\">");
                sb.AppendFormat("<div class=\"Tab\" style=\"cursor:pointer;\" onclick=\"showhide('#list{0}')\">{1}</div>", upIdModel.id, upIdModel.funcName);
                sb.AppendFormat("<div id=\"list{0}\"  class=\"Content\" style=\"display:none\">", upIdModel.id);
                sb.Append("<ul class=\"menu\">");
                IList<LN.Model.sysFunction> list = new LN.BLL.sysFunction().GetList(string.Format(" s.id in ({0}) and s.upId = {1} ", rolePage,item.ToString()));
                if (list.Count > 0)
                {
                    foreach (LN.Model.sysFunction m in list)
                    {
                        sb.AppendFormat("<li><a href=\"WebUI/{0}/{1}\" target=\"main\">{2}</a></li>", m.FolderName, m.callFormClass, m.funcName);
                    }
                }
                sb.Append("</ul></div></div>");
            }
        }
        strOutput = sb.ToString();
    }
}

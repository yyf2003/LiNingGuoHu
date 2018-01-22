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

public partial class Error : System.Web.UI.Page
{
    protected string param = String.Empty;
    protected string errorInfo = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        param = Request.QueryString["param"] == null ? "" : Request.QueryString["param"].Trim();
        showErrorInfo(param);
    }

    private void showErrorInfo(string Param)
    {
        switch (param)
        {
            case "1":
                errorInfo = "<FONT class=\"red\">添加POP材料报价失败。</FONT><BR><BR>系统服务器忙，请您稍后添加材料报价。<BR><BR><BR><A class=red2 href=\"#\" onclick=\"javascript:history.back();\">点击此处可返回上一页</A>";
                break;
            case "2":
                errorInfo = "<FONT class=\"red\">修改POP材料报价失败。</FONT><BR><BR>系统服务器忙，请您稍后修改材料报价。<BR><BR><BR><A class=red2 href=\"#\" onclick=\"javascript:history.back();\">点击此处可返回上一页</A>";
                break;
            case "3":
                errorInfo = "<FONT class=\"red\">没有可设置价格的POP发起。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
            case "4":
                errorInfo = "<FONT class=\"red\">抱歉，您没有添加供应商人员的权限。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
            case "5":
                errorInfo = "<FONT class=\"red\">添加供货商员工失败。</FONT><BR><BR>原因：可能您添加的员工用户名已经存在。<BR><BR><BR><A class=red2 href=\"#\" onclick=\"javascript:history.back();\">点击此处可返回上一页</A>";
                break;
            case "6":
                errorInfo = "<FONT class=\"red\">添加供货商员工失败。</FONT><BR><BR>原因：可能您添加的物流公司已经存在。<BR><BR><BR><A class=red2 href=\"#\" onclick=\"javascript:history.back();\">点击此处可返回上一页</A>";
                break;
            case "7":
                errorInfo = "<FONT class=\"red\">抱歉，您没有添加发货记录单的权限。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
            case "8":
                errorInfo = "<FONT class=\"red\">抱歉，您没有查看发货单的权限。</FONT><BR><BR>原因：可能您没有被添加到指定一级客户。<BR><BR><BR>";
                break;
            case "9":
                errorInfo = "<FONT class=\"red\">抱歉，您没有查看发货单的权限。</FONT><BR><BR>原因：可能您没有被添加到指定供应商。<BR><BR><BR>";
                break;
            case "10":
                errorInfo = "<FONT class=\"red\">抱歉，您没有被分配到指定供应商。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
            case "11":
                errorInfo = "<FONT class=\"red\">抱歉，提交发货单失败。</FONT><BR><BR>系统服务器忙，请您稍后提交发货单。<BR><BR><BR>";
                break;
            case "12":
                errorInfo = "<FONT class=\"red\">抱歉，您没有上传POP安装图片的权限。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
            case "13":
                errorInfo = "<FONT class=\"red\">抱歉，您上传POP安装图片失败。</FONT><BR><BR>系统服务器忙，请您稍后上传POP安装图片。<BR><BR><BR><A class=red2 href=\"#\" onclick=\"javascript:history.back();\">点击此处可返回上一页</A>";
                break;
            case "14":
                errorInfo = "<FONT class=\"red\">抱歉，您不是一级客户，没有“确认安装”的权限。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
            case "15":
                errorInfo = "<FONT class=\"red\">抱歉，您不是直属客户，没有“确认安装”的权限。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
            case "17":
                errorInfo = "<FONT class=\"red\">抱歉，您不是VM管理员，没有添加直属客户的权限。</FONT><BR><BR>欢迎使用李宁pop管理系统。<BR><BR><BR>";
                break;
        }
    }
}

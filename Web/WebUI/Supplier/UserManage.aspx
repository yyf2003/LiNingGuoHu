<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="WebUI_Supplier_UserManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>供应商人员管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*分页样式风格*/
        .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 10px 10px 0; margin: 0px; float:right;}
        .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
        .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
        .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
        .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;} 
    </style>
</head>
<body style="font-size:12px; background-position:center bottom; background-repeat:no-repeat; text-align:center; left:auto;right:auto;">
    <form id="form1" runat="server">
    <div style="width:100%; text-align:center;">
    <div style=" font-size:14px;width:40%; font-weight:bold; text-align:left; float:left; margin-left:20px; padding-left:20px;color: #c86000;">供应商人员管理</div>
    <div style="float:right;width:10%; text-align:right; margin-right:250px"><asp:HyperLink ID="hyLink" runat="server" ForeColor="#000" Visible="false">添加人员</asp:HyperLink></div>
        <table class="table" style="margin-top:30px; float:left; margin-left:20px">
            <tr>
                <td style="width:10%">员工名称：</td>
                <td><asp:TextBox runat="server" id="txtUserName" CssClass="txtwith"></asp:TextBox></td>
                <td style="width:10%">员工权限：</td>
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="txtwith">
                        <asp:ListItem Value="-1">请选择员工权限</asp:ListItem>
                        <asp:ListItem Value="0">只查询</asp:ListItem>
                        <asp:ListItem Value="1">可修改</asp:ListItem>
                        <asp:ListItem Value="2">管理员</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:10%"><asp:Button runat="server" Text="查  询" id="btnSearch" CssClass="qr0" OnClick="btnSearch_Click"></asp:Button></td>
            </tr>
        </table>
        <table class="table" style="margin-top:30px; float:left; margin-left:20px">
            <tr>
                <th>员工名称</th>
                <th>性别</th>
                <th>人员角色</th>
                <th>电子邮件</th>
                <th>联系电话</th>
                <th>手机号码</th>
            </tr>
            <asp:Repeater ID="RepSupplierUser" runat="server">
            <ItemTemplate>
            <tr>
                <td><%# Eval("Username")%></td>
                <td><%# Eval("Sex")%></td>
                <td><%# Eval("TypeID").ToString() == "2" ? "管理员" : Eval("TypeID").ToString() == "1" ? "修改权限" : "查看权限"%></td>
                <td><%# Eval("UserEmail")%></td>
                <td><%# Eval("UserPhone")%></td>
                <td><%# Eval("UserMobel")%></td>
            </tr>
            </ItemTemplate>
	        </asp:Repeater>
        </table>
    <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb"  ID="ListPages" runat="server" 
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"  PageSize="20" Width="900" OnPageChanging="ListPages_PageChanging" ></webdiyer:AspNetPager>
    <asp:HiddenField ID="hidSupplierID" runat="server" />
    </div>
    </form>
</body>
</html>

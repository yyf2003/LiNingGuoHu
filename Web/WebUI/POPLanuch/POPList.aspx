<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPList.aspx.cs" Inherits="WebUI_POPLanuch_POPList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>POP列表</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:20px">
    <div style="width:900px;font-size:14px; font-weight:bold; text-align:left; float:left; color: #c86000;">POP发起列表</div>
    <br />
    <br />
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table class="table">
        <tr>
        <th style="width:40px">序号</th><th style="width:120px">发起ID</th><th style="width:15%">主题</th><th style="width:60px">起始时间</th><th style="width:60px">结束时间</th><th  style="width:200px">产品系列</th><th style="width:50px">查 看</th></tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
         <td><%#Eval("ID")%></td><td><%#Eval("POPID") %></td><td><%#Eval("POPTitle") %></td><td><%#DateTime.Parse(Eval("BeginDate").ToString()).ToShortDateString() %></td><td><%#DateTime.Parse(Eval("EndDate").ToString()).ToShortDateString()%></td><td><%#Eval("ProductLineDatas")%></td><td><a href="POPDetail.aspx?POPID=<%#Eval("POPID") %>&POPpro=<%#Eval("ProductUrl")%>">查看详细</a></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>

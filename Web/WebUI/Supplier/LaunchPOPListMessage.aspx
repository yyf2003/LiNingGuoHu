<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LaunchPOPListMessage.aspx.cs" Inherits="WebUI_Supplier_LaunchPOPListMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>POP 发起 列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body >
<form id="form1" runat="server">
    <div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;">POP发起活动列表</div>
    <table class="table" style="margin-top:20px; color:navy; float:left; margin-left:20px">
	    <tr>
	    	<th style="height: 24px">POP编号</th>
	        <th style="height: 24px">POP标题</th>
	        <th style="height: 24px">发起人</th>
	        <th style="height: 24px">开始时间</th>
	        <th style="height: 24px">结束时间</th>
	        <th style="height: 24px">查看报价</th>   
	    </tr>
        <asp:Repeater ID="RepLaunchPOP" runat="server">
        <ItemTemplate>
        <tr>
	    	<td><%# Eval("POPID") %></td>
	        <td><%# Eval("POPTitle")%></td>
	        <td><%# Eval("OrganigerName")%></td>
	        <td><%# Eval("BeginDate")%></td>
	        <td><%# Eval("EndDate")%></td>
	        <td><a href='ShowSupplierLaunch.aspx?id=<%# Eval("POPID") %>'>查看</a></td>
	    </tr>
        </ItemTemplate>
        </asp:Repeater>   
	</table>
    </div>
</form>
</body>
</html>

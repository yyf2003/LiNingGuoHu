<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSROfCheckResult.aspx.cs" Inherits="WebUI_DSRCheck_DSROfCheckResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DSR 个人检查结果</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>


</head>
<body >
<form id="form1" runat="server">
	<div style="width:90%">
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">DSR个人数据分析</div>
		<table class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td style="width: 15%">供应商：</td>
				<td style="width: 250px">&nbsp;<asp:DropDownList ID="ddl_supplier" runat="server">
                    <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">
                    DSR检查人：</td>
				<td>&nbsp;<asp:TextBox ID="txt_DsrName" runat="server" Width="95%" Enabled="False"></asp:TextBox></td>
			</tr>
			<tr>
			<td>POP发起ID：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_POPID" runat="server">
                    </asp:DropDownList></td>
				<td></td>
				<td>&nbsp;</td>
				
			</tr>
			<tr>
			<td colspan="4" align="center">
                    <asp:Button ID="Btn_search" runat="server" OnClick="Btn_search_Click" Text="分 析" CssClass="qr0" />&nbsp;</td>
			</tr>
		</table>
		<br />
      <div style="font-size:14px; color:#c86000;padding-left:40px;"><%=resultstr %></div>
 		<br />
		<%=Bigtable.ToString()%>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowPOPImg.aspx.cs" Inherits="WebUI_ShopPOP_ShowPOPImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>指定POP图片预览</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
	<link href="../../CSS/examples.css"rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">
<div>
	<table class="table">
		<tr>
			<td style="font-size:14px;color:#c86000; font-weight:bold">POP图片预览</td>
		</tr>
	</table>
	<asp:Repeater ID="RepShowImg" runat="server">
		<HeaderTemplate>
			<table class="table">
			<tr style="text-align:center">
				<td style="height:40px; font-weight:bold;font-size:16px;">图片</td>
				<td style="font-weight:bold;font-size:16px;">描述</td>
			</tr>
		</HeaderTemplate>
		<ItemTemplate>
			<tr style="text-align:center">
				<td style="width:50%">
					<img alt="" src='<%#Eval("Img_URL")%>' style="width:50%" />
				</td>
				<td>
					<%#Eval("Img_Describe")%>
				</td>
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

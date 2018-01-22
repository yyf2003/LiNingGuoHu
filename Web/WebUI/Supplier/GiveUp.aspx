<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GiveUp.aspx.cs" Inherits="WebUI_Supplier_GiveUp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta content="zh-cn" http-equiv="Content-Language" />
<title>放弃供应商</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
</style>
</head>

<body>

<form id="form1" runat="server">
	<div>
		<table border="1"  cellpadding="1" cellspacing="1" class="table">
			<tr>
				<td></td>
			</tr>
		</table>
		<br />
		<table border="1"  cellpadding="1" cellspacing="1" class="table">
			<tr>
				<td style="width: 15%">供应商：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_supplier" CssClass="txtwith" runat="server"></asp:TextBox></td>
				<td style="width: 15%">联系人：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_lxr"  CssClass="txtwith" runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">联系电话：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_phone" CssClass="txtwith"  runat="server"></asp:TextBox></td>
				<td style="width: 15%">联系人职位：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_Role" CssClass="txtwith"  runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">放弃备注：</td>
				<td colspan="3">&nbsp;<asp:TextBox ID="Txt_remarks" runat="server" Width="98%" TextMode="MultiLine" Height="84px"></asp:TextBox></td>
			</tr>
		</table>
        <br />
		<table border="1"  cellpadding="1" cellspacing="1" class="table">
			<tr>
				<td align="center">&nbsp;<asp:Button ID="btn_fangqi" runat="server" Text="放 弃" OnClick="btn_fangqi_Click" /></td>
			</tr>
		</table>
	</div>
</form>

</body>

</html>

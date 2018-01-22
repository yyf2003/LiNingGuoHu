<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownEffectImg.aspx.cs" Inherits="WebUI_Supplier_DownEffectImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>下载安装效果图</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">
<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">下载安装效果图</div>
<table  class="table" style="margin-top:20px; margin-left:20px; width:100%">
	<tr style="height:50px;">
		<td style="width:15%; text-align:right">发起POP编号：</td>
		<td >
			<asp:DropDownList id="ddlPOPID" runat="server" CssClass="txtwith"></asp:DropDownList>
		</td>
		<td style="width:15%; text-align:right">供应商编号：</td>
		<td >
			<asp:DropDownList id="ddlSupplierID" runat="server" CssClass="txtwith"></asp:DropDownList>
		</td>
	</tr>
	<tr style="height:50px;">
		<td colspan="4" style="text-align:center">
			<asp:Button id="btnUpLoad" runat="server"  CssClass="qr0" Text="查  询" OnClick="btnUpLoad_Click" />
		</td>
	</tr>
</table>
<table class="table" style="margin-top:20px; color:navy; float:left; margin-left:20px; width:100%">
	    <tr>
	    	<th style="height: 24px; width:10%">图片编号</th>
	        <th style="width:15%">缩略图</th>
	        <th style="width:30%">所属供应商</th>
	        <th style="width:15%">上传人</th>
	        <th style="height: 24px">上传时间</th>
	        <th style="height: 24px">下载</th>   
	    </tr>
        <asp:Repeater ID="RepImgList" runat="server">
        <ItemTemplate>
        <tr style="text-align:center">
	    	<td><%# Eval("ID")%></td>
	        <td><img alt="" src='<%# Eval("ImgURL")%>' style="width:130px; height:130px;" /></td>
	        <td><%# Eval("SupplierName")%></td>
	        <td><%# Eval("UserName")%></td>
	        <td><%# Eval("CreateDate")%></td>
	        <td><a href='<%# Eval("ImgURL")%>' target="_blank">下载</a></td>   
	    </tr>
        </ItemTemplate>
        </asp:Repeater>   
	</table>
</form>
</body>
</html>

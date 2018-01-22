<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopPOPSetupList.aspx.cs" Inherits="WebUI_Supplier_ShopPOPSetupList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<meta content="zh-cn" http-equiv="Content-Language" />
<title>店铺列表</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
<script language="javascript" type="text/javascript" src="javascript/GetShopPOPSetupList.js"></script>
<script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
<script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
<script language ="javascript" type="text/javascript">
	function GetcityList()
	{
		var pro=$("#DDL_Province").val();
		GetCityname(pro);
	}
	
	$(function(){
		$("table.datalist tr:nth-child(odd)").addClass("altrow");
	});
</script>
<style type="text/css">
	.datalist tr.altrow{background-color:#a5e5aa;	/* 隔行变色 */}
	td{background-color:white;}
</style>
</head>

<body >

<form id="form1" runat="server">
	<div style="width:90%">
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">已收货店铺管理</div>
		<table class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td style="width:15%;text-align:left">店铺编号：</td>
				<td style="width:30%;">&nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width:15%;text-align:left">店铺名称：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width:15%;text-align:left">省：</td>
				<td style="width:30%;">&nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                    <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width:15%;text-align:left">地级城市：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td style="width:15%;text-align:left">一级客户：</td>
				<td style="width:30%;">&nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width:15%;text-align:left">安装支持：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_install" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="-1">请选择供应商是否支持安装</asp:ListItem>
                    <asp:ListItem Value="1">支持</asp:ListItem>
                    <asp:ListItem Value="0">不支持</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td style="width:15%;text-align:left">店铺类型：</td>
				<td style="width:30%;">&nbsp;<asp:DropDownList id="DDL_Shoptype" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择店铺类型</asp:ListItem>
				</asp:DropDownList>
				</td>
				<td style="width:15%;text-align:left">零售分类：</td>
				<td>&nbsp;
				<asp:DropDownList id="SaleTypeID" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="0">请选择零售分类</asp:ListItem>
				</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td style="width:15%;text-align:left">店铺状态：</td>
				<td style="width:30%;">&nbsp;<asp:DropDownList id="DDL_shopstate" CssClass="txtwith" runat="server">
                    <asp:ListItem Value="-1">请选择店铺状态</asp:ListItem>
                     <asp:ListItem Value="1">正常</asp:ListItem>
                      <asp:ListItem Value="0">关闭</asp:ListItem>
                </asp:DropDownList></td>
				<td style="width: 15%">&nbsp;</td>
				<td align="center">&nbsp;<input id="Btn_search" type="button"  class="qr0" value="查 询"  onclick="GetShopPOPSetupList(1)"/></td>
			</tr>
		</table>
        <asp:HiddenField ID="HidSupplierID" runat="server" />
	</div>
	<br />
	<div id="fillTable" style="margin-top:20px; margin-left:5%"></div>
	 <div id="HyperLinkPage" style="margin-top:20px; text-align:center; padding-left:10px; width:900px; font-size:14px; margin-left:5%"></div>
</form>

</body>

</html>
